using System;
using System.Collections.Generic;

namespace FlightReservationSystem.Models
{
    public partial class Bookings
    {
        public decimal Id { get; set; }

        public decimal UserId { get; set; }

        public decimal FlightId { get; set; }

        public DateTime? BookingTime { get; set; }

        public string? Status { get; set; }

        public decimal TotalPrice { get; set; }

        // Navigation properties

        public virtual Users User { get; set; } = null!;

        public virtual Flights Flight { get; set; } = null!;

        public virtual ICollection<BookedTickets> BookedTickets { get; set; } = new List<BookedTickets>();

        public virtual ICollection<Passengers> Passengers { get; set; } = new List<Passengers>();
    }
}
