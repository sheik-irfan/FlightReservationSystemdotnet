using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightReservationSystem.Models
{
    [Table("PASSENGERS")]
    public class Passengers
    {
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal Id { get; set; }

        [Column("BOOKING_ID")]
        public decimal BookingId { get; set; }

        [Column("FIRST_NAME")]
        public string FirstName { get; set; } = string.Empty;

        [Column("LAST_NAME")]
        public string LastName { get; set; } = string.Empty;

        [Column("GENDER")]
        public string Gender { get; set; } = string.Empty;

        [Column("AGE")]
        public int Age { get; set; }

        [Column("AADHAAR_NUMBER")]
        public string AadhaarNumber { get; set; } = string.Empty;
    }
}
