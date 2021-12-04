using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.VCR.Model
{
    /// <summary>
    /// 审核结果项
    /// <para> 在审核结果中，每个审核类型都对应一个items，表示该子审核的结果。数组中的元素称为审核结果项 </para>
    /// </summary>
    public class XGVcrAudioResultItem
    {
        private string subType;
        private string target;
        private int startTimeInSeconds;
        private int endTimeInSeconds;
        private double confidence;
        private string label;
        private string extra;
        private XGVcrAudioEvidence evidence;

        public XGVcrAudioResultItem()
        {
        }

        /// <summary>
        /// 审核项
        /// </summary>
        [JsonProperty(PropertyName = "subType", NullValueHandling = NullValueHandling.Ignore)]
        public string SubType { get => subType; set => subType = value; }
        /// <summary>
        /// 音频审核物料类型，可选值：audio, speech
        /// </summary>
        [JsonProperty(PropertyName = "target", NullValueHandling = NullValueHandling.Ignore)]
        public string Target { get => target; set => target = value; }
        /// <summary>
        /// 物料在音频中的起始秒数，和endTimeInSeconds同时存在，audio/speech审核物料有该属性
        /// </summary>
        [JsonProperty(PropertyName = "startTimeInSeconds", NullValueHandling = NullValueHandling.Ignore)]
        public int StartTimeInSeconds { get => startTimeInSeconds; set => startTimeInSeconds = value; }
        /// <summary>
        /// 物料在音频中的结束秒数，和startTimeInSeconds同时存在
        /// </summary>
        [JsonProperty(PropertyName = "endTimeInSeconds", NullValueHandling = NullValueHandling.Ignore)]
        public int EndTimeInSeconds { get => endTimeInSeconds; set => endTimeInSeconds = value; }
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
        /// <para> target=audio，暂无审核证据 </para>
        /// <para> target=speech，审核证据=text </para>
        /// </summary>
        [JsonProperty(PropertyName = "evidence", NullValueHandling = NullValueHandling.Ignore)]
        public XGVcrAudioEvidence Evidence { get => evidence; set => evidence = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
