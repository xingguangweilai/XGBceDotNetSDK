using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using static XGBceDotNetSDK.Services.LSS.Model.XGLssEnum;

namespace XGBceDotNetSDK.Services.LSS.Model
{
    /// <summary>
    /// 多码率下flv直播播放地址列表
    /// </summary>
    public class XGLssStreamPlayFlvUrls
    {
        private string l0;
        private string l1;
        private string l2;
        private string l3;
        private string l4;

        /// <summary>
        /// L0模式flv直播播放地址
        /// </summary>
        [JsonProperty(PropertyName = "L0", NullValueHandling = NullValueHandling.Ignore)]
        public string L0 { get => l0; set => l0 = value; }
        /// <summary>
        /// L1模式flv直播播放地址
        /// </summary>
        [JsonProperty(PropertyName = "L1", NullValueHandling = NullValueHandling.Ignore)]
        public string L1 { get => l1; set => l1 = value; }
        /// <summary>
        /// L2模式flv直播播放地址
        /// </summary>
        [JsonProperty(PropertyName = "L2", NullValueHandling = NullValueHandling.Ignore)]
        public string L2 { get => l2; set => l2 = value; }
        /// <summary>
        /// L3模式flv直播播放地址
        /// </summary>
        [JsonProperty(PropertyName = "L3", NullValueHandling = NullValueHandling.Ignore)]
        public string L3 { get => l3; set => l3 = value; }
        /// <summary>
        /// L4模式flv直播播放地址
        /// </summary>
        [JsonProperty(PropertyName = "L4", NullValueHandling = NullValueHandling.Ignore)]
        public string L4 { get => l4; set => l4 = value; }
    }

    /// <summary>
    /// 多码率下hls直播播放地址列表
    /// </summary>
    public class XGLssStreamPlayRtmpUrls
    {
        private string l0;
        private string l1;
        private string l2;
        private string l3;
        private string l4;

        /// <summary>
        /// L0模式rtmp直播播放地址
        /// </summary>
        [JsonProperty(PropertyName = "L0", NullValueHandling = NullValueHandling.Ignore)]
        public string L0 { get => l0; set => l0 = value; }
        /// <summary>
        /// L1模式rtmp直播播放地址
        /// </summary>
        [JsonProperty(PropertyName = "L1", NullValueHandling = NullValueHandling.Ignore)]
        public string L1 { get => l1; set => l1 = value; }
        /// <summary>
        /// L2模式rtmp直播播放地址
        /// </summary>
        [JsonProperty(PropertyName = "L2", NullValueHandling = NullValueHandling.Ignore)]
        public string L2 { get => l2; set => l2 = value; }
        /// <summary>
        /// L3模式rtmp直播播放地址
        /// </summary>
        [JsonProperty(PropertyName = "L3", NullValueHandling = NullValueHandling.Ignore)]
        public string L3 { get => l3; set => l3 = value; }
        /// <summary>
        /// L4模式rtmp直播播放地址
        /// </summary>
        [JsonProperty(PropertyName = "L4", NullValueHandling = NullValueHandling.Ignore)]
        public string L4 { get => l4; set => l4 = value; }
    }

    /// <summary>
    /// 多码率下hls直播播放地址列表
    /// </summary>
    public class XGLssStreamPlayHlsUrls
    {
        private string l0;
        private string l1;
        private string l2;
        private string l3;
        private string l4;

        /// <summary>
        /// L0模式hls直播播放地址
        /// </summary>
        [JsonProperty(PropertyName = "L0", NullValueHandling = NullValueHandling.Ignore)]
        public string L0 { get => l0; set => l0 = value; }
        /// <summary>
        /// L1模式hls直播播放地址
        /// </summary>
        [JsonProperty(PropertyName = "L1", NullValueHandling = NullValueHandling.Ignore)]
        public string L1 { get => l1; set => l1 = value; }
        /// <summary>
        /// L2模式hls直播播放地址
        /// </summary>
        [JsonProperty(PropertyName = "L2", NullValueHandling = NullValueHandling.Ignore)]
        public string L2 { get => l2; set => l2 = value; }
        /// <summary>
        /// L3模式hls直播播放地址
        /// </summary>
        [JsonProperty(PropertyName = "L3", NullValueHandling = NullValueHandling.Ignore)]
        public string L3 { get => l3; set => l3 = value; }
        /// <summary>
        /// L4模式hls直播播放地址
        /// </summary>
        [JsonProperty(PropertyName = "L4", NullValueHandling = NullValueHandling.Ignore)]
        public string L4 { get => l4; set => l4 = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }

    /// <summary>
    /// 直播播放信息
    /// </summary>
    public class XGLssStreamPlayInfo
    {
        private string hlsUrl;
        private string rtmpUrl;
        private string flvUrl;
        private XGLssStreamPlayHlsUrls hlsUrls;
        private XGLssStreamPlayRtmpUrls rtmpUrls;
        private XGLssStreamPlayFlvUrls flvUrls;

        /// <summary>
        /// hls直播播放地址
        /// </summary>
        [JsonProperty(PropertyName = "hlsUrl", NullValueHandling = NullValueHandling.Ignore)]
        public string HlsUrl { get => hlsUrl; set => hlsUrl = value; }
        /// <summary>
        /// rtmp直播播放地址
        /// </summary>
        [JsonProperty(PropertyName = "rtmpUrl", NullValueHandling = NullValueHandling.Ignore)]
        public string RtmpUrl { get => rtmpUrl; set => rtmpUrl = value; }
        /// <summary>
        /// flv直播播放地址
        /// </summary>
        [JsonProperty(PropertyName = "flvUrl", NullValueHandling = NullValueHandling.Ignore)]
        public string FlvUrl { get => flvUrl; set => flvUrl = value; }
        /// <summary>
        /// 多码率下hls直播播放地址列表
        /// </summary>
        [JsonProperty(PropertyName = "hlsUrls", NullValueHandling = NullValueHandling.Ignore)]
        public XGLssStreamPlayHlsUrls HlsUrls { get => hlsUrls; set => hlsUrls = value; }
        /// <summary>
        /// 多码率下rtmp直播播放地址列表
        /// </summary>
        [JsonProperty(PropertyName = "rtmpUrls", NullValueHandling = NullValueHandling.Ignore)]
        public XGLssStreamPlayRtmpUrls RtmpUrls { get => rtmpUrls; set => rtmpUrls = value; }
        /// <summary>
        /// 多码率下flv直播播放地址列表
        /// </summary>
        [JsonProperty(PropertyName = "flvUrls", NullValueHandling = NullValueHandling.Ignore)]
        public XGLssStreamPlayFlvUrls FlvUrls { get => flvUrls; set => flvUrls = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }

    /// <summary>
    /// 多码率下转码模板列表
    /// </summary>
    public class XGLssTranscodingPresets
    {
        private string l0;
        private string l1;
        private string l2;
        private string l3;
        private string l4;

        /// <summary>
        /// L0模式下使用的转码模板名称
        /// </summary>
        [JsonProperty(PropertyName = "L0", NullValueHandling = NullValueHandling.Ignore)]
        public string L0 { get => l0; set => l0 = value; }
        /// <summary>
        /// L1模式下使用的转码模板名称
        /// </summary>
        [JsonProperty(PropertyName = "L1", NullValueHandling = NullValueHandling.Ignore)]
        public string L1 { get => l1; set => l1 = value; }
        /// <summary>
        /// L2模式下使用的转码模板名称
        /// </summary>
        [JsonProperty(PropertyName = "L2", NullValueHandling = NullValueHandling.Ignore)]
        public string L2 { get => l2; set => l2 = value; }
        /// <summary>
        /// L3模式下使用的转码模板名称
        /// </summary>
        [JsonProperty(PropertyName = "L3", NullValueHandling = NullValueHandling.Ignore)]
        public string L3 { get => l3; set => l3 = value; }
        /// <summary>
        /// L4模式下使用的转码模板名称
        /// </summary>
        [JsonProperty(PropertyName = "L4", NullValueHandling = NullValueHandling.Ignore)]
        public string L4 { get => l4; set => l4 = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }

    /// <summary>
    /// 水印模版
    /// </summary>
    public class XGLssStreamWatermark
    {
        private string image;
        private string timestamp;

        /// <summary>
        /// 图片水印模版名称列表
        /// </summary>
        [JsonProperty(PropertyName = "image", NullValueHandling = NullValueHandling.Ignore)]
        public string Image { get => image; set => image = value; }
        /// <summary>
        /// 时间戳水印模版名称，单模版支持创建一个时间戳水印
        /// </summary>
        [JsonProperty(PropertyName = "timestamp", NullValueHandling = NullValueHandling.Ignore)]
        public string Timestamp { get => timestamp; set => timestamp = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }

    /// <summary>
    /// 即时流统计信息
    /// </summary>
    public class XGLssStreamStatistics
    {
        private long? bandwidthInBps;
        private int? playCount;

        /// <summary>
        /// 当前流的占用带宽(bps)
        /// </summary>
        [JsonProperty(PropertyName = "bandwidthInBps", NullValueHandling = NullValueHandling.Ignore)]
        public long? BandwidthInBps { get => bandwidthInBps; set => bandwidthInBps = value; }
        /// <summary>
        /// 当前流的播放人数
        /// </summary>
        [JsonProperty(PropertyName = "playCount", NullValueHandling = NullValueHandling.Ignore)]
        public int? PlayCount { get => playCount; set => playCount = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }

    /// <summary>
    /// 查询特定Stream请求类
    /// </summary>
    public class XGLssQueryStreamResponse:XGLssResponse
    {
        private string sessionId;
        private string app;
        private string playDomain;
        private string description;
        private XGLssStreamPublishInfo publish;
        private XGLssStreamPlayInfo play;
        private XGLssStreamStatus? status;
        private XGLssStreamingStatus? streamingStatus;
        private DateTime? createTime;
        private string securityPolicy;
        private string preset;
        private XGLssTranscodingPresets presets;
        private string recording;
        private string thumbnail;
        private XGLssStreamWatermark watermarks;
        private string notification;
        private string audit;
        private string scene;
        private XGLssStreamStatistics statistics;

        public XGLssQueryStreamResponse() { }

        /// <summary>
        /// 直播流对应的会话ID
        /// </summary>
        [JsonProperty(PropertyName = "sessionId", NullValueHandling = NullValueHandling.Ignore)]
        public string SessionId { get => sessionId; set => sessionId = value; }
        /// <summary>
        /// app信息
        /// </summary>
        [JsonProperty(PropertyName = "app", NullValueHandling = NullValueHandling.Ignore)]
        public string App { get => app; set => app = value; }
        /// <summary>
        /// 直播播放域名
        /// </summary>
        [JsonProperty(PropertyName = "playDomain", NullValueHandling = NullValueHandling.Ignore)]
        public string PlayDomain { get => playDomain; set => playDomain = value; }
        /// <summary>
        /// 流描述
        /// </summary>
        [JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get => description; set => description = value; }
        /// <summary>
        /// 直播源信息
        /// </summary>
        [JsonProperty(PropertyName = "publish", NullValueHandling = NullValueHandling.Ignore)]
        public XGLssStreamPublishInfo Publish { get => publish; set => publish = value; }
        /// <summary>
        /// 直播状态
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)), JsonProperty(PropertyName = "status", NullValueHandling = NullValueHandling.Ignore)]
        public XGLssStreamStatus? Status { get => status; set => status = value; }
        /// <summary>
        /// 直播流状态
        /// <para>仅当status=ONGOING时存在</para>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)), JsonProperty(PropertyName = "streamingStatus", NullValueHandling = NullValueHandling.Ignore)]
        public XGLssStreamingStatus? StreamingStatus { get => streamingStatus; set => streamingStatus = value; }
        /// <summary>
        /// 流创建时间
        /// </summary>
        [JsonProperty(PropertyName = "createTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? CreateTime { get => createTime; set => createTime = value; }
        /// <summary>
        /// 安全策略
        /// </summary>
        [JsonProperty(PropertyName = "securityPolicy", NullValueHandling = NullValueHandling.Ignore)]
        public string SecurityPolicy { get => securityPolicy; set => securityPolicy = value; }
        /// <summary>
        /// 转码模板
        /// </summary>
        [JsonProperty(PropertyName = "preset", NullValueHandling = NullValueHandling.Ignore)]
        public string Preset { get => preset; set => preset = value; }
        /// <summary>
        /// 多码率下转码模板列表
        /// </summary>
        [JsonProperty(PropertyName = "presets", NullValueHandling = NullValueHandling.Ignore)]
        public XGLssTranscodingPresets Presets { get => presets; set => presets = value; }
        /// <summary>
        /// 录制模板
        /// </summary>
        [JsonProperty(PropertyName = "recording", NullValueHandling = NullValueHandling.Ignore)]
        public string Recording { get => recording; set => recording = value; }
        /// <summary>
        /// 缩略图模板
        /// </summary>
        [JsonProperty(PropertyName = "thumbnail", NullValueHandling = NullValueHandling.Ignore)]
        public string Thumbnail { get => thumbnail; set => thumbnail = value; }
        /// <summary>
        /// 水印模版
        /// <para>包括图片水印模版和时间戳水印模版，每个流不能超过五个水印模版</para>
        /// </summary>
        [JsonProperty(PropertyName = "watermarks", NullValueHandling = NullValueHandling.Ignore)]
        public XGLssStreamWatermark Watermarks { get => watermarks; set => watermarks = value; }
        /// <summary>
        /// 通知
        /// </summary>
        [JsonProperty(PropertyName = "notification", NullValueHandling = NullValueHandling.Ignore)]
        public string Notification { get => notification; set => notification = value; }
        /// <summary>
        /// 内容审核名称
        /// </summary>
        [JsonProperty(PropertyName = "audit", NullValueHandling = NullValueHandling.Ignore)]
        public string Audit { get => audit; set => audit = value; }
        /// <summary>
        /// 直播场景名称
        /// </summary>
        [JsonProperty(PropertyName = "scene", NullValueHandling = NullValueHandling.Ignore)]
        public string Scene { get => scene; set => scene = value; }
        /// <summary>
        /// 即时流统计信息
        /// </summary>
        [JsonProperty(PropertyName = "statistics", NullValueHandling = NullValueHandling.Ignore)]
        public XGLssStreamStatistics Statistics { get => statistics; set => statistics = value; }
        /// <summary>
        /// 直播播放信息
        /// </summary>
        [JsonProperty(PropertyName = "play", NullValueHandling = NullValueHandling.Ignore)]
        public XGLssStreamPlayInfo Play { get => play; set => play = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
