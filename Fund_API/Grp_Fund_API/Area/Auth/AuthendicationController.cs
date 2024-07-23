using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Grp_Fund_API.Area.Auth

{

    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    [Produces("application/json")]
    public class AuthendicationController(ILogger<AuthendicationController> logger) : ControllerBase
    {
        // Remove the unused private member

        [HttpGet(Name = "GetAuthendication")]
        public async Task<IActionResult> Authendication(string username, string password)
        {
            try
            {
                if (username == "admin" && password == "admin")
                {
                    return Ok("Login Success");
                }
                else
                {
                    return BadRequest("Invalid Credentials");
                }
            }
            catch (Exception ex)
            {
                LoggerMessage.Define(LogLevel.Error, new EventId(), "Error in Authendication").Invoke((ILogger)ex, null);
                return StatusCode(500, "Internal Server Error");
            }

        }

    }
}
