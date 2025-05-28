using FlightReservationSystem.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightReservationSystem.Services
{
    public interface IReviewService
    {
        Task<IEnumerable<ReviewDto>> GetAllAsync(); // Admin view.
        Task<IEnumerable<ReviewDto>> GetByUserIdAsync(decimal userId); // User's own reviews.
        Task<ReviewDto?> GetByIdAsync(decimal id);
        Task<ReviewDto> CreateReviewAsync(CreateReviewDto dto);
        Task<bool> UpdateReviewAsync(decimal id, ReviewDto dto, decimal userId);
        Task<bool> DeleteReviewAsync(decimal id, decimal userId);
    }
}
