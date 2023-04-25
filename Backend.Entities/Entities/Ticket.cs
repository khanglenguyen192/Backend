using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Backend.Entities.EnumUtil;

namespace Backend.Entities
{
    public class Ticket : BaseEntity
    {
        public int AssignorId { get; set; }
        [ForeignKey("AssignorId")]
        public virtual User Assignor { get; set; }
        public int AssigneeId { get; set; }
        [ForeignKey("AssigneeId")]
        public virtual User Assignee { get; set; }
        //public int? ProjectId { get; set; }
        //[ForeignKey("ProjectId")]
        //public virtual Project? Project { get; set; }
        public int? DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department? Department { get; set; }
        public string? Content { get; set; }
        public TicketStatus TicketStatus { get; set; }
        public string? TeamsNoitifyId { get; set; }
    }
}
