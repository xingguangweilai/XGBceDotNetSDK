using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using XGBceDotNetSDK.Sign;
using XGBceDotNetSDK.Utils;

namespace XGBceDotNetSDK.BaseClass
{
    public class XGBceIternalRequest
    {
        private Dictionary<String, String> parameters = new Dictionary<string, string>();
        private Dictionary<String, String> headers = new Dictionary<string, string>();
        private DateTime date;
        private string host;

        private IDictionary pa;
        private Uri uri;
        private BceHttpMethod httpMethod;
        //private RestartableInputStream content;
        private XGBceCredentials credentials;
        private BceSignOption signOptions;
        //private boolean expectContinueEnabled;
        public XGBceIternalRequest()
        {
        }
        /// <summary>
        /// 请求头
        /// </summary>
        public Dictionary<string, string> Headers { get => headers; set {
                if (value != null)
                {
                    foreach (KeyValuePair<string, string> kvp in value)
                    {
                        string headerkey = kvp.Key.Trim().ToLower();
                        if (headerkey == "Host".ToLower())
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
        public string Host { get => host; set => host = value; }
        public DateTime Date { get => date; set {
                date = value;
                if (!headers.ContainsKey("x-bce-date"))
                    headers.Add("x-bce-date", HttpUtil.FormatUTCTime(date));
                if (signOptions != null)
                    signOptions.TimeStamp = date;

            } }
        /// <summary>
        /// 请求参数
        /// </summary>
        public Dictionary<string, string> Parameters { get => parameters; set => parameters = value; }

        public string GetHttpMethodString()
        {
            return HttpUtil.BceHttpMethodToString(httpMethod);
        }

        public void AddHeader(string name,string value)
        {
            Headers.Add(name, value);
        }
    }
}
