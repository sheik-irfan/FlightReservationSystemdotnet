using FlightReservationSystem.Models;
using FlightReservationSystem.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem.Services;

public class UserService : IUserService
{
    private readonly MyDbContext _context;

    public UserService(MyDbContext context)
    {
        _context = context;
    }

    public async Task<bool> UserExistsAsync(string email)
    {
        return await _context.Users.AnyAsync(u => u.Email == email);
    }

    public async Task<Users> CreateUserAsync(RegisterDto dto)
    {
        var user = new Users
        {
            Name = dto.Name,
            Email = dto.Email,
            Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),
            Role = string.IsNullOrWhiteSpace(dto.Role) ? "CUSTOMER" : dto.Role,
            Gender = dto.Gender,
            CreatedAt = DateTime.UtcNow,
            MobileNumber = dto.MobileNumber,
            DateOfBirth = dto.DateOfBirth
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return user;
    }


    public async Task<Users?> ValidateUserAsync(string email, string password)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        if (user == null)
            return null;

        var hashedPassword = HashPassword(password);
        if (user.Password != hashedPassword)
            return null;

        return user;
    }

    private string HashPassword(string password)
    {
        using var sha256 = SHA256.Create();
        var bytes = Encoding.UTF8.GetBytes(password);
        var hash = sha256.ComputeHash(bytes);
        return Convert.ToBase64String(hash);
    }
}
