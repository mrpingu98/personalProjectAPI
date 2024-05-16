using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace personalProjectAPI.Controllers;

[ApiController]
[Route("/auth")]
public class AuthorisationController : ControllerBase
{
    private readonly SignInManager<IdentityUser> _signInManager;

    public AuthorisationController(SignInManager<IdentityUser> signInManager)
    {
        _signInManager = signInManager;
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout([FromBody] object empty)
    {
        if (empty != null)
        {
            await _signInManager.SignOutAsync();
            return Ok(); // Returns a 200 OK response
        }
        return Unauthorized(); // Returns a 401 Unauthorized response
    }
}


