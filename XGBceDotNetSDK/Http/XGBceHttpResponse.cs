using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using XGBceDotNetSDK.Utils;

namespace XGBceDotNetSDK.Http
{
    public class XGBceHttpResponse
    {
        private HttpWebResponse httpResponse;
        private Stream content;
        public XGBceHttpResponse() { }

        /// <summary>
        /// XGBceHttpResponse
        /// </summary>
        /// <param name="httpWebResponse"></param>
        /// <exception cref="IOException"></exception>
        public XGBceHttpResponse(HttpWebResponse httpWebResponse)
        {
            httpResponse = httpWebResponse;
            content = httpWebResponse.GetResponseStream();
            
        }

        public HttpWebResponse HttpResponse { get => httpResponse;  }
        public Stream Content { get => content;}
        /// <summary>
        /// 状态描述
        /// </summary>
        public string StatusText { get => HttpResponse.StatusDescription; }
        /// <summary>
        /// 状态码
        /// </summary>
        public int StatusCode { get => (int)HttpResponse.StatusCode; }
        /// <summary>
        /// 请求头
        /// </summary>
        public Dictionary<string,string> Headers
        {
            get
            {
                Dictionary<string, string> headers = new Dictionary<string, string>();
                for(int i = 0; i < httpResponse.Headers.Count; i++)
                {
                    headers.Add(httpResponse.Headers.GetKey(i), httpResponse.Headers.Get(i));
                }
                return headers;
            }
        }

        public string GetHeader(string name)
        {
            return httpResponse.GetResponseHeader(name);
        }

        public long GetHeaderAsLong(string name)
        {
            string value = httpResponse.GetResponseHeader(name);
            if (value == null)
                return -1L;
            else
            {
                try
                {
                    return long.Parse(value);
                }
                catch
                {
                    //TODO  日志
                    return -1;
                }
            }
        }

        public DateTime? GetHeaderAsRfc822Date(string dateStr)
        {
            string value = GetHeader(dateStr);
            if (value == null)
                return null;
            else
            {
                try
                {
                    return XGDateUtils.ParseRfc822Date(dateStr);
                }
                catch
                {
                    //TODO
                    Console.WriteLine(dateStr+"："+value + " 无效");
                    return null;
                }
            }
        }

    }
}
