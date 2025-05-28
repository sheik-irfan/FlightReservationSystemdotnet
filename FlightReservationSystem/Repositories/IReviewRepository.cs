using FlightReservationSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightReservationSystem.Repositories
{
    public interface IReviewRepository
    {
        Task<IEnumerable<Review>> GetAllAsync();
        Task<IEnumerable<Review>> GetByUserIdAsync(decimal userId);
        Task<Review?> GetByIdAsync(decimal id);
        Task<Review> AddAsync(Review review);
        Task UpdateAsync(Review review);
        Task DeleteAsync(Review review);
    }
}
