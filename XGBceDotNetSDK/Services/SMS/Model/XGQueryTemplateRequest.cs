using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.SMS.Model
{
    /// <summary>
    /// 查询模板请求类
    /// </summary>
    public class XGQueryTemplateRequest:XGSmsRequest
    {
        private string templateId;
        public XGQueryTemplateRequest()
        {
        }

        /// <summary>
        /// 模板ID，用于唯一标识一个模板
        /// <para>必需</para>
        /// </summary>
        [JsonIgnore]
        public string TemplateId { get => templateId; set => templateId = value; }
    }
}
