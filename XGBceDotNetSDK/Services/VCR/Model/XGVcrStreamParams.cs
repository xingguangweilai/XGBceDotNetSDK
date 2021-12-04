using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace XGBceDotNetSDK.Services.VCR.Model
{
    /// <summary>
    /// 直播审核参数
    /// </summary>
    public class XGVcrStreamParams
    {
        private string preset;
        private XGVcrNotifyLevel notifyLevel;
        private float? thumbnailInterval;
        private int? audioInterval;

        public XGVcrStreamParams()
        {
        }

        /// <summary>
        /// 审核模板名称
        /// </summary>
        [JsonProperty(PropertyName = "preset", NullValueHandling = NullValueHandling.Ignore)]
        public string Preset { get => preset; set => preset = value; }
        /// <summary>
        /// 通知等级
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)), JsonProperty(PropertyName = "notifyLevel", NullValueHandling = NullValueHandling.Ignore)]
        public XGVcrNotifyLevel NotifyLevel { get => notifyLevel; set => notifyLevel = value; }
        /// <summary>
        /// 抽帧间隔
        /// </summary>
        [JsonProperty(PropertyName = "thumbnailInterval", NullValueHandling = NullValueHandling.Ignore)]
        public float? ThumbnailInterval { get => thumbnailInterval; set => thumbnailInterval = value; }
        /// <summary>
        /// 抽音频间隔
        /// </summary>
        [JsonProperty(PropertyName = "audioInterval", NullValueHandling = NullValueHandling.Ignore)]
        public int? AudioInterval { get => audioInterval; set => audioInterval = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
