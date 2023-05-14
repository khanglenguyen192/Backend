using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Backend.Entities.EnumUtil;

namespace Backend.Common
{
    public class CreateDepartmentModel
    {
        public int? ParentId { get; set; }

        public string DepartmentName { get; set; }

        public DepartmentStatus Status { get; set; }

        public string? Description { get; set; }
    }
}
