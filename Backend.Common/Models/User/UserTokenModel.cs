using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Backend.Entities.EnumUtil;

namespace Backend.Common.Models.User
{
    public class UserTokenModel
    {
        public int UserId { get; set; }
        public UserRole UserRole { get; set; }
        public TimeZoneInfo TimeZoneInfo { get; set; }
        public string FullName { get; set; }
    }
}
