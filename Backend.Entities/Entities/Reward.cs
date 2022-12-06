using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Backend.Entities.EnumUtil;

namespace Backend.Entities
{
    public class Reward : BaseEntity
    {
        public string? Template { get; set; }

        public string? Subject { get; set; }

        public RewardStatus Status { get; set; }
    }
}
