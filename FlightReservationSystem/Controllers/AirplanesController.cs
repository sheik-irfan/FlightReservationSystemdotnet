using FlightReservationSystem.Models.DTOs;
using FlightReservationSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationSystem.Controllers;

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
    public async Task<ActionResult<IEnumerable<AirplaneDto>>> GetAll()
    {
        var airplanes = await _service.GetAllAirplanesAsync();
        return Ok(airplanes);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AirplaneDto>> GetById(decimal id)
    {
        var airplane = await _service.GetAirplaneByIdAsync(id);
        if (airplane == null) return NotFound();
        return Ok(airplane);
    }

    [HttpPost]
    public async Task<ActionResult<AirplaneDto>> Create([FromBody] AirplaneDto dto)
    {
        var createdAirplane = await _service.CreateAirplaneAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = createdAirplane.Id }, createdAirplane);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(decimal id, [FromBody] AirplaneDto dto)
    {
        if (id != dto.Id)
            return BadRequest("Id mismatch");

        var result = await _service.UpdateAirplaneAsync(id, dto);
        if (!result) return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(decimal id)
    {
        var result = await _service.DeleteAirplaneAsync(id);
        if (!result) return NotFound();

        return NoContent();
    }
}
