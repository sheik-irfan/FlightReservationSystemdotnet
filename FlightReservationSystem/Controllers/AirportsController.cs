using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using FlightReservationSystem.Services;
using FlightReservationSystem.DTOs;

namespace FlightReservationSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "ADMIN")] // Restrict by default to ADMINs
    public class AirportsController : ControllerBase
    {
        private readonly IAirportService _airportService;

        public AirportsController(IAirportService airportService)
        {
            _airportService = airportService;
        }

        /// <summary>
        /// Get all airports.
        /// This endpoint is now open to all (i.e. not restricted to ADMINs).
        /// </summary>
        [HttpGet]
        [AllowAnonymous]  // Override admin restriction for this action
        [ProducesResponseType(typeof(List<AirportDto>), 200)]
        public async Task<ActionResult<List<AirportDto>>> GetAll()
        {
            var airports = await _airportService.GetAllAsync();
            return Ok(airports);
        }

        /// <summary>
        /// Get airport by id.
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(AirportDto), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<AirportDto>> GetById(decimal id)
        {
            var airport = await _airportService.GetByIdAsync(id);
            if (airport == null)
                return NotFound();

            return Ok(airport);
        }

        /// <summary>
        /// Create a new airport.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(AirportDto), 201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<AirportDto>> Create([FromBody] AirportCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdAirport = await _airportService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = createdAirport.Id }, createdAirport);
        }

        /// <summary>
        /// Update an existing airport.
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update(decimal id, [FromBody] AirportUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var success = await _airportService.UpdateAsync(id, dto);
            if (!success)
                return NotFound();

            return NoContent();
        }

        /// <summary>
        /// Delete an airport by id.
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(decimal id)
        {
            var success = await _airportService.DeleteAsync(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
