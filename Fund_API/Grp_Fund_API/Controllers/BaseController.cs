using Grp_Fund_Model;
using Microsoft.AspNetCore.Mvc;

namespace Grp_Fund_API.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)] // Exclude from Swagger
    public class BaseController : ControllerBase
    {
        private readonly ResultArgs ResultArgs = new();

        protected IActionResult GlobalException(Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred. Please try again later.");
        }

        protected IActionResult ApiResult()
        {
            return ResultArgs.StatusCode switch
            {
                StatusCodes.Status200OK => Ok(ResultArgs),
                StatusCodes.Status400BadRequest => BadRequest(ResultArgs),
                StatusCodes.Status404NotFound => NotFound(ResultArgs),
                StatusCodes.Status500InternalServerError => StatusCode(StatusCodes.Status500InternalServerError, ResultArgs),
                StatusCodes.Status401Unauthorized => Unauthorized(ResultArgs),
                StatusCodes.Status403Forbidden => Forbid(),
                _ => BadRequest(ResultArgs),
            };
        }

    }
}
