using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace XGBceDotNetSDK.Services.MEDIA.Model
{
    /// <summary>
    /// HLS加解密信息
    /// </summary>
    public class XGMediaHLSEncryption
    {
        private XGMediaHLSEncryptionStrategy? strategy;
        private string aesKey;

        /// <summary>
        /// 视频加密策略
        /// <para>必需</para>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)), JsonProperty(PropertyName = "strategy", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaHLSEncryptionStrategy? Strategy { get => strategy; set => strategy = value; }
        /// <summary>
        /// AES128加密密钥
        /// <para>必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "aesKey", NullValueHandling = NullValueHandling.Ignore)]
        public string AesKey { get => aesKey; set => aesKey = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
    /// <summary>
    /// 视频编码的配置选项
    /// </summary>
    public class XGMediaVideoCodecOptions
    {
        private XGMediaVideoCodecProfile? profile;

        /// <summary>
        /// 档次
        /// <para>非必需</para>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)),JsonProperty(PropertyName = "profile", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaVideoCodecProfile? Profile { get => profile; set => profile = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
    /// <summary>
    /// 视频输出信息的集合
    /// </summary>
    public class XGMediaVideoOutInfo
    {
        private XGMediaVideoCodec? codec;
        private long? bitRateInBps;
        private int? crf;
        private float? maxFrameRate;
        private int? maxWidthInPixel;
        private int? maxHeightInPixel;
        private XGMediaVideoSizingPolicy? sizingPolicy;
        private bool? autoAdjustResolution;
        private float? playbackSpeed;

        /// <summary>
        /// 视频编码信息集合
        /// <para>非必需</para>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)), JsonProperty(PropertyName = "codec", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaVideoCodec? Codec { get => codec; set => codec = value; }
        /// <summary>
        /// 视频目标码率
        /// <para>必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "bitRateInBps", NullValueHandling = NullValueHandling.Ignore)]
        public long? BitRateInBps { get => bitRateInBps; set => bitRateInBps = value; }
        /// <summary>
        /// 恒定质量因子
        /// <para>若设置了crf值，bitRateInBps可表示最大目标码率</para>
        /// <para>取值范围：1 ~ 51</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "crf", NullValueHandling = NullValueHandling.Ignore)]
        public int? Crf { get => crf; set => crf = value; }
        /// <summary>
        /// 目标视频最大帧率
        /// <para>取值范围：10,15, 23.97, 24, 25, 29.97, 30, 50, 60</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "maxFrameRate", NullValueHandling = NullValueHandling.Ignore)]
        public float? MaxFrameRate { get => maxFrameRate; set => maxFrameRate = value; }
        /// <summary>
        /// 目标视频的最大宽度
        /// <para>取值范围：128 ~ 4096</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "maxWidthInPixel", NullValueHandling = NullValueHandling.Ignore)]
        public int? MaxWidthInPixel { get => maxWidthInPixel; set => maxWidthInPixel = value; }
        /// <summary>
        /// 目标视频的最大高度
        /// <para>取值范围：	96 ~ 3072</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "maxHeightInPixel", NullValueHandling = NullValueHandling.Ignore)]
        public int? MaxHeightInPixel { get => maxHeightInPixel; set => maxHeightInPixel = value; }
        /// <summary>
        /// 尺寸伸缩策略
        /// <para>非必需</para>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)),JsonProperty(PropertyName = "sizingPolicy", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaVideoSizingPolicy? SizingPolicy { get => sizingPolicy; set => sizingPolicy = value; }
        /// <summary>
        /// 当原视频为竖形时，自动调整模板的宽小于高，保证缩放比最小，反之亦然
        /// <para>仅当sizingPolicy为keep时可以设置</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "autoAdjustResolution", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AutoAdjustResolution { get => autoAdjustResolution; set => autoAdjustResolution = value; }
        /// <summary>
        /// 回放速度
        /// <para>值低于1.0时为减速视频，高于1.0时为加速视频（不可同时指定音频设置）</para>
        /// <para>取值范围：0.05 ~ 20.0</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "playbackSpeed", NullValueHandling = NullValueHandling.Ignore)]
        public float? PlaybackSpeed { get => playbackSpeed; set => playbackSpeed = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
    /// <summary>
    /// 音量相关参数设置
    /// </summary>
    public class XGMediaAudioVolumeAdjust
    {
        private bool? mute;
        private bool? norm;
        private int? gain;

        /// <summary>
        /// 是否进行静音操作
        /// <para>当设置了mute时，Job中不允许有audio类型的insert。mute和其它audio参数同时设置时，优先进行静音（mute）操作</para>
        /// </summary>
        [JsonProperty(PropertyName = "bitRateInBps", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Mute { get => mute; set => mute = value; }
        /// <summary>
        /// 是否进行音频归一化操作
        /// </summary>
        [JsonProperty(PropertyName = "norm", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Norm { get => norm; set => norm = value; }
        /// <summary>
        /// 音量调节的大小
        /// <para>单位db，值为正则增大音量</para>
        /// <para>取值范围：-60 ~ 60</para>
        /// </summary>
        [JsonProperty(PropertyName = "gain", NullValueHandling = NullValueHandling.Ignore)]
        public int? Gain { get => gain; set => gain = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
    /// <summary>
    /// 音频输出信息的集合
    /// </summary>
    public class XGMediaAudioOutInfo
    {
        private int? bitRateInBps;
        private int? sampleRateInHz;
        private int? channels;
        private string pcmFormat;
        private XGMediaAudioVolumeAdjust volumeAdjust;

        /// <summary>
        /// 视频片段的起始时间
        /// </summary>
        [JsonProperty(PropertyName = "bitRateInBps", NullValueHandling = NullValueHandling.Ignore)]
        public int? BitRateInBps { get => bitRateInBps; set => bitRateInBps = value; }
        /// <summary>
        /// 音频采样率
        /// <para>取值范围：22050, 32000, 44100, 48000, 96000</para>
        /// <para>不填写，表示与输入保持一致</para>
        /// </summary>
        [JsonProperty(PropertyName = "sampleRateInHz", NullValueHandling = NullValueHandling.Ignore)]
        public int? SampleRateInHz { get => sampleRateInHz; set => sampleRateInHz = value; }
        /// <summary>
        /// 音频声道数目
        /// <para>取值范围：1, 2</para>
        /// </summary>
        [JsonProperty(PropertyName = "channels", NullValueHandling = NullValueHandling.Ignore)]
        public int? Channels { get => channels; set => channels = value; }
        /// <summary>
        /// PCM音频格式
        /// <para>仅当container=pcm时有效</para>
        /// <para>取值范围：s16le</para>
        /// </summary>
        [JsonProperty(PropertyName = "pcmFormat", NullValueHandling = NullValueHandling.Ignore)]
        public string PcmFormat { get => pcmFormat; set => pcmFormat = value; }
        /// <summary>
        /// 音量相关参数设置
        /// </summary>
        [JsonProperty(PropertyName = "volumeAdjust", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaAudioVolumeAdjust VolumeAdjust { get => volumeAdjust; set => volumeAdjust = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }

    /// <summary>
    /// 截取音视频片段
    /// </summary>
    public class XGMediaClip
    {
        private int? startTimeInSecond;
        private int? durationInSecond;

        /// <summary>
        /// 视频片段的起始时间
        /// </summary>
        [JsonProperty(PropertyName = "startTimeInSecond", NullValueHandling = NullValueHandling.Ignore)]
        public int? StartTimeInSecond { get => startTimeInSecond; set => startTimeInSecond = value; }
        /// <summary>
        /// 视频片段的持续时间
        /// </summary>
        [JsonProperty(PropertyName = "durationInSecond", NullValueHandling = NullValueHandling.Ignore)]
        public int? DurationInSecond { get => durationInSecond; set => durationInSecond = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }

    /// <summary>
    /// 多水印
    /// </summary>
    public class XGMediaWatermark
    {
        private List<string> image;

        /// <summary>
        /// 多水印watermarkId数组
        /// <para>size最大为5</para>
        /// <para>必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "image", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Image { get => image; set => image = value; }

        /// <summary>
        /// 水印是否有效
        /// </summary>
        /// <returns></returns>
        public bool IsValid()
        {
            if(image!=null&&image.Count>0)
            {
                foreach(string waterMarkId in image)
                {
                    if (string.IsNullOrEmpty(waterMarkId) || string.IsNullOrWhiteSpace(waterMarkId))
                        return false;
                }
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }

    /// <summary>
    /// 转码配置信息
    /// </summary>
    public class XGMediaTransCfg
    {
        private XGMediaTransMode? transMode;

        /// <summary>
        /// 转码模式
        /// <para>当转码模式为twopass时，video不能为空。</para>
        /// <para>必需</para>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)),JsonProperty(PropertyName = "transMode", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaTransMode? TransMode { get => transMode; set => transMode = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }

    /// <summary>
    /// 转码额外配置
    /// </summary>
    public class XGMediaTransExtraCfg
    {
        private string watermarkDisableWhitelist;
        private float? segmentDurationInSecond;
        private int? gopLength;
        private bool? skipBlackFrame;
        private bool? horiToVeri;
        private bool? stabilization;

        /// <summary>
        /// 设置不加水印的条件
        /// <para>当前可设置 portrait，表示竖屏视频不加水印</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "watermarkDisableWhitelist", NullValueHandling = NullValueHandling.Ignore)]
        public string WatermarkDisableWhitelist { get => watermarkDisableWhitelist; set => watermarkDisableWhitelist = value; }
        /// <summary>
        /// 设置分片时长
        /// <para>仅当container为hls,a-hls,dash时可以设置</para>
        /// <para>取值范围：3.0 ~ 15.0，浮点数精度为小数点后三位以内</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "segmentDurationInSecond", NullValueHandling = NullValueHandling.Ignore)]
        public float? SegmentDurationInSecond { get => segmentDurationInSecond; set => segmentDurationInSecond = value; }
        /// <summary>
        /// 设置gop长度
        /// <para>仅当配置了video参数时可以设置；当segmentDurationInSecond和gopLength参数共存时，建议保证 segmentDurationInSecond*原视频帧率 为gopLength的整数倍</para>
        /// <para>取值范围：[0, 250]，其中0表示结果视频只包含i帧</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "gopLength", NullValueHandling = NullValueHandling.Ignore)]
        public int? GopLength { get => gopLength; set => gopLength = value; }
        /// <summary>
        /// 智能检测并裁剪片头黑帧，最长截取前5s黑帧
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "skipBlackFrame", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SkipBlackFrame { get => skipBlackFrame; set => skipBlackFrame = value; }
        /// <summary>
        /// 视频横转竖
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "horiToVeri", NullValueHandling = NullValueHandling.Ignore)]
        public bool? HoriToVeri { get => horiToVeri; set => horiToVeri = value; }
        /// <summary>
        /// 视频去抖动
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "stabilization", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Stabilization { get => stabilization; set => stabilization = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }

    /// <summary>
    /// 创建模板请求类
    /// </summary>
    public class XGMediaCreatePresetRequest:XGAbstractMediaRequest
    {
        private string presetName;
        private string description;
        private string container;
        private bool? transmux;
        private XGMediaClip clip;
        private XGMediaAudioOutInfo audio;
        private XGMediaVideoOutInfo video;
        private XGMediaHLSEncryption encryption;
        private string watermarkId;
        private XGMediaWatermark watermarks;
        private XGMediaTransCfg transCfg;

        public XGMediaCreatePresetRequest()
        {
        }

        /// <summary>
        /// 模板名称
        /// <para>必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "presetName", NullValueHandling = NullValueHandling.Ignore)]
        public string PresetName { get => presetName; set => presetName = value; }
        /// <summary>
        /// 转码模板描述
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get => description; set => description = value; }
        /// <summary>
        /// 音视频文件的容器
        /// <para>取值范围：mp4, flv, hls, mp3, m4a, a-hls, pcm, dash, ts</para>
        /// <para>必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "container", NullValueHandling = NullValueHandling.Ignore)]
        public string Container { get => container; set => container = value; }
        /// <summary>
        /// 是否仅执行容器格式转换
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "transmux", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Transmux { get => transmux; set => transmux = value; }
        /// <summary>
        /// 是否截取音视频片段
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "clip", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaClip Clip { get => clip; set => clip = value; }
        /// <summary>
        /// 音频输出信息的集合
        /// <para>不设置audio相关参数则转码输出不包含音频流，如果保留音频流则必须设置此对象</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "audio", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaAudioOutInfo Audio { get => audio; set => audio = value; }
        /// <summary>
        /// 视频输出信息的集合
        /// <para>不设置vedio相关参数则转码输出不包含视频流，如果保留视频流则必须设置此对象</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "video", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaVideoOutInfo Video { get => video; set => video = value; }
        /// <summary>
        /// HLS加解密信息的集合
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "encryption", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaHLSEncryption Encryption { get => encryption; set => encryption = value; }
        /// <summary>
        /// 水印id
        /// <para>当transmux=true时不允许添加水印</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "watermarkId", NullValueHandling = NullValueHandling.Ignore)]
        public string WatermarkId { get => watermarkId; set => watermarkId = value; }
        /// <summary>
        /// 多水印设置
        /// <para>不可同时指定watermarkId和watermarks</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "watermarks", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaWatermark Watermarks { get => watermarks; set => watermarks = value; }
        /// <summary>
        /// 转码额外配置
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "transCfg", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaTransCfg TransCfg { get => transCfg; set => transCfg = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
