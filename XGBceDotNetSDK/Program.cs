using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using XGBceDotNetSDK.Sign;
using XGBceDotNetSDK.Services.SMS;
using XGBceDotNetSDK.Utils;

namespace XGBceDotNetSDK
{
    class SendSMS
    { 

        public string mobile;

        public string template;

        public string signatureId;

        public Dictionary<string, string> contentVar;

    }

    class Program
    {
        private static string host = @"smsv3.bj.baidubce.com";
        private static string access_key_id = @"8cb37ef681d94490b45d697d69fad240";
        private static string secret_access_key = @"317e6b734a7a471cbb5fe7fcfb9bfe60";
        private static string requestVersion = @"bce-auth-v1";

        private static string httpMethod = @"PUT";
        private static string timestamp;

        private static string signedHeaders;
        private static string expirationPeriodInSeconds = @"1800";
        private static string authorization;
        private static string canonicalRequest;



        public static string Access_key_id { get => access_key_id; set => access_key_id = value; }
        public static string Secret_access_key { get => secret_access_key; set => secret_access_key = value; }
        public static string RequestVersion { get => requestVersion; set => requestVersion = value; }
        public static string HttpMethod { get => httpMethod; set => httpMethod = value; }
        /// <summary>
        /// 签名头域
        /// </summary>
        public static string SignedHeaders { get => signedHeaders; set => signedHeaders = value; }
        /// <summary>
        /// 过期时长
        /// </summary>
        public static string ExpirationPeriodInSeconds { get => expirationPeriodInSeconds; set => expirationPeriodInSeconds = value; }
        /// <summary>
        /// 认证字符串
        /// </summary>
        public static string Authorization { get => authorization; set => authorization = value; }
        /// <summary>
        /// 认证前缀字符串
        /// </summary>
        public static string AuthStringPrefix { get => requestVersion + "/" + access_key_id + "/" + timestamp + "/" + expirationPeriodInSeconds; }
        public static string CanonicalRequest { get => canonicalRequest; set => canonicalRequest = value; }
        public static string Host { get => host; set => host = value; }

        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            new XGSmsClient();


            //Dictionary<string, string> dic = new Dictionary<string, string>() {
            //    { "content-type","json"},
            //    { "Content-Type","application/json"},
            //    { "content","text"},
            //    {"type","jsonStr" }
            //};


            //XGSmsClientConfiguration smsClientConfiguration = new XGSmsClientConfiguration() {
            //    Credentials=new DefaultBceCredentials(access_key_id,secret_access_key),
            //Endpoint= "http://smsv3.bj.baidubce.com"
            //};

            //SendSMS sendSMS = new SendSMS()
            //{
            //    mobile = "18697762125",
            //    //template = "sms-tmpl-IYQpaG59486",
            //    //signatureId = "sms-sign-RLOmyr26320",
            //    //contentVar = new Dictionary<string, string> { { "ticketNumber", "10010" }, { "ticketTitle", "测试工单标题" } }

            //    template = "sms-tmpl-YqwEal08207",
            //    signatureId = "sms-sign-RLOmyr26320",
            //    contentVar = new Dictionary<string, string> { { "vCode", "12306" } }
            //};

            //var sendSMSJson = JsonConvert.SerializeObject(sendSMS);

            //BceIternalRequest bceIternalRequest = new BceIternalRequest();
            //bceIternalRequest.Credentials = new DefaultBceCredentials(access_key_id, secret_access_key);
            //bceIternalRequest.Headers = new Dictionary<string, string> { { "Host", Host }, { "Content-Type", "application/json;charset=UTF-8" } };
            //bceIternalRequest.QueryParams = new Dictionary<string, string>();
            //bceIternalRequest.HttpMethod = BceHttpMethod.POST;
            //bceIternalRequest.SignOptions = BceSignOption.defaultBceSignOption;

            //string urlpath = "http://" + Host + "/api/v3/sendSms";
            //if (bceIternalRequest.QueryParams.Count > 0)
            //{
            //    urlpath += "?";
            //    foreach (KeyValuePair<string, string> kvp in bceIternalRequest.QueryParams)
            //    {
            //        urlpath += kvp.Key.Trim() + "=" + kvp.Value.Trim() + "&";
            //    }
            //    urlpath = urlpath.TrimEnd('&');
            //}

            //bceIternalRequest.Uri = new Uri(urlpath);

            //new XGBceSignerV1().Sign(bceIternalRequest);

            //try
            //{
            //    Console.WriteLine("发送成功：" + HttpPost(bceIternalRequest, sendSMSJson));
            //}
            //catch (WebException ex)
            //{
            //    HttpWebResponse res = ex.Response as HttpWebResponse;
            //    string strError = "";
            //    if (res.StatusCode == HttpStatusCode.BadRequest)
            //    {
            //        Stream s = res.GetResponseStream();
            //        StreamReader objReader = new StreamReader(s, System.Text.Encoding.UTF8);
            //        strError = objReader.ReadToEnd();
            //        objReader.Close();
            //    }
            //    else
            //    {
            //        strError = ex.Message;
            //    }

            //    Console.WriteLine(strError);
            //}

        }

        /// <summary>
        /// 发送POST请求
        /// </summary>
        /// <param name="url">请求URL</param>
        /// <param name="data">请求参数</param>
        /// <returns></returns>
        static string HttpPost(BceIternalRequest iternalRequest, string data)
        {
            Console.WriteLine(data);

            HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(iternalRequest.Uri.ToString());
            //字符串转换为字节码
            byte[] bs = Encoding.UTF8.GetBytes(data);
            //参数类型，这里是json类型
            //httpWebRequest.ContentType = "application/json";
            foreach (KeyValuePair<string, string> kvp in iternalRequest.Headers)
            {
                httpWebRequest.Headers.Add(kvp.Key, kvp.Value);
            }

            if (iternalRequest.Host != null)
                httpWebRequest.Host = iternalRequest.Host;
            if (iternalRequest.Content_type != null)
                httpWebRequest.ContentType = iternalRequest.Content_type;
            httpWebRequest.Date = iternalRequest.Date;

            //参数数据长度
            //httpWebRequest.ContentLength = bs.Length;
            //设置请求类型
            httpWebRequest.Method = iternalRequest.GetHttpMethodString();
            //设置超时时间
            httpWebRequest.Timeout = 20000;
            //将参数写入请求地址中
            httpWebRequest.GetRequestStream().Write(bs, 0, bs.Length);
            //发送请求
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            //读取返回数据
            StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.UTF8);
            string responseContent = streamReader.ReadToEnd();
            streamReader.Close();
            httpWebResponse.Close();
            httpWebRequest.Abort();
            return responseContent;
        }
    }
}
