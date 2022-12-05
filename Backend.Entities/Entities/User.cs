using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Backend.Entities.EnumUtil;

namespace Backend.Entities
{
    public class User : BaseEntity
    {
        private SalaryType _salaryType;

        public String UserCode { get; set; }
        public string UserName { get; set; }
        public string PassCode { get; set; }
        public string Salt { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsFirstLogin { get; set; }
        public UserRole Role { get;set; }
        public bool IsHardCode { get; set; }
        public string FullName { get; set; }
        public Gender Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string Avatar { get; set; }
        public string Address { get; set; }
        public DateTime DateJoinCompany { get; set; }
        public DateTime DateStartContract { get; set; }

        public double HourSalary { get; set; }
        public long BasicSalary { get; set; }
        public long LunchMoney { get; set; }
        public long TelephoneFee { get; set; }
        public long PetrolMoney { get; set; }
        public long HousingSupport { get; set; }
        public long ReduceYourself { get; set; }
        public long SalaryCalculatedForBHXHnBHYT { get; set; }
        public long SalaryCalculatedForBHTN { get; set; }
        public long TotalTaxableIncome { get; set; }
        public SalaryType SalaryType
        {
            get
            {
                if (_salaryType == 0)
                {
                    return SalaryType.Net;
                }

                return _salaryType;
            }
            set
            {
                _salaryType = value;
            }
        }

        public string SlackId { get; set; }
        public string BankAccount { get; set; }

        public bool IsChangingPassword { get; set; }
        public DateTime LastLogin { get; set; }
        public int TotalLoginFail { get; set; }
        public DateTime LastLoginFail { get; set; }
        public string TimeZone { get; set; }

        public string SkypeId { get; set; }
        public string LinkedId { get; set; }
        public string FacebookId { get; set; }

        public long UserIdentity { get; set; }
        public DateTime IdIssueDate { get; set; }
        public string IdIssuePlace { get; set; }
        public string IdFrontImage { get; set; }
        public string IdBackImage { get; set; }

        public double TotalDayOffRemainInYear { get; set; }
        public double TotalDayOffInYear { get; set; }

        public int NumberOfDenpendents { get; set; }
    }
}
