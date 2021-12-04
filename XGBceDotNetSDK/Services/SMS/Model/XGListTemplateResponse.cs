using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.SMS.Model
{
    public class XGListTemplateResponse:XGSmsResponse
    {
        private List<XGQueryTemplateResponse> templates;
        private int? totalCount;

        public XGListTemplateResponse()
        {
        }

        /// <summary>
        /// 短信模板列表
        /// </summary>
        [JsonProperty(PropertyName = "templates", NullValueHandling = NullValueHandling.Ignore)]
        public List<XGQueryTemplateResponse> Templates { get => templates; set => templates = value; }
        /// <summary>
        /// 总数
        /// </summary>
        [JsonProperty(PropertyName = "totalCount", NullValueHandling = NullValueHandling.Ignore)]
        public int? TotalCount { get => totalCount; set => totalCount = value; }

        public override string ToString()
        {
            return GetType().ToString() +"\n"+ JsonConvert.SerializeObject(this);
        }
    }
}
