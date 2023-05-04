using Backend.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Common
{
    public class ReportModel
    {
        public int TicketId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
    }
}
