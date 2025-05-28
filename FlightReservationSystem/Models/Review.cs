using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightReservationSystem.Models
{
    [Table("REVIEWS")]
    public partial class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public decimal Id { get; set; }

        [Column("USER_ID")]
        public decimal UserId { get; set; }

        [Column("BOOKING_ID")]
        public decimal BookingId { get; set; }

        [Column("RATING")]
        public decimal Rating { get; set; }

        // We name this column REVIEW_COMMENT rather than COMMENT since COMMENT is reserved.
        [Column("REVIEW_COMMENT")]
        public string? ReviewComment { get; set; }

        [Column("CREATED_AT")]
        public DateTime CreatedAt { get; set; }
    }
}
