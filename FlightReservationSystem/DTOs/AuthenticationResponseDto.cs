namespace FlightReservationSystem.Models.DTOs;

public class AuthenticationResponseDto
{
    public string Token { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Role { get; set; } = null!;
}
