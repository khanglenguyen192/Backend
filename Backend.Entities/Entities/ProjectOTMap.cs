using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Entities
{
    public class ProjectOTMap : BaseEntity
    {
        public int OverTimeId { get; set; }
        [ForeignKey("OverTimeId")]
        public virtual OverTime OverTime { get; set; }

        public int ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        public virtual Project Project { get; set; }
    }
}
