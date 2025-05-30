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
        if (!ModelState.IsValid)
        {
            var errors = ModelState
                .Where(x => x.Value?.Errors.Count > 0)
                .ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value?.Errors.Select(e => e.ErrorMessage).ToArray()
                );
            return BadRequest(new { sucess = false, errors });
        }

        var result = await _userProfileService.Create(request);
        if (result.Succeeded)
        {
            return Ok(new { Message = "User profile created successfully." });
        }
        return StatusCode(StatusCodes.Status500InternalServerError, result.Error);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(string id)
    {
        var selectedUser = await _userProfileService.GetUserProfileByIdAsync(id);
        if (selectedUser == null)
        {
            return NotFound(new { message = "User not found" });
        }
        return Ok(selectedUser);
    }
}
