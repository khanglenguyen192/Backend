using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Backend.Entities.EnumUtil;

namespace Backend.Entities
{
    public class CashAdvance : BaseEntity
    {
        public DateTime? Month { get; set; }

        public long Cash { get; set; }

        public string Reason { get; set; }

        public CashAdvanceStatus Status { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
