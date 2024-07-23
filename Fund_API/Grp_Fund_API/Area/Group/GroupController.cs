using Fund_API.Framework;
using Microsoft.AspNetCore.Mvc;

namespace Grp_Fund_API.Area.Group
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        [HttpGet]
        [ActionName(APIActionName.Group.GetAllGroups)]
        public IActionResult GetGroupDetailsAsync()
        {
            return Ok();
        }

        [HttpGet]
        [ActionName(APIActionName.Group.GetGroupById)]
        public IActionResult GetGroupById(int groupId)
        {

            Console.WriteLine(groupId);
            return Ok();
        }

        [HttpPost]
        [ActionName(APIActionName.Group.CreateGroup)]
        public IActionResult CreateGroupAsync()
        {
            return Ok();
        }

        [HttpDelete]
        [ActionName(APIActionName.Group.DeleteGroup)]
        public IActionResult DeleteGroupAsync()
        {
            return Ok();
        }

        [HttpPut]
        [ActionName(APIActionName.Group.UpdateGroup)]
        public IActionResult UpdateGroupAsync()
        {
            return Ok();
        }

    }
}
