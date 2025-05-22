using System;
using System.Collections.Generic;

namespace FlightReservationSystem.Models;

public partial class FlightPrices
{
    public decimal Id { get; set; }

    public decimal FlightId { get; set; }

    public string FlightClass { get; set; } = null!;

    public decimal Price { get; set; }

    public virtual Flights Flight { get; set; } = null!;
}
