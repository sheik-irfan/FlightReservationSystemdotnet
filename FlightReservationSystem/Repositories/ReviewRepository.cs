using FlightReservationSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightReservationSystem.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly FlightReservation _context;

        public ReviewRepository(FlightReservation context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Review>> GetAllAsync()
        {
            return await _context.Reviews.ToListAsync();
        }

        public async Task<IEnumerable<Review>> GetByUserEmailAsync(string userEmail)
        {
            return await _context.Reviews
                .Where(r => r.UserEmail == userEmail)
                .ToListAsync();
        }

        public async Task<Review> GetByIdAsync(decimal id)
        {
            return await _context.Reviews.FindAsync(id);
        }

        public async Task<Review> AddReviewAsync(Review review)
        {
            await _context.Reviews.AddAsync(review);
            await _context.SaveChangesAsync();
            return review;
        }

        public async Task UpdateAsync(Review review)
        {
            _context.Reviews.Update(review);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Review review)
        {
            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();
        }
    }
}
