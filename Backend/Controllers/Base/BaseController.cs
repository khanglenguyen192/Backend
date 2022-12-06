using Backend.Common;
using Backend.Common.Models.User;
using Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using static Backend.Entities.EnumUtil;

namespace Backend.Controllers
{
    /// <summary>
    /// BaseController
    /// </summary>
    public abstract class BaseController : ControllerBase
    {
        protected readonly IWebHostEnvironment _webHostEnvironment;
        protected readonly ILogger<BaseController> _logger;
        protected readonly IUserService _userService;

        protected UserTokenModel CurrentUser { get { return GetUserIdentify(); } }

        public BaseController(IUserService userService, IWebHostEnvironment webHostEnvironment, ILogger<BaseController> logger)
        {
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
        }

        protected ResponseModel GetOKResult(object result)
        {
            return new ResponseModel
            {
                Status = HttpStatusCode.OK,
                IsSuccess = true,
                Data = result,
                Error = null
            };
        }

        protected ResponseModel GetServerErrorResult(string ex)
        {
            return new ResponseModel
            {
                Status = HttpStatusCode.InternalServerError,
                IsSuccess = false,
                Data = null,
                Error = new ErrorModel
                {
                    Code = HttpStatusCode.InternalServerError.ToString(),
                    Message = ErrorMessageCode.SERVER_ERROR,
                    InnerError = ex
                }
            };
        }

        protected ResponseModel GetBadRequestResult(string message)
        {
            return new ResponseModel
            {
                Status = HttpStatusCode.BadRequest,
                IsSuccess = false,
                Data = null,
                Error = new ErrorModel
                {
                    Code = HttpStatusCode.BadRequest.ToString(),
                    Message = ErrorMessageCode.BAD_REQUEST,
                    InnerError = message
                }
            };
        }

        protected UserTokenModel GetUserIdentify()
        {
            var userModel = new UserTokenModel();

            var identity = HttpContext.User.Identity as System.Security.Claims.ClaimsIdentity;

            if (identity == null) return null;

            userModel.UserId = Convert.ToInt32(identity.Name);

            var claim = identity.Claims.FirstOrDefault(p => p.Type.ToLower().Equals(Constants.ROLE.ToLower()));

            if (claim != null)
            {
                userModel.UserRole = (UserRole)Convert.ToInt32(claim.Value);
            }

            var user = _userService.GetUserById(userModel.UserId)?.Result;

            if (user == null) return null;

            userModel.FullName = user.FullName;

            TimeZoneInfo timeZone = CommonUtils.GetLocalTimeZone(user);
            userModel.TimeZoneInfo = timeZone;

            return userModel;
        }
    }
}
