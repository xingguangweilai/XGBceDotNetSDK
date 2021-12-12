using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace XGBceDotNetSDK.Services.MEDIA.Model
{
    /// <summary>
    /// 目标缩略图信息的集合
    /// </summary>
    public class XGMediaThumbnailTargetInfo
    {
        private string targetBucket;
        private string keyPrefix;
        private List<string> keys;
        private XGMediaThumbnailFormat? format;
        private XGMediaVideoSizingPolicy? sizingPolicy;
        private int? widthInPixel;
        private int? heightInPixel;
        private float? frameRate;
        private XGMediaGifQuality? gifQuality;
        private XGMediaThumbnailSpriteOutputCfg spriteOutputCfg;

        /// <summary>
        /// 目标缩略图的BOS Bucket
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "targetBucket", NullValueHandling = NullValueHandling.Ignore)]
        public string TargetBucket { get => targetBucket; set => targetBucket = value; }
        /// <summary>
        /// 目标缩略图的BOS Key的前缀
        /// <para>mode=auto/idl/highlight 时目标文件名为 {keyPrefix}，mode=manual/split/shot 时目标文件名为 {keyPrefix}加截图时间点</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "keyPrefix", NullValueHandling = NullValueHandling.Ignore)]
        public string KeyPrefix { get => keyPrefix; set => keyPrefix = value; }
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
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "widthInPixel", NullValueHandling = NullValueHandling.Ignore)]
        public int? WidthInPixel { get => widthInPixel; set => widthInPixel = value; }
        /// <summary>
        /// 目标缩略图的高
        /// <para>如果视频实际分辨率低于目标分辨率则按照实际分辨率输出</para>
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
        /// <para>仅当format为gif且mode为manual、split时可选</para>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)), JsonProperty(PropertyName = "gifQuality", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaGifQuality? GifQuality { get => gifQuality; set => gifQuality = value; }
        /// <summary>
        /// 雪碧图输出参数设置
        /// <para>仅当抽取多图（即mode=manual/split）,且输出为非动图（即format=jpg/png）时可选</para>
        /// </summary>
        [JsonProperty(PropertyName = "spriteOutputCfg", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaThumbnailSpriteOutputCfg SpriteOutputCfg { get => spriteOutputCfg; set => spriteOutputCfg = value; }
        /// <summary>
        /// 目标缩略图的BOS的Key的集合
        /// <para>响应参数中使用</para>
        /// </summary>
        [JsonProperty(PropertyName = "keys", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Keys { get => keys; set => keys = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }

    /// <summary>
    /// 输入视频信息的集合
    /// </summary>
    public class XGMediaThumbnailVideoSource
    {
        private string sourceBucket;
        private string key;

        /// <summary>
        /// 输入视频文件的BOS Bucket
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "sourceBucket", NullValueHandling = NullValueHandling.Ignore)]
        public string SourceBucket { get => sourceBucket; set => sourceBucket = value; }
        /// <summary>
        /// 输入视频文件的BOS Key，支持public bucket下的hls（即key为m3u8文件）
        /// <para>必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "key", NullValueHandling = NullValueHandling.Ignore)]
        public string Key { get => key; set => key = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }

    /// <summary>
    /// 创建缩略图任务请求类
    /// </summary>
    public class XGMediaCreateThumbnailJobRequest:XGAbstractMediaRequest
    {
        private string pipelineName;
        private string presetName;
        private XGMediaThumbnailVideoSource source;
        private XGMediaThumbnailTargetInfo target;
        private XGMediaThumbnailCapture capture;
        private XGMediaDelogoArea delogoArea;
        private List<XGMediaDelogoArea> delogoAreas;
        private XGMediaCrop crop;

        public XGMediaCreateThumbnailJobRequest()
        {
        }

        /// <summary>
        /// 任务所属的pipelineName	
        /// <para>必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "pipelineName", NullValueHandling = NullValueHandling.Ignore)]
        public string PipelineName { get => pipelineName; set => pipelineName = value; }
        /// <summary>
        /// 任务的模板名称（模板和job中重复内容以job中为准）
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "presetName", NullValueHandling = NullValueHandling.Ignore)]
        public string PresetName { get => presetName; set => presetName = value; }
        /// <summary>
        /// 输入视频信息的集合
        /// <para>必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "source", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaThumbnailVideoSource Source { get => source; set => source = value; }
        /// <summary>
        /// 目标缩略图信息的集合
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "target", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaThumbnailTargetInfo Target { get => target; set => target = value; }
        /// <summary>
        /// 生成缩略图的规则
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "capture", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaThumbnailCapture Capture { get => capture; set => capture = value; }
        /// <summary>
        /// 去水印参数，描述水印位置区域。
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "delogoAreas", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaDelogoArea DelogoArea { get => delogoArea; set => delogoArea = value; }
        /// <summary>
        /// 去水印参数，描述水印位置区域。
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "delogoAreas", NullValueHandling = NullValueHandling.Ignore)]
        public List<XGMediaDelogoArea> DelogoAreas { get => delogoAreas; set => delogoAreas = value; }
        /// <summary>
        /// 黑边裁剪参数
        /// <para>描述除去黑边后的有效区域（不可同时设置crop和shrinkToFit）</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "crop", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaCrop Crop { get => crop; set => crop = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
