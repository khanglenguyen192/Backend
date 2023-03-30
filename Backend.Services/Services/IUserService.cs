using Backend.Common;
using Backend.Common.Models.User;
using Backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Backend.Entities.EnumUtil;

namespace Backend.Services
{
    public interface IUserService
    {
        User GetUserById(int id);

        ResponseModel LoginUser(LoginModel loginModel);

        ResponseModel CreateUser(UserApiModel model, UserRole userRole);
    }
}
