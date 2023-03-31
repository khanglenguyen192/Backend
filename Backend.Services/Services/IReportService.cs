using Backend.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Services
{
    public interface IReportService
    {
        TicketModel GetDailyReportById(int id);
        List<TicketModel> GetDailyReports(int userId);
        TicketModel CreateDailyReport(TicketModel DailyReportModel, int userId);
    }
}
