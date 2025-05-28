using FlightReservationSystem.Configs;
using FlightReservationSystem.Models;
using FlightReservationSystem.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FlightReservationSystem.Services
{
    public class UserService : IUserService
    {
        private readonly FlightReservation _context;
        private readonly JwtSettings _jwtSettings;
        private readonly IWalletService _walletService;

        public UserService(FlightReservation context, IOptions<JwtSettings> jwtOptions, IWalletService walletService)
        {
            _context = context;
            _jwtSettings = jwtOptions.Value;
            _walletService = walletService;
        }

        public async Task<bool> RegisterAsync(RegisterDto dto)
        {
            if (await _context.Users.AnyAsync(u => u.Email == dto.Email))
                return false; // Email already exists

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            var user = new Users
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = hashedPassword,
                Role = dto.Role.ToUpper(),
                Gender = dto.Gender,
                MobileNumber = dto.MobileNumber,
                Dob = dto.Dob,
                CreatedAt = DateTime.UtcNow
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            // ✅ Create wallet ONLY for USER role
            if (user.Role == "USER")
            {
                await _walletService.CreateWalletForUserAsync(user.Id);
            }

            return true;
        }

        public async Task<AuthenticationResponseDto?> AuthenticateAsync(AuthenticationRequestDto dto)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == dto.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
                return null;

            var token = GenerateJwtToken(user);

            return new AuthenticationResponseDto
            {
                Email = user.Email,
                Role = user.Role,
                Token = token
            };
        }

        private string GenerateJwtToken(Users user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_jwtSettings.SecretKey);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
                Issuer = _jwtSettings.Issuer,
                Audience = _jwtSettings.Audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
