using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Backend.Entities.EnumUtil;

namespace Backend.Common
{
    public class UpdateDepartmentUserModel
    {
        public int DepartmentId { get; set; }
        public int UserId { get; set; }
        public DepartmentRole RoleId { get; set; }
    }
}
