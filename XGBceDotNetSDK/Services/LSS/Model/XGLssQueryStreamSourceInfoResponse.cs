using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.LSS.Model
{
    /// <summary>
    /// 音频信息
    /// </summary>
    public class XGLssStreamAudioInfo
    {
        private string codec;
        private string profile;
        private long? sampleRateInHz;
        private int? channels;
        private int? bitRateInBps;

        /// <summary>
        /// 音频codec，NA表示无音频或未识别
        /// </summary>
        [JsonProperty(PropertyName = "codec", NullValueHandling = NullValueHandling.Ignore)]
        public string Codec { get => codec; set => codec = value; }
        /// <summary>
        /// 音频profile， NA表示无音频或未识别
        /// </summary>
        [JsonProperty(PropertyName = "profile", NullValueHandling = NullValueHandling.Ignore)]
        public string Profile { get => profile; set => profile = value; }
        /// <summary>
        /// 音频采样率，0表示无音频或未识别
        /// </summary>
        [JsonProperty(PropertyName = "sampleRateInHz", NullValueHandling = NullValueHandling.Ignore)]
        public long? SampleRateInHz { get => sampleRateInHz; set => sampleRateInHz = value; }
        /// <summary>
        /// 音频声道数，0表示无音频或未识别
        /// </summary>
        [JsonProperty(PropertyName = "channels", NullValueHandling = NullValueHandling.Ignore)]
        public int? Channels { get => channels; set => channels = value; }
        /// <summary>
        /// 音频实时码率
        /// </summary>
        [JsonProperty(PropertyName = "bitRateInBps", NullValueHandling = NullValueHandling.Ignore)]
        public int? BitRateInBps { get => bitRateInBps; set => bitRateInBps = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }

    /// <summary>
    /// 视频信息
    /// </summary>
    public class XGLssStreamVideoInfo
    {
        private string codec;
        private string profile;
        private string level;
        private int? widthInPixel;
        private int? heightInPixel;
        private double? frameRate;
        private long? bitRateInBps;
        private float? realFPS;

        /// <summary>
        /// 视频codec，NA表示无视频或未识别
        /// </summary>
        [JsonProperty(PropertyName = "codec", NullValueHandling = NullValueHandling.Ignore)]
        public string Codec { get => codec; set => codec = value; }
        /// <summary>
        /// 视频profile，NA表示无视频或未识别
        /// </summary>
        [JsonProperty(PropertyName = "profile", NullValueHandling = NullValueHandling.Ignore)]
        public string Profile { get => profile; set => profile = value; }
        /// <summary>
        /// 视频level，NA表示无视频或未识别
        /// </summary>
        [JsonProperty(PropertyName = "level", NullValueHandling = NullValueHandling.Ignore)]
        public string Level { get => level; set => level = value; }
        /// <summary>
        /// 视频宽度，0表示无视频或未识别
        /// </summary>
        [JsonProperty(PropertyName = "widthInPixel", NullValueHandling = NullValueHandling.Ignore)]
        public int? WidthInPixel { get => widthInPixel; set => widthInPixel = value; }
        /// <summary>
        /// 视频高度，0表示无视频或未识别
        /// </summary>
        [JsonProperty(PropertyName = "heightInPixel", NullValueHandling = NullValueHandling.Ignore)]
        public int? HeightInPixel { get => heightInPixel; set => heightInPixel = value; }
        /// <summary>
        /// 视频标称帧率，0表示无视频或未识别
        /// </summary>
        [JsonProperty(PropertyName = "frameRate", NullValueHandling = NullValueHandling.Ignore)]
        public double? FrameRate { get => frameRate; set => frameRate = value; }
        /// <summary>
        /// 视频实时码率
        /// </summary>
        [JsonProperty(PropertyName = "bitRateInBps", NullValueHandling = NullValueHandling.Ignore)]
        public long? BitRateInBps { get => bitRateInBps; set => bitRateInBps = value; }
        /// <summary>
        /// 视频实时帧率
        /// </summary>
        [JsonProperty(PropertyName = "realFPS", NullValueHandling = NullValueHandling.Ignore)]
        public float? RealFPS { get => realFPS; set => realFPS = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }

    /// <summary>
    /// 查询实时直播源信息响应类
    /// </summary>
    public class XGLssQueryStreamSourceInfoResponse:XGLssResponse
    {
        private string sessionId;
        private string sourceIP;
        private string publishIP;
        private int? score;
        private DateTime? captureTime;
        private long? inputBitRateInBps;
        private XGLssStreamVideoInfo video;
        private XGLssStreamAudioInfo audio;

        public XGLssQueryStreamSourceInfoResponse()
        {
        }

        /// <summary>
        /// 流的唯一ID
        /// </summary>
        [JsonProperty(PropertyName = "sessionId", NullValueHandling = NullValueHandling.Ignore)]
        public string SessionId { get => sessionId; set => sessionId = value; }
        /// <summary>
        /// 返回将直播流推向媒体中心CDN的对应IP
        /// </summary>
        [JsonProperty(PropertyName = "sourceIP", NullValueHandling = NullValueHandling.Ignore)]
        public string SourceIP { get => sourceIP; set => sourceIP = value; }
        /// <summary>
        /// 推流端IP地址
        /// </summary>
        [JsonProperty(PropertyName = "publishIP", NullValueHandling = NullValueHandling.Ignore)]
        public string PublishIP { get => publishIP; set => publishIP = value; }
        /// <summary>
        /// 推流拉流质量评分
        /// <para>[0,100]，100表示质量最好，0 表示质量最差</para>
        /// </summary>
        [JsonProperty(PropertyName = "score", NullValueHandling = NullValueHandling.Ignore)]
        public int? Score { get => score; set => score = value; }
        /// <summary>
        /// 直播源信息采时间
        /// </summary>
        [JsonProperty(PropertyName = "captureTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? CaptureTime { get => captureTime; set => captureTime = value; }
        /// <summary>
        /// 实时输入总码率,包括视频/音频/数据
        /// </summary>
        [JsonProperty(PropertyName = "inputBitRateInBps", NullValueHandling = NullValueHandling.Ignore)]
        public long? InputBitRateInBps { get => inputBitRateInBps; set => inputBitRateInBps = value; }
        /// <summary>
        /// 视频信息
        /// </summary>
        [JsonProperty(PropertyName = "video", NullValueHandling = NullValueHandling.Ignore)]
        public XGLssStreamVideoInfo Video { get => video; set => video = value; }
        /// <summary>
        /// 音频信息
        /// </summary>
        [JsonProperty(PropertyName = "audio", NullValueHandling = NullValueHandling.Ignore)]
        public XGLssStreamAudioInfo Audio { get => audio; set => audio = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
