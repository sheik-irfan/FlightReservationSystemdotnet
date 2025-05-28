using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightReservationSystem.Models
{
    [Table("WALLET_TRANSACTIONS")]
    public class WalletTransaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public decimal Id { get; set; }

        [Column("WALLET_ID")]
        public decimal WalletId { get; set; }

        [Column("AMOUNT")]
        public decimal Amount { get; set; }

        // Removed: Description property – the WALLET_TRANSACTIONS table does not have a DESCRIPTION column.
        // [Column("DESCRIPTION")]
        // public string Description { get; set; } = string.Empty;

        // Allowed values: 'COMPLETED', 'PENDING', 'FAILED', 'CANCELLED'
        [Column("STATUS")]
        public string Status { get; set; } = string.Empty;

        [Column("TRANSACTION_TIME")]
        public DateTime CreatedAt { get; set; }

        [Column("TRANSACTION_TYPE")]
        public string TransactionType { get; set; } = string.Empty;
    }
}
