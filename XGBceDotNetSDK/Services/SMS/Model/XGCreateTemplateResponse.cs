using System;
using Newtonsoft.Json;
using XGBceDotNetSDK.BaseClass;

namespace XGBceDotNetSDK.Services.SMS.Model
{
    public class XGCreateTemplateResponse: XGBaseResponse
    {
        private string templateId;
        private string status;

        public XGCreateTemplateResponse()
        {
        }

        /// <summary>
        /// 模板ID，用于唯一标识一个模板
        /// </summary>
        [JsonProperty(PropertyName = "templateId", NullValueHandling = NullValueHandling.Ignore)]
        public string TemplateId { get => templateId; set => templateId = value; }
        /// <summary>
        /// 模板状态
        /// </summary>
        [JsonProperty(PropertyName = "status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get => status; set => status = value; }
    }
}
