using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.SMS.Model
{
    /// <summary>
    /// 签名列表响应体
    /// </summary>
    public class XGListSignatureResponse:XGSmsResponse
    {
        private List<XGQuerySignatureResponse> signatureApplies;
        private int? totalCount;
        private string nextMarker;
        private int? maxKeys;

        public XGListSignatureResponse()
        {
        }

        /// <summary>
        /// 签名列表
        /// </summary>
        [JsonProperty(PropertyName = "signatureApplies", NullValueHandling = NullValueHandling.Ignore)]
        public List<XGQuerySignatureResponse> SignatureApplies { get => signatureApplies; set => signatureApplies = value; }
        /// <summary>
        /// 总数
        /// </summary>
        [JsonProperty(PropertyName = "totalCount", NullValueHandling = NullValueHandling.Ignore)]
        public int? TotalCount { get => totalCount; set => totalCount = value; }
        /// <summary>
        /// 下一个签名
        /// </summary>
        [JsonProperty(PropertyName = "nextMarker", NullValueHandling = NullValueHandling.Ignore)]
        public string NextMarker { get => nextMarker; set => nextMarker = value; }
        /// <summary>
        /// 页面大小
        /// </summary>
        [JsonProperty(PropertyName = "maxKeys", NullValueHandling = NullValueHandling.Ignore)]
        public int? MaxKeys { get => maxKeys; set => maxKeys = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
