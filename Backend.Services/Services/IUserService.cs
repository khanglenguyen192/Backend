using Backend.Common;
using Backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Services
{
    public interface IUserService
    {
        User GetUserById(int id);

        ResponseModel LoginUser(LoginModel loginModel);
    }
}
