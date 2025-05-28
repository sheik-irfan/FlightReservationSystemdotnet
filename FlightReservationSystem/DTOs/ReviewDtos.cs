using System;

namespace FlightReservationSystem.DTOs
{
    // Used for retrieving and updating reviews.
    public class ReviewDto
    {
        public decimal Id { get; set; }
        public decimal UserId { get; set; }
        public decimal BookingId { get; set; }
        public decimal Rating { get; set; }
        public string? ReviewComment { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    // Used for creating a new review.
    public class CreateReviewDto
    {
        public decimal UserId { get; set; }
        public decimal BookingId { get; set; }
        public decimal Rating { get; set; }
        public string? ReviewComment { get; set; }
    }
}
