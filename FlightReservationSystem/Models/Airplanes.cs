using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightReservationSystem.Models
{
    [Table("AIRPLANES")]
    public class Airplanes
    {
        [Key]
        public decimal Id { get; set; }  // decimal to match FK in Flights

        public string AirplaneNumber { get; set; } = null!;
        public string Model { get; set; } = null!;
        public int TotalSeats { get; set; }
        public int EconomySeats { get; set; }
        public int BusinessSeats { get; set; }

        // Add this navigation property:
        public virtual ICollection<Flights> Flights { get; set; } = new List<Flights>();
    }
}
