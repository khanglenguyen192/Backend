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
        public DailyReportModel CreateDailyReport(DailyReportModel DailyReportModel, int userId)
        {
            return new DailyReportModel();
        }

        public DailyReportModel GetDailyReportById(int id)
        {
            return new DailyReportModel();
        }

        public List<DailyReportModel> GetDailyReports(int userId)
        {
            return new List<DailyReportModel> { new DailyReportModel() };
        }
    }
}
