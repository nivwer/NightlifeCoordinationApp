using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NightlifeCoordinationAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpGet]
    [Authorize]
    public IActionResult GetUser()
    {
        // var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var email = User.Identity?.Name;

        return Ok(new { Email = email });
    }
}
