using AutoMapper;
using FlightReservationSystem.DTOs;
using FlightReservationSystem.Models;
using FlightReservationSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightReservationSystem.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _repository;
        private readonly IWalletService _walletService;
        private readonly IMapper _mapper;

        public BookingService(IBookingRepository repository, IWalletService walletService, IMapper mapper)
        {
            _repository = repository;
            _walletService = walletService;
            _mapper = mapper;
        }

        public async Task<bool> CreateBookingAsync(BookingDto dto)
        {
            // Debit the user's wallet.
            var success = await _walletService.DebitAsync(dto.UserId, dto.TotalPrice, "Flight Booking");
            if (!success)
            {
                Console.WriteLine($"[Service] Wallet debit failed for user {dto.UserId}.");
                return false;
            }

            // Create new booking with status "PENDING"
            var booking = new Bookings
            {
                UserId = dto.UserId,
                FlightId = dto.FlightId,
                BookingTime = DateTime.UtcNow,
                Status = "PENDING", // Initial status
                TotalPrice = dto.TotalPrice
            };

            Console.WriteLine($"[Service] Creating booking for user {booking.UserId} with status: [{booking.Status}]");

            var bookingId = await _repository.AddBookingAsync(booking);
            Console.WriteLine($"[Service] Booking created with generated ID: {bookingId}");

            // Process each passenger in the booking.
            foreach (var p in dto.Passengers)
            {
                // Check for an existing passenger with the same Aadhaar.
                var existingPassenger = await _repository.GetPassengerByAadhaarAsync(p.AadhaarNumber);
                decimal passengerId;
                if (existingPassenger != null)
                {
                    passengerId = existingPassenger.Id;
                    Console.WriteLine($"[Service] Found existing passenger with ID: {passengerId} for Aadhaar {p.AadhaarNumber}");
                }
                else
                {
                    var passenger = new Passengers
                    {
                        BookingId = bookingId,
                        FirstName = p.FirstName,
                        LastName = p.LastName,
                        Gender = p.Gender,
                        Age = p.Age,
                        AadhaarNumber = p.AadhaarNumber
                    };

                    passengerId = await _repository.AddPassengerAsync(passenger);
                    Console.WriteLine($"[Service] Created new passenger with ID: {passengerId} for Aadhaar {p.AadhaarNumber}");
                }

                // Check if a ticket already exists for this booking and passenger.
                var existingTicket = await _repository.GetTicketByBookingAndPassengerAsync(bookingId, passengerId);
                if (existingTicket != null)
                {
                    Console.WriteLine($"[Service] Ticket already exists for BookingID: {bookingId} and PassengerID: {passengerId}. Skipping ticket insertion.");
                }
                else
                {
                    // Create ticket with allowed status "BOOKED"
                    var ticket = new BookedTickets
                    {
                        BookingId = bookingId,
                        PassengerId = passengerId,
                        FlightClass = p.FlightClass,
                        Price = p.Price,
                        Status = "BOOKED"  // Allowed values for tickets: 'BOOKED' or 'CANCELLED'
                    };

                    await _repository.AddTicketAsync(ticket);
                    Console.WriteLine($"[Service] Ticket created for PassengerID: {passengerId} under BookingID: {bookingId}");
                }
            }

            return true;
        }

        public async Task<bool> CancelBookingAsync(decimal bookingId)
        {
            Console.WriteLine($"[Service] Cancelling booking with ID: {bookingId}");
            var booking = await _repository.GetBookingByIdAsync(bookingId);
            if (booking == null || booking.Status == "CANCELLED")
            {
                Console.WriteLine($"[Service] Booking {bookingId} not found or already cancelled.");
                return false;
            }

            booking.Status = "CANCELLED";
            await _repository.UpdateBookingAsync(booking);
            Console.WriteLine($"[Service] Booking {bookingId} status set to CANCELLED.");

            var tickets = await _repository.GetTicketsByBookingIdAsync(bookingId);
            foreach (var ticket in tickets)
            {
                ticket.Status = "CANCELLED";
                ticket.CancellationTime = DateTime.UtcNow;
                await _repository.UpdateTicketAsync(ticket);
                Console.WriteLine($"[Service] Ticket for BookingID {bookingId} cancelled at {ticket.CancellationTime}");
            }

            var refundSuccess = await _walletService.RefundAsync(booking.UserId, booking.TotalPrice, "Booking Refund");
            Console.WriteLine($"[Service] Refund processed for user {booking.UserId}: {refundSuccess}");
            return refundSuccess;
        }

        // New: Confirm a booking (changing its status from PENDING to CONFIRMED).
        public async Task<bool> ConfirmBookingAsync(decimal bookingId)
        {
            Console.WriteLine($"[Service] Confirming booking with ID: {bookingId}");
            var booking = await _repository.GetBookingByIdAsync(bookingId);
            if (booking == null)
            {
                Console.WriteLine($"[Service] Booking {bookingId} not found.");
                return false;
            }

            // Here you might also check if all tickets are valid, etc.
            booking.Status = "CONFIRMED";
            await _repository.UpdateBookingAsync(booking);
            Console.WriteLine($"[Service] Booking {bookingId} status updated to CONFIRMED.");
            return true;
        }

        // New: Get bookings for a specific user.
        public async Task<List<Bookings>> GetBookingsByUserAsync(decimal userId)
        {
            return await _repository.GetBookingsByUserAsync(userId);
        }

        // New: Get all bookings (for admin).
        public async Task<List<Bookings>> GetAllBookingsAsync()
        {
            return await _repository.GetAllBookingsAsync();
        }
    }
}
