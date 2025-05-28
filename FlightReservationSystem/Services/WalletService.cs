using AutoMapper;
using FlightReservationSystem.DTOs;
using FlightReservationSystem.Models;
using FlightReservationSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightReservationSystem.Services
{
    public class WalletService : IWalletService
    {
        private readonly IWalletRepository _repository;
        private readonly IMapper _mapper;

        public WalletService(IWalletRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateWalletForUserAsync(decimal userId)
        {
            var wallet = new Wallets
            {
                UserId = userId,
                Balance = 0
            };
            await _repository.CreateAsync(wallet);
        }

        public async Task<WalletDto?> GetUserWalletAsync(decimal userId)
        {
            var wallet = await _repository.GetByUserIdAsync(userId);
            return wallet == null ? null : _mapper.Map<WalletDto>(wallet);
        }

        public async Task<List<WalletTransactionDto>> GetUserTransactionsAsync(decimal userId)
        {
            var transactions = await _repository.GetTransactionsByUserIdAsync(userId);
            return _mapper.Map<List<WalletTransactionDto>>(transactions);
        }

        public async Task<List<WalletTransactionDto>> GetAllTransactionsAsync()
        {
            var all = await _repository.GetAllTransactionsAsync();
            return _mapper.Map<List<WalletTransactionDto>>(all);
        }

        public async Task<bool> DebitAsync(decimal userId, decimal amount, string description)
        {
            var wallet = await _repository.GetByUserIdAsync(userId);
            if (wallet == null || wallet.Balance < amount)
                return false;

            wallet.Balance -= amount;
            await _repository.UpdateAsync(wallet);

            var transaction = new WalletTransaction
            {
                WalletId = wallet.Id,
                Amount = amount,
                TransactionType = "DEBIT",
                CreatedAt = DateTime.UtcNow,
                Status = "COMPLETED" // Allowed status.
            };
            await _repository.AddTransactionAsync(transaction);

            return true;
        }

        public async Task<bool> RefundAsync(decimal userId, decimal amount, string description)
        {
            var wallet = await _repository.GetByUserIdAsync(userId);
            if (wallet == null)
                return false;

            wallet.Balance += amount;
            await _repository.UpdateAsync(wallet);

            var transaction = new WalletTransaction
            {
                WalletId = wallet.Id,
                Amount = amount,
                TransactionType = "CREDIT",
                CreatedAt = DateTime.UtcNow,
                Status = "COMPLETED"  // Updated to satisfy the check constraint.
            };
            await _repository.AddTransactionAsync(transaction);

            return true;
        }

    }
}
