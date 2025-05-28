using System.Threading.Tasks;
using FlightReservationSystem.DTOs;

namespace FlightReservationSystem.Services
{
    public interface IWalletService
    {
        Task<WalletDto?> GetUserWalletAsync(decimal userId);
        Task<List<WalletTransactionDto>> GetUserTransactionsAsync(decimal userId);
        Task<List<WalletTransactionDto>> GetAllTransactionsAsync(); // Admin only
        Task CreateWalletForUserAsync(decimal userId);
        Task<bool> DebitAsync(decimal userId, decimal amount, string description);
        Task<bool> RefundAsync(decimal userId, decimal amount, string description);
    }
}
