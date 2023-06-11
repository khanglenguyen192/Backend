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
        public int UserId { get; set; }
        public string? UserCode { get; set; }
        public string? Avatar { get; set; }

        public string? Email { get; set; }

        public string? FullName { get; set; }

        public string? UserName { get; set; }

        public string? Phone { get; set; }

        public Gender Gender { get; set; }

        public SalaryType SalaryType { get; set; } = SalaryType.Net;

        public string? Address { get; set; }

        public UserRole Role { get; set; }

        public string? Birthday { get; set; }

        public string? DateJoinCompany { get; set; }

        public double HourSalary { get; set; } = 0;

        public long BasicSalary { get; set; } = 0;

        public long LunchMoney { get; set; } = 0;

        public long TelephoneFee { get; set; } = 0;

        public long PetrolMoney { get; set; } = 0;

        public long HousingSupport { get; set; } = 0;

        public long ReduceYourself { get; set; } = 0;

        public long RealSalary { get; set; } = 0;

        public long SalaryPerformance { get; set; } = 0;

        public string? BankAccount { get; set; }

        public string? TimeZone { get; set; }

        public string? SkypeId { get; set; }

        public string? LinkedId { get; set; }

        public string? FacebookId { get; set; }

        public int NumberOfDenpendents { get; set; } = 0;

        public long? UserIdentity { get; set; }

        public DateTime? IdIssueDate { get; set; }

        public string? IdIssuePlace { get; set; }

        public string? IdFrontImage { get; set; }

        public string? IdBackImage { get; set; }

        public double TotalDayOffRemainInYear { get; set; }

        public double TotalDayOffInYear { get; set; }
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

        public static User Update(this User user, UpdateUserModel model)
        {
            user.Email = model.Email;
            user.FullName= model.FullName;
            user.Phone = model.Phone;
            user.Gender = model.Gender;
            user.Birthday = Convert.ToDateTime(model.Birthday);
            user.BankAccount = model.BankAccount;
            user.SkypeId = model.SkypeId;
            user.LinkedId = model.LinkedId;
            user.FacebookId = model.FacebookId;

            return user;
        }

        public static User Update(this User user, UpdateUserIdentityModel model)
        {
            user.IdIssuePlace = model.IdIssuePlace;
            user.UserIdentity = model.UserIdentity.GetValueOrDefault(0);
            user.IdIssueDate = CommonUtils.ConvertDateTime(model.IdIssueDate, Constants.DATETIME_FORMAT);

            return user;
        }
    }
}
