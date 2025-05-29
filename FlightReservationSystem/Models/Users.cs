using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightReservationSystem.Models
{
    [Table("USERS")]
    public partial class Users
    {
        public Users()
        {
            Bookings = new HashSet<Bookings>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public decimal Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("NAME")]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        [Column("EMAIL")]
        public string Email { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        [Column("PASSWORD")]
        public string Password { get; set; } = null!;

        [Required]
        [MaxLength(10)]
        [Column("ROLE")]
        public string Role { get; set; } = null!;

        [Required]
        [MaxLength(1)]
        [Column("GENDER")]
        public string Gender { get; set; } = null!;

        [Required]
        [MaxLength(15)]
        [Column("MOBILE_NUMBER")]
        public string MobileNumber { get; set; } = null!;

        [Required]
        [Column("DOB", TypeName = "DATE")]
        public DateTime Dob { get; set; }

        [Column("CREATED_AT", TypeName = "TIMESTAMP")]
        public DateTime? CreatedAt { get; set; }

        // Navigation property for related bookings
        public virtual ICollection<Bookings> Bookings { get; set; }
        public virtual ICollection<Review> Reviews { get; set; } = new HashSet<Review>();

    }
}
