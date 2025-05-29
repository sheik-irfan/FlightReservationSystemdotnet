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

        /** Add a new booking */
        public async Task<decimal> AddBookingAsync(Bookings booking)
        {
            _context.Bookings.Add(booking);
            System.Console.WriteLine($"[Repository] Adding booking with status: [{booking.Status}]");
            await _context.SaveChangesAsync();
            System.Console.WriteLine($"[Repository] Booking saved with generated ID: {booking.Id}");
            return booking.Id;
        }

        /** Add a new passenger */
        public async Task<decimal> AddPassengerAsync(Passengers passenger)
        {
            _context.Passengers.Add(passenger);
            System.Console.WriteLine($"[Repository] Adding new passenger for BookingID: {passenger.BookingId} with Aadhaar: {passenger.AadhaarNumber}");
            await _context.SaveChangesAsync();
            System.Console.WriteLine($"[Repository] Passenger saved with generated ID: {passenger.Id}");
            return passenger.Id;
        }

        /** Add a ticket for a passenger */
        public async Task AddTicketAsync(BookedTickets ticket)
        {
            _context.BookedTickets.Add(ticket);
            System.Console.WriteLine($"[Repository] Adding ticket for BookingID: {ticket.BookingId}, PassengerID: {ticket.PassengerId}");
            await _context.SaveChangesAsync();
            System.Console.WriteLine($"[Repository] Ticket added for BookingID: {ticket.BookingId}, PassengerID: {ticket.PassengerId}");
        }

        /** Fetch a specific booking */
        public async Task<Bookings?> GetBookingByIdAsync(decimal bookingId)
        {
            return await (from booking in _context.Bookings
                          join user in _context.Users on booking.UserId equals user.Id
                          where booking.Id == bookingId
                          select new Bookings
                          {
                              Id = booking.Id,
                              UserId = booking.UserId,
                              FlightId = booking.FlightId,
                              BookingTime = booking.BookingTime,
                              Status = booking.Status,
                              TotalPrice = booking.TotalPrice,
                              UserName = user.Name
                          }).FirstOrDefaultAsync();
        }

        /** Update a booking */
        public async Task UpdateBookingAsync(Bookings booking)
        {
            _context.Bookings.Update(booking);
            System.Console.WriteLine($"[Repository] Updating booking ID: {booking.Id} to status: {booking.Status}");
            await _context.SaveChangesAsync();
        }

        /** Get all tickets for a booking */
        public async Task<List<BookedTickets>> GetTicketsByBookingIdAsync(decimal bookingId)
        {
            return await _context.BookedTickets
                .Where(t => t.BookingId == bookingId)
                .ToListAsync();
        }

        /** Update a booked ticket */
        public async Task UpdateTicketAsync(BookedTickets ticket)
        {
            _context.BookedTickets.Update(ticket);
            System.Console.WriteLine($"[Repository] Updating ticket for BookingID: {ticket.BookingId} to status: {ticket.Status}");
            await _context.SaveChangesAsync();
        }

        /** Fetch a passenger by Aadhaar */
        public async Task<Passengers?> GetPassengerByAadhaarAsync(string aadhaarNumber)
        {
            return await _context.Passengers
                .FirstOrDefaultAsync(p => p.AadhaarNumber == aadhaarNumber);
        }

        /** Fetch a ticket using booking and passenger */
        public async Task<BookedTickets?> GetTicketByBookingAndPassengerAsync(decimal bookingId, decimal passengerId)
        {
            return await _context.BookedTickets
                .FirstOrDefaultAsync(t => t.BookingId == bookingId && t.PassengerId == passengerId);
        }

        /** Get all bookings made by a specific user */
        public async Task<List<Bookings>> GetBookingsByUserAsync(decimal userId)
        {
            return await (from booking in _context.Bookings
                          join user in _context.Users on booking.UserId equals user.Id
                          where booking.UserId == userId
                          select new Bookings
                          {
                              Id = booking.Id,
                              UserId = booking.UserId,
                              FlightId = booking.FlightId,
                              BookingTime = booking.BookingTime,
                              Status = booking.Status,
                              TotalPrice = booking.TotalPrice,
                              UserName = user.Name
                          }).ToListAsync();
        }

        /** Get all bookings (admin view) */
        public async Task<List<Bookings>> GetAllBookingsAsync()
        {
            return await (from booking in _context.Bookings
                          join user in _context.Users on booking.UserId equals user.Id
                          select new Bookings
                          {
                              Id = booking.Id,
                              UserId = booking.UserId,
                              FlightId = booking.FlightId,
                              BookingTime = booking.BookingTime,
                              Status = booking.Status,
                              TotalPrice = booking.TotalPrice,
                              UserName = user.Name
                          }).ToListAsync();
        }

        /** Get bookings by user email */
        public async Task<List<Bookings>> GetBookingsByUserEmailAsync(string email)
        {
            return await (from booking in _context.Bookings
                          join user in _context.Users on booking.UserId equals user.Id
                          where user.Email == email
                          select new Bookings
                          {
                              Id = booking.Id,
                              UserId = booking.UserId,
                              FlightId = booking.FlightId,
                              BookingTime = booking.BookingTime,
                              Status = booking.Status,
                              TotalPrice = booking.TotalPrice,
                              UserName = user.Name
                          }).ToListAsync();
        }
    }
}
