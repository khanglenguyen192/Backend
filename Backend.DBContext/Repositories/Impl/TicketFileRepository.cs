using Backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DBContext
{
    public class TicketFileRepository : BaseRepository<TicketFile>, ITicketFileRepository
    {
        public TicketFileRepository(IDbContextFactory contextFactory) : base(contextFactory)
        {
        }
    }
}
