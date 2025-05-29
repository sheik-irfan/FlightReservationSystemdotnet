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
            var success = await _walletService.DebitAsync(dto.UserId, dto.TotalPrice, "Flight Booking");
            if (!success) return false;

            var booking = new Bookings
            {
                UserId = dto.UserId,
                FlightId = dto.FlightId,
                BookingTime = DateTime.UtcNow,
                Status = "PENDING",
                TotalPrice = dto.TotalPrice
            };

            var bookingId = await _repository.AddBookingAsync(booking);

            foreach (var p in dto.Passengers)
            {
                var existingPassenger = await _repository.GetPassengerByAadhaarAsync(p.AadhaarNumber);
                decimal passengerId = existingPassenger?.Id ?? await _repository.AddPassengerAsync(new Passengers
                {
                    BookingId = bookingId,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Gender = p.Gender,
                    Age = p.Age,
                    AadhaarNumber = p.AadhaarNumber
                });

                var ticketExists = await _repository.GetTicketByBookingAndPassengerAsync(bookingId, passengerId);
                if (ticketExists == null)
                {
                    await _repository.AddTicketAsync(new BookedTickets
                    {
                        BookingId = bookingId,
                        PassengerId = passengerId,
                        FlightClass = p.FlightClass,
                        Price = p.Price,
                        Status = "BOOKED"
                    });
                }
            }

            return true;
        }

        public async Task<bool> CancelBookingAsync(decimal bookingId)
        {
            var booking = await _repository.GetBookingByIdAsync(bookingId);
            if (booking == null || booking.Status == "CANCELLED") return false;

            booking.Status = "CANCELLED";
            await _repository.UpdateBookingAsync(booking);

            var tickets = await _repository.GetTicketsByBookingIdAsync(bookingId);
            foreach (var ticket in tickets)
            {
                ticket.Status = "CANCELLED";
                ticket.CancellationTime = DateTime.UtcNow;
                await _repository.UpdateTicketAsync(ticket);
            }

            return await _walletService.RefundAsync(booking.UserId, booking.TotalPrice, "Booking Refund");
        }

        public async Task<bool> ConfirmBookingAsync(decimal bookingId)
        {
            var booking = await _repository.GetBookingByIdAsync(bookingId);
            if (booking == null) return false;

            booking.Status = "CONFIRMED";
            await _repository.UpdateBookingAsync(booking);
            return true;
        }

        public async Task<List<Bookings>> GetBookingsByUserAsync(decimal userId)
        {
            return await _repository.GetBookingsByUserAsync(userId);
        }

        public async Task<List<Bookings>> GetBookingsByUserEmailAsync(string email)
        {
            return await _repository.GetBookingsByUserEmailAsync(email);
        }

        public async Task<List<Bookings>> GetAllBookingsAsync()
        {
            return await _repository.GetAllBookingsAsync();
        }
    }
}
