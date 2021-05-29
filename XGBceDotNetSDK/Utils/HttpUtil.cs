using System;
using System.Collections.Generic;
using System.Text;

namespace XGBceDotNetSDK.Utils
{
    public enum BceHttpMethod
    {
        GET=0,
        POST,
        PUT,
        DELETE,
        HEAD
    }
    public class HttpUtil
    {
        public HttpUtil()
        {
        }

        public static string BceHttpMethodToString(BceHttpMethod bceHttpMethod)
        {
            return new List<string> { "GET","POST","PUT","DELETE","HEAD"}[(int)bceHttpMethod];
        }

        /// <summary>
        /// 转换成UTC格式时间
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string FormatUTCTime(DateTime dateTime) {
            return dateTime.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ");
        }

        public static string UriEncode(string input, bool encodeSlash = false)
        {
            StringBuilder builder = new StringBuilder();
            foreach (byte b in Encoding.UTF8.GetBytes(input))
            {
                if ((b >= 'a' && b <= 'z') || (b >= 'A' && b <= 'Z') || (b >= '0' && b <= '9') || b == '_' || b == '-' || b == '~' || b == '.')
                {
                    builder.Append((char)b);
                }
                else if (b == '/')
                {
                    if (encodeSlash)
                    {
                        builder.Append("%2F");
                    }
                    else
                    {
                        builder.Append((char)b);
                    }
                }
                else
                {
                    builder.Append('%').Append(b.ToString("X2"));
                }
            }
            return builder.ToString();
        }
    }
}
