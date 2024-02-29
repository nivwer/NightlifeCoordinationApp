using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NightlifeCoordinationAPI.Data;

namespace NightlifeCoordinationAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    // private readonly UserManager<IdentityUser> _userManager;

    // public UserController(UserManager<IdentityUser> userManager)
    // {
    //     _userManager = userManager;
    // }




    // public async Task<User?> GetUsers()
    // {
    //     var user = await _userManager.Fi

    //     // var user = await _context.Users.FindAsync(id);

    //     // return user;
    // }


    [HttpGet]
    [Authorize]
    public IActionResult GetUser()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var username = User.Identity?.Name;

        return Ok(new { UserId = userId, Username = username });
    }
}
