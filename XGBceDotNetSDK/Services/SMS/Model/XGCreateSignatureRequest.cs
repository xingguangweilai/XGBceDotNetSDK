using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace XGBceDotNetSDK.Services.SMS.Model
{
    /// <summary>
    /// 短信签名类型
    /// </summary>
    public enum XGSmsContentType
    {
        /// <summary>
        /// 企业
        /// </summary>
        Enterprise,
        /// <summary>
        /// 移动应用名称
        /// </summary>
        MobileApp,
        /// <summary>
        /// 工信部备案的网站名称
        /// </summary>
        Web,
        /// <summary>
        /// 微信公众号名称
        /// </summary>
        WeChatPublic,
        /// <summary>
        /// 商标名称
        /// </summary>
        Brand,
        /// <summary>
        /// 其他
        /// </summary>
        Else
    }
    /// <summary>
    /// 适用国家类型
    /// </summary>
    public enum XGSmsCountryType
    {
        /// <summary>
        /// 国内
        /// </summary>
        DOMESTIC,
        /// <summary>
        /// 国际/港澳台
        /// </summary>
        INTERNATIONAL,
        /// <summary>
        /// 全球
        /// </summary>
        GLOBAL
    }

    /// <summary>
    /// 申请签名
    /// <para> 接口文档：https://cloud.baidu.com/doc/SMS/s/3kijycp30 </para>
    /// </summary>
    public class XGCreateSignatureRequest: XGSmsRequest
    {

        private string content;
        private XGSmsContentType contentType;
        private string description;
        private XGSmsCountryType countryType;
        private string signatureFileBase64;
        private string signatureFileFormat;

        public XGCreateSignatureRequest()
        {
        }

        /// <summary>
        /// 签名内容
        /// <para>必需</para>
        /// </summary>
        [JsonProperty("content", NullValueHandling = NullValueHandling.Ignore)]
        public string Content { get => content; set => content = value; }
        /// <summary>
        /// 短信签名类型。
        /// <para>必需</para>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)), JsonProperty("contentType", NullValueHandling = NullValueHandling.Ignore)]
        public XGSmsContentType ContentType { get => contentType; set => contentType = value; }
        /// <summary>
        /// 对于签名的描述
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get => description; set => description = value; }
        /// <summary>
        /// 签名适用的国家类型,默认为DOMESTIC
        /// <para>非必需</para>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)),JsonProperty(PropertyName = "countryType", NullValueHandling = NullValueHandling.Ignore)]
        public XGSmsCountryType CountryType { get => countryType; set => countryType = value; }
        /// <summary>
        /// 签名的证明文件经过base64编码后的字符串。文件大小不超过2MB。
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "signatureFileBase64", NullValueHandling = NullValueHandling.Ignore)]
        public string SignatureFileBase64 { get => signatureFileBase64; set => signatureFileBase64 = value; }
        /// <summary>
        /// 签名证明文件的格式，目前支持JPG、PNG、JPEG三种格式
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "signatureFileFormat", NullValueHandling = NullValueHandling.Ignore)]
        public string SignatureFileFormat { get => signatureFileFormat; set => signatureFileFormat = value; }
    }
}
