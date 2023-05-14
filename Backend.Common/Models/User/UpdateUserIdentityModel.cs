using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Common
{
    public class UpdateUserIdentityModel
    {
        public long? UserIdentity { get; set; }

        public DateTime? IdIssueDate { get; set; }

        public string? IdIssuePlace { get; set; }

        public string? IdFrontImage { get; set; }

        public string? IdBackImage { get; set; }
    }
}
