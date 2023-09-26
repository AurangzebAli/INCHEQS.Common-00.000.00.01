using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace INCHEQS.Common
{

    public class DatabaseUtils
    {
        
        public static List<SqlParameter> getSqlParametersFromArray(string[] array, string parameterName = "") {
            
            List<SqlParameter> sqlParameterList = new List<SqlParameter>();
            for (int i = 0; i <= array.Length - 1; i++) {
                sqlParameterList.Add(new SqlParameter("@p" + parameterName + Convert.ToString(i), StringUtils.Trim(array[i])));
            }
            return sqlParameterList;
        }

        public static string getParameterizedStatementFromArray(string[] array , string parameterName = "") {

            string result = "";
            for (int i = 0; i <= array.Length - 1; i++) {
                result = result + "@p" + parameterName + Convert.ToString(i) + ",";
            }
            result = result.TrimEnd(',');
            return result;
        }

        public static string SanitizeString(string unsafeString) {
            if (!string.IsNullOrEmpty(unsafeString)) {
                return unsafeString.Replace("'", "''");
            }
            return null;
        }

    }
}