using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Entities
{
    public class MeetingCompany : BaseEntity
    {
        public DateTime TimeStart { get; set; }

        public string Content { get; set; }

        public int LeaderId { get; set; }
        [ForeignKey("LeaderId")]
        public User User { get; set; }
    }
}
