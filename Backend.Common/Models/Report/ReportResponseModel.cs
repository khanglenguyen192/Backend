using Backend.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Common
{
    public class ReportResponseModel
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }
        public List<ReportFile>? ReportFiles { get; set; }
    }
}
