using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace XGBceDotNetSDK.Services.MEDIA.Model
{
    /// <summary>
    /// 有效显示起止时间
    /// </summary>
    public class XGMediaInsertTimeline
    {
        private long? startTimeInMillisecond;
        private long? durationInMillisecond;

        /// <summary>
        /// 水印、图片、文本水印等的显示起始时间，单位：豪秒
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "startTimeInMillisecond", NullValueHandling = NullValueHandling.Ignore)]
        public long? StartTimeInMillisecond { get => startTimeInMillisecond; set => startTimeInMillisecond = value; }
        /// <summary>
        /// 水印、图片、文本水印等的显示持续时间，单位：豪秒
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "durationInMillisecond", NullValueHandling = NullValueHandling.Ignore)]
        public long? DurationInMillisecond { get => durationInMillisecond; set => durationInMillisecond = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }

    /// <summary>
    /// 显示位置
    /// </summary>
    public class XGMediaInsertLayout
    {
        private XGMediaVerticalAlignment? verticalAlignment;
        private XGMediaHorizontalAlignment? horizontalAlignment;
        private int? verticalOffsetInPixel;
        private int? horizontalOffsetInPixel;

        /// <summary>
        /// 垂直对齐方式
        /// <para>非必需</para>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)),JsonProperty(PropertyName = "verticalAlignment", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaVerticalAlignment? VerticalAlignment { get => verticalAlignment; set => verticalAlignment = value; }
        /// <summary>
        /// 水平对齐方式
        /// <para>非必需</para>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)), JsonProperty(PropertyName = "horizontalAlignment", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaHorizontalAlignment? HorizontalAlignment { get => horizontalAlignment; set => horizontalAlignment = value; }
        /// <summary>
        /// 垂直偏移
        /// <para>该参数仅在verticalAlignment设置为top或bottom时有效，单位：像素</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "verticalOffsetInPixel", NullValueHandling = NullValueHandling.Ignore)]
        public int? VerticalOffsetInPixel { get => verticalOffsetInPixel; set => verticalOffsetInPixel = value; }
        /// <summary>
        /// 水平偏移
        /// <para>该参数仅在horizontalAlignment设置为left或right时有效，单位：像素</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "horizontalOffsetInPixel", NullValueHandling = NullValueHandling.Ignore)]
        public int? HorizontalOffsetInPixel { get => horizontalOffsetInPixel; set => horizontalOffsetInPixel = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }

    }
    /// <summary>
    /// 文本字体
    /// </summary>
    public class XGMediaInsertTextFont
    {
        private string family;
        private int? sizeInPoint;

        /// <summary>
        /// 字体系列
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "family", NullValueHandling = NullValueHandling.Ignore)]
        public string Family { get => family; set => family = value; }
        /// <summary>
        /// 字体大小
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "sizeInPoint", NullValueHandling = NullValueHandling.Ignore)]
        public int? SizeInPoint { get => sizeInPoint; set => sizeInPoint = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }

    /// <summary>
    /// 待插入（叠加）的内容
    /// <para>类型可以为图片、视频、音频、字幕、文本水印等</para>
    /// </summary>
    public class XGMediaInsert
    {
        private string bucket;
        private string key;
        private XGMediaInsertType? type;
        private string text;
        private XGMediaInsertTextFont font;
        private XGMediaInsertTimeline timeline;

        /// <summary>
        /// BOS存储上insert文件Bucket
        /// <para>type 为 text 时不可设置，否则必须设置	</para>
        /// </summary>
        [JsonProperty(PropertyName = "bucket", NullValueHandling = NullValueHandling.Ignore)]
        public string Bucket { get => bucket; set => bucket = value; }
        /// <summary>
        /// BOS存储上insert文件Key
        /// <para>type 为 text 时不可设置，否则必须设置</para>
        /// </summary>
        [JsonProperty(PropertyName = "key", NullValueHandling = NullValueHandling.Ignore)]
        public string Key { get => key; set => key = value; }
        /// <summary>
        /// insert类型
        /// <para>非必需</para>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)),JsonProperty(PropertyName = "type", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaInsertType? Type { get => type; set => type = value; }
        /// <summary>
        /// 文本水印内容
        /// <para>当且仅当 type 为 text 时设置</para>
        /// </summary>
        [JsonProperty(PropertyName = "text", NullValueHandling = NullValueHandling.Ignore)]
        public string Text { get => text; set => text = value; }
        /// <summary>
        /// 字体效果
        /// <para>当且仅当 type 为 subtitle、 text 时设置</para>
        /// </summary>
        [JsonProperty(PropertyName = "font", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaInsertTextFont Font { get => font; set => font = value; }
        /// <summary>
        /// 有效显示起止时间
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "timeline", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaInsertTimeline Timeline { get => timeline; set => timeline = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
    /// <summary>
    /// 黑边裁剪参数
    /// </summary>
    public class XGMediaCrop
    {
        private int? x;
        private int? y;
        private int? width;
        private int? height;

        /// <summary>
        /// 去黑边后的有效区域相对左上角的x（横）坐标，左上角为0
        /// <para>必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "x", NullValueHandling = NullValueHandling.Ignore)]
        public int? X { get => x; set => x = value; }
        /// <summary>
        /// 去黑边后的有效区域相对左上角的y（纵）坐标，左上角为0	大
        /// <para>必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "y", NullValueHandling = NullValueHandling.Ignore)]
        public int? Y { get => y; set => y = value; }
        /// <summary>
        /// 去黑边后的有效区域横向宽度
        /// <para>必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "width", NullValueHandling = NullValueHandling.Ignore)]
        public int? Width { get => width; set => width = value; }
        /// <summary>
        /// 去黑边后的有效区域纵向高度
        /// <para>必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "height", NullValueHandling = NullValueHandling.Ignore)]
        public int? Height { get => height; set => height = value; }

        /// <summary>
        /// 是否有空属性
        /// </summary>
        /// <returns></returns>
        public bool HasNullProperty()
        {
            if (x == null || y == null || width == null || height == null)
                return true;
            return false;
        }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
    /// <summary>
    /// 去水印参数
    /// </summary>
    public class XGMediaDelogoArea
    {
        private int? x;
        private int? y;
        private int? width;
        private int? height;

        /// <summary>
        /// 水印区域相对左上角的x（横）坐标，左上角为0
        /// <para>必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "x", NullValueHandling = NullValueHandling.Ignore)]
        public int? X { get => x; set => x = value; }
        /// <summary>
        /// 水印区域相对左上角的y（纵）坐标，左上角为0
        /// <para>必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "y", NullValueHandling = NullValueHandling.Ignore)]
        public int? Y { get => y; set => y = value; }
        /// <summary>
        /// 水印区域横向宽度
        /// <para>必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "width", NullValueHandling = NullValueHandling.Ignore)]
        public int? Width { get => width; set => width = value; }
        /// <summary>
        /// 水印区域纵向高度
        /// <para>必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "height", NullValueHandling = NullValueHandling.Ignore)]
        public int? Height { get => height; set => height = value; }

        /// <summary>
        /// 是否有空属性
        /// </summary>
        /// <returns></returns>
        public bool HasNullProperty()
        {
            if (x == null || y == null || width == null || height == null)
                return true;
            return false;
        }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }

    /// <summary>
    /// 输出信息的集合
    /// </summary>
    public class XGMediaTargetInfo
    {
        private string targetBucket;
        private string targetKey;
        private string presetName;
        private bool? autoDelogo;
        private XGMediaDelogoMode? delogoMode;
        private XGMediaDelogoArea delogoArea;
        private List<XGMediaDelogoArea> delogoAreas;
        private bool? autoCrop;
        private XGMediaCrop crop;
        private List<string> watermarkIds;
        private List<XGMediaInsert> inserts;

        /// <summary>
        /// 目标文件的输出BOS bucket
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "targetBucket", NullValueHandling = NullValueHandling.Ignore)]
        public string TargetBucket { get => targetBucket; set => targetBucket = value; }
        /// <summary>
        /// 目标文件的BOS key，即是相对于输出Bucket的文件的相对路径
        /// <para>必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "targetKey", NullValueHandling = NullValueHandling.Ignore)]
        public string TargetKey { get => targetKey; set => targetKey = value; }
        /// <summary>
        /// 输出处理的模板的名称
        /// <para>必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "presetName", NullValueHandling = NullValueHandling.Ignore)]
        public string PresetName { get => presetName; set => presetName = value; }
        /// <summary>
        /// 自动去水印
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "autoDelogo", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AutoDelogo { get => autoDelogo; set => autoDelogo = value; }
        /// <summary>
        /// 自动去水印模式
        /// <para>非必需</para>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)),JsonProperty(PropertyName = "delogoMode", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaDelogoMode? DelogoMode { get => delogoMode; set => delogoMode = value; }
        /// <summary>
        /// 去水印参数，描述水印位置区域
        /// <para>使用delogo去水印功能时，不能指定transmux模式的模板</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "delogoArea", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaDelogoArea DelogoArea { get => delogoArea; set => delogoArea = value; }
        /// <summary>
        /// 去多个水印参数，描述水印位置区域，至多指定5个
        /// <para>使用delogo去水印功能时，不能指定transmux模式的模板，不可与delogoArea同时指定</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "delogoAreas", NullValueHandling = NullValueHandling.Ignore)]
        public List<XGMediaDelogoArea> DelogoAreas { get => delogoAreas; set => delogoAreas = value; }
        /// <summary>
        /// 开启自动剪裁黑边
        /// <para>和crop同时设置时，以crop为准</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "autoCrop", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AutoCrop { get => autoCrop; set => autoCrop = value; }
        /// <summary>
        /// 黑边裁剪参数，描述除去黑边后的有效区域
        /// <para>使用crop去黑边功能时，不能指定transmux模式的模板</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "crop", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaCrop Crop { get => crop; set => crop = value; }
        /// <summary>
        /// 水印模板id集合，最大size 5
        /// <para>当Job和Preset中同时指定watermarkId(s)时，优先使用Job中设置的watermarkId，以支持更灵活地设置水印</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "watermarkIds", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> WatermarkIds { get => watermarkIds; set => watermarkIds = value; }
        /// <summary>
        /// 待插入（叠加）的内容
        /// <para>audio类型的inserts不能和其他类型inserts共存。不支持同时设置水印和inserts。多clips的任务不可设置inserts。数组最大长度为200</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "inserts", NullValueHandling = NullValueHandling.Ignore)]
        public List<XGMediaInsert> Inserts { get => inserts; set => inserts = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }

    public class XGMediaSourceClipInfo
    {
        private string bucket;
        private string sourceKey;
        private bool? asMasterClip;
        private bool? enableLogo;
        private bool? enableDelogo;
        private bool? enableCrop;
        private int? startTimeInSecond;
        private int? durationInSecond;
        private int? startTimeInMillisecond;
        private int? durationInMillisecond;

        /// <summary>
        /// 原始文件的BOS Bucket
        /// <para>用户必须有该bucket的读权限</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "bucket", NullValueHandling = NullValueHandling.Ignore)]
        public string Bucket { get => bucket; set => bucket = value; }
        /// <summary>
        /// 原始文件的BOS Key
        /// <para>相对于输入Bucket的文件的相对路径，支持输入为public bucket下的hls（即sourceKey为m3u8文件）</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "sourceKey", NullValueHandling = NullValueHandling.Ignore)]
        public string SourceKey { get => sourceKey; set => sourceKey = value; }
        /// <summary>
        /// 是否指定该片段作为主分片，即转码分辨率参考该片段
        /// <para>。当clips中存在 asMasterClip为true时，对应模板Preset的 video.sizingPolicy 必须为shrinkToFit，此时输出分辨率保持主分片视频宽高比，其他分片参考该分辨率加黑边对齐。</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "asMasterClip", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AsMasterClip { get => asMasterClip; set => asMasterClip = value; }
        /// <summary>
        /// 是否允许在该片段添加水印
        /// <para>为空时，如有指定水印，默认该片段添加水印</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "enableLogo", NullValueHandling = NullValueHandling.Ignore)]
        public bool? EnableLogo { get => enableLogo; set => enableLogo = value; }
        /// <summary>
        /// 是否允许在该片段进行去水印
        /// <para>去水印位置参数为job.target.delogo</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "enableDelogo", NullValueHandling = NullValueHandling.Ignore)]
        public bool? EnableDelogo { get => enableDelogo; set => enableDelogo = value; }
        /// <summary>
        /// 是否允许在该片段添进行去黑边
        /// <para>去黑边位置参数为job.target.crop</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "enableCrop", NullValueHandling = NullValueHandling.Ignore)]
        public bool? EnableCrop { get => enableCrop; set => enableCrop = value; }
        /// <summary>
        /// 视频片段的起始时间
        /// <para>大于等于0</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "startTimeInSecond", NullValueHandling = NullValueHandling.Ignore)]
        public int? StartTimeInSecond { get => startTimeInSecond; set => startTimeInSecond = value; }
        /// <summary>
        /// 视频片段的持续时间
        /// <para>大于等于1</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "durationInSecond", NullValueHandling = NullValueHandling.Ignore)]
        public int? DurationInSecond { get => durationInSecond; set => durationInSecond = value; }
        /// <summary>
        /// 视频片段的起始时间
        /// <para>单位毫秒，与startTimeInSecond同时指定时优先生效</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "startTimeInMillisecond", NullValueHandling = NullValueHandling.Ignore)]
        public int? StartTimeInMillisecond { get => startTimeInMillisecond; set => startTimeInMillisecond = value; }
        /// <summary>
        /// 视频片段的持续时间
        /// <para>单位毫秒，与durationInSecond同时指定时优先生效</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "durationInMillisecond", NullValueHandling = NullValueHandling.Ignore)]
        public int? DurationInMillisecond { get => durationInMillisecond; set => durationInMillisecond = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
    /// <summary>
    /// 转码视频原始信息集合
    /// </summary>
    public class XGMediaSourceInfo
    {
        private string sourceKey;
        private List<XGMediaSourceClipInfo> clips;

        /// <summary>
        /// 原始文件的BOS Key，即是相对于输入Bucket的文件的相对路径
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "sourceKey", NullValueHandling = NullValueHandling.Ignore)]
        public string SourceKey { get => sourceKey; set => sourceKey = value; }
        /// <summary>
        ///待合并的原始视频信息
        /// <para>与上面的sourceKey不可同时指定，数组长度[1,200]</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "clips", NullValueHandling = NullValueHandling.Ignore)]
        public List<XGMediaSourceClipInfo> Clips { get => clips; set => clips = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
    /// <summary>
    /// 创建视频转码任务请求类
    /// </summary>
    public class XGMediaCreateTranscodingJobRequest:XGAbstractMediaRequest
    {
        private string pipelineName;
        private XGMediaSourceInfo source;
        private XGMediaTargetInfo target;
        public XGMediaCreateTranscodingJobRequest()
        {
        }

        /// <summary>
        /// 任务所属的队列名称
        /// <para>必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "pipelineName", NullValueHandling = NullValueHandling.Ignore)]
        public string PipelineName { get => pipelineName; set => pipelineName = value; }
        /// <summary>
        /// 输入的原始信息的集合
        /// <para>必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "source", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaSourceInfo Source { get => source; set => source = value; }
        /// <summary>
        /// 输出信息的集合
        /// <para>必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "target", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaTargetInfo Target { get => target; set => target = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
