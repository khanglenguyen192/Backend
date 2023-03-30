using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Common.Models.Project
{
    public class AddProjectUsersModel
    {
        public int ProjectId { get; set; }
        public List<int>? UserIds { get; set; }
        public int? LeaderId { get; set; }
    }
}
