using Backend.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Backend.Entities.EnumUtil;

namespace Backend.Common
{
    public class TicketModel
    {
        public int Id { get; set; }

        public int AssignorId { get; set; }

        public int AssigneeId { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

        public string? Content { get; set; }

        public TicketStatus TicketStatus { get; set; }

        public int ProjectId { get; set; }

        public IList<TicketFile>? TicketFiles { get; set; }
    }
}
