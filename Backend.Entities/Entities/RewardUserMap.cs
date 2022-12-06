using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Backend.Entities.EnumUtil;

namespace Backend.Entities
{
    public class RewardUserMap : BaseEntity
    {
        public long Value { get; set; }

        public RewardStatus RewardStatus { get; set; }

        public bool IsPaid { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public int RewardId { get; set; }
        [ForeignKey("RewardId")]
        public virtual Reward Reward { get; set; }
    }
}
