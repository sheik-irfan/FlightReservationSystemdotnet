using FlightReservationSystem.DTOs;
using FlightReservationSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightReservationSystem.Services
{
    /// <summary>
    /// Defines the contract for booking-related services.
    /// </summary>
    public interface IBookingService
    {
        Task<bool> CreateBookingAsync(BookingDto dto);
        Task<bool> CancelBookingAsync(decimal bookingId);
        Task<bool> ConfirmBookingAsync(decimal bookingId);

        // New methods to view bookings:
        Task<List<Bookings>> GetBookingsByUserAsync(decimal userId);
        Task<List<Bookings>> GetAllBookingsAsync();
    }
}
