using System;

namespace FlightReservationSystem.DTOs
{
    public class ReviewDto
    {
        public decimal Id { get; set; }
        public string UserEmail { get; set; } = null!;
        public decimal BookingId { get; set; }
        public decimal Rating { get; set; }
        public string? ReviewComment { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class CreateReviewDto
    {
        // UserEmail is NOT here because we get it from authenticated user
        public decimal BookingId { get; set; }
        public decimal Rating { get; set; }
        public string? ReviewComment { get; set; }
    }
}
