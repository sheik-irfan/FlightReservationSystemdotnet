using System.ComponentModel.DataAnnotations;

namespace FlightReservationSystem.Models.DTOs
{
    public class RegisterDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; } = null!;

        [Required]
        [MinLength(6)]  // Example minimum password length
        public string Password { get; set; } = null!;

        [MaxLength(10)]
        public string Role { get; set; } = "CUSTOMER";  // default role

        [Required]
        [RegularExpression("^[MF]$", ErrorMessage = "Gender must be 'M' or 'F'")]
        public string Gender { get; set; } = null!;

        [Required]
        [RegularExpression(@"^\d{10,15}$", ErrorMessage = "Mobile number must be 10-15 digits.")]
        public string MobileNumber { get; set; } = null!;


        [Required]
        public DateTime Dob { get; set; }
    }
}
