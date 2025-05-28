namespace FlightReservationSystem.Models.DTOs;

public class AuthenticationRequestDto
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}
