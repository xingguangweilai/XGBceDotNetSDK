using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.VCR.Model
{
    /// <summary>
    /// 文本审核结果项
    /// </summary>
    public class XGVcrTextResultItem
    {
        private double confidence;
        private string label;
        private string extra;
        public XGVcrTextResultItem()
        {
        }

        /// <summary>
        /// 该审核结果项的置信度，0~100的浮点数
        /// </summary>
        [JsonProperty(PropertyName = "confidence", NullValueHandling = NullValueHandling.Ignore)]
        public double Confidence { get => confidence; set => confidence = value; }
        /// <summary>
        /// 审核结果项标记
        /// </summary>
        [JsonProperty(PropertyName = "label", NullValueHandling = NullValueHandling.Ignore)]
        public string Label { get => label; set => label = value; }
        /// <summary>
        /// 额外信息，例如涉政、暴恐、违禁敏感词
        /// </summary>
        [JsonProperty(PropertyName = "extra", NullValueHandling = NullValueHandling.Ignore)]
        public string Extra { get => extra; set => extra = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
