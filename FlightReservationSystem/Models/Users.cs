using System.Collections.Generic;

namespace FlightReservationSystem.Models
{
    public partial class Users
    {
        public Users()
        {
            Bookings = new HashSet<Bookings>();
            // Add other navigation collections if needed
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Role { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
        public string MobileNumber { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }

        // Navigation property
        public virtual ICollection<Bookings> Bookings { get; set; }
    }
}
