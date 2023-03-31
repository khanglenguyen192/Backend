using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Common
{
    public class UpdateTicketAssigneeModel
    {
        public int TicketId { get; set; }

        public int AssigneeId { get; set; }
    }
}
