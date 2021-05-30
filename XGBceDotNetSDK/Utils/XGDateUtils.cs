using System;
using System.Runtime.Serialization;

namespace XGBceDotNetSDK.Utils
{
    public class XGDateUtils
    {
        public XGDateUtils()
        {
        }

        /// <summary>
        /// 将ISO8601时间字符串转换成DateTime
        /// </summary>
        /// <param name="dateString">SO8601时间</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static DateTime ParseIso8601Date(string dateString)
        {
            return DateTime.ParseExact(dateString, "yyyy-MM-ddTHH:mm:ssZ", System.Globalization.CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// 格式化为ISO8601时间字符串
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string FormatISO8601Date(DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-ddTHH:mm:ssZ");
        }

        /// <summary>
        /// 将RFC822时间字符串转换成DateTime
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime ParseRfc822Date(string dateTime)
        {
            return Rfc822DateTime.Parse(dateTime);
        }

        /// <summary>
        /// 格式化为RFC822时间字符串
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string FormatRFC822Date(DateTime dateTime)
        {
            return dateTime.ToString(Rfc822DateTime.Rfc822DateTimeFormat);
        }
    }
}
