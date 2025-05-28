using System.Collections.Generic;

namespace FlightReservationSystem.DTOs
{
    public class BookingDto
    {
        public decimal UserId { get; set; }
        public decimal FlightId { get; set; }
        public decimal TotalPrice { get; set; }
        public List<PassengerDto> Passengers { get; set; } = new();
    }
}
