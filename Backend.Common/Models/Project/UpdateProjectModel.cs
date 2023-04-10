using Backend.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Backend.Entities.EnumUtil;

namespace Backend.Common
{
    public class UpdateProjectModel
    {
        public string? ProjectName { get; set; }

        public ProjectStatus Status { get; set; }

        public string? Description { get; set; }

        public string? ProjectLogo { get; set; }
        public string? CustomerName { get; set; }
    }
}
