//using FlightReservationSystem.Models.DTOs;
//using FlightReservationSystem.Services;
//using Microsoft.AspNetCore.Mvc;

//namespace FlightReservationSystem.Controllers;

//[ApiController]
//[Route("api/[controller]")]
//public class UsersController : ControllerBase
//{
//    private readonly IUserService _userService;

//    public UsersController(IUserService userService)
//    {
//        _userService = userService;
//    }

//    [HttpPost("register")]
//    public async Task<IActionResult> Register([FromBody] RegisterDto dto)
//    {
//        var success = await _userService.RegisterAsync(dto);
//        if (!success)
//            return BadRequest(new { message = "Email already exists." });

//        return Ok(new { message = "User registered successfully." });
//    }

//    [HttpPost("login")]
//    public async Task<IActionResult> Login([FromBody] AuthenticationRequestDto dto)
//    {
//        var response = await _userService.AuthenticateAsync(dto);
//        if (response == null)
//            return Unauthorized(new { message = "Invalid email or password." });

//        return Ok(response);
//    }
//}
