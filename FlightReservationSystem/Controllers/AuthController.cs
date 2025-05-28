using FlightReservationSystem.Models;
using FlightReservationSystem.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BCrypt.Net;

namespace FlightReservationSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly FlightReservation _context;
        private readonly IConfiguration _configuration;

        public AuthController(FlightReservation context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await _context.Users.AnyAsync(u => u.Email == dto.Email.Trim()))
                return BadRequest("Email is already registered.");

            var role = (dto.Role ?? "CUSTOMER").Trim().ToUpper();
            if (role != "USER" && role != "ADMIN")
                return BadRequest("Invalid role. Allowed values: USER, ADMIN.");

            var gender = dto.Gender?.Trim().ToUpper();
            if (string.IsNullOrWhiteSpace(gender) || (gender != "M" && gender != "F"))
                return BadRequest("Gender must be 'M' or 'F'.");

            if (dto.Password.Length < 6)
                return BadRequest("Password must be at least 6 characters long.");

            if (!System.Text.RegularExpressions.Regex.IsMatch(dto.MobileNumber, @"^\d{10}$"))
                return BadRequest("Mobile number must be exactly 10 digits.");

            var user = new Users
            {
                Name = dto.Name.Trim(),
                Email = dto.Email.Trim(),
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password.Trim()),
                Role = role,
                Gender = gender,
                MobileNumber = dto.MobileNumber.Trim(),
                Dob = dto.Dob,
                CreatedAt = DateTime.UtcNow
            };

            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return Ok(new { message = "Registration successful" });
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new { message = "Database error", details = ex.InnerException?.Message ?? ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Unexpected error", details = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (string.IsNullOrWhiteSpace(dto.Email) || string.IsNullOrWhiteSpace(dto.Password))
                return BadRequest("Email and password are required.");

            var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == dto.Email.Trim());
            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
                return Unauthorized("Invalid credentials");

            var token = GenerateJwtToken(user);

            return Ok(new
            {
                token,
                user = new
                {
                    user.Id,
                    user.Name,
                    user.Email,
                    user.Role
                }
            });
        }

        private string GenerateJwtToken(Users user)
        {
            var secretKey = _configuration["JwtSettings:SecretKey"];
            var issuer = _configuration["JwtSettings:Issuer"];
            var audience = _configuration["JwtSettings:Audience"];
            var expiryMinutes = int.TryParse(_configuration["JwtSettings:ExpiryMinutes"], out var minutes) ? minutes : 60;

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expiryMinutes),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private decimal GenerateNewUserId()
        {
            var maxId = _context.Users.Any() ? _context.Users.Max(u => u.Id) : 0;
            return maxId + 1;
        }
    }
}
