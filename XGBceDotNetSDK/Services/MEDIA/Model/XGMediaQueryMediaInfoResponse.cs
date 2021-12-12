using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.MEDIA.Model
{
    /// <summary>
    /// 音频信息
    /// </summary>
    public class XGMediaAudioInfo
    {
        private string codec;
        private int? channels;
        private long? sampleRateInHz;
        private long? bitRateInBps;

        /// <summary>
        /// 音频文件的编码规格
        /// </summary>
        [JsonProperty(PropertyName = "codec", NullValueHandling = NullValueHandling.Ignore)]
        public string Codec { get => codec; set => codec = value; }
        /// <summary>
        /// 音频文件的声道信息
        /// </summary>
        [JsonProperty(PropertyName = "channels", NullValueHandling = NullValueHandling.Ignore)]
        public int? Channels { get => channels; set => channels = value; }
        /// <summary>
        /// 音频文件的采样率
        /// </summary>
        [JsonProperty(PropertyName = "sampleRateInHz", NullValueHandling = NullValueHandling.Ignore)]
        public long? SampleRateInHz { get => sampleRateInHz; set => sampleRateInHz = value; }
        /// <summary>
        /// 音频文件的码率
        /// </summary>
        [JsonProperty(PropertyName = "bitRateInBps", NullValueHandling = NullValueHandling.Ignore)]
        public long? BitRateInBps { get => bitRateInBps; set => bitRateInBps = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }

    /// <summary>
    /// 视频信息
    /// </summary>
    public class XGMediaVideoInfo
    {
        private string codec;
        private int? heightInPixel;
        private int? widthInPixel;
        private long? bitRateInBps;
        private float? frameRate;
        private float? rotate;
        private string dar;

        /// <summary>
        /// 视频文件的编码规格
        /// </summary>
        [JsonProperty(PropertyName = "codec", NullValueHandling = NullValueHandling.Ignore)]
        public string Codec { get => codec; set => codec = value; }
        /// <summary>
        /// 视频高度
        /// </summary>
        [JsonProperty(PropertyName = "heightInPixel", NullValueHandling = NullValueHandling.Ignore)]
        public int? HeightInPixel { get => heightInPixel; set => heightInPixel = value; }
        /// <summary>
        /// 视频宽度
        /// </summary>
        [JsonProperty(PropertyName = "widthInPixel", NullValueHandling = NullValueHandling.Ignore)]
        public int? WidthInPixel { get => widthInPixel; set => widthInPixel = value; }
        /// <summary>
        /// 视频媒体的码流
        /// </summary>
        [JsonProperty(PropertyName = "bitRateInBps", NullValueHandling = NullValueHandling.Ignore)]
        public long? BitRateInBps { get => bitRateInBps; set => bitRateInBps = value; }
        /// <summary>
        /// 视频媒体的帧率
        /// </summary>
        [JsonProperty(PropertyName = "frameRate", NullValueHandling = NullValueHandling.Ignore)]
        public float? FrameRate { get => frameRate; set => frameRate = value; }
        /// <summary>
        /// 旋转角度（部分视频包含该参数）
        /// </summary>
        [JsonProperty(PropertyName = "rotate", NullValueHandling = NullValueHandling.Ignore)]
        public float? Rotate { get => rotate; set => rotate = value; }
        /// <summary>
        /// 视频显示宽高比
        /// <para>如 "16:9" （部分视频包含该参数）</para>
        /// </summary>
        [JsonProperty(PropertyName = "dar", NullValueHandling = NullValueHandling.Ignore)]
        public string Dar { get => dar; set => dar = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
    /// <summary>
    /// 查询指定媒体信息响应类
    /// </summary>
    public class XGMediaQueryMediaInfoResponse:XGMediaResponse
    {
        private string bucket;
        private string key;
        private long? fileSizeInByte;
        private long? durationInSecond;
        private string container;
        private string etag;
        private string type;
        private XGMediaVideoInfo video;
        private XGMediaAudioInfo audio;

        public XGMediaQueryMediaInfoResponse()
        {
        }

        /// <summary>
        /// 音视频文件所在的BOS的Bucket
        /// </summary>
        [JsonProperty(PropertyName = "bucket", NullValueHandling = NullValueHandling.Ignore)]
        public string Bucket { get => bucket; set => bucket = value; }
        /// <summary>
        /// 音视频文件的BOS的Key）
        /// </summary>
        [JsonProperty(PropertyName = "key", NullValueHandling = NullValueHandling.Ignore)]
        public string Key { get => key; set => key = value; }
        /// <summary>
        /// 音视频文件的大小
        /// </summary>
        [JsonProperty(PropertyName = "fileSizeInByte", NullValueHandling = NullValueHandling.Ignore)]
        public long? FileSizeInByte { get => fileSizeInByte; set => fileSizeInByte = value; }
        /// <summary>
        /// 音视频媒体时长
        /// </summary>
        [JsonProperty(PropertyName = "durationInSecond", NullValueHandling = NullValueHandling.Ignore)]
        public long? DurationInSecond { get => durationInSecond; set => durationInSecond = value; }
        /// <summary>
        /// 音视频文件的容器类型
        /// </summary>
        [JsonProperty(PropertyName = "container", NullValueHandling = NullValueHandling.Ignore)]
        public string Container { get => container; set => container = value; }
        /// <summary>
        /// 文件的版本标识
        /// </summary>
        [JsonProperty(PropertyName = "etag", NullValueHandling = NullValueHandling.Ignore)]
        public string Etag { get => etag; set => etag = value; }
        /// <summary>
        /// 文件类型
        /// </summary>
        [JsonProperty(PropertyName = "type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get => type; set => type = value; }
        /// <summary>
        /// 视频信息集合
        /// </summary>
        [JsonProperty(PropertyName = "video", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaVideoInfo Video { get => video; set => video = value; }
        /// <summary>
        /// 音频信息集合
        /// </summary>
        [JsonProperty(PropertyName = "audio", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaAudioInfo Audio { get => audio; set => audio = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
