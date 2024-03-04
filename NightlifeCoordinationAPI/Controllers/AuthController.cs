using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace NightlifeCoordinationAPI.Controllers;

[Route("/")]
public class AuthController : ControllerBase
{
    public SignInManager<IdentityUser> _signInManager { get; set; }

    public AuthController(SignInManager<IdentityUser> signInManager)
    {
        _signInManager = signInManager;
    }

    [HttpPost]
    [Route("logout")]
    [Authorize]
    public async Task<IActionResult> Logout([FromBody] object empty)
    {
        if (empty == null)
        {
            return Unauthorized();
        }

        await _signInManager.SignOutAsync();
        return Ok();
    }
}
