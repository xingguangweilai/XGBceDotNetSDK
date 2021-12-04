using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace XGBceDotNetSDK.Utils
{
    public class UnixTimestampJsonConverter: DateTimeConverterBase
    {

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is DateTime)
            {
                //var ts = ((DateTime)value).ToUniversalTime() - new DateTime(1970,1,1,0,0,0,0);
                //writer.WriteValue(Convert.ToDouble(ts.TotalSeconds));
                writer.WriteValue(((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss"));
            }
            else
            {
                throw new ArgumentException("日期格式错误：" + value.GetType());
            }
            
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.EndObject)
                return null;

            if (reader.TokenType == JsonToken.Integer)
            {
                long instance = serializer.Deserialize<long>(reader);

                if (instance.ToString().Length == 10)        //精确到秒
                {
                    return DateTimeOffset.FromUnixTimeSeconds(instance).LocalDateTime;
                }
                else if (instance.ToString().Length == 13)   //精确到毫秒
                {
                    return DateTimeOffset.FromUnixTimeMilliseconds(instance).LocalDateTime;
                }
            }

            return null;
        }
    }

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

        /// <summary>
        /// 格式化为GMT时间字符串
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string FormatGMTDate(DateTime dateTime)
        {
            return dateTime.ToString("r");
        }
    }
}
