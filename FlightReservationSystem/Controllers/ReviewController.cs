using FlightReservationSystem.DTOs;
using FlightReservationSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightReservationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        // GET: api/Review/user/{userId}
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetReviewsByUser(decimal userId)
        {
            // In a production environment, extract userId from User.Claims
            var reviews = await _reviewService.GetByUserIdAsync(userId);
            return Ok(reviews);
        }

        // GET: api/Review/all (Admin only)
        [HttpGet("all")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllReviews()
        {
            var reviews = await _reviewService.GetAllAsync();
            return Ok(reviews);
        }

        // GET: api/Review/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReview(decimal id)
        {
            var review = await _reviewService.GetByIdAsync(id);
            if (review == null)
                return NotFound();
            return Ok(review);
        }

        // POST: api/Review
        [HttpPost]
        public async Task<IActionResult> CreateReview([FromBody] CreateReviewDto dto)
        {
            var review = await _reviewService.CreateReviewAsync(dto);
            return CreatedAtAction(nameof(GetReview), new { id = review.Id }, review);
        }

        // PUT: api/Review/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReview(decimal id, [FromBody] ReviewDto dto)
        {
            // In production, extract user id from User.Claims instead of dto.UserId.
            if (!await _reviewService.UpdateReviewAsync(id, dto, dto.UserId))
                return BadRequest("Review update failed. Permission denied or review does not exist.");
            return NoContent();
        }

        // DELETE: api/Review/{id}?userId=xxx
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(decimal id, [FromQuery] decimal userId)
        {
            if (!await _reviewService.DeleteReviewAsync(id, userId))
                return BadRequest("Review deletion failed. Permission denied or review does not exist.");
            return NoContent();
        }
    }
}
