using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace XGBceDotNetSDK.Services.SMS.Model
{
    /// <summary>
    /// 查询签名接口响应类
    /// </summary>
    public class XGQuerySignatureResponse:XGSmsResponse
    {
        private string signatureId;
        private string userId;
        private string content;
        private XGSmsContentType contentType;
        private XGSmsSignatureStatus status;
        private XGSmsCountryType countryType;
        private string review;
        private string description;
        private DateTime? createDate;
        private DateTime? updateDate;

        public XGQuerySignatureResponse()
        {
        }

        /// <summary>
        /// 签名内容
        /// </summary>
        [JsonProperty(PropertyName = "content", NullValueHandling = NullValueHandling.Ignore)]
        public string Content { get => content; set => content = value; }
        /// <summary>
        /// 签名类型
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)), JsonProperty(PropertyName = "contentType", NullValueHandling = NullValueHandling.Ignore)]
        public XGSmsContentType ContentType { get => contentType; set => contentType = value; }
        /// <summary>
        /// 审核状态
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)), JsonProperty(PropertyName = "status", NullValueHandling = NullValueHandling.Ignore)]
        public XGSmsSignatureStatus Status { get => status; set => status = value; }
        /// <summary>
        /// 签名适用的国家类型
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)), JsonProperty(PropertyName = "countryType", NullValueHandling = NullValueHandling.Ignore)]
        public XGSmsCountryType CountryType { get => countryType; set => countryType = value; }
        /// <summary>
        /// 签名ID，唯一标识一个签名
        /// </summary>
        [JsonProperty(PropertyName = "signatureId", NullValueHandling = NullValueHandling.Ignore)]
        public string SignatureId { get => signatureId; set => signatureId = value; }
        /// <summary>
        /// 签名所属的用户百度云账号
        /// </summary>
        [JsonProperty(PropertyName ="userId", NullValueHandling = NullValueHandling.Ignore)]
        public string UserId { get => userId; set => userId = value; }
        /// <summary>
        /// 审核意见
        /// </summary>
        [JsonProperty(PropertyName ="review", NullValueHandling = NullValueHandling.Ignore)]
        public string Review { get => review; set => review = value; }
        /// <summary>
        /// 对于签名的描述
        /// </summary>
        [JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get => description; set => description = value; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [JsonConverter(typeof(XGSmsDateTimeConverter)), JsonProperty(PropertyName = "createDate", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? CreateDate { get => createDate; set => createDate = value; }
        /// <summary>
        /// 更新时间
        /// </summary>
        [JsonConverter(typeof(XGSmsDateTimeConverter)),  JsonProperty(PropertyName = "updateDate", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? UpdateDate { get => updateDate; set => updateDate = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
