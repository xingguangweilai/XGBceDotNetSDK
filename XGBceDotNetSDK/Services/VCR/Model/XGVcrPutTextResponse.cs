using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using XGBceDotNetSDK.BaseClass;

namespace XGBceDotNetSDK.Services.VCR.Model
{
    /// <summary>
    /// 提交文本审核响应类
    /// </summary>
    public class XGVcrPutTextResponse: XGAbstractBceResponse
    {
        private string text;
        private string label;
        private List<XGVcrTextResult> results;
        public XGVcrPutTextResponse()
        {
        }

        /// <summary>
        /// 审核文本
        /// </summary>
        [JsonProperty(PropertyName = "text", NullValueHandling = NullValueHandling.Ignore)]
        public string Source { get => text; set => text = value; }
        /// <summary>
        /// 审核结果标记，可选值：NORMAL/REVIEW/REJECT
        /// </summary>
        [JsonProperty(PropertyName = "label", NullValueHandling = NullValueHandling.Ignore)]
        public string Label { get => label; set => label = value; }
        /// <summary>
        /// 审核结果详情
        /// </summary>
        [JsonProperty(PropertyName = "results", NullValueHandling = NullValueHandling.Ignore)]
        public List<XGVcrTextResult> Results { get => results; set => results = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
