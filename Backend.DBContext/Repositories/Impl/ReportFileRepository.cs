using Backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DBContext.Repositories.Impl
{
    public class ReportFileRepository : BaseRepository<ReportFile>, IReportFileRepository
    {
        public ReportFileRepository(IDbContextFactory contextFactory) : base(contextFactory)
        {
        }
    }
}
