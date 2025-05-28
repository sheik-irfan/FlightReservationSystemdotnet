namespace FlightReservationSystem.DTOs
{
    public class FlightPriceDto
    {
        public decimal Id { get; set; }
        public string FlightClass { get; set; } = null!;
        public decimal Price { get; set; }
    }

    public class FlightPriceCreateDto
    {
        public decimal FlightId { get; set; }
        public string FlightClass { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
