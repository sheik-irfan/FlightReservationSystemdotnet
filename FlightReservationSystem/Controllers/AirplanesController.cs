using FlightReservationSystem.DTOs;
using FlightReservationSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AirplanesController : ControllerBase
    {
        private readonly IAirplaneService _service;

        public AirplanesController(IAirplaneService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<AirplaneDto>>> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AirplaneDto>> GetById(decimal id)
        {
            var airplane = await _service.GetByIdAsync(id);
            return airplane == null ? NotFound() : Ok(airplane);
        }

        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        public async Task<ActionResult<AirplaneDto>> Create([FromBody] AirplaneCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [Authorize(Roles = "ADMIN")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(decimal id, [FromBody] AirplaneUpdateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
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
    }
}
