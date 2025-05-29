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

        [ForeignKey("UserId")]
        public virtual Users User { get; set; } = null!;

        [Column("BOOKING_ID")]
        public decimal BookingId { get; set; }

        [Column("RATING")]
        public decimal Rating { get; set; }

        [Column("REVIEW_COMMENT")]
        public string? ReviewComment { get; set; }

        [Column("CREATED_AT")]
        public DateTime CreatedAt { get; set; }

        [Column("USER_EMAIL")]
        [MaxLength(255)]
        public string? UserEmail { get; set; }
    }
}
