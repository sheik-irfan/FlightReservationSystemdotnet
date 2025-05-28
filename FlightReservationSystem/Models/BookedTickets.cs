using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightReservationSystem.Models
{
    [Table("BOOKED_TICKETS")]
    public class BookedTickets
    {
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal Id { get; set; }

        [Column("BOOKING_ID")]
        public decimal BookingId { get; set; }

        [Column("PASSENGER_ID")]
        public decimal PassengerId { get; set; }

        [Column("FLIGHT_CLASS")]
        public string FlightClass { get; set; } = string.Empty;

        [Column("PRICE")]
        public decimal Price { get; set; }

        [Column("STATUS")]
        public string Status { get; set; } = string.Empty;

        [Column("CANCELLATION_TIME")]
        public DateTime? CancellationTime { get; set; }
    }
}
