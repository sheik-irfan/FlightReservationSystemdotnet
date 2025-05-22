using System;
using System.Collections.Generic;

namespace FlightReservationSystem.Models;

public partial class Wallets
{
    public decimal Id { get; set; }

    public decimal UserId { get; set; }

    public decimal? Balance { get; set; }

    public virtual Users User { get; set; } = null!;

    public virtual ICollection<WalletTransactions> WalletTransactions { get; set; } = new List<WalletTransactions>();
}
