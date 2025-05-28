using FlightReservationSystem.DTOs;
using FlightReservationSystem.Models;
using FlightReservationSystem.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightReservationSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateBooking([FromBody] BookingDto dto)
        {
            System.Console.WriteLine($"[Controller] Received booking request for user {dto.UserId} with totalPrice {dto.TotalPrice}");
            var result = await _bookingService.CreateBookingAsync(dto);
            if (!result)
            {
                System.Console.WriteLine("[Controller] Booking creation failed.");
                return BadRequest("Booking failed due to insufficient wallet balance or other issues.");
            }
            System.Console.WriteLine("[Controller] Booking creation succeeded.");
            return Ok("Booking successful.");
        }

        [HttpPost("cancel/{bookingId}")]
        public async Task<IActionResult> CancelBooking(decimal bookingId)
        {
            System.Console.WriteLine($"[Controller] Received cancellation request for BookingID: {bookingId}");
            var result = await _bookingService.CancelBookingAsync(bookingId);
            if (!result)
            {
                System.Console.WriteLine("[Controller] Booking cancellation failed.");
                return BadRequest("Cancellation failed. Booking not found or already cancelled.");
            }
            System.Console.WriteLine("[Controller] Booking cancellation succeeded.");
            return Ok("Booking cancelled and refund processed.");
        }

        // New endpoint: Confirm a booking.
        [HttpPost("confirm/{bookingId}")]
        public async Task<IActionResult> ConfirmBooking(decimal bookingId)
        {
            System.Console.WriteLine($"[Controller] Received confirmation request for BookingID: {bookingId}");
            var result = await _bookingService.ConfirmBookingAsync(bookingId);
            if (!result)
            {
                System.Console.WriteLine("[Controller] Booking confirmation failed.");
                return BadRequest("Booking confirmation failed.");
            }
            System.Console.WriteLine("[Controller] Booking confirmed successfully.");
            return Ok("Booking confirmed.");
        }

        // New endpoint: Get bookings for a specific user.
        [HttpGet("mybookings/{userId}")]
        public async Task<IActionResult> GetBookingsByUser(decimal userId)
        {
            System.Console.WriteLine($"[Controller] Retrieving bookings for user ID: {userId}");
            List<Bookings> bookings = await _bookingService.GetBookingsByUserAsync(userId);
            if (bookings == null || bookings.Count == 0)
            {
                return NotFound("No bookings found for this user.");
            }
            return Ok(bookings);
        }

        // New endpoint: Get all bookings (admin view).
        [HttpGet("all")]
        public async Task<IActionResult> GetAllBookings()
        {
            System.Console.WriteLine("[Controller] Retrieving all bookings (admin view)");
            List<Bookings> bookings = await _bookingService.GetAllBookingsAsync();
            if (bookings == null || bookings.Count == 0)
            {
                return NotFound("No bookings found.");
            }
            return Ok(bookings);
        }
    }
}
