using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace XGBceDotNetSDK.Services.SMS.Model
{
    /// <summary>
    /// 短信类型
    /// </summary>
    public enum XGSmsType
    {
        /// <summary>
        /// 普通营销
        /// </summary>
        CommonSale,
        /// <summary>
        /// 普通验证码
        /// </summary>
        CommonVcode,
        /// <summary>
        /// 普通通知
        /// </summary>
        CommonNotice,
        /// <summary>
        /// 物流验证码
        /// </summary>
        ExpressVcode,
        /// <summary>
        /// 物流通知
        /// </summary>
        ExpressNotice,
        /// <summary>
        /// 传统金融营销
        /// </summary>
        FinanceSale,
        /// <summary>
        /// 传统金融验证码
        /// </summary>
        FinanceVcode,
        /// <summary>
        /// 传统金融通知
        /// </summary>
        FinanceNotice,
        /// <summary>
        /// 互联网金融营销
        /// </summary>
        ItfinSale,
        /// <summary>
        /// 互联网金融验证码
        /// </summary>
        ItfinVcode,
        /// <summary>
        /// 互联网金融通知
        /// </summary>
        ItfinNotice,
        /// <summary>
        /// 信用卡营销
        /// </summary>
        CreditcardSale,
        /// <summary>
        /// 信用卡验证码
        /// </summary>
        CreditcardVcode,
        /// <summary>
        /// 信用卡通知
        /// </summary>
        CreditcardNotice,
        /// <summary>
        /// 催收通知
        /// </summary>
        CollectionNotice,
        /// <summary>
        /// 游戏营销
        /// </summary>
        GameSale,
        /// <summary>
        /// 游戏验证码
        /// </summary>
        GameVcode,
        /// <summary>
        /// 游戏通知
        /// </summary>
        GameNotice,
        /// <summary>
        /// 小游戏营销
        /// </summary>
        GamesSale,
        /// <summary>
        /// 小游戏验证码
        /// </summary>
        GamesVcode,
        /// <summary>
        /// 小游戏通知
        /// </summary>
        GamesNotice,
        /// <summary>
        /// 教育营销
        /// </summary>
        EducationSale,
        /// <summary>
        /// 教育验证码
        /// </summary>
        EducationVcode,
        /// <summary>
        /// 教育通知
        /// </summary>
        EducationNotice,
        /// <summary>
        /// 电商营销
        /// </summary>
        EcSale,
        /// <summary>
        /// 电商验证码
        /// </summary>
        EcVcode,
        /// <summary>
        /// 电商通知
        /// </summary>
        EcNotice
    }

    /// <summary>
    /// 创建模板请求类
    /// </summary>
    public class XGCreateTemplateRequest:XGSmsRequest
    {
        private string name;
        private string content;
        private XGSmsType smsType;
        private XGSmsCountryType countryType;
        private string description;

        public XGCreateTemplateRequest()
        {
        }

        /// <summary>
        /// 模板名称
        /// <para>必需</para>
        /// </summary>
        [JsonProperty("name")]
        public string Name { get => name; set => name = value; }
        /// <summary>
        /// 模板内容
        /// <para>必需</para>
        /// </summary>
        [JsonProperty("content")]
        public string Content { get => content; set => content = value; }
        /// <summary>
        /// 短信类型
        /// <para>必需</para>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)),JsonProperty("smsType", NullValueHandling = NullValueHandling.Ignore)]
        public XGSmsType SmsType { get => smsType; set => smsType = value; }
        /// <summary>
        /// 适用国家类型
        /// <para>必需</para>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)), JsonProperty("countryType", NullValueHandling = NullValueHandling.Ignore)]
        public XGSmsCountryType CountryType { get => countryType; set => countryType = value; }
        /// <summary>
        /// 模板描述
        /// <para>必需</para>
        /// </summary>
        [JsonProperty("description")]
        public string Description { get => description; set => description = value; }
    }
}
