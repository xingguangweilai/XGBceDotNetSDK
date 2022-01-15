using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using static XGBceDotNetSDK.Services.LSS.Model.XGLssEnum;

namespace XGBceDotNetSDK.Services.LSS.Model
{
    /// <summary>
    /// 缩略图生成规则
    /// </summary>
    public class XGLssThumbnailCapture
    {
        private string mode;
        private long? startTimeInSecond;
        private long? endTimeInSecond;
        private int? intervalInSecond;

        /// <summary>
        ///缩略图生成模式
        /// </summary>
        [JsonProperty(PropertyName = "mode", NullValueHandling = NullValueHandling.Ignore)]
        public string Mode { get => mode; set => mode = value; }
        /// <summary>
        /// 缩略图开始时间
        /// </summary>
        [JsonProperty(PropertyName = "startTimeInSecond", NullValueHandling = NullValueHandling.Ignore)]
        public long? StartTimeInSecond { get => startTimeInSecond; set => startTimeInSecond = value; }
        /// <summary>
        /// 缩略图结束时间
        /// </summary>
        [JsonProperty(PropertyName = "endTimeInSecond", NullValueHandling = NullValueHandling.Ignore)]
        public long? EndTimeInSecond { get => endTimeInSecond; set => endTimeInSecond = value; }
        /// <summary>
        /// 缩略图截图间隔
        /// <para>有效值：[1-21600]</para>
        /// </summary>
        [JsonProperty(PropertyName = "intervalInSecond", NullValueHandling = NullValueHandling.Ignore)]
        public int? IntervalInSecond { get => intervalInSecond; set => intervalInSecond = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }

    /// <summary>
    /// 缩略图目标信息
    /// </summary>
    public class XGLssThumbnailTarget
    {
        private string format;
        private XGLssSizingPolicy? sizingPolicy;
        private int? maxWidthInPixel;
        private int? maxHeightInPixel;

        /// <summary>
        /// 缩略图文件格式
        /// </summary>
        [JsonProperty(PropertyName = "format", NullValueHandling = NullValueHandling.Ignore)]
        public string Format { get => format; set => format = value; }
        /// <summary>
        /// 缩略图拉伸策略
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)), JsonProperty(PropertyName = "sizingPolicy", NullValueHandling = NullValueHandling.Ignore)]
        public XGLssSizingPolicy? SizingPolicy { get => sizingPolicy; set => sizingPolicy = value; }
        /// <summary>
        /// 缩略图宽度尺寸
        /// </summary>
        [JsonProperty(PropertyName = "maxWidthInPixel", NullValueHandling = NullValueHandling.Ignore)]
        public int? MaxWidthInPixel { get => maxWidthInPixel; set => maxWidthInPixel = value; }
        /// <summary>
        /// 缩略图高度尺寸
        /// </summary>
        [JsonProperty(PropertyName = "maxHeightInPixel", NullValueHandling = NullValueHandling.Ignore)]
        public int? MaxHeightInPixel { get => maxHeightInPixel; set => maxHeightInPixel = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }

    /// <summary>
    /// 缩略图文件存储至BOS的配置信息
    /// </summary>
    public class XGLssThumbnailBos
    {
        private string bucket;
        private string region;

        /// <summary>
        /// 存储缩略图文件的BOS Bucket名称
        /// </summary>
        [JsonProperty(PropertyName = "bucket", NullValueHandling = NullValueHandling.Ignore)]
        public string Bucket { get => bucket; set => bucket = value; }
        /// <summary>
        /// 存储缩略图文件的BOS区域
        /// </summary>
        [JsonProperty(PropertyName = "region", NullValueHandling = NullValueHandling.Ignore)]
        public string Region { get => region; set => region = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }

    /// <summary>
    /// 查询缩略图模板响应类
    /// </summary>
    public class XGLssQueryThumbnailResponse:XGLssResponse
    {
        private string name;
        private string description;
        private string pattern;
        private XGLssThumbnailBos bos;
        private XGLssThumbnailTarget target;
        private XGLssThumbnailCapture capture;
        private DateTime? createTime;
        private long? lastUpdateTime;

        public XGLssQueryThumbnailResponse()
        {
        }

        /// <summary>
        /// 缩略图模板名称
        /// </summary>
        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get => name; set => name = value; }
        /// <summary>
        /// 缩略图模板描述
        /// </summary>
        [JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get => description; set => description = value; }
        /// <summary>
        /// 缩略图文件命名模式
        /// </summary>
        [JsonProperty(PropertyName = "pattern", NullValueHandling = NullValueHandling.Ignore)]
        public string Pattern { get => pattern; set => pattern = value; }
        /// <summary>
        /// 缩略图文件存储至BOS的配置信息
        /// </summary>
        [JsonProperty(PropertyName = "bos", NullValueHandling = NullValueHandling.Ignore)]
        public XGLssThumbnailBos Bos { get => bos; set => bos = value; }
        /// <summary>
        /// 缩略图目标信息
        /// </summary>
        [JsonProperty(PropertyName = "target", NullValueHandling = NullValueHandling.Ignore)]
        public XGLssThumbnailTarget Target { get => target; set => target = value; }
        /// <summary>
        /// 缩略图生成规则
        /// </summary>
        [JsonProperty(PropertyName = "capture", NullValueHandling = NullValueHandling.Ignore)]
        public XGLssThumbnailCapture Capture { get => capture; set => capture = value; }
        /// <summary>
        /// 缩略图模版创建时间
        /// </summary>
        [JsonProperty(PropertyName = "region", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? CreateTime { get => createTime; set => createTime = value; }
        /// <summary>
        /// 缩略图模版最后更新时间
        /// </summary>
        [JsonProperty(PropertyName = "lastUpdateTime", NullValueHandling = NullValueHandling.Ignore)]
        public long? LastUpdateTime { get => lastUpdateTime; set => lastUpdateTime = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
