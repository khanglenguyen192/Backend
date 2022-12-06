using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Entities
{
    public class UserChecking : BaseEntity
    {
        public DateTime CheckinTime { get; set; }
        public DateTime CheckoutTime { get; set; }

        public string CheckinNotes { get; set; }
        public string CheckoutNotes { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
