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

        public async Task<ReviewDto> CreateReviewAsync(CreateReviewDto dto, string userEmail)
        {
            var review = _mapper.Map<Review>(dto);
            review.UserEmail = userEmail;
            review.CreatedAt = DateTime.UtcNow;
            review = await _repository.AddReviewAsync(review);  // Corrected method name
            return _mapper.Map<ReviewDto>(review);
        }

        public async Task<bool> DeleteReviewAsync(decimal id, string userEmail)
        {
            var review = await _repository.GetByIdAsync(id);
            if (review == null || review.UserEmail != userEmail)
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

        public async Task<IEnumerable<ReviewDto>> GetByUserEmailAsync(string userEmail)
        {
            var reviews = await _repository.GetByUserEmailAsync(userEmail);
            return _mapper.Map<IEnumerable<ReviewDto>>(reviews);
        }

        public async Task<bool> UpdateReviewAsync(decimal id, ReviewDto dto, string userEmail)
        {
            var review = await _repository.GetByIdAsync(id);
            if (review == null || review.UserEmail != userEmail)
                return false;

            review.BookingId = dto.BookingId;
            review.Rating = dto.Rating;
            review.ReviewComment = dto.ReviewComment;

            await _repository.UpdateAsync(review);
            return true;
        }
    }
}
