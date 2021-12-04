using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace XGBceDotNetSDK.Services.SMS.Model
{
    /// <summary>
    /// 短信签名审核状态
    /// </summary>
    public enum XGSmsSignatureStatus
    {
        /// <summary>
        /// 申请已提交
        /// </summary>
        SUBMITTED,
        /// <summary>
        /// 审核通过，但还不可用
        /// </summary>
        APPROVED,
        /// <summary>
        /// 审核拒绝
        /// </summary>
        REJECTED,
        /// <summary>
        /// 申请通过，签名可用
        /// </summary>
        READY,
        /// <summary>
        /// 审核取消
        /// </summary>
        ABORTED
    }

    /// <summary>
    /// 查看签名列表请求类
    /// </summary>
    public class XGListSignatureRequest:XGSmsRequest
    {
        private string signatureId;
        private string content;
        private XGSmsSignatureStatus? status;
        private XGSmsCountryType? countryType;
        private int pageNo=0;
        private int pageSize=10;

        /// <summary>
        /// 签名内容
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty("content")]
        public string Content { get => content; set => content = value; }
        /// <summary>
        /// 签名审核状态
        /// <para>非必需</para>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)), JsonProperty(PropertyName = "status", NullValueHandling = NullValueHandling.Ignore)]
        public XGSmsSignatureStatus? Status { get => status; set => status = value; }
        /// <summary>
        /// 签名适用的国家类型,默认为DOMESTIC
        /// <para>非必需</para>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)), JsonProperty(PropertyName = "countryType", NullValueHandling = NullValueHandling.Ignore)]
        public XGSmsCountryType? CountryType { get => countryType; set => countryType = value; }
        /// <summary>
        /// 签名ID，唯一标识一个签名
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "signatureId", NullValueHandling = NullValueHandling.Ignore)]
        public string SignatureId { get => signatureId; set => signatureId = value; }
        /// <summary>
        /// 页码
        /// <para>必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "pageNo", NullValueHandling = NullValueHandling.Ignore)]
        public int PageNo { get => pageNo; set{
                if (value < 1) return;
                pageNo = value;
            }}
        /// <summary>
        /// 页数
        /// <para>必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "pageSize", NullValueHandling = NullValueHandling.Ignore)]
        public int PageSize { get => pageSize; set {
                if (value < 1) return;
                pageSize = value;
            } }
    }
}
