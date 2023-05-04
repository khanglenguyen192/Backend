using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Entities
{
    public class TicketFile : BaseEntity
    {
        public int TicketId { get; set; }
        [ForeignKey("TicketId")]
        public Ticket Ticket { get; set; }
        public string? FileName { get; set; }
        public string? DisplayName { get; set; }
        public long Size { get; set; }
    }
}
