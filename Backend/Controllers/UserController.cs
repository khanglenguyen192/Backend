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
        [Authorize]
        public ResponseModel UpdateUser(int userId, [FromForm] UpdateUserModel model, IFormFile image)
        {
            try
            {
                var user = _userRepository.FirstOrDefault(u => u.Id == userId && !u.IsDeactivate);
                if (user == null)
                    return ResponseUtil.GetBadRequestResult("user_not_found");

                user.Update(model);

                if (_userRepository.Update(user) > 0 && image != null)
                {
                    if (!string.IsNullOrWhiteSpace(user.Avatar))
                    {
                        FileUtils.DeleteFile(Constants.UserDataFolderName, user.Avatar);
                    }

                    user.Avatar = FileUtils.ImageUpload(Constants.UserDataFolderName, image);
                    _userRepository.Update(user);
                }

                return ResponseUtil.GetOKResult(model);
            }
            catch (Exception ex)
            {
                return ResponseUtil.GetServerErrorResult(ex.ToString());
            }
        }

        [HttpPost]
        [Produces("application/json")]
        [Route("update-user-identity")]
        [Authorize]
        public ResponseModel UpdateUserIdentity(int userId, [FromForm] UpdateUserIdentityModel model, IFormFile idFrontImage, IFormFile idBackImage)
        {
            try
            {
                var user = _userRepository.FirstOrDefault(u => u.Id == userId && !u.IsDeactivate);
                if (user == null)
                    return ResponseUtil.GetBadRequestResult("user_not_found");

                user.Update(model);
                bool updateResult = _userRepository.Update(user) > 0;

                if (updateResult && (idFrontImage != null || idBackImage != null))
                {
                    if (idFrontImage != null)
                    {
                        if (!string.IsNullOrWhiteSpace(user.IdFrontImage))
                        {
                            FileUtils.DeleteFile(Constants.UserDataFolderName, user.IdFrontImage);
                        }

                        user.IdFrontImage = FileUtils.ImageUpload(Constants.UserDataFolderName, idFrontImage);
                    }

                    if (idBackImage != null)
                    {
                        if (!string.IsNullOrWhiteSpace(user.IdBackImage))
                        {
                            FileUtils.DeleteFile(Constants.UserDataFolderName, user.IdBackImage);
                        }

                        user.IdBackImage = FileUtils.ImageUpload(Constants.UserDataFolderName, idBackImage);
                    }

                    _userRepository.Update(user);
                }

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
