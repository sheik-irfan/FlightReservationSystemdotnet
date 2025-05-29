using FlightReservationSystem.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightReservationSystem.Services
{
    public interface IReviewService
    {
        // Add userEmail parameter here to match implementation
        Task<ReviewDto> CreateReviewAsync(CreateReviewDto dto, string userEmail);

        Task<IEnumerable<ReviewDto>> GetAllAsync();
        Task<IEnumerable<ReviewDto>> GetByUserEmailAsync(string userEmail);
        Task<ReviewDto?> GetByIdAsync(decimal id);
        Task<bool> UpdateReviewAsync(decimal id, ReviewDto dto, string userEmail);
        Task<bool> DeleteReviewAsync(decimal id, string userEmail);
    }
}
