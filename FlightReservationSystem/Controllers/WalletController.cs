using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FlightReservationSystem.Models;
using FlightReservationSystem.DTOs;
using Microsoft.EntityFrameworkCore;
//using FlightReservationSystem.Enums;

namespace FlightReservationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WalletController : ControllerBase
    {
        private readonly FlightReservation _context;

        public WalletController(FlightReservation context)
        {
            _context = context;
        }

        // GET: api/Wallet
        [HttpGet]
        public async Task<ActionResult<WalletDto>> GetWallet()
        {
            var userId = GetUserId();
            if (userId is null)
                return Unauthorized();

            var wallet = await _context.Wallets.FirstOrDefaultAsync(w => w.UserId == userId);
            if (wallet is null)
                return NotFound("Wallet not found");

            return new WalletDto
            {
                Id = wallet.Id,
                Balance = wallet.Balance ?? 0
            };
        }

        // POST: api/Wallet
        [HttpPost]
        public async Task<ActionResult<WalletDto>> CreateWallet()
        {
            var userId = GetUserId();
            if (userId is null)
                return Unauthorized();

            var existingWallet = await _context.Wallets.FirstOrDefaultAsync(w => w.UserId == userId);
            if (existingWallet != null)
                return BadRequest("Wallet already exists");

            var wallet = new Wallets
            {
                UserId = userId.Value,
                Balance = 0
            };

            _context.Wallets.Add(wallet);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetWallet), new { id = wallet.Id }, new WalletDto
            {
                Id = wallet.Id,
                Balance = 0
            });
        }

        // PUT: api/Wallet/add-balance
        [HttpPut("add-balance")]
        public async Task<ActionResult<WalletDto>> AddBalance([FromBody] decimal amount)
        {
            var userId = GetUserId();
            if (userId is null)
                return Unauthorized();

            if (amount <= 0)
                return BadRequest("Amount must be greater than 0");

            var wallet = await _context.Wallets.FirstOrDefaultAsync(w => w.UserId == userId);
            if (wallet == null)
                return NotFound("Wallet not found");

            wallet.Balance = (wallet.Balance ?? 0) + amount;

            // Optional: add to wallet transactions
            _context.WalletTransactions.Add(new WalletTransaction
            {
                WalletId = (int)wallet.Id,
                TransactionType = "CREDIT",
                Amount = amount,
                CreatedAt = DateTime.UtcNow,
                Status = "COMPLETED"
            });

            await _context.SaveChangesAsync();

            return Ok(new WalletDto
            {
                Id = wallet.Id,
                Balance = wallet.Balance ?? 0
            });
        }

        // Helper method
        private decimal? GetUserId()
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type.Contains("nameidentifier"));
            if (userIdClaim is null)
                return null;

            return decimal.TryParse(userIdClaim.Value, out var userId) ? userId : (decimal?)null;
        }
    }
}
