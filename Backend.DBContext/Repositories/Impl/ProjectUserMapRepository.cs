using Backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DBContext
{
    public class ProjectUserMapRepository : BaseRepository<ProjectUserMap>, IProjectUserMapRepository
    {
        public ProjectUserMapRepository(IDbContextFactory contextFactory) : base(contextFactory)
        {
        }
    }
}
