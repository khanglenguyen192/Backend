using Backend.Common;
using Backend.DBContext;
using Backend.Entities;
using Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/users")]
    public class UserController : BaseController
    {
        private readonly IUserRepository _userRepository;

        public UserController(
            IUserService userService,
            IWebHostEnvironment webHostEnvironment,
            ILogger<BaseController> logger,
            IUserRepository userRepository) : base(userService, webHostEnvironment, logger)
        {
            _userRepository= userRepository;
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
        public ResponseModel UpdateUser(int userId, [FromBody] UpdateUserModel model)
        {
            try
            {
                var user = _userRepository.FirstOrDefault(u => u.Id == userId && !u.IsDeactivate);
                if (user == null)
                    return ResponseUtil.GetBadRequestResult("user_not_found");

                user = _mapper.Map<UpdateUserModel, User>(model);

                _userRepository.Update(user);

                return ResponseUtil.GetOKResult(model);
            }
            catch (Exception ex)
            {
                return ResponseUtil.GetServerErrorResult(ex.ToString());
            }
        }
    }
}
