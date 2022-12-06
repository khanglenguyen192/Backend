using Backend.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public DbSet<DailyReport> DailyReport { get; set; }
    }
}
