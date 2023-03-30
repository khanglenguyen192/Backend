using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Common.Models.Department
{
    public class AddDepartmentUserModel
    {
        public int DepartmentId { get; set; }
        public List<UserMapDepartmentModel> Users { get; set; }
    }
}
