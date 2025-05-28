using FlightReservationSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightReservationSystem.Repositories
{
    public interface IBookingRepository
    {
        Task<decimal> AddBookingAsync(Bookings booking);
        Task<decimal> AddPassengerAsync(Passengers passenger);
        Task AddTicketAsync(BookedTickets ticket);
        Task<Bookings?> GetBookingByIdAsync(decimal bookingId);
        Task UpdateBookingAsync(Bookings booking);
        Task<List<BookedTickets>> GetTicketsByBookingIdAsync(decimal bookingId);
        Task UpdateTicketAsync(BookedTickets ticket);

        // Helper methods:
        Task<Passengers?> GetPassengerByAadhaarAsync(string aadhaarNumber);
        Task<BookedTickets?> GetTicketByBookingAndPassengerAsync(decimal bookingId, decimal passengerId);

        // New methods for viewing bookings:
        Task<List<Bookings>> GetBookingsByUserAsync(decimal userId);
        Task<List<Bookings>> GetAllBookingsAsync();
    }
}
