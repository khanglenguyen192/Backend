using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Common
{
    public class UpdateReportModel
    {
        public int ReportId { get; set; }
        public int TicketId { get; set; }
        public string? Content { get; set; }
    }
}
