using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Common
{
    public static class ErrorMessageCode
    {
        public const string AUTH_FORBIDDEN_ERROR = "auth_forbidden_error";
        public const string EMAIL_INVALID = "email_invalid"; //Email invalid
        public const string USER_NOT_FOUND = "user_not_found"; //User not found
        public const string USER_IS_DEACTIVATE = "user_is_deactivate"; //User is deactivate
        public const string SERVER_ERROR = "server_error"; //Server Error
        public const string BAD_REQUEST = "bad_request";
        public const string EMAIL_OR_PHONE_NUMBER_ALREADY_EXIST = "email_or_phone_number_already_exist"; //This email or phone number already exist.
        public const string EMAIL_OR_PHONE_NUMBER_INVALID = "email_or_phone_number_invalid"; //This email or phone number is invalid.
        public const string PASSWORD_INVALID = "password_invalid"; //This password is invalid.
        public const string THIS_NEW_PASSWORD_SAME_OLD_PASSWORD = "this_new_password_same_old_password"; //this_new_password_same_old_password.
        public const string UPDATE_PASSWORD_FAILED = "update_password_failed"; //password update is failed.
        public const string PASSWORD_INCORRECT = "password_incorrect"; //Your password is Incorrect.
        public const string FORGOT_PASSWORD_DONE = "forgot_password_done"; //Please check email or phone number
        public const string FIELDS_IS_EMPTY = "fields_is_empty"; //Field not empty
        public const string FILES_NOT_BE_CHOSEN = "files_not_be_chosen";
        public const string USERNAME_ALREADY_EXIST = "username_already_exist"; //This username already exist.
        public const string LIST_HOLIDAY_IS_EMPTY = "list_holiday_is_empty"; //list holiday is empty.
        public const string LIST_REMOTE_DAYS_IS_EMPTY = "list_remote_days_is_empty"; //list remote days is empty.
        public const string EXIST_A_DAYOFF_INVALID = "exist_a_dayoff_invalid"; //list holiday is empty.
        public const string INSERT_HOLIDAYS_IS_FAILED = "insert_holidays_is_failed"; //insert holidays is failed.
        public const string INSERT_REMOTE_DAYS_IS_FAILED = "insert_remote_days_is_failed"; //insert remote days is failed.
        public const string INSERT_RATEOVERTIME_IS_FAILED = "insert_rateovertime_is_failed"; //insert rate overtime is failed.
        public const string DAYOFF_IS_NOT_AVAILABLE = "dayoff_is_not_available"; //This dayoff is not available.
        public const string DAYOFF_IS_NOT_NULL = "dayoff_is_not_null"; //dayoff is not null.
        public const string UPDATE_DAYOFF_FAILED = "update_dayoff_failed"; //dayoff update is failed.
        public const string PROJECT_NAME_NOT_NULL = "project_name_not_null"; //This username already exist.
        public const string CAN_NOT_DELETE_USER = "can_not_delete_user"; //Can not delete User
        public const string CAN_NOT_DEACTIVATE_USER = "can_not_deactivate_user"; //Can not delete User
        public const string USER_ALREADY_CHECKIN_TODAY = "USER_ALREADY_CHECKIN_TODAY";
        public const string USER_CHECKING_NOT_FOUND = "USER_CHECKING_NOT_FOUND";
        public const string INSERT_USER_DATE_WORKING_ERROR = "INSERT_USER_DATE_WORKING_ERROR";
        public const string UPDATE_USER_DATE_WORKING_ERROR = "UPDATE_USER_DATE_WORKING_ERROR";
        public const string USER_HAVE_NOT_CHECKEDIN_TODAY = "USER_HAVE_NOT_CHECKEDIN_TODAY";
        public const string FACIAL_DATA_EMPTY = "FACIAL_DATA_EMPTY";
        public const string FACIAL_ADD_FAILED = "FACIAL_ADD_FAILED";
        public const string FACIAL_UPDATE_FAILED = "FACIAL_UPDATE_FAILED";
        public const string USER_CHECKING_UPDATE_FAILED = "USER_CHECKING_UPDATE_FAILED";
        public const string FACIAL_AUTHEN_FAILDED = "FACIAL_AUTHEN_FAILDED";
        public const string FIELD_NOT_EMPTY = "field_not_empty"; //field not empty
        public const string PASSWORD_HAS_CHANGED = "password_has_changed"; //Password has Changed
        public const string CHANGE_PASSWORD_EXPIRE = "change_password_expire"; //Change password expire
        public const string CHANGE_PASSWORD_DONE = "change_password_done"; //Change password Done
        public const string NUM_DAYOFF_NOT_IS_VALID = "num_dayoff_not_is_valid"; // time b4 off atleast n day
        public const string NUM_WFH_NOT_IS_VALID = "num_wfh_not_is_valid"; // time b4 off atleast n day
        public const string LIST_DAYOFF_IS_EMPTY = "list_dayoff_is_empty"; //list dayoff is empty. 
        public const string START_TIME_INVALID = "start_time_invalid"; //start time invalid
        public const string FINISH_TIME_INVALID = "finish_time_invalid"; //finish time invalid
        public const string YOU_CANT_LOG_OT_FOR_YESTERDAY = "you_cant_log_ot_for_yesterday"; //you cannot log over time for yesterday
        public const string WORK_TIME_INVALID = "work_time_invalid"; //work time invalid
        public const string PROJECT_NOT_FOUND = "project_not_found"; //This username already exist.
        public const string DELETE_DAYOFF_IS_FAILED = "delete_dayoff_is_failed"; //delete dayoff is failed.
        public const string DATETIME_INVALID = "datetime_invalid"; //This datetime is invalid.
        public const string USER_IS_EARLY_ACTIVATE = "user_is_early_activate"; // User is early activate
        public const string USER_IS_ACTIVATED = "user_is_activated"; // User is activated
        public const string USER_HAS_BEEN_LOCKED = "user_has_been_locked"; // User has been locked
        public const string OVERTIME_NOT_FOUND = "overtime_not_found"; // Overtime not found
        public const string CANT_REMOVE_OT = "cant_remove_ot"; // can't remove ot
        public const string RATE_OVERTIME_NOT_FOUND = "rate_overtime_not_found"; //Rate overtime not found
        public const string SALARY_HAS_BEEN_THE_LOCK = "salary_has_been_the_lock";
        public const string CASH_ADVANCE_INVALID = "cash_advance_invalid"; //cash advance invalid
        public const string UPDATE_DAYOFF_FAIL = "update_dayoff_fail"; //update dayoff fail
        public const string UPDATE_DAYOFF_SUCCESS = "update_dayoff_success"; //update dayoff success
        public const string SCHEDULE_TIME_INVALID = "schedule_time_invalid"; //schedule_time_invalid
        public const string DAY_OFF_NOT_SUBMIT_AT_WEEKEND = "day_off_not_submit_at_weekend"; //day_off_not_submit_at_weekend
        public const string DAY_OFF_URGENT_JUST_FOR_HALF_DAY = "day_off_urgent_just_for_half_day"; //day_off_urgent_just_for_half_day
        public const string REWARD_NOT_EXIST = "reward_not_exist"; //number of value is zero
        public const string REWARD_NOT_HAVE_CONTENT = "reward_not_have_content"; // reward_not_have_content
        public const string REWARD_NOT_HAVE_SUBJECT = "reward_not_have_subject"; // reward_not_have_subject
        public const string CAN_NOT_DELETE_REWARD = "can_not_delete_reward"; // can_not_delete_reward
        public const string REWARD_HAVE_FINISH = "reward_have_finish"; // reward_have_finish
        public const string REWARD_VALUE_INVALID = "reward_value_invalid"; // reward_value_invalid
        public const string CASH_ADVANCE_NOT_FOUND = "cash_advance_not_found"; //cash_advance_not_found
        public const string CASH_ADVANCE_HAS_BEEN_APPROVED = "cash_advance_has_been_approved"; //cash_advance_has_been_aprove
        public const string FILE_NOT_FOUND = "file_not_found"; //file_not_found
        public const string MEETING_NOT_FOUND = "meeting_not_found"; //meeting_not_found
        public const string USER_NOT_PERMISSION = "user_not_permission"; //user_not_permission
        public const string CAN_NOT_OFF_AT_HOLIDAY = "can_not_off_at_holiday"; //can_not_off_at_holiday
        public const string YOU_CAN_NOT_OFF_AT_MONDAY = "you_can_not_off_at_monday"; //you_can_not_off_at_monday
        public const string DAY_OFF_INVALID = "day_off_invalid"; // day_off_invalid
        public const string CAN_NOT_DELETE_FOLDER_PARRENT = "can_not_delete_folder_parent"; //can_not_delete_folder_parent
        public const string CAN_NOT_DELETE_FOLDER_OR_FILE = "can_not_delete_folder_or_file"; //can_not_delete_folder_or_file
        public const string DEPARTMENT_NOT_FOUND = "department_not_found"; //department_not_found
        public const string CAN_NOT_CREATE_DEPARTMENT = "can_not_create_department"; //can_not_create_department
        public const string CAN_NOT_EDIT_DEPARTMENT = "can_not_edit_department"; //can_not_edit_department
        public const string CAN_NOT_CREATE_ROOM = "can_not_create_room"; // can_not_create_room
        public const string USERCODE_ALREADY_EXIST = "User_Code_already_exist"; //usercode already exist.
        public const string USERCODE_NOT_FOUND = "User_Code_not_found"; //usercode not found.
        public const string DAILY_REPORT_ALREADY_EXIST = "daily_report_already_exist"; //daily report already exist.
        public const string ADMIN_CANT_ADD_DAILY_REPORT = "admin_cant_add_daily_report"; //admin can't add daily report.
        public const string DAILY_REPORT_IS_NOT_EXIST = "daily_report_is_not_exist"; //daily report is not exist.
        public const string CAN_NOT_EDIT_OLD_REPORT = "can_not_edit_old_report"; //can not edit old report
        public const string USER_NOT_IN_PROJECT = "user_not_in_project"; //user not in project
        public const string REPORT_NOT_FOUND = "report_not_found"; //report not found.
    }
}
