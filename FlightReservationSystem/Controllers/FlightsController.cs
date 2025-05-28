using FlightReservationSystem.DTOs;
using FlightReservationSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FlightReservationSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlightsController : ControllerBase
    {
        private readonly IFlightService _service;

        public FlightsController(IFlightService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(decimal id)
        {
            var flight = await _service.GetByIdAsync(id);
            return flight == null ? NotFound() : Ok(flight);
        }

        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        public async Task<IActionResult> Create(FlightCreateDto dto)
        {
            if (dto.SourceAirportId == dto.DestinationAirportId)
                return BadRequest("Source and destination airports cannot be the same.");

            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [Authorize(Roles = "ADMIN")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(decimal id, FlightUpdateDto dto)
        {
            if (dto.SourceAirportId == dto.DestinationAirportId)
                return BadRequest("Source and destination airports cannot be the same.");

            var success = await _service.UpdateAsync(id, dto);
            return success ? NoContent() : NotFound();
        }

        [Authorize(Roles = "ADMIN")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(decimal id)
        {
            var success = await _service.DeleteAsync(id);
            return success ? NoContent() : NotFound();
        }

        [HttpGet("{flightId}/prices")]
        public async Task<IActionResult> GetPrices(decimal flightId)
        {
            var prices = await _service.GetPricesAsync(flightId);
            return Ok(prices);
        }

        [Authorize(Roles = "ADMIN")]
        [HttpPost("{flightId}/prices")]
        public async Task<IActionResult> AddPrice(decimal flightId, FlightPriceCreateDto dto)
        {
            if (dto.FlightId != flightId)
                return BadRequest("Flight ID mismatch.");

            try
            {
                var result = await _service.AddPriceAsync(dto);
                return Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
        }

        [Authorize(Roles = "ADMIN")]
        [HttpPut("{flightId}/prices")]
        public async Task<IActionResult> UpdatePrice(decimal flightId, FlightPriceCreateDto dto)
        {
            if (dto.FlightId != flightId)
                return BadRequest("Flight ID mismatch.");

            try
            {
                var updated = await _service.UpdatePriceAsync(dto);
                return Ok(updated);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] int sourceAirportId, [FromQuery] int destinationAirportId)
        {
            var flights = await _service.SearchAsync(sourceAirportId, destinationAirportId);
            return Ok(flights);
        }
    }
}
