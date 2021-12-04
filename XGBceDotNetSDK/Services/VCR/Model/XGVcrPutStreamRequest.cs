using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace XGBceDotNetSDK.Services.VCR.Model
{
    /// <summary>
    /// 提交直播审核请求类
    /// </summary>
    public class XGVcrPutStreamRequest: XGAbstractVcrRequest
    {
        private string source;
        private string preset;
        private string notification;
        private string description;
        private XGVcrNotifyLevel? notifyLevel;
        private float? thumbnailInterval;
        private int? audioInterval;

        public XGVcrPutStreamRequest()
        {
            VcrVersion = XGVcrVersion.v2;
        }

        /// <summary>
        /// 直播流地址，支持RTMP/HTTP拉流
        /// <para>长度不超过1024</para>
        /// <para>必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "source")]
        public string Source { get => source; set => source = value; }
        /// <summary>
        /// 审核模板名称
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "preset", NullValueHandling = NullValueHandling.Ignore)]
        public string Preset { get => preset; set => preset = value; }
        /// <summary>
        /// 通知名称
        /// <para>必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "notification")]
        public string Notification { get => notification; set => notification = value; }
        /// <summary>
        /// 视频描述
        /// <para>默认为空字符串，不超过256字符</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get => description; set => description = value; }
        /// <summary>
        /// 通知等级
        /// <para>默认REVIEW</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)), JsonProperty(PropertyName = "notifyLevel", NullValueHandling = NullValueHandling.Ignore)]
        public XGVcrNotifyLevel? NotifyLevel { get => notifyLevel; set => notifyLevel = value; }
        /// <summary>
        /// 抽帧间隔
        /// <para>>=1s，默认为1s</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "thumbnailInterval", NullValueHandling = NullValueHandling.Ignore)]
        public float? ThumbnailInterval { get => thumbnailInterval; set => thumbnailInterval = value; }
        /// <summary>
        /// 抽音频间隔
        /// <para> >=10s,默认为30s</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "audioInterval", NullValueHandling = NullValueHandling.Ignore)]
        public int? AudioInterval { get => audioInterval; set => audioInterval = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
