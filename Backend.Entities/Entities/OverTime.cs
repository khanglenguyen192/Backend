using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Backend.Entities.EnumUtil;

namespace Backend.Entities
{
    public class OverTime : BaseEntity
    {
        public DateTime TimeStart { get; set; }
        public DateTime TimeFinish { get; set; }
        public double WorkTime { get; set; }
        public double WorkTimeWithRate { get; set; }
        public string Description { get; set; }
        public DateTime? Month { get; set; }
        public int UserId { get; set; }
        public OvertimeRateType OvertimeRateType { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
