using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightReservationSystem.Models
{
    [Table("WALLETS")]
    public class Wallets
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public decimal Id { get; set; }

        [Column("USER_ID")]
        public decimal UserId { get; set; }

        [Column("BALANCE")]
        public decimal? Balance { get; set; }
    }
}
