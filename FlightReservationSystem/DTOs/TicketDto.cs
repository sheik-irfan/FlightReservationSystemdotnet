using System;

namespace FlightReservationSystem.DTOs
{
    public class TicketDto
    {
        public decimal Id { get; set; }
        public decimal BookingId { get; set; }
        public decimal PassengerId { get; set; }
        public string FlightClass { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime? CancellationTime { get; set; }
    }
}
