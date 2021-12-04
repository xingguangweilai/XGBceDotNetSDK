using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.VCR.Model
{
    /// <summary>
    /// 图片审核结果项
    /// <para> 在审核结果中，每个审核类型都对应一个items，表示该子审核的结果。数组中的元素称为审核结果项 </para>
    /// </summary>
    public class XGVcrImageResultItem
    {
        private string subType;
        private string target;
        private double confidence;
        private string label;
        private string extra;
        private XGVcrImageEvidence evidence;

        public XGVcrImageResultItem()
        {
        }

        /// <summary>
        /// 审核项
        /// </summary>
        [JsonProperty(PropertyName = "subType", NullValueHandling = NullValueHandling.Ignore)]
        public string SubType { get => subType; set => subType = value; }
        /// <summary>
        /// 审核物料类型
        /// <para>可选值：thumbnail, character</para>
        /// </summary>
        [JsonProperty(PropertyName = "target", NullValueHandling = NullValueHandling.Ignore)]
        public string Target { get => target; set => target = value; }
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
        /// 额外信息，如有；例如政治敏感人物识别出来的人名
        /// </summary>
        [JsonProperty(PropertyName = "extra", NullValueHandling = NullValueHandling.Ignore)]
        public string Extra { get => extra; set => extra = value; }
        /// <summary>
        /// 审核证据
        /// </summary>
        [JsonProperty(PropertyName = "evidence", NullValueHandling = NullValueHandling.Ignore)]
        public XGVcrImageEvidence Evidence { get => evidence; set => evidence = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
