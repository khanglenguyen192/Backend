using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Entities
{
    public class DepartmentMap : BaseEntity
    {
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        public int ParentDepartmentId { get; set; }
        [ForeignKey("ParentDepartmentId")]
        public virtual Department ParentDepartment { get; set; }
    }
}
