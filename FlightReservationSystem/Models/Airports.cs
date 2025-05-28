using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightReservationSystem.Models
{
    [Table("AIRPORTS")]
    public class Airports
    {
        [Key]
        public decimal Id { get; set; }  // decimal for sequence matching

        [Required]
        [MaxLength(150)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        public string City { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        public string Country { get; set; } = null!;

        [Required]
        [MaxLength(3)]
        [Column(TypeName = "CHAR(3)")]
        public string AirportCode { get; set; } = null!;
    }
}
