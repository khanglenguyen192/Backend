using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Common
{
    public class Constants
    {
        public const string DATETIME_FORMAT = "dd'/'MM'/'yyyy HH:mm:ss";
        public const string DATE_FORMAT = "dd'/'MM'/'yyyy";
        public const string TTME_FORMAT = "HH:mm:ss";
        public const string SQL_DATE_FORMAT = "yyyy-MM-dd";

        public const string DEFAULT_PASSCODE = "123456x@X";

        public const string ROLE = "role";
        public const string USERID = "userId";

        public static string UserDataFolderName = "UserData";
        public static string ImageDisplayPrefix = "/userData/images";

        public const string API_ISSUER = "BackEndSystem";
        public const string API_CLIENT = "BackEndSystemClient";
    }
}
