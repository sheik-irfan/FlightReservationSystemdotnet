using FlightReservationSystem.DTOs;
using FlightReservationSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightReservationSystem.Services
{
    public interface IBookingService
    {
        Task<bool> CreateBookingAsync(BookingDto dto);
        Task<bool> CancelBookingAsync(decimal bookingId);
        Task<bool> ConfirmBookingAsync(decimal bookingId);
        Task<List<Bookings>> GetBookingsByUserAsync(decimal userId);
        Task<List<Bookings>> GetAllBookingsAsync();
        Task<List<Bookings>> GetBookingsByUserEmailAsync(string email);
    }
}
