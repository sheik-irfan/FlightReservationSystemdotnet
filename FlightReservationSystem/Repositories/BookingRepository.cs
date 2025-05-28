using FlightReservationSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightReservationSystem.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly FlightReservation _context;

        public BookingRepository(FlightReservation context)
        {
            _context = context;
        }

        public async Task<decimal> AddBookingAsync(Bookings booking)
        {
            _context.Bookings.Add(booking);
            System.Console.WriteLine($"[Repository] Adding booking with status: [{booking.Status}]");
            await _context.SaveChangesAsync();
            System.Console.WriteLine($"[Repository] Booking saved with generated ID: {booking.Id}");
            return booking.Id;
        }

        public async Task<decimal> AddPassengerAsync(Passengers passenger)
        {
            _context.Passengers.Add(passenger);
            System.Console.WriteLine($"[Repository] Adding new passenger for BookingID: {passenger.BookingId} with Aadhaar: {passenger.AadhaarNumber}");
            await _context.SaveChangesAsync();
            System.Console.WriteLine($"[Repository] Passenger saved with generated ID: {passenger.Id}");
            return passenger.Id;
        }

        public async Task AddTicketAsync(BookedTickets ticket)
        {
            _context.BookedTickets.Add(ticket);
            System.Console.WriteLine($"[Repository] Adding ticket for BookingID: {ticket.BookingId}, PassengerID: {ticket.PassengerId}");
            await _context.SaveChangesAsync();
            System.Console.WriteLine($"[Repository] Ticket added for BookingID: {ticket.BookingId}, PassengerID: {ticket.PassengerId}");
        }

        public async Task<Bookings?> GetBookingByIdAsync(decimal bookingId)
        {
            return await _context.Bookings.FindAsync(bookingId);
        }

        public async Task UpdateBookingAsync(Bookings booking)
        {
            _context.Bookings.Update(booking);
            System.Console.WriteLine($"[Repository] Updating booking ID: {booking.Id} to status: {booking.Status}");
            await _context.SaveChangesAsync();
        }

        public async Task<List<BookedTickets>> GetTicketsByBookingIdAsync(decimal bookingId)
        {
            return await _context.BookedTickets
                .Where(t => t.BookingId == bookingId)
                .ToListAsync();
        }

        public async Task UpdateTicketAsync(BookedTickets ticket)
        {
            _context.BookedTickets.Update(ticket);
            System.Console.WriteLine($"[Repository] Updating ticket for BookingID: {ticket.BookingId} to status: {ticket.Status}");
            await _context.SaveChangesAsync();
        }

        public async Task<Passengers?> GetPassengerByAadhaarAsync(string aadhaarNumber)
        {
            return await _context.Passengers
                      .FirstOrDefaultAsync(p => p.AadhaarNumber == aadhaarNumber);
        }

        public async Task<BookedTickets?> GetTicketByBookingAndPassengerAsync(decimal bookingId, decimal passengerId)
        {
            return await _context.BookedTickets
                .FirstOrDefaultAsync(t => t.BookingId == bookingId && t.PassengerId == passengerId);
        }

        // New: Get all bookings for a specific user.
        public async Task<List<Bookings>> GetBookingsByUserAsync(decimal userId)
        {
            return await _context.Bookings
                .Where(b => b.UserId == userId)
                .ToListAsync();
        }

        // New: Get all bookings (admin view).
        public async Task<List<Bookings>> GetAllBookingsAsync()
        {
            return await _context.Bookings.ToListAsync();
        }
    }
}
