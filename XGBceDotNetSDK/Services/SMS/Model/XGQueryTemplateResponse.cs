using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.SMS.Model
{
    public class XGQueryTemplateResponse:XGSmsResponse
    {
        private string name;
        private string templateId;
        private string userId;
        private string content;
        private string smsType;
        private string status;
        private string countryType;
        private string review;
        private string description;
        private DateTime? createDate;
        private DateTime? updateDate;

        public XGQueryTemplateResponse()
        {
        }

        /// <summary>
        /// 模板内容
        /// 必需
        /// </summary>
        [JsonProperty(PropertyName = "content", NullValueHandling = NullValueHandling.Ignore)]
        public string Content { get => content; set => content = value; }
        /// <summary>
        /// 短信类型
        /// </summary>
        [JsonProperty(PropertyName = "smsType", NullValueHandling = NullValueHandling.Ignore)]
        public string SmsType { get => smsType; set => smsType = value; }
        /// <summary>
        /// 审核状态
        /// </summary>
        [JsonProperty(PropertyName = "status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get => status; set => status = value; }
        /// <summary>
        /// 签名适用的国家类型,默认为DOMESTIC
        ///DOMESTIC：国内
        ///INTERNATIONAL：国际/港澳台
        ///GLOBAL：全球均适用
        /// </summary>
        [JsonProperty(PropertyName = "countryType", NullValueHandling = NullValueHandling.Ignore)]
        public string CountryType { get => countryType; set => countryType = value; }
        /// <summary>
        /// 模板ID，用于唯一标识一个模板
        /// </summary>
        [JsonProperty(PropertyName = "templateId", NullValueHandling = NullValueHandling.Ignore)]
        public string TemplateId { get => templateId; set => templateId = value; }
        /// <summary>
        /// 签名所属的用户百度云账号
        /// </summary>
        [JsonProperty(PropertyName = "userId", NullValueHandling = NullValueHandling.Ignore)]
        public string UserId { get => userId; set => userId = value; }
        /// <summary>
        /// 审核意见
        /// </summary>
        [JsonProperty(PropertyName = "review", NullValueHandling = NullValueHandling.Ignore)]
        public string Review { get => review; set => review = value; }
        /// <summary>
        /// 对于签名的描述
        /// </summary>
        [JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get => description; set => description = value; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [JsonConverter(typeof(XGSmsDateTimeConverter)),JsonProperty(PropertyName = "createDate", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? CreateDate { get => createDate; set => createDate = value; }
        /// <summary>
        /// 更新时间
        /// </summary>
        [JsonConverter(typeof(XGSmsDateTimeConverter)),JsonProperty(PropertyName = "updateDate", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? UpdateDate { get => updateDate; set => updateDate = value; }
        /// <summary>
        /// 模板名称
        /// </summary>
        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get => name; set => name = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
