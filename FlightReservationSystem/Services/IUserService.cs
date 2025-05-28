using FlightReservationSystem.Models.DTOs;

namespace FlightReservationSystem.Services;

public interface IUserService
{
    Task<bool> RegisterAsync(RegisterDto dto);
    Task<AuthenticationResponseDto?> AuthenticateAsync(AuthenticationRequestDto dto);
}
