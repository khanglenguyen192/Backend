using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Entities
{
    public static class EnumUtil
    {
        public enum UserRole
        {
            Administrator = 1,
            Manager,
            Employee,
            Probationer,
            Interns,
            Collaborators
        }
        public enum SpecialDayType
        {
            None = 0,
            DayOff = 1,
            Holiday = 2,
            MakeUp = 3,
            Weekend = 4,
            Remote = 5
        }
        public enum HolidayType
        {
            Default = 1,
            NoneDefault,
            Company
        }
        public enum OvertimeRateType
        {
            Night = 0,
            Weekend = 1,
            X2 = 2,
            X3 = 3
        }
        public enum Gender
        {
            Male = 1,
            Female = 2,
            Other = 3
        }

        public enum DayOffOption
        {
            FullDay = 1,
            Morning,
            Afternoon
        }
        public enum DayOffStatus
        {
            Approve = 1,
            Waiting,
            Reject
        }

        public enum SlackAction
        {
            DayOffApprove = 1,
            DayOffDeny = 2,
            SubmitOverTime,
            RemoveDayOffApprove,
            RemoveDayOffDeny,
            CashAdvanceApprove,
            CashAdvanceDeny,
            MeetingApprove,
            MeetingReject,
            WFHApprove,
            WFHOffDeny
        }

        public enum ProjectStatus
        {
            Working = 1,
            Pending = 2,
            Finish = 3
        }

        public enum RewardStatus
        {
            None = 0,
            Sent = 1,
            Draft = 2,
        }

        public enum CashAdvanceStatus
        {
            None = 0,
            Approve = 1,
            Reject = 2,
            Waiting = 3
        }

        public enum SalaryType
        {
            Net = 1,
            Gross,
            Parttime,
            Probation
        }

        public enum CompanyEventType
        {
            DayOffEmailAdmin,
            Meeting,
            DayOffRemind
        }

        public enum MeetingStatus
        {
            Join = 1,
            Waiting,
            Reject
        }

        public enum PatternTemplateEnum
        {
            LaborContract = 1,
            ProbationaryContract = 2,
            SalaryTemplate = 3,
            SalaryBankTemplate = 4,
            CollaboratorContract = 6
        }

        public enum DepartmentStatus
        {
            Activate = 1,
            Deactivate = 2,
            ComingSoon = 3
        }

        public enum DepartmentUserRole
        {
            Manager = 1,
            Deputy = 2,
            Member = 3
        }

        //Virtual Tag
        public enum DeviceSupport
        {
            Tag,
            Beacon,
            Anchor,
            Gateway
        }
        public enum ReceiveType
        {
            None = 0,
            BLE,
            BLEMesh,
            WiFi,
            Ethernet
        }
        public enum TransmitType
        {
            None = 0,
            BLE,
            BLEMesh,
            WiFi,
            Ethernet
        }
        public enum DataType
        {
            Bluetooth,
            Wifi,
        }

        public enum SpecialDayOff
        {
            Marriage = 1,
            ChildrenMarriage = 2,
            Childbirth = 3,
            Mourn = 4
        }
    }
}
