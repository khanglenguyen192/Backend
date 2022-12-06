using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Backend.Entities.EnumUtil;

namespace Backend.Common
{
    public class SalaryModel
    {
        public int Id { get; set; }
        public int Month { get; set; }
        public long BasicSalary { get; set; }
        public long LunchMoney { get; set; }
        public long TelephoneFee { get; set; }
        public long PetrolMoney { get; set; }
        public long HousingSupport { get; set; }
        public long ReduceYourself { get; set; }
        public long RealSalary { get; set; }//
        public long OTSalary { get; set; }
        public long HolidayBonus { get; set; }
        public long SalaryPerformance { get; set; }
        public long TotalAllowance { get; set; }
        public long TotalIncome { get; set; }
        public long BHXH { get; set; }
        public long BHYT { get; set; }
        public long BHTN { get; set; }
        public long SelfBHXH { get; set; }
        public long SelfBHYT { get; set; }
        public long SelfBHTN { get; set; }
        public long KPCD { get; set; }
        public long SalaryCalculatedForBHXHnBHYT { get; set; }
        public long SalaryCalculatedForBHTN { get; set; }
        public long TotalCP { get; set; }
        public long BHXHCompulsory { get; set; }
        public long BHYTCompulsory { get; set; }
        public long BHTNCompulsory { get; set; }
        public long TotalCompulsoryInsurance { get; set; }
        public long TotalTax { get; set; }
        public long NET { get; set; }
        public long PITExcludingRent { get; set; }
        public long TNConversionIncludingRent { get; set; }
        public long TaxableIncome { get; set; }
        public long TotalTaxableIncome { get; set; }
        public long PIT { get; set; }
        public long PITByEmployee { get; set; }
        public long CashAdvance { get; set; }
        public long PaidDayOff { get; set; }
        public bool IsApprove { get; set; }
        public double TotalOTHours { get; set; }
        public double OTRate { get; set; }
        public SalaryType SalaryType { get; set; }
        public UserInfoModel UserModel { get; set; }

        public bool IsEmptySalary { get; set; }

        public SalaryModel()
        {
            UserModel = new UserInfoModel();
        }

    }
}
