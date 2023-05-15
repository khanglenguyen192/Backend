using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Backend.Entities.EnumUtil;

namespace Backend.Common
{
    public class OverTimeModel
    {
        public DateTime TimeStart { get; set; }
        public DateTime TimeFinish { get; set; }
        public double WorkTime { get; set; }
        public string? Description { get; set; }
        public int UserId { get; set; }
    }
}
