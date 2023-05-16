using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Common
{
    public class OverTimeResponeModel : OverTimeModel
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public string? UserName { get; set; }
        public string? UserAvatar { get; set; }
    }
}
