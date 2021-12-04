using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.SMS.Model
{
    /// <summary>
    /// 变更模板请求类
    /// </summary>
    public class XGModifyTemplateRequest:XGCreateTemplateRequest
    {
        private string templateId;
        public XGModifyTemplateRequest()
        {
        }

        /// <summary>
        /// 模板描述
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty("description")]
        public new string Description { get ; set ; }

        /// <summary>
        /// 模板ID，唯一标识一个模板
        /// <para>必需</para>
        /// </summary>
        [JsonIgnore]
        public string TemplateId { get => templateId; set => templateId = value; }
    }
}
