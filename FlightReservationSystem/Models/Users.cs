using System;

namespace FlightReservationSystem.Models
{
    public partial class Users
    {
        public decimal Id { get; set; }  // Matches Oracle sequence (decimal)

        public string Name { get; set; } = null!;  // Max 100 chars in DB, consider validation in DTO or UI

        public string Email { get; set; } = null!; // Max 100 chars, unique constraint assumed

        public string Password { get; set; } = null!; // Hashed password, max 100 chars

        public string Role { get; set; } = null!;  // Max 10 chars, e.g. "CUSTOMER", "ADMIN"

        public string Gender { get; set; } = null!; // Single char, e.g. "M" or "F"

        public string MobileNumber { get; set; } = null!; // Max 15 chars

        public DateTime Dob { get; set; }

        public DateTime? CreatedAt { get; set; }  // Nullable in DB, set on insert

        // Optional: You can add validation methods here or use FluentValidation elsewhere.
    }
}
