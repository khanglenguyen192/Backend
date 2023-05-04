using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Backend.Entities.EnumUtil;

namespace Backend.Common
{
    public class SearchTicketModel : PagingModel
    {
        public int? AssignorId { get; set; }

        public int? AssigneeId { get; set; }

        public TicketStatus? TicketStatus { get; set; }

        public int? ProjectId { get; set; }

        public int? DepartmentId { get; set; }
    }
}
