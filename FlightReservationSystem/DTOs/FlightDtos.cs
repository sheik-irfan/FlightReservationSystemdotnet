using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FlightReservationSystem.DTOs
{
    public class FlightDto
    {
        public int Id { get; set; }
        public string FlightName { get; set; } = null!;

        public string AirplaneName { get; set; } = null!;
        public string SourceAirportName { get; set; } = null!;
        public string DestinationAirportName { get; set; } = null!;

        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }

        public string Status { get; set; } = null!;

        public List<FlightPriceDto> FlightPrices { get; set; } = new();
    }

    public class FlightCreateDto
    {
        [Required]
        [StringLength(100)]
        public string FlightName { get; set; } = null!;

        [Required]
        public decimal AirplaneId { get; set; }

        [Required]
        public decimal SourceAirportId { get; set; }

        [Required]
        public decimal DestinationAirportId { get; set; }

        [Required]
        public DateTime DepartureTime { get; set; }

        [Required]
        public DateTime ArrivalTime { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; } = null!;
    }

    public class FlightUpdateDto : FlightCreateDto { }

    public class FlightSearchDto
    {
        public decimal? SourceAirportId { get; set; }
        public decimal? DestinationAirportId { get; set; }
    }
}
