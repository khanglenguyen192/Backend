using Backend.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DBContext
{
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(IDbContextFactory contextFactory) : base(contextFactory)
        {
            
        }

        public IList<Department> GetRootDepartments()
        {
            using (var context = ContextFactory.CreateDbContext())
            {
                string sqlQuery = "SELECT * FROM Department AS d  ORDER BY d.Created";

                return null;
            }
        }
    }
}
