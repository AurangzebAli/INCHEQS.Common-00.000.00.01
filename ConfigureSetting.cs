using System.Configuration;

namespace INCHEQS.Common
{
   public class ConfigureSetting
    {
        public static string GetApplicationCulture()
        {
            return ConfigurationManager.AppSettings["ApplicationCulture"];
        }

        public static string GetLogFileIndicator()
        {
            return ConfigurationManager.AppSettings["LogFileIndicator"];
        }

        public static string GetLogFile()
        {
            return ConfigurationManager.AppSettings["LogFile"];
        }

        public static string GetVersion()
        {
            return ConfigurationManager.AppSettings["Version"];
        }
        public static string GetDateFormat()
        {
            return ConfigurationManager.AppSettings["DateFormat"];
        }
        public static string GetTimeStampFormat()
        {
            return ConfigurationManager.AppSettings["TimeStampFormat"];
        }

        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["default"].ConnectionString;
        }

        public static string GetConnectionString(string strConnName)
        {
            return ConfigurationManager.ConnectionStrings[strConnName].ConnectionString;
        }

        public static string GetValue(string strKey)
        {
            return ConfigurationManager.AppSettings[strKey];
        }
    }
}
