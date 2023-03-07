using Backend.Common;
using Backend.Entities;
using Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Backend.Controllers
{
    [Route("api/home")]
    [ApiController]
    public class HomeController : BaseController
    {
        public HomeController(IUserService userService,
                              IWebHostEnvironment webHostEnvironment,
                              ILogger<BaseController> logger) : base(userService, webHostEnvironment, logger)
        { 

        }

        [HttpPost]
        [Route("login")]
        public ResponseModel Login([FromBody] LoginModel userLoginModel)
        {
            if (userLoginModel == null || string.IsNullOrWhiteSpace(userLoginModel.PassCode))
                return ResponseUtil.GetBadRequestResult(ErrorMessageCode.FIELDS_IS_EMPTY);

            return _userService.LoginUser(userLoginModel);
        }

        [HttpPost]
        [Route("logout")]
        public ResponseModel Logout()
        {
            return ResponseUtil.GetOKResult(null);
        }

        [HttpGet]
        [Route("getUserIndex")]
        public ResponseModel GetUserIndex(int userId)
        {
            return ResponseUtil.GetOKResult(new UserIndexModel());
        }
    }
}
