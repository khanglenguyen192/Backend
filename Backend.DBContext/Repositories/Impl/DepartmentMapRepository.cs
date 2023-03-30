using Backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DBContext
{
    public class DepartmentMapRepository : BaseRepository<DepartmentMap>, IDepartmentMapRepository
    {
        public DepartmentMapRepository(IDbContextFactory contextFactory) : base(contextFactory)
        {
        }
    }
}
