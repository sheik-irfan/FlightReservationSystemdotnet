using System;
using System.Collections.Generic;

namespace FlightReservationSystem.Models;

public partial class BookedTickets
{
    public decimal Id { get; set; }

    public decimal BookingId { get; set; }

    public decimal PassengerId { get; set; }

    public string FlightClass { get; set; } = null!;

    public decimal Price { get; set; }

    public string? Status { get; set; }

    public DateTime? CancellationTime { get; set; }

    public virtual Bookings Booking { get; set; } = null!;

    public virtual Passengers Passenger { get; set; } = null!;
}
