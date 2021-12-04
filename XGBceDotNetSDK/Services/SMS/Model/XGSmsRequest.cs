using System;
using Newtonsoft.Json;
using XGBceDotNetSDK.BaseClass;
using XGBceDotNetSDK.Sign;

namespace XGBceDotNetSDK.Services.SMS.Model
{
    public class XGSmsRequest: XGAbstractBceRequest
    {
        /// <summary>
        /// 幂等性参数，避免client在http响应超时而重试时出现同一条短信多次发送的情况。
        /// <para>如传入，则作为请求的messageId前缀，并在响应中回传</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonIgnore]
        public string ClientToken { get; set; }

        public XGSmsRequest()
        {
        }

    }
}
