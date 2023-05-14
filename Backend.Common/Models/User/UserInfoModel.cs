using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Backend.Entities.EnumUtil;

namespace Backend.Common
{
    public class UserInfoModel
    {
        public int Id { get; set; }
        public UserRole Role { get; set; }
        public string? FullName { get; set; }
        public string? UserCode { get; set; }

        public string? Avatar { get; set; }
        public string? Email { get; set; }

        public bool IsInterns { get; set; }
        public SpecialDayType SpecialDayType { get; set; }
        public DateTime? DayGoBack { get; set; }
        public Gender Gender { get; set; }
        public bool IsDeactive { get; set; }
        public bool IsLeader { get; set; }
        public bool IsLockedSalary { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime DateJoinCompany { get; set; }
        public string? BankAccount { get; set; }
        public int? DepartmentRole { get; set; }
    }
}
