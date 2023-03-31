using Backend.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Backend.Entities.EnumUtil;

namespace Backend.Common
{
    public class UserApiModel
    {
        [JsonProperty(PropertyName = "userid")]
        public int UserId { get; set; }
        [JsonProperty(PropertyName = "usercode")]
        public string? UserCode { get; set; }
        [JsonProperty(PropertyName = "avatar")]
        public string? Avatar { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string? Email { get; set; }

        [JsonProperty(PropertyName = "fullname")]
        public string? FullName { get; set; }

        [JsonProperty(PropertyName = "username")]
        public string? UserName { get; set; }

        [JsonProperty(PropertyName = "phone")]
        public string? Phone { get; set; }

        [JsonProperty(PropertyName = "gender")]
        public Gender Gender { get; set; }

        [JsonProperty(PropertyName = "salaryType")]
        public SalaryType SalaryType { get; set; }

        [JsonProperty(PropertyName = "address")]
        public string? Address { get; set; }

        [JsonProperty(PropertyName = "role")]
        public UserRole Role { get; set; }

        [JsonProperty(PropertyName = "isinterns")]
        public bool IsInterns { get; set; }

        [JsonProperty(PropertyName = "birthday")]
        public string? Birthday { get; set; }

        [JsonProperty(PropertyName = "dateJoincompany")]
        public string? DateJoinCompany { get; set; }

        [JsonProperty(PropertyName = "hoursalary")]
        public double HourSalary { get; set; }

        [JsonProperty(PropertyName = "basicsalary")]
        public long BasicSalary { get; set; }

        [JsonProperty(PropertyName = "lunchmoney")]
        public long LunchMoney { get; set; }

        [JsonProperty(PropertyName = "telephonefee")]
        public long TelephoneFee { get; set; }

        [JsonProperty(PropertyName = "petrolmoney")]
        public long PetrolMoney { get; set; }

        [JsonProperty(PropertyName = "housingsupport")]
        public long HousingSupport { get; set; }

        [JsonProperty(PropertyName = "reduceyourself")]
        public long ReduceYourself { get; set; }

        [JsonProperty(PropertyName = "realsalary")]
        public long RealSalary { get; set; }

        [JsonProperty(PropertyName = "salaryperformance")]
        public long SalaryPerformance { get; set; }

        [JsonProperty(PropertyName = "bankAccount")]
        public string? BankAccount { get; set; }

        [JsonProperty(PropertyName = "timeZone")]
        public string? TimeZone { get; set; }

        [JsonProperty(PropertyName = "skypeId")]
        public string? SkypeId { get; set; }

        [JsonProperty(PropertyName = "linkedId")]
        public string? LinkedId { get; set; }

        [JsonProperty(PropertyName = "facebookId")]
        public string? FacebookId { get; set; }


        [JsonProperty(PropertyName = "isavatardelete")]
        public bool IsAvatarDelete { get; set; }

        [JsonProperty(PropertyName = "numberOfDenpendents")]
        public int NumberOfDenpendents { get; set; }

    }

    public static class UserModelEmm
    {
        public static User ToEntity(this UserApiModel model, User entity, UserRole role, bool isSelfProfile = false)
        {
            if (entity == null)
                entity = new User();

            if (entity.Id == 0 || (isSelfProfile && role == UserRole.Administrator))
            {
                entity.UserCode = model.UserCode;
                entity.FullName = model.FullName;
                entity.UserName = model.UserName;
                entity.Email = model.Email;
                entity.Phone = model.Phone;
                entity.Gender = model.Gender;
                entity.SalaryType = model.SalaryType;
                entity.Address = model.Address;
                entity.Birthday = CommonUtils.ConvertDateTime(model.Birthday, Constants.DATETIME_FORMAT);
                entity.BankAccount = model.BankAccount;
                entity.Role = model.Role;
                entity.BasicSalary = model.BasicSalary;
                entity.HourSalary = model.HourSalary;
                entity.LunchMoney = model.LunchMoney;
                entity.TelephoneFee = model.TelephoneFee;
                entity.PetrolMoney = model.PetrolMoney;
                entity.HousingSupport = model.HousingSupport;
                entity.ReduceYourself = model.ReduceYourself;
                entity.TimeZone = model.TimeZone;
                entity.FacebookId = model.FacebookId;
                entity.SkypeId = model.SkypeId;
                entity.LinkedId = model.LinkedId;
                if (string.IsNullOrWhiteSpace(model.DateJoinCompany))
                    entity.DateJoinCompany = DateTime.UtcNow;
                else
                    entity.DateJoinCompany = CommonUtils.ConvertDateTime(model.DateJoinCompany, Constants.DATETIME_FORMAT);
            }
            else
            {
                if (role != UserRole.Administrator)
                {

                    entity.UserName = model.UserName;
                    entity.Phone = model.Phone;
                    entity.FullName = model.FullName;
                    entity.Birthday = CommonUtils.ConvertDateTime(model.Birthday, Constants.DATETIME_FORMAT);
                    entity.Address = model.Address;
                    entity.Email = model.Email;
                    entity.BankAccount = model.BankAccount;
                    entity.Gender = model.Gender;
                    entity.TimeZone = model.TimeZone;
                    entity.FacebookId = model.FacebookId;
                    entity.SkypeId = model.SkypeId;
                    entity.LinkedId = model.LinkedId;
                    entity.SalaryType = model.SalaryType;
                    entity.BankAccount = model.BankAccount;
                    entity.DateJoinCompany = CommonUtils.ConvertDateTime(model.DateJoinCompany, Constants.DATETIME_FORMAT);
                }
                else
                {
                    entity.UserCode = model.UserCode;
                    entity.Role = model.Role;
                    entity.BasicSalary = model.BasicSalary;
                    entity.TelephoneFee = model.TelephoneFee;
                    entity.HousingSupport = model.HousingSupport;
                    entity.HourSalary = model.HourSalary;
                    entity.LunchMoney = model.LunchMoney;
                    entity.PetrolMoney = model.PetrolMoney;
                    entity.ReduceYourself = model.ReduceYourself;
                    entity.SalaryType = model.SalaryType;
                    if (!string.IsNullOrWhiteSpace(model.DateJoinCompany))
                        entity.DateJoinCompany = CommonUtils.ConvertDateTime(model.DateJoinCompany, Constants.DATETIME_FORMAT);

                    entity.NumberOfDenpendents = model.NumberOfDenpendents;
                }
            }

            return entity;
        }
    }
}
