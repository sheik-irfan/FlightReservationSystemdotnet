using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightReservationSystem.Models
{
    [Table("BOOKINGS")]
    public class Bookings
    {
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal Id { get; set; }

        [Column("USER_ID")]
        public decimal UserId { get; set; }

        [Column("FLIGHT_ID")]
        public decimal FlightId { get; set; }

        [Column("BOOKING_TIME")]
        public DateTime BookingTime { get; set; }

        [Column("STATUS")]
        public string Status { get; set; } = string.Empty;

        [Column("TOTAL_PRICE")]
        public decimal TotalPrice { get; set; }

        [ForeignKey("UserId")]
        public virtual Users User { get; set; }  // <-- Use 'Users' not 'User'

        [NotMapped]
        public string UserName { get; set; } // For convenience in response
    }
}
