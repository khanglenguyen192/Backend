using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Backend.Entities.EnumUtil;

namespace Backend.Common
{
    public class UpdateTicketStatusModel
    {
        public int TicketId { get; set; }
        public TicketStatus TicketStatus { get; set; }
    }
}
