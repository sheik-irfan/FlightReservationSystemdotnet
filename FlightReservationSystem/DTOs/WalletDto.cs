namespace FlightReservationSystem.DTOs
{
    public class WalletDto
    {
        public decimal Id { get; set; }
        public decimal Balance { get; set; }
    }

    public class WalletTransactionDto
    {
        public decimal Id { get; set; }
        public string TransactionType { get; set; } = null!;
        public decimal Amount { get; set; }
        public DateTime? TransactionTime { get; set; }
        public string? Status { get; set; }
    }
}
