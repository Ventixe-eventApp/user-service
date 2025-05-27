using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;
using Presentation.Services;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController(IUserProfileService userProfileService) : ControllerBase
{
    private readonly IUserProfileService _userProfileService = userProfileService;

    [HttpPost("create")]
    public async Task<IActionResult> CreateUserProfile([FromBody] UserProfileRequest request)
    {
        if (request == null)
        {
            return BadRequest("User profile request cannot be null.");
        }
        var result = await _userProfileService.Create(request);
        if (result.Succeeded)
        {
            return Ok(new { Message = "User profile created successfully." });
        }
        return StatusCode(StatusCodes.Status500InternalServerError, result.Error);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEventById(string id)
    {
        var selectedEvent = await _userProfileService.GetUserProfileByIdAsync(id);
        if (selectedEvent == null)
        {
            return NotFound(new { message = "User not found" });
        }
        return Ok(selectedEvent);
    }
}
