using System.ComponentModel.DataAnnotations;

namespace FlightReservationSystem.DTOs
{
    public class AirportDto
    {
        public decimal Id { get; set; }

        public string Name { get; set; } = null!;

        public string City { get; set; } = null!;

        public string Country { get; set; } = null!;

        public string AirportCode { get; set; } = null!;
    }

    public class AirportCreateDto
    {
        [Required]
        [StringLength(150)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string City { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string Country { get; set; } = null!;

        [Required]
        [RegularExpression(@"^[A-Z]{3}$", ErrorMessage = "Airport code must be 3 uppercase letters.")]
        public string AirportCode { get; set; } = null!;
    }

    public class AirportUpdateDto
    {
        [Required]
        [StringLength(150)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string City { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string Country { get; set; } = null!;

        [Required]
        [RegularExpression(@"^[A-Z]{3}$", ErrorMessage = "Airport code must be 3 uppercase letters.")]
        public string AirportCode { get; set; } = null!;
    }
}
