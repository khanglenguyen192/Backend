using Backend.Common;
using Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/users")]
    public class UserController : BaseController
    {
        public UserController(
            IUserService userService,
            IWebHostEnvironment webHostEnvironment,
            ILogger<BaseController> logger) : base(userService, webHostEnvironment, logger)
        {

        }

        [HttpPost]
        [Produces("application/json")]
        [Route("create-user")]
        //[Authorize(Roles = "Administrator")]
        [Authorize]
        public ResponseModel CreateUser([FromBody] UserApiModel model)
        {
            try
            {
                var result = _userService.CreateUser(model, Entities.EnumUtil.UserRole.Administrator);
                if (result != null)
                {
                    return ResponseUtil.GetOKResult(result);
                }

                return ResponseUtil.GetServerErrorResult("cannot_create_user");
            }
            catch (Exception ex)
            {
                return ResponseUtil.GetServerErrorResult(ex.ToString());
            }
        }
    }
}
