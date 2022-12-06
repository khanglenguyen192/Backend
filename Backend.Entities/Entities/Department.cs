using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Backend.Entities.EnumUtil;

namespace Backend.Entities
{
    public class Department : BaseEntity
    {
        public string DepartmentName { get; set; }

        public DepartmentStatus Status { get; set; }

        public string Description { get; set; }
        public string DepartmentLogo { get; set; }
        public int OwnerId { get; set; }
        [ForeignKey("OwnerId")]
        public virtual User Owner { get; set; }
    }
}
