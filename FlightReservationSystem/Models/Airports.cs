using System;
using System.Collections.Generic;

namespace FlightReservationSystem.Models;

public partial class Airports
{
    public decimal Id { get; set; }

    public string Name { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string AirportCode { get; set; } = null!;

    public virtual ICollection<Flights> FlightsDestinationAirport { get; set; } = new List<Flights>();

    public virtual ICollection<Flights> FlightsSourceAirport { get; set; } = new List<Flights>();
}
