using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace XGBceDotNetSDK.Services.MEDIA.Model
{
    /// <summary>
    /// highlight 模式下输出控制参数
    /// </summary>
    public class XGMediaThumbnailHighlightOutputCfg
    {
        private float? durationInSecond;
        private float? playbackSpeed;
        private float? frameRate;
        private bool? reverseConcat;

        /// <summary>
        /// 截取片段时长
        /// <para>取值范围：0.1 ~ 7200.0，单位：秒</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "durationInSecond", NullValueHandling = NullValueHandling.Ignore)]
        public float? DurationInSecond { get => durationInSecond; set => durationInSecond = value; }
        /// <summary>
        /// 回放速度
        /// <para>值低于1.0时为减速视频，高于1.0时为加速视频</para>
        /// <para>取值范围：0.05 ~ 20.0</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "playbackSpeed", NullValueHandling = NullValueHandling.Ignore)]
        public float? PlaybackSpeed { get => playbackSpeed; set => playbackSpeed = value; }
        /// <summary>
        /// 输出视频帧率
        /// <para>取值范围：0.1 ~ 60.0，单位：fps</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "frameRate", NullValueHandling = NullValueHandling.Ignore)]
        public float? FrameRate { get => frameRate; set => frameRate = value; }
        /// <summary>
        /// 正播反播合并效果
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "reverseConcat", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ReverseConcat { get => reverseConcat; set => reverseConcat = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }

    /// <summary>
    /// 生成缩略图的规则
    /// </summary>
    public class XGMediaThumbnailCapture
    {
        private XGMediaThumbnailMode? mode;
        private int? frameNumber;
        private float? startTimeInSecond;
        private float? endTimeInSecond;
        private float? intervalInSecond;
        private float? minIntervalInSecond;
        private bool? skipBlackFrame;
        private XGMediaThumbnailHighlightOutputCfg highlightOutputCfg;

        /// <summary>
        /// 生成缩略图的模式
        /// <para>非必需</para>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)), JsonProperty(PropertyName = "mode", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaThumbnailMode? Mode { get => mode; set => mode = value; }
        /// <summary>
        /// 生成缩略图的张数
        /// <para>仅当mode=split时可选</para>
        /// </summary>
        [JsonProperty(PropertyName = "frameNumber", NullValueHandling = NullValueHandling.Ignore)]
        public int? FrameNumber { get => frameNumber; set => frameNumber = value; }
        /// <summary>
        /// 生成缩略图的开始时间
        /// <para>当mode=manual或split时可选</para>
        /// </summary>
        [JsonProperty(PropertyName = "startTimeInSecond", NullValueHandling = NullValueHandling.Ignore)]
        public float? StartTimeInSecond { get => startTimeInSecond; set => startTimeInSecond = value; }
        /// <summary>
        /// 生成缩略图的结束时间
        /// <para>当mode=manual或split时可选，且不得小于start time</para>
        /// </summary>
        [JsonProperty(PropertyName = "endTimeInSecond", NullValueHandling = NullValueHandling.Ignore)]
        public float? EndTimeInSecond { get => endTimeInSecond; set => endTimeInSecond = value; }
        /// <summary>
        /// 生成缩略图的间隔时间
        /// <para>仅当mode=manual时可选</para>
        /// </summary>
        [JsonProperty(PropertyName = "intervalInSecond", NullValueHandling = NullValueHandling.Ignore)]
        public float? IntervalInSecond { get => intervalInSecond; set => intervalInSecond = value; }
        /// <summary>
        /// 生成缩略图的最小间隔时间
        /// <para>仅当mode=split时可选</para>
        /// </summary>
        [JsonProperty(PropertyName = "minIntervalInSecond", NullValueHandling = NullValueHandling.Ignore)]
        public float? MinIntervalInSecond { get => minIntervalInSecond; set => minIntervalInSecond = value; }
        /// <summary>
        /// 是否跳过黑帧
        /// <para>仅当mode=manual或split时可选</para>
        /// </summary>
        [JsonProperty(PropertyName = "skipBlackFrame", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SkipBlackFrame { get => skipBlackFrame; set => skipBlackFrame = value; }
        /// <summary>
        /// highlight 模式下输出控制参数
        /// <para>仅当mode=highlight时可选</para>
        /// </summary>
        [JsonProperty(PropertyName = "highlightOutputCfg", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaThumbnailHighlightOutputCfg HighlightOutputCfg { get => highlightOutputCfg; set => highlightOutputCfg = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }

    /// <summary>
    /// 雪碧图输出参数
    /// </summary>
    public class XGMediaThumbnailSpriteOutputCfg
    {
        private int? rows;
        private int? columns;
        private int? margin;
        private int? padding;
        private bool? keepCellPic;
        private string spriteKeyTag;

        /// <summary>
        /// 雪碧图拼接行数
        /// <para>取值范围：1 ~ 100</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "rows", NullValueHandling = NullValueHandling.Ignore)]
        public int? Rows { get => rows; set => rows = value; }
        /// <summary>
        /// 雪碧图拼接列数
        /// <para>取值范围：1 ~ 100</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "columns", NullValueHandling = NullValueHandling.Ignore)]
        public int? Columns { get => columns; set => columns = value; }
        /// <summary>
        /// 外框宽度
        /// <para>取值范围：1 ~ 1000，单位：px</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "margin", NullValueHandling = NullValueHandling.Ignore)]
        public int? Margin { get => margin; set => margin = value; }
        /// <summary>
        /// 内框宽度
        /// <para>取值范围：1 ~ 1000，单位：px</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "padding", NullValueHandling = NullValueHandling.Ignore)]
        public int? Padding { get => padding; set => padding = value; }
        /// <summary>
        /// 是否保留子图原图
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "keepCellPic", NullValueHandling = NullValueHandling.Ignore)]
        public bool? KeepCellPic { get => keepCellPic; set => keepCellPic = value; }
        /// <summary>
        /// 上传BOS的雪碧图的key中用于标记为雪碧图的tag
        /// <para>最终文件名为 {keyPrefix}+{spriteKeyTag}+{雪碧图序号%05d}，雪碧图中子图按照原视频中的顺序排列</para>
        /// <para>字符串长度范围为1 ~ 100</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "spriteKeyTag", NullValueHandling = NullValueHandling.Ignore)]
        public string SpriteKeyTag { get => spriteKeyTag; set => spriteKeyTag = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }

    /// <summary>
    /// 目标缩略图信息
    /// </summary>
    public class XGMediaThumbnailTarget
    {
        private XGMediaThumbnailFormat? format;
        private XGMediaVideoSizingPolicy? sizingPolicy;
        private int? widthInPixel;
        private int? heightInPixel;
        private float? frameRate;
        private XGMediaGifQuality? gifQuality;
        private XGMediaThumbnailSpriteOutputCfg spriteOutputCfg;

        /// <summary>
        /// 目标缩略图的格式
        /// <para>非必需</para>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)), JsonProperty(PropertyName = "format", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaThumbnailFormat? Format { get => format; set => format = value; }
        /// <summary>
        /// 目标缩略图的尺寸伸缩策略
        /// <para>非必需</para>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)), JsonProperty(PropertyName = "sizingPolicy", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaVideoSizingPolicy? SizingPolicy { get => sizingPolicy; set => sizingPolicy = value; }
        /// <summary>
        /// 目标缩略图的宽
        /// <para>如果视频实际分辨率低于目标分辨率则按照实际分辨率输出</para>
        /// <para>取值范围：10 ~ 2000</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "widthInPixel", NullValueHandling = NullValueHandling.Ignore)]
        public int? WidthInPixel { get => widthInPixel; set => widthInPixel = value; }
        /// <summary>
        /// 目标缩略图的高
        /// <para>如果视频实际分辨率低于目标分辨率则按照实际分辨率输出</para>
        /// <para>取值范围：10 ~ 2000</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "heightInPixel", NullValueHandling = NullValueHandling.Ignore)]
        public int? HeightInPixel { get => heightInPixel; set => heightInPixel = value; }
        /// <summary>
        /// 动图的帧率
        /// <para>仅当format为mp4、gif、webp且mode为manual、split时可选</para>
        /// </summary>
        [JsonProperty(PropertyName = "frameRate", NullValueHandling = NullValueHandling.Ignore)]
        public float? FrameRate { get => frameRate; set => frameRate = value; }
        /// <summary>
        /// gif的质量
        /// <para>非必需</para>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)), JsonProperty(PropertyName = "gifQuality", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaGifQuality? GifQuality { get => gifQuality; set => gifQuality = value; }
        /// <summary>
        /// 雪碧图输出参数设置
        /// <para>仅当抽取多图（即mode=manual/split）,且输出为非动图（即format=jpg/png）时可选</para>
        /// </summary>
        [JsonProperty(PropertyName = "spriteOutputCfg", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaThumbnailSpriteOutputCfg SpriteOutputCfg { get => spriteOutputCfg; set => spriteOutputCfg = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }


    /// <summary>
    /// 创建缩略图模板
    /// </summary>
    public class XGMediaCreateThumbnailPresetRequest:XGAbstractMediaRequest
    {
        private string presetName;
        private string description;
        private XGMediaThumbnailTarget target;

        public XGMediaCreateThumbnailPresetRequest()
        {
        }

        /// <summary>
        /// 缩略图模板名称
        /// <para>必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "presetName", NullValueHandling = NullValueHandling.Ignore)]
        public string PresetName { get => presetName; set => presetName = value; }
        /// <summary>
        /// 缩略图模板描述
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get => description; set => description = value; }
        /// <summary>
        ///目标缩略图信息的集合
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "target", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaThumbnailTarget Target { get => target; set => target = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
