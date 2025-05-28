using AutoMapper;
using FlightReservationSystem.DTOs;
using FlightReservationSystem.Models;
using FlightReservationSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightReservationSystem.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _repository;
        private readonly IMapper _mapper;

        public ReviewService(IReviewRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ReviewDto> CreateReviewAsync(CreateReviewDto dto)
        {
            var review = _mapper.Map<Review>(dto);
            review.CreatedAt = DateTime.UtcNow; // Set creation time
            review = await _repository.AddAsync(review);
            return _mapper.Map<ReviewDto>(review);
        }

        public async Task<bool> DeleteReviewAsync(decimal id, decimal userId)
        {
            var review = await _repository.GetByIdAsync(id);
            if (review == null || review.UserId != userId)
                return false;

            await _repository.DeleteAsync(review);
            return true;
        }

        public async Task<IEnumerable<ReviewDto>> GetAllAsync()
        {
            var reviews = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ReviewDto>>(reviews);
        }

        public async Task<ReviewDto?> GetByIdAsync(decimal id)
        {
            var review = await _repository.GetByIdAsync(id);
            return review == null ? null : _mapper.Map<ReviewDto>(review);
        }

        public async Task<IEnumerable<ReviewDto>> GetByUserIdAsync(decimal userId)
        {
            var reviews = await _repository.GetByUserIdAsync(userId);
            return _mapper.Map<IEnumerable<ReviewDto>>(reviews);
        }

        public async Task<bool> UpdateReviewAsync(decimal id, ReviewDto dto, decimal userId)
        {
            var review = await _repository.GetByIdAsync(id);
            if (review == null || review.UserId != userId)
                return false;

            // Update only allowed fields (BookingId, Rating, ReviewComment)
            review.BookingId = dto.BookingId;
            review.Rating = dto.Rating;
            review.ReviewComment = dto.ReviewComment;

            await _repository.UpdateAsync(review);
            return true;
        }
    }
}
