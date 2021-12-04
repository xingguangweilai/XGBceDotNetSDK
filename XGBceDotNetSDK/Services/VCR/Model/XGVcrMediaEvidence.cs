using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.VCR.Model
{
    /// <summary>
    /// 视频审核证据
    /// </summary>
    public class XGVcrMediaEvidence
    {
        private string thumbnail;
        private XGVcrEvidenceLocation location;
        private string text;

        public XGVcrMediaEvidence()
        {
        }

        /// <summary>
        /// 缩略图URL
        /// </summary>
        [JsonProperty(PropertyName = "thumbnail", NullValueHandling = NullValueHandling.Ignore)]
        public string Thumbnail { get => thumbnail; set => thumbnail = value; }
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
