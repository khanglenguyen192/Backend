using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Entities
{
    public class Salary : BaseEntity
    {
        public DateTime? Month { get; set; }
        public long BasicSalary { get; set; }
        public long LunchMoney { get; set; }
        public long TelephoneFee { get; set; }
        public long PetrolMoney { get; set; }
        public long HousingSupport { get; set; }
        public long ReduceYourself { get; set; }
        public long RealSalary { get; set; }
        public long OTSalary { get; set; }
        public long HolidayBonus { get; set; }
        public long SalaryPerformance { get; set; }
        public long TotalAllowance { get; set; }
        public long TotalIncome { get; set; }
        public long SalaryCalculatedForBHXHnBHYT { get; set; }
        public long SalaryCalculatedForBHTN { get; set; }
        public long BHXH { get; set; }
        public long BHYT { get; set; }
        public long BHTN { get; set; }
        public long SelfBHXH { get; set; }
        public long SelfBHYT { get; set; }
        public long SelfBHTN { get; set; }
        public long KPCD { get; set; }
        public long TotalCP { get; set; }
        public long BHXHCompulsory { get; set; }
        public long BHYTCompulsory { get; set; }
        public long BHTNCompulsory { get; set; }
        public long TotalCompulsoryInsurance { get; set; }
        public long Tax { get; set; }
        public long PITExcludingRent { get; set; }
        public long TNConversionIncludingRent { get; set; }
        public long TaxableIncome { get; set; }
        public long PIT { get; set; }
        public long PITByEmployee { get; set; }
        public long PaidDayOff { get; set; }
        public long CashAdvance { get; set; }
        public long TotalTax { get; set; }
        public long TotalTaxableIncome { get; set; }
        public bool IsApprove { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
