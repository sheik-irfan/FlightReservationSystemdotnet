using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FlightReservationSystem.DTOs;
using FlightReservationSystem.Models;
using FlightReservationSystem.Repositories;

namespace FlightReservationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewController(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        // ✅ Admin can view all reviews
        [HttpGet("all")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> GetAllReviews()
        {
            var reviews = await _reviewRepository.GetAllAsync();

            var reviewDtos = reviews.Select(r => new ReviewDto
            {
                Id = r.Id,
                UserEmail = r.UserEmail ?? "Unknown",
                BookingId = r.BookingId,
                Rating = r.Rating,
                ReviewComment = r.ReviewComment,
                CreatedAt = r.CreatedAt
            });

            return Ok(reviewDtos);
        }

        // ✅ Authenticated user gets all their own reviews
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetOwnReviews()
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            if (string.IsNullOrEmpty(userEmail))
                return Unauthorized("User email claim not found.");

            var reviews = await _reviewRepository.GetByUserEmailAsync(userEmail);

            var reviewDtos = reviews.Select(r => new ReviewDto
            {
                Id = r.Id,
                UserEmail = r.UserEmail ?? "Unknown",
                BookingId = r.BookingId,
                Rating = r.Rating,
                ReviewComment = r.ReviewComment,
                CreatedAt = r.CreatedAt
            });

            return Ok(reviewDtos);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateReview([FromBody] CreateReviewDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            if (string.IsNullOrEmpty(userEmail))
                return Unauthorized("User email claim not found.");

            var review = new Review
            {
                BookingId = dto.BookingId,
                Rating = dto.Rating,
                ReviewComment = dto.ReviewComment,
                UserEmail = userEmail,
                CreatedAt = DateTime.UtcNow
            };

            await _reviewRepository.AddReviewAsync(review);

            return CreatedAtAction(nameof(GetOwnReviews), new { }, review);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateReview(decimal id, [FromBody] ReviewDto dto)
        {
            var review = await _reviewRepository.GetByIdAsync(id);
            if (review == null)
                return NotFound();

            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            if (review.UserEmail != userEmail)
                return Forbid();

            review.Rating = dto.Rating;
            review.ReviewComment = dto.ReviewComment;
            review.BookingId = dto.BookingId;

            await _reviewRepository.UpdateAsync(review);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteReview(decimal id)
        {
            var review = await _reviewRepository.GetByIdAsync(id);
            if (review == null)
                return NotFound();

            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            if (review.UserEmail != userEmail)
                return Forbid();

            await _reviewRepository.DeleteAsync(review);
            return NoContent();
        }
    }
}
