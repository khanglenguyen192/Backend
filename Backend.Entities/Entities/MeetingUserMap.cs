using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Backend.Entities.EnumUtil;

namespace Backend.Entities
{
    public class MeetingUserMap : BaseEntity
    {
        public MeetingUserMap()
        {
        }

        public int MeetingId { get; set; }

        [ForeignKey("MeetingId")]
        public MeetingCompany MeetingCompany { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public MeetingStatus Status { get; set; }

        public MeetingUserMap(int meetingId, int userId)
        {
            MeetingId = meetingId;
            UserId = userId;
            Status = MeetingStatus.Waiting;
        }
    }
}
