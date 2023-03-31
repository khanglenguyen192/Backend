using Backend.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Services
{
    public class ReportService : IReportService
    {
        public TicketModel CreateDailyReport(TicketModel DailyReportModel, int userId)
        {
            return new TicketModel();
        }

        public TicketModel GetDailyReportById(int id)
        {
            return new TicketModel();
        }

        public List<TicketModel> GetDailyReports(int userId)
        {
            return new List<TicketModel> { new TicketModel() };
        }
    }
}
