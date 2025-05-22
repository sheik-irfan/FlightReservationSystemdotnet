using System;
using System.Collections.Generic;

namespace FlightReservationSystem.Models;

public partial class Airplanes
{
    public decimal Id { get; set; }

    public string AirplaneNumber { get; set; } = null!;

    public string Model { get; set; } = null!;

    public decimal TotalSeats { get; set; }

    public decimal EconomySeats { get; set; }

    public decimal BusinessSeats { get; set; }

    public virtual ICollection<Flights> Flights { get; set; } = new List<Flights>();
}
