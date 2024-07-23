//using Fund_API.AuditLog;
using System.Globalization;

namespace Fund_API.Framework.Helper
{
    public static class ConversionHelper
    {
        public static string FormatSQL(string objString)
        {
            return string.IsNullOrEmpty(objString) ? "NULL" : "'" + objString + "'";
        }

        public static string? ToString(object objString)
        {
            return objString != null ? Convert.ToString(objString) : string.Empty;
        }

        public static string ToDate(string sSource)
        {
            string sDest = string.Empty;

            try
            {
                if (DateTime.TryParseExact(sSource, "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dtValue))
                {
                    sDest = dtValue.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                }
                else
                {
                    // Handle parsing failure, if necessary.
                    // In this example, I'll return an empty string for parsing failure.
                }
            }
            catch (Exception ex)
            {
                // Log the exception using your ErrorLog class.
                new ErrorLog().WriteLog(ex);

                // Optionally rethrow the exception if needed.
                // throw;
            }

            return sDest;
        }
        public static string TosqlDatetime(object objDate)
        {
            string sDest = string.Empty;

            if (objDate != null)
            {
                if (DateTime.TryParseExact(objDate.ToString(), "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dtValue))
                {
                    sDest = dtValue.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                }
            }
            return sDest;
        }
        public static string TosqlDate(object objDate)
        {
            string sDest = string.Empty;

            if (objDate != null)
            {
                if (DateTime.TryParseExact(objDate.ToString(), "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dtValue))
                {
                    sDest = dtValue.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                }
            }
            return sDest;
        }

        public static string TosqlDate(object objDate, string inputFormat = "dd-MM-yyyy HH:mm:ss")
        {
            string sDest = string.Empty;

            if (objDate != null)
            {
                if (DateTime.TryParseExact(objDate.ToString(), inputFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dtValue))
                {
                    sDest = dtValue.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                }
            }
            return sDest;
        }

        public static DateTime ToDateTime(string sSource, string dateFormat = "MM/dd/yyyy")
        {
            DateTime dtValue = DateTime.Now; // Default value if parsing fails or input is null.
            if (!string.IsNullOrEmpty(sSource))
            {
                if (DateTime.TryParseExact(sSource, dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dtValue))
                {
                    // Parsing successful; dtValue now holds the parsed DateTime.
                }
            }
            return dtValue;
        }

        public static DateTime ToDateTime(string sSource)
        {
            if (DateTime.TryParse(sSource, out DateTime dtValue))
            {
                return dtValue; // Parsing was successful; return the parsed DateTime.
            }
            return DateTime.Now;
        }

        public static DateTime ToDateTime(object objDate)
        {
            if (objDate == null)
            {
                throw new ArgumentNullException(nameof(objDate), "Input object cannot be null.");
            }

            if (objDate is DateTime dateValue)
            {
                return dateValue; // If the object is already a DateTime, return it directly.
            }

            if (DateTime.TryParse(objDate.ToString(), out DateTime dtValue))
            {
                return dtValue;
            }
            return DateTime.Now;
        }

        /// <summary>
        /// this method is used to return Null if object value is empty -- 03/16/2020
        /// </summary>
        /// <param name="objDate"></param>
        /// <returns></returns>
        public static DateTime? ToDateTimeNull(object objDate)
        {
            if (DateTime.TryParse(ToString(objDate), out DateTime dtValue))
            {
                return dtValue;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sSource"></param>
        /// <returns></returns>
        public static short ToInt16(string sSource)
        {
            if (short.TryParse(sSource, out short iValue))
            {
                return iValue;
            }
            return 0;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="objSource"></param>
        /// <returns></returns>
        public static short ToInt16(object objSource)
        {
            if (objSource != null && short.TryParse((string?)objSource, out short iValue))
            {
                return iValue;
            }
            return 0;
        }

        public static int ToInt32(string sSource)
        {
            if (int.TryParse(sSource, out int iValue))
            {
                return iValue;
            }
            return 0;
        }

        public static int ToInt32(object sSource)
        {
            if (sSource != null && int.TryParse((string?)sSource, out int iValue))
            {
                return iValue;
            }
            return 0;
        }

        public static long ToInt64(object objSource)
        {
            if (long.TryParse(objSource?.ToString(), out long iValue))
            {
                return iValue;
            }
            return 0;
        }

        public static int ToInteger(string sSource)
        {
            if (int.TryParse(sSource, out int iValue))
            {
                return iValue;
            }
            return 0;
        }

        public static int ToInteger(object objSource)
        {
            if (int.TryParse(objSource?.ToString(), out int iValue))
            {
                return iValue;
            }
            return 0;
        }

        public static int ToInteger(bool istrue)
        {
            return istrue ? 1 : 0;
        }

        public static decimal ToDecimal(string sSource)
        {
            if (decimal.TryParse(sSource?.ToString(), out decimal iValue))
            {
                return iValue;
            }
            return 0;
        }

        public static decimal ToDecimal(object obj)
        {
            if (decimal.TryParse(obj?.ToString(), out decimal result))
            {
                return result;
            }
            return 0.0M;
        }

        public static double ToDouble(string sSource)
        {
            return double.TryParse(sSource, out double result) ? result : 0.0;
        }

        public static double ToDouble(object obj)
        {
            return double.TryParse(obj?.ToString(), out double result) ? result : 0.0;
        }

        public static float ToFloat(string sSource)
        {
            return float.TryParse(sSource, out float result) ? result : 0.0f;
        }

        public static float ToFloat(object obj)
        {
            return float.TryParse(obj?.ToString(), out float result) ? result : 0.0f;
        }

        public static bool ToBoolean(string sSource)
        {
            return bool.TryParse(sSource, out bool result) && result;
        }

        public static bool ToBoolean(object obj)
        {
            return bool.TryParse(obj?.ToString(), out bool result) && result;
        }
    }
}
