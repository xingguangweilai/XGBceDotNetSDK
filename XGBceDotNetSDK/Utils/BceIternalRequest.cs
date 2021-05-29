using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using XGBceDotNetSDK.Sign;

namespace XGBceDotNetSDK.Utils
{
    public class BceIternalRequest
    {
        private Dictionary<String, String> queryParams = new Dictionary<string, string>();
        private Dictionary<String, String> headers = new Dictionary<string, string>();
        private string content_type;
        private string content_length;
        private DateTime date;
        private string host;

        private IDictionary pa;
        private Uri uri;
        private BceHttpMethod httpMethod;
        //private RestartableInputStream content;
        private XGBceCredentials credentials;
        private BceSignOption signOptions;
        //private boolean expectContinueEnabled;
        public BceIternalRequest()
        {
        }

        /// <summary>
        /// 请求参数
        /// </summary>
        public Dictionary<string, string> QueryParams { get => queryParams; set => queryParams = value; }
        /// <summary>
        /// 请求头
        /// </summary>
        public Dictionary<string, string> Headers { get => headers; set {
                if (value != null)
                {
                    foreach (KeyValuePair<string, string> kvp in value)
                    {
                        string headerkey = kvp.Key.Trim().ToLower();
                        if (headerkey == "Content-Length".ToLower())
                        {
                            if (content_length == null || content_length.Length < 1)
                                content_length = kvp.Value.Trim();
                            continue;
                        }
                        else if (headerkey == "Content-Type".ToLower())
                        {
                            if (content_type == null || content_type.Length < 1)
                                content_type = kvp.Value.Trim();
                            continue;
                        }
                        else if (headerkey == "Host".ToLower())
                        {
                            if (host == null || host.Length < 1)
                                host = kvp.Value.Trim();
                            continue;
                        }
                        headers.Add(headerkey, kvp.Value.Trim());
                    }
                }
                else
                {
                    headers = new Dictionary<string, string>();
                }
            } }
        /// <summary>
        /// 请求方法
        /// </summary>
        public BceHttpMethod HttpMethod { get => httpMethod; set => httpMethod = value; }
        /// <summary>
        /// Uri
        /// </summary>
        public Uri Uri { get => uri; set => uri = value; }
        public XGBceCredentials Credentials { get => credentials; set => credentials = value; }
        /// <summary>
        /// 签名配置
        /// </summary>
        public BceSignOption SignOptions { get => signOptions; set {
                signOptions = value;
                if(value!=null)
                    this.Date = signOptions.TimeStamp;
            } }
        public string Content_type { get => content_type; set => content_type = value; }
        public string Content_length { get => content_length; set => content_length = value; }
        public string Host { get => host; set => host = value; }
        public DateTime Date { get => date; set {
                date = value;
                if (!headers.ContainsKey("x-bce-date"))
                    headers.Add("x-bce-date", HttpUtil.FormatUTCTime(date));
                if (signOptions != null)
                    signOptions.TimeStamp = date;

            } }
        public Dictionary<string,string> GetIternalHeaders()
        {
            Dictionary<string, string> iternalHeaders = new Dictionary<string, string>(headers);
            if (content_type != null && content_type.Length > 0)
                iternalHeaders.Add("Content-type", content_type);
            if (host != null && host.Length > 0)
                iternalHeaders.Add("Host", host);
            if (content_length != null && content_length.Length > 0)
                iternalHeaders.Add("Content-length", content_length);

            return iternalHeaders;
        }

        public string GetHttpMethodString()
        {
            return HttpUtil.BceHttpMethodToString(httpMethod);
        }
    }
}
