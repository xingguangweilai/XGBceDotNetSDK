using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using XGBceDotNetSDK.Http;

namespace XGBceDotNetSDK.Utils
{
    public enum BceHttpMethod
    {
        GET=0,
        POST,
        PUT,
        DELETE,
        HEAD,
        OPTIONS
    }

    public class HttpUtil
    {
        private static string DEFAULT_ENCODING = "UTF-8";
        private static string[] PERCENT_ENCODED_STRINGS = new string[256];
        public HttpUtil()
        {
        }

        public static string BceHttpMethodToString(BceHttpMethod bceHttpMethod)
        {
            return new List<string> { "GET","POST","PUT","DELETE","HEAD", "OPTIONS" }[(int)bceHttpMethod];
        }

        /// <summary>
        /// 转换成UTC格式时间
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string FormatUTCTime(DateTime dateTime) {
            return dateTime.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ");
        }

        public static Uri AppendUri(Uri baseUri,params string[] pathComponents)
        {
            StringBuilder builder = new StringBuilder(baseUri.ToString());
            if (builder[builder.Length-1] == '/')
            {
                builder.Remove(builder.Length - 1, 1);
            }
            string[] var3 = pathComponents;

            for(int i = 0; i < var3.Length; i++)
            {
                string path = var3[i];
                if (!path.StartsWith("/"))
                    path = '/' + path;
                builder.Append(path);
            }
            try
            {
                return new Uri(HttpUtility.UrlPathEncode(builder.ToString()));
            }
            catch(UriFormatException ex)
            {
                throw new ArgumentException(ex.Message);
            }
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

        public static string GetCanonicalQueryString(Dictionary<string,string> parameters, bool forSignature=false)
        {
            if (parameters == null || parameters.Count < 1)
                return "";

            List<string> parameterList = new List<string>();

            foreach(KeyValuePair<string,string> kvp in parameters)
            {
                if (forSignature && XGBceHeaders.AUTHORIZATION.Equals(kvp.Key, StringComparison.OrdinalIgnoreCase))
                    continue;
                string key = kvp.Key;
                if (key == null)
                    throw new ArgumentNullException("key不能为Null");
                key = UriEncode(key,true);
                string value = kvp.Value;
                if (string.IsNullOrEmpty(value))
                {
                    
                    if (forSignature)
                        parameterList.Add(key + '=');
                    else
                        parameterList.Add(key);
                }
                else
                {
                    value = UriEncode(value,true);
                    parameterList.Add(key + '=' + value);
                }
            }
            parameterList.Sort();
            return string.Join("&", parameterList);
        }

        
    }
}
