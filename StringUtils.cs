
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace INCHEQS.Common {

    public class StringUtils {
        public static string Trim(string input) {
            if (string.IsNullOrEmpty(input)) {
                return "";
            } else {
                return input.Trim();
            }
        }

        public static int convertToInt(string input) {
            if (string.IsNullOrEmpty(input)) {
                return 0;
            } else {
                return Convert.ToInt32(input);
            }
        }

        public static string ReplaceParamsWithMap(string inputStr, Dictionary<string, string> dictionary) {
            string result = inputStr;
            foreach (KeyValuePair<string, string> pair in dictionary) {
                result = result.Replace("@" + pair.Key, pair.Value);
            }
            return result;
        }



        public static string JoinArrayToSqlArrayStr(string[] input) {
            if (input == null) {
                return "''";
            }

            dynamic result = "";
            for (var i = 0; i <= input.Length - 1; i++) {
                if ((!string.IsNullOrEmpty(input[i]))) {
                    result += "'" + input[i] + "' ,";
                } else {
                    result += "'' ,";
                }
            }

            return result.TrimEnd(',');
        }

        public static string Left(string input, int index) {
            return "";
        }

        public static string Right(string input, int index) {
            return input.Substring(input.Length - index);
        }
        public static string Mid(string input, int start, int end) { //"check" => mid(2,2)=> output:"ec"
            return input.Substring(start, end);
        }

        public static int Len(string input) {
            return input.Length;
        }

        public static string UCase(string input) {
            return input.ToUpper();
        }

        public static string LCase(string input) {
            return input.ToLower();
        }


        public static string RemoveSpecialCharacters(string str) {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str) {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_') {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        public static string InsertDecimal(string value, int precision) {
            string padded = value.PadLeft(precision, '0');
            string result = padded.Insert(padded.Length - precision, ".");
            if (result.EndsWith(".")) {
                result = result.Remove(result.Length - 1);
            }
            return result;
        }

        public static string FormatCurrency(string strAmount) {
            //TODO: FIX THIS CURRENCY


            if (string.IsNullOrEmpty(strAmount) || strAmount.Equals("0")) {
                return "0";
            }
            decimal decCurrency = decimal.Parse(strAmount);
            string result = string.Format("{0:#,###,###.##}", decCurrency);
            if(result.IndexOf(".") > 0)
            {
                if (".".Equals(result.Substring(result.Length - 2, 1)))
                {
                    result = result + "0";
                }
                else if (".".Equals(result.Substring(result.Length - 3, 1)))
                {
                    result = result + "";

                }
                else
                {
                    result = result + ".00";
                }
            }
            else if (result.IndexOf(".") == 0)
            {
                if (result.Length == 2)
                {
                    result = "0" + result + "0";
                }
                else
                {
                    result = "0" + result;
                }
                
            }
            else
            {
                if (result.Length<2)
                {
                    result = result + ".00";
                }
                else if (".".Equals(result.Substring(result.Length - 2, 1)))
                {
                    result = result + "0";
                }
                else
                {
                    result = result + ".00";
                }

            }

            return result;
        }

        public static string Format(string input, object p) {
            foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(p))
                input = input.Replace("{" + prop.Name + "}", (prop.GetValue(p) ?? "(null)").ToString());

            return input;
        }

        public string FormatModifiedField(string value, string checker) {
            checker = checker.Trim(',');
            if (!value.Contains(checker)) {
                value = checker + ",";
            }
            return value;
        }

        public static bool Compare<T>(string op, T left, T right) where T : IComparable<T> {
            switch (op) {
                case "<": return left.CompareTo(right) < 0;
                case ">": return left.CompareTo(right) > 0;
                case "<=": return left.CompareTo(right) <= 0;
                case ">=": return left.CompareTo(right) >= 0;
                case "==": return left.Equals(right);
                case "!=": return !left.Equals(right);
                default: throw new ArgumentException("Invalid comparison operator: {0}", op);
            }
        }

    }
}