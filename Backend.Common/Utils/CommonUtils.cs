﻿using Backend.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
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
    }
}
