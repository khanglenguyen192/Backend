using Backend.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DBContext
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(IDbContextFactory contextFactory) : base(contextFactory)
        {

        }

        public IList<User> GetUserToAddDepartment(int departmentId)
        {
            string sql = string.Format("SELECT * FROM `User` AS u WHERE u.Id != 1 AND u.Id NOT IN (SELECT DISTINCT du.UserId FROM DepartmentUserMap AS du WHERE du.DepartmentId = {0})", departmentId);

            using (var context = ContextFactory.CreateDbContext())
            {
                return context.User.FromSqlRaw(sql).ToList();
            }
        }
    }
}
