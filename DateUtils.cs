using System;

namespace INCHEQS.Common {

    public class DateUtils {

        public static DateTime AddDate(string dateType, int number, dynamic date) {
            dateType = dateType.ToLower();

            if(date is string) {
                date = Convert.ToDateTime(date);
            }

            switch (dateType) {
                case "y":
                    return date.AddYears(number);
                case "d":
                    return date.AddDays(number);
                case "m":
                    return date.AddMonths(number);
            }
            return DateTime.Now;
        }
        

        public static string GetCurrentDate() {
            DateTime now = DateTime.Now;
            return now.Year + "-" + StringUtils.Right("00" + now.Month, 2) + "-" + StringUtils.Right("00" + now.Day, 2);
            //return DateTime.Now;
        }

        public static string GetCurrentDatetime() {
            DateTime now = DateTime.Now;
            return now.Year + "-" + StringUtils.Right("00" + now.Month, 2) + "-" + StringUtils.Right("00" + now.Day, 2) + " " + StringUtils.Right("00" + now.Hour, 2) + ":" + StringUtils.Right("00" + now.Minute, 2) + ":" + StringUtils.Right("00" + now.Second, 2);
            
        }
        public static DateTime GetCurrentDatetimeForSql() {
            return DateTime.Now;
        }

        public static object FormatDBDate2Universal(DateTime sDate) {
            return sDate.Year + "-" + StringUtils.Right("00" + sDate.Month, 2) + "-" + StringUtils.Right("00" + sDate.Day, 2);            
        }
        
        public static string formatTimeStampFromSql(string strDateTime) {
            try {
                if ((string.IsNullOrEmpty(strDateTime))) {
                    return "";
                } else {
                    DateTime dateTime = DateTime.Parse(strDateTime);
                    return dateTime.ToString(ConfigureSetting.GetTimeStampFormat()); //Output based on AppSettings["TimeStampFormat"]
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

        public static string formatDateFromSql(string strDateTime) {
            try {
                if ((string.IsNullOrEmpty(strDateTime))) {
                    return "";
                } else {
                    DateTime dateTime = DateTime.Parse(strDateTime);
                    return dateTime.ToString(ConfigureSetting.GetDateFormat()); //Output based on AppSettings["DateFormat"]
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        public static string formatDateToSql(string strDateTime) {
            try {
                if ((string.IsNullOrEmpty(strDateTime) || strDateTime == "undefined")) {
                    return "";
                } else {
                    DateTime dateTime = DateTime.ParseExact(strDateTime, ConfigureSetting.GetDateFormat(), null);
                    return dateTime.ToString("dd/MMM/yyyy"); //Output : 31/Dec/2016
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

        public static string formatDateToSqlyyyymmdd(string strDateTime) //forSecurityAuditLog
        {
            try
            {
                if ((string.IsNullOrEmpty(strDateTime) || strDateTime == "undefined"))
                {
                    return "";
                }
                else
                {
                    DateTime dateTime = DateTime.ParseExact(strDateTime, ConfigureSetting.GetDateFormat(), null);
                    return dateTime.ToString("yyyy-MM-dd");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string formatDateToFileDate(string strDateTime) {
            try {
                if ((string.IsNullOrEmpty(strDateTime))) {
                    return "";
                } else {
                    DateTime dateTime = DateTime.ParseExact(strDateTime, ConfigureSetting.GetDateFormat(), null);
                    return dateTime.ToString("yyyyMMdd"); //Output : 20161231
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        public static string formatDateToReportDate(string strDateTime)
        {
            try
            {
                if ((string.IsNullOrEmpty(strDateTime)))
                {
                    return "";
                }
                else
                {
                    DateTime dateTime = DateTime.ParseExact(strDateTime, ConfigureSetting.GetDateFormat(), null);
                    return dateTime.ToString("yyyy-MM-dd"); //Output : 20161231
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string ConvertDateFormatToJQuery(string format) {
            //=======================================================================   
            // Handle:   
            //  C#     jQuery  Meaning   
            //  d      d       Day of month (no leading 0)  
            //  dd     dd      Day of month (leading 0)   
            //  ddd    D       Day name short
            //  dddd   DD      Day name long
            //  M      m       Month of year (no leading 0)   
            //  MM     mm      Month of year (leading 0)   
            //  MMM    M       Month name short
            //  MMMM   MM      Month name long
            //  yy     y       Two digit year   
            //  yyyy   yy      Four digit year 
            //======================================================================= 
            string currentFormat = format;

            // Convert the date
            currentFormat = currentFormat.Replace("dddd", "DD");
            currentFormat = currentFormat.Replace("ddd", "D");

            // Convert month
            if (currentFormat.Contains("MMMM")) {
                currentFormat = currentFormat.Replace("MMMM", "MM");
            } else if (currentFormat.Contains("MMM")) {
                currentFormat = currentFormat.Replace("MMM", "M");
            } else if (currentFormat.Contains("MM")) {
                currentFormat = currentFormat.Replace("MM", "mm");
            } else {
                currentFormat = currentFormat.Replace("M", "m");
            }

            // Convert year
            currentFormat = currentFormat.Contains("yyyy") ? currentFormat.Replace("yyyy", "yy") : currentFormat.Replace("yy", "y");

            return currentFormat;
        }

    }
}