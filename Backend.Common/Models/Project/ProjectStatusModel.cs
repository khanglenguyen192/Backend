using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Backend.Entities.EnumUtil;

namespace Backend.Common
{
    public class ProjectStatusModel
    {
        public int ProjectId { get; set; }
        public ProjectStatus ProjectStatus { get; set; }
    }
}
