using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace XGBceDotNetSDK.Services.SMS.Model
{
    /// <summary>
    /// 变更签名请求类
    /// </summary>
    public class XGModifySignatureRequest: XGCreateSignatureRequest
    {
        private string signatureId;
        public XGModifySignatureRequest()
        {
        }

        /// <summary>
        /// 签名适用的国家类型,默认为DOMESTIC
        /// <para>必需</para>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)), JsonProperty("countryType", NullValueHandling = NullValueHandling.Ignore)]
        public new XGSmsCountryType CountryType { get; set; }

        /// <summary>
        /// URL参数： 签名ID，唯一标识一个签名
        /// <para>必需</para>
        /// </summary>
        [JsonIgnore]
        public string SignatureId { get => signatureId; set => signatureId = value; }
    }
}
