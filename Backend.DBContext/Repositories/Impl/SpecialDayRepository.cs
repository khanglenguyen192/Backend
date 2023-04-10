using Backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DBContext
{
    public class SpecialDayRepository : BaseRepository<SpecialDay>, ISpecialDayRepository
    {
        public SpecialDayRepository(IDbContextFactory contextFactory) : base(contextFactory)
        {
        }
    }
}
