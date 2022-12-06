using Backend.Common;
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
        public ResponseModel Login([FromBody] LoginModel model)
        {
            return GetOKResult(model);
        }

        [HttpPost]
        [Route("logout")]
        public ResponseModel Logout()
        {
            return GetOKResult(null);
        }

        [HttpGet]
        [Route("getUserIndex")]
        public ResponseModel GetUserIndex(int userId)
        {
            return GetOKResult(new UserIndexModel());
        }
    }
}
