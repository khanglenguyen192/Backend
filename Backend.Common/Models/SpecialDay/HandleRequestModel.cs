using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Backend.Entities.EnumUtil;

namespace Backend.Common
{
    public class HandleRequestModel
    {
        public int ID { get; set; }
        public DayOffStatus DayOffStatus { get; set; }
    }
}
