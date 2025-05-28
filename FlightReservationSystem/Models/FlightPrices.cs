using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightReservationSystem.Models
{
    [Table("FLIGHT_PRICES")]
    public class FlightPrices
    {
        [Key]
        public decimal Id { get; set; }  // decimal for sequence matching

        public decimal FlightId { get; set; }

        [Required]
        [MaxLength(50)]
        public string FlightClass { get; set; } = null!;

        public decimal Price { get; set; }

        [ForeignKey("FlightId")]
        public virtual Flights Flight { get; set; } = null!;
    }
}
