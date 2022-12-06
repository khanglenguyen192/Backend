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
        DailyReportModel GetDailyReportById(int id);
        List<DailyReportModel> GetDailyReports(int userId);
        DailyReportModel CreateDailyReport(DailyReportModel DailyReportModel, int userId);
    }
}
