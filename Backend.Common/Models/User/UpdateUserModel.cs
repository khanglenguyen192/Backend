using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Backend.Entities.EnumUtil;

namespace Backend.Common
{
    public class UpdateUserModel
    {
        public string? Avatar { get; set; }

        public string? Email { get; set; }

        public string? FullName { get; set; }

        public string? Phone { get; set; }

        public Gender Gender { get; set; }        

        public string? Birthday { get; set; }

        public string? BankAccount { get; set; }

        public string? SkypeId { get; set; }

        public string? LinkedId { get; set; }

        public string? FacebookId { get; set; }
    }
}
