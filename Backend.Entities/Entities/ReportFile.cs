using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Entities
{
    public class ReportFile : BaseEntity
    {
        public int ReportId { get; set; }
        [ForeignKey("TicketId")]
        public Report Report { get; set; }
        public string? FileName { get; set; }
        public string? DisplayName { get; set; }
    }
}
