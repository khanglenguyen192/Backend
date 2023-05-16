using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.DBContext.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CurrencyExchange",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Rate = table.Column<long>(type: "bigint", nullable: false),
                    IsDeactivate = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyExchange", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FilePolicy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Content = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDirectory = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    IsDeactivate = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilePolicy", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "HardCode",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ParentId = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<int>(type: "int", nullable: false),
                    IsDeactivate = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HardCode", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RateOvertime",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Rate = table.Column<float>(type: "float", nullable: false),
                    IsDeactivate = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RateOvertime", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Reward",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Template = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Subject = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IsDeactivate = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reward", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeactivate = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SystemConfig",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ExpireToken = table.Column<int>(type: "int", nullable: false),
                    LoginBackground = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Logo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AbsenceSlackId = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WorkFromHomeId = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OvertimeSlackId = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OfficeSlackId = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OfficalSlackId = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CashAdvanceSlackId = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MeetingSlackId = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DailyReportSlackId = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Port = table.Column<int>(type: "int", nullable: false),
                    TimeRemind = table.Column<long>(type: "bigint", nullable: false),
                    BirthdayEmailTemplate = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SalaryEmailTemplate = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CelebratorEmailTemplate = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ForgotPasswordEmailTemplate = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RemindEmailTemplate = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FooterText = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FavIcon = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DocumentTitle = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CelebratorDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsDeactivate = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemConfig", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserCode = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PassCode = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Salt = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsFirstLogin = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    IsHardCode = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    FullName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Avatar = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateJoinCompany = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DateStartContract = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    HourSalary = table.Column<double>(type: "double", nullable: false),
                    BasicSalary = table.Column<long>(type: "bigint", nullable: false),
                    LunchMoney = table.Column<long>(type: "bigint", nullable: false),
                    TelephoneFee = table.Column<long>(type: "bigint", nullable: false),
                    PetrolMoney = table.Column<long>(type: "bigint", nullable: false),
                    HousingSupport = table.Column<long>(type: "bigint", nullable: false),
                    ReduceYourself = table.Column<long>(type: "bigint", nullable: false),
                    SalaryCalculatedForBHXHnBHYT = table.Column<long>(type: "bigint", nullable: false),
                    SalaryCalculatedForBHTN = table.Column<long>(type: "bigint", nullable: false),
                    TotalTaxableIncome = table.Column<long>(type: "bigint", nullable: false),
                    SalaryType = table.Column<int>(type: "int", nullable: false),
                    SlackId = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BankAccount = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsChangingPassword = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LastLogin = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TotalLoginFail = table.Column<int>(type: "int", nullable: false),
                    LastLoginFail = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TimeZone = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SkypeId = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LinkedId = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FacebookId = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserIdentity = table.Column<long>(type: "bigint", nullable: false),
                    IdIssueDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IdIssuePlace = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdFrontImage = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdBackImage = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TotalDayOffRemainInYear = table.Column<double>(type: "double", nullable: false),
                    TotalDayOffInYear = table.Column<double>(type: "double", nullable: false),
                    NumberOfDenpendents = table.Column<int>(type: "int", nullable: false),
                    IsDeactivate = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CashAdvance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Month = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Cash = table.Column<long>(type: "bigint", nullable: false),
                    Reason = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsDeactivate = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashAdvance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CashAdvance_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CompanyEvent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TimeStart = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EventType = table.Column<int>(type: "int", nullable: false),
                    TargetObject = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsDeactivate = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyEvent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyEvent_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DepartmentName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DepartmentLogo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OwnerId = table.Column<int>(type: "int", nullable: true),
                    IsRoot = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsDeactivate = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Department_User_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "User",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MeetingCompany",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TimeStart = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Content = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LeaderId = table.Column<int>(type: "int", nullable: false),
                    IsDeactivate = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingCompany", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeetingCompany_User_LeaderId",
                        column: x => x.LeaderId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "NotifyMessage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Message = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Title = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Link = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsRead = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AlertGroups = table.Column<int>(type: "int", nullable: false),
                    IsDeactivate = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotifyMessage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotifyMessage_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OverTime",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TimeStart = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TimeFinish = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    WorkTime = table.Column<double>(type: "double", nullable: false),
                    WorkTimeWithRate = table.Column<double>(type: "double", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Month = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OvertimeRateType = table.Column<int>(type: "int", nullable: false),
                    IsDeactivate = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OverTime", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OverTime_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProjectName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProjectLogo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeactivate = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Project_User_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RewardUserMap",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<long>(type: "bigint", nullable: false),
                    RewardStatus = table.Column<int>(type: "int", nullable: false),
                    IsPaid = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RewardId = table.Column<int>(type: "int", nullable: false),
                    IsDeactivate = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RewardUserMap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RewardUserMap_Reward_RewardId",
                        column: x => x.RewardId,
                        principalTable: "Reward",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RewardUserMap_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Salary",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Month = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    BasicSalary = table.Column<long>(type: "bigint", nullable: false),
                    LunchMoney = table.Column<long>(type: "bigint", nullable: false),
                    TelephoneFee = table.Column<long>(type: "bigint", nullable: false),
                    PetrolMoney = table.Column<long>(type: "bigint", nullable: false),
                    HousingSupport = table.Column<long>(type: "bigint", nullable: false),
                    ReduceYourself = table.Column<long>(type: "bigint", nullable: false),
                    RealSalary = table.Column<long>(type: "bigint", nullable: false),
                    OTSalary = table.Column<long>(type: "bigint", nullable: false),
                    HolidayBonus = table.Column<long>(type: "bigint", nullable: false),
                    SalaryPerformance = table.Column<long>(type: "bigint", nullable: false),
                    TotalAllowance = table.Column<long>(type: "bigint", nullable: false),
                    TotalIncome = table.Column<long>(type: "bigint", nullable: false),
                    SalaryCalculatedForBHXHnBHYT = table.Column<long>(type: "bigint", nullable: false),
                    SalaryCalculatedForBHTN = table.Column<long>(type: "bigint", nullable: false),
                    BHXH = table.Column<long>(type: "bigint", nullable: false),
                    BHYT = table.Column<long>(type: "bigint", nullable: false),
                    BHTN = table.Column<long>(type: "bigint", nullable: false),
                    SelfBHXH = table.Column<long>(type: "bigint", nullable: false),
                    SelfBHYT = table.Column<long>(type: "bigint", nullable: false),
                    SelfBHTN = table.Column<long>(type: "bigint", nullable: false),
                    KPCD = table.Column<long>(type: "bigint", nullable: false),
                    TotalCP = table.Column<long>(type: "bigint", nullable: false),
                    BHXHCompulsory = table.Column<long>(type: "bigint", nullable: false),
                    BHYTCompulsory = table.Column<long>(type: "bigint", nullable: false),
                    BHTNCompulsory = table.Column<long>(type: "bigint", nullable: false),
                    TotalCompulsoryInsurance = table.Column<long>(type: "bigint", nullable: false),
                    Tax = table.Column<long>(type: "bigint", nullable: false),
                    PITExcludingRent = table.Column<long>(type: "bigint", nullable: false),
                    TNConversionIncludingRent = table.Column<long>(type: "bigint", nullable: false),
                    TaxableIncome = table.Column<long>(type: "bigint", nullable: false),
                    PIT = table.Column<long>(type: "bigint", nullable: false),
                    PITByEmployee = table.Column<long>(type: "bigint", nullable: false),
                    PaidDayOff = table.Column<long>(type: "bigint", nullable: false),
                    CashAdvance = table.Column<long>(type: "bigint", nullable: false),
                    TotalTax = table.Column<long>(type: "bigint", nullable: false),
                    TotalTaxableIncome = table.Column<long>(type: "bigint", nullable: false),
                    IsApprove = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsDeactivate = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Salary_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SpecialDay",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Reason = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Option = table.Column<int>(type: "int", nullable: false),
                    IsUrgent = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DayOffStatus = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    HolidayType = table.Column<int>(type: "int", nullable: true),
                    IsPaidOff = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsDeactivate = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialDay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecialDay_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserChecking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CheckinTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CheckoutTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CheckinNotes = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CheckoutNotes = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsDeactivate = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserChecking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserChecking_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DepartmentMap",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    ParentDepartmentId = table.Column<int>(type: "int", nullable: false),
                    IsDeactivate = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentMap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepartmentMap_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentMap_Department_ParentDepartmentId",
                        column: x => x.ParentDepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DepartmentUserMap",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    IsDeactivate = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentUserMap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepartmentUserMap_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentUserMap_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MeetingUserMap",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MeetingId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IsDeactivate = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingUserMap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeetingUserMap_MeetingCompany_MeetingId",
                        column: x => x.MeetingId,
                        principalTable: "MeetingCompany",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MeetingUserMap_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProjectOTMap",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OverTimeId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    IsDeactivate = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectOTMap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectOTMap_OverTime_OverTimeId",
                        column: x => x.OverTimeId,
                        principalTable: "OverTime",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectOTMap_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProjectUserMap",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsLeader = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    IsDeactivate = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectUserMap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectUserMap_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectUserMap_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AssignorId = table.Column<int>(type: "int", nullable: false),
                    AssigneeId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Content = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TicketStatus = table.Column<int>(type: "int", nullable: false),
                    TeamsNoitifyId = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeactivate = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ticket_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ticket_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ticket_User_AssigneeId",
                        column: x => x.AssigneeId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ticket_User_AssignorId",
                        column: x => x.AssignorId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TicketId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Content = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsDeactivate = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Report_Ticket_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Ticket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Report_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TicketFile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TicketId = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DisplayName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Size = table.Column<long>(type: "bigint", nullable: false),
                    IsDeactivate = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketFile_Ticket_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Ticket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ReportFile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ReportId = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DisplayName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Size = table.Column<long>(type: "bigint", nullable: false),
                    IsDeactivate = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportFile_Report_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Report",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "HardCode",
                columns: new[] { "Id", "Created", "IsDeactivate", "Modified", "Name", "ParentId", "Value" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 15, 8, 13, 22, 770, DateTimeKind.Utc).AddTicks(3378), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "UserRole", "", 0 },
                    { 2, new DateTime(2023, 5, 15, 8, 13, 22, 770, DateTimeKind.Utc).AddTicks(3390), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Administrator", "UserRole", 1 },
                    { 4, new DateTime(2023, 5, 15, 8, 13, 22, 770, DateTimeKind.Utc).AddTicks(3399), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Manager", "UserRole", 2 },
                    { 5, new DateTime(2023, 5, 15, 8, 13, 22, 770, DateTimeKind.Utc).AddTicks(3407), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Employee", "UserRole", 3 },
                    { 6, new DateTime(2023, 5, 15, 8, 13, 22, 770, DateTimeKind.Utc).AddTicks(3415), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Interns", "UserRole", 5 },
                    { 7, new DateTime(2023, 5, 15, 8, 13, 22, 770, DateTimeKind.Utc).AddTicks(3425), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Probationer", "UserRole", 4 },
                    { 8, new DateTime(2023, 5, 15, 8, 13, 22, 770, DateTimeKind.Utc).AddTicks(3433), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Collaborators", "UserRole", 6 },
                    { 20, new DateTime(2023, 5, 15, 8, 13, 22, 770, DateTimeKind.Utc).AddTicks(3441), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gender", "", 0 },
                    { 21, new DateTime(2023, 5, 15, 8, 13, 22, 770, DateTimeKind.Utc).AddTicks(3448), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nam", "Gender", 1 },
                    { 22, new DateTime(2023, 5, 15, 8, 13, 22, 770, DateTimeKind.Utc).AddTicks(3487), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nữ", "Gender", 2 },
                    { 23, new DateTime(2023, 5, 15, 8, 13, 22, 770, DateTimeKind.Utc).AddTicks(3497), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Khác", "Gender", 3 },
                    { 41, new DateTime(2023, 5, 15, 8, 13, 22, 770, DateTimeKind.Utc).AddTicks(3505), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DayOffOption", "", 0 },
                    { 42, new DateTime(2023, 5, 15, 8, 13, 22, 770, DateTimeKind.Utc).AddTicks(3513), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cả ngày", "DayOffOption", 1 },
                    { 43, new DateTime(2023, 5, 15, 8, 13, 22, 770, DateTimeKind.Utc).AddTicks(3520), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sáng", "DayOffOption", 2 },
                    { 44, new DateTime(2023, 5, 15, 8, 13, 22, 770, DateTimeKind.Utc).AddTicks(3528), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chiều", "DayOffOption", 3 },
                    { 45, new DateTime(2023, 5, 15, 8, 13, 22, 770, DateTimeKind.Utc).AddTicks(3535), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ProjectStatus", "", 0 },
                    { 47, new DateTime(2023, 5, 15, 8, 13, 22, 770, DateTimeKind.Utc).AddTicks(3599), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đang hoạt động", "ProjectStatus", 1 },
                    { 48, new DateTime(2023, 5, 15, 8, 13, 22, 770, DateTimeKind.Utc).AddTicks(3611), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tạm dừng", "ProjectStatus", 2 },
                    { 49, new DateTime(2023, 5, 15, 8, 13, 22, 770, DateTimeKind.Utc).AddTicks(3619), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đã hoàn thành", "ProjectStatus", 3 },
                    { 50, new DateTime(2023, 5, 15, 8, 13, 22, 770, DateTimeKind.Utc).AddTicks(3627), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "HolidayType", "", 0 },
                    { 51, new DateTime(2023, 5, 15, 8, 13, 22, 770, DateTimeKind.Utc).AddTicks(3635), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ngày nghỉ cố định", "HolidayType", 1 },
                    { 52, new DateTime(2023, 5, 15, 8, 13, 22, 770, DateTimeKind.Utc).AddTicks(3643), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ngày nghỉ không cố định", "HolidayType", 2 },
                    { 53, new DateTime(2023, 5, 15, 8, 13, 22, 770, DateTimeKind.Utc).AddTicks(3651), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ngày nghỉ do công ty quy định", "HolidayType", 3 },
                    { 54, new DateTime(2023, 5, 15, 8, 13, 22, 770, DateTimeKind.Utc).AddTicks(3659), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OvertimeRateType", "", 0 },
                    { 55, new DateTime(2023, 5, 15, 8, 13, 22, 770, DateTimeKind.Utc).AddTicks(3668), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "x2", "OvertimeRateType", 2 },
                    { 56, new DateTime(2023, 5, 15, 8, 13, 22, 770, DateTimeKind.Utc).AddTicks(3676), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "x3", "OvertimeRateType", 3 },
                    { 57, new DateTime(2023, 5, 15, 8, 13, 22, 770, DateTimeKind.Utc).AddTicks(3721), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SalaryType", "", 0 },
                    { 58, new DateTime(2023, 5, 15, 8, 13, 22, 770, DateTimeKind.Utc).AddTicks(3730), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "NET", "SalaryType", 1 },
                    { 59, new DateTime(2023, 5, 15, 8, 13, 22, 770, DateTimeKind.Utc).AddTicks(3738), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GROSS", "SalaryType", 2 },
                    { 60, new DateTime(2023, 5, 15, 8, 13, 22, 770, DateTimeKind.Utc).AddTicks(3745), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PARTTIME", "SalaryType", 3 },
                    { 61, new DateTime(2023, 5, 15, 8, 13, 22, 770, DateTimeKind.Utc).AddTicks(3753), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PROBATION", "SalaryType", 4 },
                    { 62, new DateTime(2023, 5, 15, 8, 13, 22, 770, DateTimeKind.Utc).AddTicks(3762), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AlertGroups", "", 0 },
                    { 63, new DateTime(2023, 5, 15, 8, 13, 22, 770, DateTimeKind.Utc).AddTicks(3770), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tất cả", "AlertGroups", 7 },
                    { 64, new DateTime(2023, 5, 15, 8, 13, 22, 770, DateTimeKind.Utc).AddTicks(3791), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đã đọc", "AlertGroups", 8 },
                    { 65, new DateTime(2023, 5, 15, 8, 13, 22, 770, DateTimeKind.Utc).AddTicks(3800), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chưa đọc", "AlertGroups", 9 },
                    { 66, new DateTime(2023, 5, 15, 8, 13, 22, 770, DateTimeKind.Utc).AddTicks(3808), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tài khoản", "AlertGroups", 1 },
                    { 67, new DateTime(2023, 5, 15, 8, 13, 22, 770, DateTimeKind.Utc).AddTicks(3816), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ngày nghỉ", "AlertGroups", 3 },
                    { 68, new DateTime(2023, 5, 15, 8, 13, 22, 770, DateTimeKind.Utc).AddTicks(3824), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tin nhắn", "AlertGroups", 0 },
                    { 69, new DateTime(2023, 5, 15, 8, 13, 22, 770, DateTimeKind.Utc).AddTicks(3831), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm thêm giờ", "AlertGroups", 4 },
                    { 70, new DateTime(2023, 5, 15, 8, 13, 22, 770, DateTimeKind.Utc).AddTicks(3840), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dự án", "AlertGroups", 2 },
                    { 71, new DateTime(2023, 5, 15, 8, 13, 22, 770, DateTimeKind.Utc).AddTicks(3848), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sinh nhật", "AlertGroups", 5 },
                    { 72, new DateTime(2023, 5, 15, 8, 13, 22, 770, DateTimeKind.Utc).AddTicks(3855), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ứng lương", "AlertGroups", 6 },
                    { 73, new DateTime(2023, 5, 15, 8, 13, 22, 770, DateTimeKind.Utc).AddTicks(3863), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DepartmentStatus", "", 0 },
                    { 74, new DateTime(2023, 5, 15, 8, 13, 22, 770, DateTimeKind.Utc).AddTicks(3871), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đang hoạt động", "DepartmentStatus", 1 },
                    { 75, new DateTime(2023, 5, 15, 8, 13, 22, 770, DateTimeKind.Utc).AddTicks(3952), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dừng hoạt động", "DepartmentStatus", 2 },
                    { 76, new DateTime(2023, 5, 15, 8, 13, 22, 770, DateTimeKind.Utc).AddTicks(3964), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sớm ra mắt", "DepartmentStatus", 3 },
                    { 85, new DateTime(2023, 5, 15, 8, 13, 22, 770, DateTimeKind.Utc).AddTicks(3971), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SpecialDayOff", "", 0 },
                    { 86, new DateTime(2023, 5, 15, 8, 13, 22, 770, DateTimeKind.Utc).AddTicks(3979), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kết hôn", "SpecialDayOff", 1 },
                    { 87, new DateTime(2023, 5, 15, 8, 13, 22, 770, DateTimeKind.Utc).AddTicks(3986), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Con đẻ, con nuôi kết hôn", "SpecialDayOff", 2 },
                    { 88, new DateTime(2023, 5, 15, 8, 13, 22, 770, DateTimeKind.Utc).AddTicks(3994), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nghỉ sinh con", "SpecialDayOff", 3 },
                    { 89, new DateTime(2023, 5, 15, 8, 13, 22, 770, DateTimeKind.Utc).AddTicks(4002), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nghỉ để tang", "SpecialDayOff", 4 }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Created", "IsDeactivate", "Modified", "RoleName" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 15, 8, 13, 22, 770, DateTimeKind.Utc).AddTicks(4020), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Administrator" },
                    { 2, new DateTime(2023, 5, 15, 8, 13, 22, 770, DateTimeKind.Utc).AddTicks(4031), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Manager" },
                    { 3, new DateTime(2023, 5, 15, 8, 13, 22, 770, DateTimeKind.Utc).AddTicks(4040), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Employee" },
                    { 4, new DateTime(2023, 5, 15, 8, 13, 22, 770, DateTimeKind.Utc).AddTicks(4049), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Probationer" },
                    { 5, new DateTime(2023, 5, 15, 8, 13, 22, 770, DateTimeKind.Utc).AddTicks(4058), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Interns" },
                    { 6, new DateTime(2023, 5, 15, 8, 13, 22, 770, DateTimeKind.Utc).AddTicks(4068), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Collaborators" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Address", "Avatar", "BankAccount", "BasicSalary", "Birthday", "Created", "DateJoinCompany", "DateStartContract", "Email", "FacebookId", "FullName", "Gender", "HourSalary", "HousingSupport", "IdBackImage", "IdFrontImage", "IdIssueDate", "IdIssuePlace", "IsChangingPassword", "IsDeactivate", "IsFirstLogin", "IsHardCode", "LastLogin", "LastLoginFail", "LinkedId", "LunchMoney", "Modified", "NumberOfDenpendents", "PassCode", "PetrolMoney", "Phone", "ReduceYourself", "Role", "SalaryCalculatedForBHTN", "SalaryCalculatedForBHXHnBHYT", "SalaryType", "Salt", "SkypeId", "SlackId", "TelephoneFee", "TimeZone", "TotalDayOffInYear", "TotalDayOffRemainInYear", "TotalLoginFail", "TotalTaxableIncome", "UserCode", "UserIdentity", "UserName" },
                values: new object[] { 1, null, null, null, 0L, new DateTime(2023, 5, 15, 8, 13, 22, 770, DateTimeKind.Utc).AddTicks(2645), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "root@gmail.com", null, "Lê Nguyên Khang", 3, 0.0, 0L, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, false, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "4gCaQiDMvnCFGpzB3UXGbWZ0cxFeVAi69XbUtGNZRno=", 0L, "0349560351", 0L, 1, 0L, 0L, 0, "00000000-0000-0000-0000-000000000000", null, "BK2N33T8B/9lHXv9Ml0hKdjqgR0jPYcuqs", 0L, null, 0.0, 0.0, 0, 0L, "1", 0L, "root@gmail.com" });

            migrationBuilder.CreateIndex(
                name: "IX_CashAdvance_UserId",
                table: "CashAdvance",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyEvent_UserId",
                table: "CompanyEvent",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_OwnerId",
                table: "Department",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentMap_DepartmentId",
                table: "DepartmentMap",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentMap_ParentDepartmentId",
                table: "DepartmentMap",
                column: "ParentDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentUserMap_DepartmentId",
                table: "DepartmentUserMap",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentUserMap_UserId",
                table: "DepartmentUserMap",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingCompany_LeaderId",
                table: "MeetingCompany",
                column: "LeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingUserMap_MeetingId",
                table: "MeetingUserMap",
                column: "MeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingUserMap_UserId",
                table: "MeetingUserMap",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_NotifyMessage_UserId",
                table: "NotifyMessage",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OverTime_UserId",
                table: "OverTime",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_OwnerId",
                table: "Project",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectOTMap_OverTimeId",
                table: "ProjectOTMap",
                column: "OverTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectOTMap_ProjectId",
                table: "ProjectOTMap",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUserMap_ProjectId",
                table: "ProjectUserMap",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUserMap_UserId",
                table: "ProjectUserMap",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Report_TicketId",
                table: "Report",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Report_UserId",
                table: "Report",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportFile_ReportId",
                table: "ReportFile",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_RewardUserMap_RewardId",
                table: "RewardUserMap",
                column: "RewardId");

            migrationBuilder.CreateIndex(
                name: "IX_RewardUserMap_UserId",
                table: "RewardUserMap",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Salary_UserId",
                table: "Salary",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialDay_UserId",
                table: "SpecialDay",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_AssigneeId",
                table: "Ticket",
                column: "AssigneeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_AssignorId",
                table: "Ticket",
                column: "AssignorId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_DepartmentId",
                table: "Ticket",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_ProjectId",
                table: "Ticket",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketFile_TicketId",
                table: "TicketFile",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_UserChecking_UserId",
                table: "UserChecking",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CashAdvance");

            migrationBuilder.DropTable(
                name: "CompanyEvent");

            migrationBuilder.DropTable(
                name: "CurrencyExchange");

            migrationBuilder.DropTable(
                name: "DepartmentMap");

            migrationBuilder.DropTable(
                name: "DepartmentUserMap");

            migrationBuilder.DropTable(
                name: "FilePolicy");

            migrationBuilder.DropTable(
                name: "HardCode");

            migrationBuilder.DropTable(
                name: "MeetingUserMap");

            migrationBuilder.DropTable(
                name: "NotifyMessage");

            migrationBuilder.DropTable(
                name: "ProjectOTMap");

            migrationBuilder.DropTable(
                name: "ProjectUserMap");

            migrationBuilder.DropTable(
                name: "RateOvertime");

            migrationBuilder.DropTable(
                name: "ReportFile");

            migrationBuilder.DropTable(
                name: "RewardUserMap");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Salary");

            migrationBuilder.DropTable(
                name: "SpecialDay");

            migrationBuilder.DropTable(
                name: "SystemConfig");

            migrationBuilder.DropTable(
                name: "TicketFile");

            migrationBuilder.DropTable(
                name: "UserChecking");

            migrationBuilder.DropTable(
                name: "MeetingCompany");

            migrationBuilder.DropTable(
                name: "OverTime");

            migrationBuilder.DropTable(
                name: "Report");

            migrationBuilder.DropTable(
                name: "Reward");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
