using System;
using Newtonsoft.Json;
using XGBceDotNetSDK.BaseClass;

namespace XGBceDotNetSDK.Services.SMS.Model
{
    public class XGCreateSignatureResponse: XGBaseResponse
    {
        public XGCreateSignatureResponse()
        {
        }

        /// <summary>
        /// 签名ID，唯一标识一个签名
        /// </summary>
        [JsonProperty("signatureId")]
        public string SignatureId { get ; set ; }
        /// <summary>
        /// 签名状态
        /// </summary>
        [JsonProperty("status")]
        public string Status { get ; set ; }

        public override string ToString()
        {
            return "XGCreateSignatureResponse [signatureId="+SignatureId+ "，status=" + Status+"]";
        }
    }
}
