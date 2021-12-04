using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.VCR.Model
{
    /// <summary>
    /// 图片审核证据
    /// </summary>
    public class XGVcrImageEvidence
    {
        private XGVcrEvidenceLocation location;
        private string text;

        public XGVcrImageEvidence()
        {
        }

        /// <summary>
        /// 证据位置信息
        /// </summary>
        [JsonProperty(PropertyName = "location", NullValueHandling = NullValueHandling.Ignore)]
        public XGVcrEvidenceLocation Location { get => location; set => location = value; }
        /// <summary>
        /// 文本证据
        /// </summary>
        [JsonProperty(PropertyName = "text", NullValueHandling = NullValueHandling.Ignore)]
        public string Text { get => text; set => text = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
