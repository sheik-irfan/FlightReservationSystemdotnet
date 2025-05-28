namespace FlightReservationSystem.DTOs
{
    public class PassengerDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public int Age { get; set; }
        public string AadhaarNumber { get; set; } = string.Empty;
        public string FlightClass { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
