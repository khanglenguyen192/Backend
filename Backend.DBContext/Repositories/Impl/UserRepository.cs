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

        public IList<User> GetUserNotInDepartment()
        {

            using (var context = ContextFactory.CreateDbContext())
            {
                //string sql = string.Format("SELECT * FROM `User` AS u WHERE u.Id != 1 AND u.Id NOT IN (SELECT DISTINCT du.UserId FROM DepartmentUserMap AS du WHERE du.DepartmentId = {0})", departmentId);

                //return context.User.FromSqlRaw(sql).ToList();

                var query = from user in context.Set<User>()
                            join d_user in context.Set<DepartmentUserMap>() on user.Id equals d_user.UserId 
                            into map 
                            from r in map.DefaultIfEmpty()
                            select new
                            {
                                User = user,
                                DepartmentUserMap = r
                            };

                var result =  query.Where(u => u.DepartmentUserMap == null 
                                            && u.User.Role != EnumUtil.UserRole.Administrator)
                    .Select(u => u.User).ToList();

                return result;
            }
        }
    }
}
