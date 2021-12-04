using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace XGBceDotNetSDK.Services.SMS.Model
{
    /// <summary>
    /// 短信模板审核状态
    /// </summary>
    public enum XGSmsTemplateStatus
    {
        /// <summary>
        /// 申请已提交
        /// </summary>
        SUBMITTED,
        /// <summary>
        /// 审核通过
        /// </summary>
        APPROVED,
        /// <summary>
        /// 审核未通过
        /// </summary>
        REJECTED,
        /// <summary>
        /// 模板可用
        /// </summary>
        READY,
        /// <summary>
        /// 模板被废弃
        /// </summary>
        DEPRECATED,
        /// <summary>
        /// 审核取消
        /// </summary>
        ABORTED
    }

    /// <summary>
    /// 查看模板列表请求类
    /// </summary>
    public class XGListTemplateRequest:XGSmsRequest
    {
        private string name;
        private string content;
        private string templateId;
        private XGSmsType? smsType;
        private XGSmsTemplateStatus? status;
        private XGSmsCountryType? countryType;
        private int pageNo;
        private int pageSize;

        public XGListTemplateRequest()
        {
        }

        /// <summary>
        /// 模板名称
        /// <para>必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get => name; set => name = value; }
        /// <summary>
        /// 模板内容
        /// <para>必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "content", NullValueHandling = NullValueHandling.Ignore)]
        public string Content { get => content; set => content = value; }
        /// <summary>
        /// 短信类型
        /// <para>必需</para>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)), JsonProperty(PropertyName = "smsType", NullValueHandling = NullValueHandling.Ignore)]
        public XGSmsType? SmsType { get => smsType; set => smsType = value; }
        /// <summary>
        /// 审核状态
        /// <para>必需</para>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)), JsonProperty(PropertyName = "status", NullValueHandling = NullValueHandling.Ignore)]
        public XGSmsTemplateStatus? Status { get => status; set => status = value; }
        /// <summary>
        /// 适用国家类型
        /// <para>必需</para>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)), JsonProperty(PropertyName = "countryType", NullValueHandling = NullValueHandling.Ignore)]
        public XGSmsCountryType? CountryType { get => countryType; set => countryType = value; }
        /// <summary>
        /// 模板描述
        /// <para>必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "templateId", NullValueHandling = NullValueHandling.Ignore)]
        public string TemplateId { get => templateId; set => templateId = value; }
        /// <summary>
        /// 页码
        /// <para>必需</para>
        /// </summary>
        [JsonIgnore]
        public int PageNo
        {
            get => pageNo; set
            {
                if (value < 1) return;
                pageNo = value;
            }
        }
        /// <summary>
        /// 页数
        /// <para>必需</para>
        /// </summary>
        [JsonIgnore]
        public int PageSize
        {
            get => pageSize; set
            {
                if (value < 1) return;
                pageSize = value;
            }
        }

    }
}
