using System;
using System.Collections.Generic;

namespace FlightReservationSystem.Models;

public partial class Passengers
{
    public decimal Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public decimal Age { get; set; }

    public decimal BookingId { get; set; }

    public virtual Bookings Booking { get; set; } = null!;

    public virtual ICollection<BookedTickets> BookedTickets { get; set; } = new List<BookedTickets>();
}
