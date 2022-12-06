using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Backend.Entities.EnumUtil;

namespace Backend.Common
{
    public class LoginResponseModel
    {
        public string Token { get; set; }

        public bool IsFirstLogin { get; set; }

        public string FullName { get; set; }

        public string Avatar { get; set; }
        public int UserId { get; set; }
        public string Role { get; set; }

        public string Email { get; set; }
    }
}
