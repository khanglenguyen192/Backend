using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Entities
{
    public class SystemConfig : BaseEntity
    {
        public int ExpireToken { get; set; } = 1;
        public string LoginBackground { get; set; }
        public string Logo { get; set; }
        public string AbsenceSlackId { get; set; }
        public string WorkFromHomeId { get; set; }
        public string OvertimeSlackId { get; set; }
        public string OfficeSlackId { get; set; }
        public string OfficalSlackId { get; set; }
        public string CashAdvanceSlackId { get; set; }
        public string MeetingSlackId { get; set; }
        public string DailyReportSlackId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public long TimeRemind { get; set; }
        public string BirthdayEmailTemplate { get; set; }
        public string SalaryEmailTemplate { get; set; }
        public string CelebratorEmailTemplate { get; set; }
        public string ForgotPasswordEmailTemplate { get; set; }
        public string RemindEmailTemplate { get; set; }
        public string FooterText { get; set; }
        public string FavIcon { get; set; }
        public string DocumentTitle { get; set; }
        public DateTime CelebratorDate { get; set; }
    }
}
