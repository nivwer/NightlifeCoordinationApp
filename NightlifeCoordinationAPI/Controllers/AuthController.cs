using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace NightlifeCoordinationAPI.Controllers;

[Route("/")]
public class AuthController : ControllerBase
{
    public SignInManager<IdentityUser> SignInManager { get; set; }

    public AuthController(SignInManager<IdentityUser> signInManager)
    {
        SignInManager = signInManager;
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

        await SignInManager.SignOutAsync();
        return Ok();
    }
}
