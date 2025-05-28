using FlightReservationSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightReservationSystem.Repositories
{
    public interface IWalletRepository
    {
        Task<Wallets?> GetByUserIdAsync(decimal userId);
        Task<Wallets> CreateAsync(Wallets wallet);
        Task<List<WalletTransaction>> GetAllTransactionsAsync();
        Task<List<WalletTransaction>> GetTransactionsByUserIdAsync(decimal userId);
        Task AddTransactionAsync(WalletTransaction transaction);
        Task UpdateAsync(Wallets wallet);
    }
}
