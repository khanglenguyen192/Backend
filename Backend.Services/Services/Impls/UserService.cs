using Backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Services
{
    public class UserService : IUserService
    {
        public async Task<User> GetUserById(int id)
        {
            return new User();
        }
    }
}
