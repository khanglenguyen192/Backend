using Backend.Common;
using Backend.DBContext;
using Backend.Entities;
using Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Backend.Controllers
{
    [Route("api/users")]
    public class UserController : BaseController
    {
        public UserController(
            IUserService userService,
            IWebHostEnvironment webHostEnvironment,
            ILogger<BaseController> logger,
            IJwtHandler jwtHandler,
            IUserRepository userRepository)
            : base(userService, webHostEnvironment, logger, jwtHandler, userRepository)
        {
        }

        [HttpPost]
        [Produces("application/json")]
        [Route("create-user")]
        //[Authorize(Roles = "Administrator")]
        [Authorize]
        public ResponseModel CreateUser([FromBody] UserApiModel model, [FromHeader] string authorization)
        {
            try
            {
                var result = _userService.CreateUser(model, model.Role);
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

        [HttpGet]
        [Produces("application/json")]
        [Route("get-user")]
        //[Authorize(Roles = "Administrator")]
        [Authorize]
        public ResponseModel GetUser(int userId)
        {
            try
            {
                var user = _userRepository.FirstOrDefault(u => u.Id == userId && !u.IsDeactivate);
                if (user != null)
                {
                    var result = _mapper.Map<User, UserApiModel>(user);
                    return ResponseUtil.GetOKResult(result);
                }

                return ResponseUtil.GetBadRequestResult("user_not_found");
            }
            catch (Exception ex)
            {
                return ResponseUtil.GetServerErrorResult(ex.ToString());
            }
        }

        [HttpPost]
        [Produces("application/json")]
        [Route("update-user")]
        //[Authorize(Roles = "Administrator")]
        [Authorize]
        public ResponseModel UpdateUser(int userId, [FromBody] UpdateUserModel model, IFormFile image)
        {
            try
            {
                var user = _userRepository.FirstOrDefault(u => u.Id == userId && !u.IsDeactivate);
                if (user == null)
                    return ResponseUtil.GetBadRequestResult("user_not_found");

                user = _mapper.Map<UpdateUserModel, User>(model);

                if (image != null)
                {
                    user.Avatar = FileUtils.ImageUpload(Constants.UserDataFolderName, image);
                }

                _userRepository.Update(user);

                return ResponseUtil.GetOKResult(model);
            }
            catch (Exception ex)
            {
                return ResponseUtil.GetServerErrorResult(ex.ToString());
            }
        }

        [HttpPost]
        [Produces("application/json")]
        [Route("reset-password")]
        [Authorize(Roles = "Administrator")]
        public ResponseModel ResetPassword(int userId)
        {
            try
            {
                var user = _userRepository.FirstOrDefault(u => u.Id == userId && !u.IsDeactivate);

                if (user == null)
                {
                    return ResponseUtil.GetBadRequestResult(ErrorMessageCode.USER_NOT_FOUND);
                }
                else
                {
                    user.Salt = Guid.NewGuid().ToString().Replace("-", "");
                    user.PassCode = CommonUtils.GeneratePasscode(Constants.DEFAULT_PASSCODE, user.Salt);
                    user.IsFirstLogin = true;
                    _userRepository.Update(user);
                    return ResponseUtil.GetOKResult("Success");
                }
            }
            catch (Exception ex)
            {
                return ResponseUtil.GetServerErrorResult(ex.ToString());
            }
        }
    }
}
