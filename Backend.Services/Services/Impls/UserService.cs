using Backend.Common;
using Backend.DBContext;
using Backend.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtHandler _jwtHandler;

        public UserService(IDbContextFactory contextFactory, IJwtHandler jwtHandler)
        {
            _userRepository = new UserRepository(contextFactory);
            _jwtHandler = jwtHandler;
        }

        public User GetUserById(int id)
        {
            return _userRepository.FirstOrDefault(x => x.Id == id);
        }

        public ResponseModel LoginUser(LoginModel loginModel)
        {
            User user = _userRepository.FirstOrDefault(u => u.Email.Equals(loginModel.UserName));

            if (user == null)
            {
                return ResponseUtil.GetErrorResult(HttpStatusCode.NotFound, ErrorMessageCode.USER_NOT_FOUND);
            }

            if (user.TotalLoginFail >= 3)
            {
                var timelogin = DateTime.UtcNow - user.LastLoginFail;
                if (timelogin.TotalMinutes < 30)
                {
                    return ResponseUtil.GetErrorResult(HttpStatusCode.Forbidden, ErrorMessageCode.USER_HAS_BEEN_LOCKED);
                }
                user.TotalLoginFail = 0;
            }

            if (user.IsDeactivate)
            {
                return ResponseUtil.GetErrorResult(HttpStatusCode.Forbidden, ErrorMessageCode.USER_IS_DEACTIVATE);
            }

            try
            {
                var passcode = CommonUtils.GeneratePasscode(loginModel.PassCode, user.Salt);
                if (passcode.Equals(user.PassCode))
                {
                    LoginResponseModel data = new LoginResponseModel();
                    data.IsFirstLogin = user.IsFirstLogin;
                    //Get Token
                    int expireToken = 5;
                    data.Token = _jwtHandler.Create(user.Id.ToString(), expireToken, user.Role);
                    data.Avatar = CommonUtils.GetDisplayImageUrl(user.Avatar);
                    data.FullName = user.FullName;
                    data.Role = user.Role.ToString();
                    data.UserId = user.Id;
                    data.Email = user.Email;

                    user.LastLogin = DateTime.UtcNow;
                    user.TotalLoginFail = 0;

                    _userRepository.Update(user);

                    return ResponseUtil.GetOKResult(data);
                }
                else
                {
                    var date = DateTime.UtcNow;
                    user.LastLoginFail = date;
                    user.TotalLoginFail++;

                    _userRepository.Update(user);

                    if (user.TotalLoginFail >= 3)
                    {
                        //TODO: Handle total login failed >= 3
                    }

                    return ResponseUtil.GetErrorResult(HttpStatusCode.NotFound, ErrorMessageCode.PASSWORD_INCORRECT);
                }
            }
            catch (Exception ex)
            {
                return ResponseUtil.GetServerErrorResult(ex.Message);
            }
        }
    }
}
