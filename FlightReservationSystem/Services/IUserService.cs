using FlightReservationSystem.Models;
using FlightReservationSystem.Models.DTOs;
using System.Threading.Tasks;

namespace FlightReservationSystem.Services;

public interface IUserService
{
    Task<bool> UserExistsAsync(string email);
    Task<Users> CreateUserAsync(RegisterDto registerDto);
    Task<Users?> ValidateUserAsync(string email, string password);
}
