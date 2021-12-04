using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.SMS.Model
{
    /// <summary>
    /// 短信下发类
    /// </summary>
    public class XGSendMessageV3Request: XGSmsRequest
    {
        /// <summary>
        /// 手机号码,支持单个或多个手机号，多个手机号之间以英文逗号分隔， 一次请求最多支持200个手机号。
        ///  <para> 国际/港澳台号码请按照E.164规范表示，例如台湾手机号以+886开头，”+“不能省略。 </para>
        ///   <para> 必需 </para> 
        /// </summary>
        [JsonProperty("mobile")]
        public string Mobile { get; set; }
        /// <summary>
        /// 短信模板ID，模板申请成功后自动创建，全局内唯一
        /// <para> 必需 </para> 
        /// </summary>
        [JsonProperty("template")]
        public string Template { get; set; }
        /// <summary>
        /// 短信签名ID，签名表申请成功后自动创建，全局内唯一
        /// <para> 必需 </para> 
        /// </summary>
        [JsonProperty("signatureId")]
        public string SignatureId { get; set; }
        /// <summary>
        /// 模板变量内容，用于替换短信模板中定义的变量
        /// <para> 必需 </para> 
        /// </summary>
        [JsonProperty("contentVar")]
        public Dictionary<string, string> ContentVar { get; set; }
        /// <summary>
        /// 用户自定义参数，格式为字符串，状态回调时会回传该值
        /// <para> 非必需 </para> 
        /// </summary>
        [JsonProperty(PropertyName = "custom", NullValueHandling = NullValueHandling.Ignore)]
        public string Custom { get; set; }
        /// <summary>
        /// 通道自定义扩展码，上行回调时会回传该值，其格式为纯数字串。
        /// <para> 默认为不开通，请求时无需设置该参数。如需开通请联系SMS帮助申请 </para>
        /// <para> 非必需 </para> 
        /// </summary>
        [JsonProperty(PropertyName = "userExtId", NullValueHandling = NullValueHandling.Ignore)]
        public string UserExtId { get; set; }
        [JsonProperty(PropertyName = "merchantUrlId", NullValueHandling = NullValueHandling.Ignore)]
        public string CallbackUrlId { get; set; }

        public XGSendMessageV3Request()
        {
        }

        
    }
}
