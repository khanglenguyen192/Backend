using Backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DBContext
{
    public interface IUserRepository : IBaseRepository<User>
    {
        IList<User> GetUserToAddDepartment(int departmentId);
    }
}
