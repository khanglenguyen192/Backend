using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Backend.Entities.EnumUtil;

namespace Backend.Entities
{
    public class NotifyMessage : BaseEntity
    {
        public string? Message { get; set; }
        public string? Title { get; set; }
        public string? Link { get; set; }
        public bool IsRead { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public AlertGroups AlertGroups { get; set; }
    }
}
