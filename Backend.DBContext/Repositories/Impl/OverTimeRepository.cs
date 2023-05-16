using Backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DBContext
{
    public class OverTimeRepository : BaseRepository<OverTime>, IOverTimeRepository
    {
        public OverTimeRepository(IDbContextFactory contextFactory) : base(contextFactory)
        {
        }
    }
}
