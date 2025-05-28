using FlightReservationSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightReservationSystem.Repositories
{
    public class WalletRepository : IWalletRepository
    {
        private readonly FlightReservation _context;

        public WalletRepository(FlightReservation context)
        {
            _context = context;
        }

        public async Task<Wallets?> GetByUserIdAsync(decimal userId)
        {
            return await _context.Wallets.FirstOrDefaultAsync(w => w.UserId == userId);
        }

        public async Task<Wallets> CreateAsync(Wallets wallet)
        {
            _context.Wallets.Add(wallet);
            await _context.SaveChangesAsync();
            return wallet;
        }

        public async Task<List<WalletTransaction>> GetAllTransactionsAsync()
        {
            return await _context.WalletTransactions.ToListAsync();
        }

        public async Task<List<WalletTransaction>> GetTransactionsByUserIdAsync(decimal userId)
        {
            var wallet = await GetByUserIdAsync(userId);
            if (wallet == null) return new();
            return await _context.WalletTransactions
                .Where(t => t.WalletId == wallet.Id)
                .ToListAsync();
        }

        public async Task AddTransactionAsync(WalletTransaction transaction)
        {
            _context.WalletTransactions.Add(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Wallets wallet)
        {
            _context.Wallets.Update(wallet);
            await _context.SaveChangesAsync();
        }
    }
}
