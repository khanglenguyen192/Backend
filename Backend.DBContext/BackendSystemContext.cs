using Backend.Common;
using Backend.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Backend.Entities.EnumUtil;

namespace Backend.DBContext
{
    public class BackendSystemContext : DbContext
    {
        public BackendSystemContext(DbContextOptions options) : base(options)
        { 
        }

        public DbSet<User> User { get; set; }
        public DbSet<CurrencyExchange> CurrencyExchange { get; set; }
        public DbSet<SpecialDay> SpecialDay { get; set; }
        public DbSet<OverTime> OverTime { get; set; }
        public DbSet<RateOvertime> RateOvertime { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<ProjectUserMap> ProjectUserMap { get; set; }
        public DbSet<Salary> Salary { get; set; }
        public DbSet<SystemConfig> SystemConfig { get; set; }
        public DbSet<HardCode> HardCode { get; set; }
        public DbSet<ProjectOTMap> ProjectOTMap { get; set; }
        public DbSet<NotifyMessage> NotifyMessage { get; set; }
        public DbSet<CashAdvance> CashAdvance { get; set; }
        public DbSet<CompanyEvent> CompanyEvent { get; set; }
        public DbSet<Reward> Reward { get; set; }
        public DbSet<RewardUserMap> RewardUserMap { get; set; }
        public DbSet<MeetingCompany> MeetingCompany { get; set; }
        public DbSet<MeetingUserMap> MeetingUserMap { get; set; }
        public DbSet<FilePolicy> FilePolicy { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<DepartmentUserMap> DepartmentUserMap { get; set; }
        public DbSet<DepartmentMap> DepartmentMap { get; set; }
        public DbSet<UserChecking> UserChecking { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<Report> Report { get; set; }
        public DbSet<ReportFile> ReportFile { get; set; }
        public DbSet<TicketFile> TicketFile { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SpecialDay>()
            .HasOne(i => i.User)
            .WithMany()
            .OnDelete(DeleteBehavior.Cascade);

            #region root user
            var salt = new Guid().ToString();
            modelBuilder.Entity<User>().HasData(new User { Id = 1, UserName = "Administrator", Email = "root@gmail.com", FullName = "Lê Nguyên Khang", Birthday = DateTime.UtcNow, Salt = salt, PassCode = CommonUtils.GeneratePasscode("123456x@X", salt), Gender = Gender.Other, Role = UserRole.Administrator, Phone = "0349560351", IsDeactivate = false, IsFirstLogin = false, IsHardCode = true, SlackId = "BK2N33T8B/9lHXv9Ml0hKdjqgR0jPYcuqs" });
            #endregion

            #region HardCode
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = 1, Name = "UserRole", Created = DateTime.UtcNow, ParentId = string.Empty, Value = 0 });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = 2, Name = "Administrator", Created = DateTime.UtcNow, ParentId = "UserRole", Value = (int)UserRole.Administrator });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = 4, Name = "Manager", Created = DateTime.UtcNow, ParentId = "UserRole", Value = (int)UserRole.Manager });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = 5, Name = "Employee", Created = DateTime.UtcNow, ParentId = "UserRole", Value = (int)UserRole.Employee });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = 6, Name = "Interns", Created = DateTime.UtcNow, ParentId = "UserRole", Value = (int)UserRole.Interns });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = 7, Name = "Probationer", Created = DateTime.UtcNow, ParentId = "UserRole", Value = (int)UserRole.Probationer });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = 8, Name = "Collaborators", Created = DateTime.UtcNow, ParentId = "UserRole", Value = (int)UserRole.Collaborators });

            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = 20, Name = "Gender", Created = DateTime.UtcNow, ParentId = string.Empty, Value = 0 });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = 21, Name = "Nam", Created = DateTime.UtcNow, ParentId = "Gender", Value = (int)Gender.Male });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = 22, Name = "Nữ", Created = DateTime.UtcNow, ParentId = "Gender", Value = (int)Gender.Female });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = 23, Name = "Khác", Created = DateTime.UtcNow, ParentId = "Gender", Value = (int)Gender.Other });

            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = 41, Name = "DayOffOption", Created = DateTime.UtcNow, ParentId = string.Empty, Value = 0 });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = 42, Name = "Cả ngày", Created = DateTime.UtcNow, ParentId = "DayOffOption", Value = (int)DayOffOption.FullDay });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = 43, Name = "Sáng", Created = DateTime.UtcNow, ParentId = "DayOffOption", Value = (int)DayOffOption.Morning });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = 44, Name = "Chiều", Created = DateTime.UtcNow, ParentId = "DayOffOption", Value = (int)DayOffOption.Afternoon });

            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = 45, Name = "ProjectStatus", Created = DateTime.UtcNow, ParentId = string.Empty, Value = 0 });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = 47, Name = "Đang hoạt động", Created = DateTime.UtcNow, ParentId = "ProjectStatus", Value = (int)ProjectStatus.Working });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = 48, Name = "Tạm dừng", Created = DateTime.UtcNow, ParentId = "ProjectStatus", Value = (int)ProjectStatus.Pending });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = 49, Name = "Đã hoàn thành", Created = DateTime.UtcNow, ParentId = "ProjectStatus", Value = (int)ProjectStatus.Finish });

            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = 50, Name = "HolidayType", Created = DateTime.UtcNow, ParentId = string.Empty, Value = 0 });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = 51, Name = "Ngày nghỉ cố định", Created = DateTime.UtcNow, ParentId = "HolidayType", Value = (int)HolidayType.Default });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = 52, Name = "Ngày nghỉ không cố định", Created = DateTime.UtcNow, ParentId = "HolidayType", Value = (int)HolidayType.NoneDefault });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = 53, Name = "Ngày nghỉ do công ty quy định", Created = DateTime.UtcNow, ParentId = "HolidayType", Value = (int)HolidayType.Company });

            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = 54, Name = "OvertimeRateType", Created = DateTime.UtcNow, ParentId = string.Empty, Value = 0 });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = 55, Name = "x2", Created = DateTime.UtcNow, ParentId = "OvertimeRateType", Value = (int)OvertimeRateType.X2 });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = 56, Name = "x3", Created = DateTime.UtcNow, ParentId = "OvertimeRateType", Value = (int)OvertimeRateType.X3 });

            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = 57, Name = "SalaryType", Created = DateTime.UtcNow, ParentId = string.Empty, Value = 0 });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = 58, Name = "NET", Created = DateTime.UtcNow, ParentId = "SalaryType", Value = (int)SalaryType.Net });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = 59, Name = "GROSS", Created = DateTime.UtcNow, ParentId = "SalaryType", Value = (int)SalaryType.Gross });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = 60, Name = "PARTTIME", Created = DateTime.UtcNow, ParentId = "SalaryType", Value = (int)SalaryType.Parttime });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = 61, Name = "PROBATION", Created = DateTime.UtcNow, ParentId = "SalaryType", Value = (int)SalaryType.Probation });


            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = 62, Name = "AlertGroups", Created = DateTime.UtcNow, ParentId = string.Empty, Value = 0 });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = 63, Name = "Tất cả", Created = DateTime.UtcNow, ParentId = "AlertGroups", Value = (int)AlertGroups.All });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = 64, Name = "Đã đọc", Created = DateTime.UtcNow, ParentId = "AlertGroups", Value = (int)AlertGroups.AllRead });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = 65, Name = "Chưa đọc", Created = DateTime.UtcNow, ParentId = "AlertGroups", Value = (int)AlertGroups.AllUnread });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = 66, Name = "Tài khoản", Created = DateTime.UtcNow, ParentId = "AlertGroups", Value = (int)AlertGroups.Account });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = 67, Name = "Ngày nghỉ", Created = DateTime.UtcNow, ParentId = "AlertGroups", Value = (int)AlertGroups.DayOff });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = 68, Name = "Tin nhắn", Created = DateTime.UtcNow, ParentId = "AlertGroups", Value = (int)AlertGroups.Message });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = 69, Name = "Làm thêm giờ", Created = DateTime.UtcNow, ParentId = "AlertGroups", Value = (int)AlertGroups.OverTime });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = 70, Name = "Dự án", Created = DateTime.UtcNow, ParentId = "AlertGroups", Value = (int)AlertGroups.Project });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = 71, Name = "Sinh nhật", Created = DateTime.UtcNow, ParentId = "AlertGroups", Value = (int)AlertGroups.Birthday });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = 72, Name = "Ứng lương", Created = DateTime.UtcNow, ParentId = "AlertGroups", Value = (int)AlertGroups.CashAdvance });

            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = 73, Name = "DepartmentStatus", Created = DateTime.UtcNow, ParentId = string.Empty, Value = 0 });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = 74, Name = "Đang hoạt động", Created = DateTime.UtcNow, ParentId = "DepartmentStatus", Value = (int)DepartmentStatus.Activate });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = 75, Name = "Dừng hoạt động", Created = DateTime.UtcNow, ParentId = "DepartmentStatus", Value = (int)DepartmentStatus.Deactivate });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = 76, Name = "Sớm ra mắt", Created = DateTime.UtcNow, ParentId = "DepartmentStatus", Value = (int)DepartmentStatus.ComingSoon });

            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = 85, Name = "SpecialDayOff", Created = DateTime.UtcNow, ParentId = string.Empty, Value = 0 });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = 86, Name = "Kết hôn", Created = DateTime.UtcNow, ParentId = "SpecialDayOff", Value = (int)SpecialDayOff.Marriage });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = 87, Name = "Con đẻ, con nuôi kết hôn", Created = DateTime.UtcNow, ParentId = "SpecialDayOff", Value = (int)SpecialDayOff.ChildrenMarriage });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = 88, Name = "Nghỉ sinh con", Created = DateTime.UtcNow, ParentId = "SpecialDayOff", Value = (int)SpecialDayOff.Childbirth });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = 89, Name = "Nghỉ để tang", Created = DateTime.UtcNow, ParentId = "SpecialDayOff", Value = (int)SpecialDayOff.Mourn });

            #endregion

            #region role
            modelBuilder.Entity<Role>().HasData(new Role { Id = 1, Created = DateTime.UtcNow, RoleName = "Administrator" });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 2, Created = DateTime.UtcNow, RoleName = "Manager" });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 3, Created = DateTime.UtcNow, RoleName = "Employee" });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 4, Created = DateTime.UtcNow, RoleName = "Probationer" });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 5, Created = DateTime.UtcNow, RoleName = "Interns" });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 6, Created = DateTime.UtcNow, RoleName = "Collaborators" });
            #endregion

        }
    }
}
