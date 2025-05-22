using System;
using System.Collections.Generic;

namespace FlightReservationSystem.Models;

public partial class WalletTransactions
{
    public decimal Id { get; set; }

    public decimal WalletId { get; set; }

    public string TransactionType { get; set; } = null!;

    public decimal Amount { get; set; }

    public DateTime? TransactionTime { get; set; }

    public string? Status { get; set; }

    public virtual Wallets Wallet { get; set; } = null!;
}
