using Backend.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Backend.Common
{
    public static class CommonUtils
    {
        public static string GeneratePasscode(string passcode, string salt)
        {
            byte[] plainTextWithSaltBytes = Encoding.UTF8.GetBytes(passcode + salt);
            HashAlgorithm algorithm = new SHA256Managed();
            var buffer = algorithm.ComputeHash(plainTextWithSaltBytes);
            return Convert.ToBase64String(buffer);
        }

        public static TimeZoneInfo GetLocalTimeZone(User user)
        {
            TimeZoneInfo timeZone = null;

            try
            {
                timeZone = TimeZoneInfo.FindSystemTimeZoneById(user.TimeZone);
            }
            catch (Exception ex)
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    timeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
                }
                else
                {
                    timeZone = TimeZoneInfo.FindSystemTimeZoneById("Asia/Ho_Chi_Minh");
                }
            }

            return timeZone;
        }

        public static DateTime ConvertDateTime(object value, string dateTimeFormat)
        {
            try
            {
                var defaultValue = DateTime.MinValue;

                if (value == null || value == DBNull.Value)
                {
                    return defaultValue;
                }

                DateTime.TryParseExact(value.ToString(), dateTimeFormat, CultureInfo.InvariantCulture,
                              DateTimeStyles.None, out defaultValue);

                return defaultValue;

            }
            catch (Exception ex)
            {
                return DateTime.MinValue;
            }

        }

        public static string GetDisplayImageUrl(string imageName)
        {
            if (string.IsNullOrWhiteSpace(imageName))
                return string.Empty;

            var imageLink = Constants.ImageDisplayPrefix.Replace(@"\", "/") + "/" + imageName;

            return imageLink;
        }

        public static DateTime GetLocalTimeNow(TimeZoneInfo timeZone)
        {
            if (timeZone == null)
                return DateTime.Now;

            return TimeZoneInfo.ConvertTime(DateTime.UtcNow, TimeZoneInfo.Utc, timeZone);
        }

        //public static bool IsValidEmail(string email)
        //{
        //    bool invalid = false;

        //    if (string.IsNullOrEmpty(email)) return false;

        //    try
        //    {
        //        email = Regex.Replace(email, @"(@)(.+)$", DomainMapper, RegexOptions.None, TimeSpan.FromMilliseconds(200));
        //    }
        //    catch (RegexMatchTimeoutException)
        //    {

        //        return false;
        //    }

        //    if (invalid)
        //        return false;

        //    try
        //    {
        //        return Regex.IsMatch(email,
        //            @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
        //              @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
        //            RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
        //    }
        //    catch (RegexMatchTimeoutException)
        //    {

        //        return false;
        //    }
        //}
    }
}
