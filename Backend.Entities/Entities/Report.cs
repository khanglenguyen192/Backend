using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Backend.Entities.EnumUtil;

namespace Backend.Entities
{
    public class Report : BaseEntity
    {
        public int TicketId { get; set; }
        [ForeignKey("TicketId")]
        public virtual Ticket Ticket { get; set; }
        public string? Content { get; set; }
    }
}
