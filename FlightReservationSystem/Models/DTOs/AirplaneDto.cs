namespace FlightReservationSystem.Models.DTOs
{
    public class AirplaneDto
    {
        public decimal Id { get; set; }
        public string AirplaneNumber { get; set; } = null!;
        public string Model { get; set; } = null!;
        public decimal TotalSeats { get; set; }
        public decimal EconomySeats { get; set; }
        public decimal BusinessSeats { get; set; }
    }
}
