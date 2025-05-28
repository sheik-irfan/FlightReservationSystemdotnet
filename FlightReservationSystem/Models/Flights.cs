using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightReservationSystem.Models
{
    public partial class Flights
    {
        public decimal Id { get; set; }

        public string FlightName { get; set; } = null!;

        public decimal? AirplaneId { get; set; }
        public decimal? SourceAirportId { get; set; }
        public decimal? DestinationAirportId { get; set; }
        // airports
        public DateTime? DepartureTime { get; set; }
        public DateTime? ArrivalTime { get; set; }
        public string Status { get; set; } = null!;

        public virtual Airplanes? Airplane { get; set; }
        public virtual Airports? SourceAirport { get; set; }
        public virtual Airports? DestinationAirport { get; set; }
        public virtual ICollection<FlightPrices> FlightPrices { get; set; } = new List<FlightPrices>();
    }
}
