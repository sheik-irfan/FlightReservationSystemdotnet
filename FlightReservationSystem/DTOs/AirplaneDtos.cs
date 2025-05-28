using System.ComponentModel.DataAnnotations;

namespace FlightReservationSystem.DTOs
{
    public class AirplaneDto
    {
        public decimal Id { get; set; }
        public string AirplaneNumber { get; set; } = null!;
        public string Model { get; set; } = null!;
        public decimal TotalSeats { get; set; }
        public decimal EconomySeats { get; set; }
        public decimal BusinessSeats { get; set; }
    }

    public class AirplaneCreateDto
    {
        [Required]
        public string AirplaneNumber { get; set; } = null!;

        [Required]
        public string Model { get; set; } = null!;

        [Range(1, int.MaxValue)]
        public decimal TotalSeats { get; set; }

        [Range(0, int.MaxValue)]
        public decimal EconomySeats { get; set; }

        [Range(0, int.MaxValue)]
        public decimal BusinessSeats { get; set; }
    }

    public class AirplaneUpdateDto
    {
        [Required]
        public string Model { get; set; } = null!;

        [Range(1, int.MaxValue)]
        public decimal TotalSeats { get; set; }

        [Range(0, int.MaxValue)]
        public decimal EconomySeats { get; set; }

        [Range(0, int.MaxValue)]
        public decimal BusinessSeats { get; set; }
    }
}
