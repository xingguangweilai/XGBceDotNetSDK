using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace XGBceDotNetSDK.Services.MEDIA.Model
{
    /// <summary>
    /// 水印有效显示起止时间
    /// </summary>
    public class XGMediaWatermarkTimeline
    {
        private long? startTimeInMillisecond;
        private long? durationInMillisecond;

        /// <summary>
        /// 水印显示起始时间
        /// <para>单位：豪秒</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "startTimeInMillisecond", NullValueHandling = NullValueHandling.Ignore)]
        public long? StartTimeInMillisecond { get => startTimeInMillisecond; set => startTimeInMillisecond = value; }
        /// <summary>
        /// 水印显示持续时间
        /// <para>单位：豪秒</para>
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
    /// 创建水印请求类
    /// </summary>
    public class XGMediaCreateWatermarkRequest:XGAbstractMediaRequest
    {
        private string bucket;
        private string key;
        private XGMediaVerticalAlignment? verticalAlignment;
        private XGMediaHorizontalAlignment? horizontalAlignment;
        private int? verticalOffsetInPixel;
        private int? horizontalOffsetInPixel;
        private XGMediaWatermarkTimeline timeline;
        private int? repeated;
        private bool? allowScaling;

        public XGMediaCreateWatermarkRequest()
        {
        }

        /// <summary>
        /// BOS存储上水印文件Bucket
        /// <para>必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "bucket", NullValueHandling = NullValueHandling.Ignore)]
        public string Bucket { get => bucket; set => bucket = value; }
        /// <summary>
        /// BOS存储上水印文件Key
        /// <para>支持JPG、PNG、APNG、BMP、PBM、TIF、GIF 、MOV等格式，其中MOV、GIF、APNG为动态水印</para>
        /// <para>必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "key", NullValueHandling = NullValueHandling.Ignore)]
        public string Key { get => key; set => key = value; }
        /// <summary>
        /// 垂直对齐方式
        /// <para>默认：top</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)),JsonProperty(PropertyName = "verticalAlignment", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaVerticalAlignment? VerticalAlignment { get => verticalAlignment; set => verticalAlignment = value; }
        /// <summary>
        /// 水平对齐方式
        /// <para>默认：left</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)), JsonProperty(PropertyName = "horizontalAlignment", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaHorizontalAlignment? HorizontalAlignment { get => horizontalAlignment; set => horizontalAlignment = value; }
        /// <summary>
        /// 垂直偏移
        /// <para>仅在verticalAlignment设置为top或bottom时有效，单位：像素</para>
        /// <para>取值范围：0 ~ 3072</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "verticalOffsetInPixel", NullValueHandling = NullValueHandling.Ignore)]
        public int? VerticalOffsetInPixel { get => verticalOffsetInPixel; set => verticalOffsetInPixel = value; }
        /// <summary>
        /// 水平偏移
        /// <para>仅在horizontalAlignment设置为left或right时有效，单位：像素</para>
        /// <para>取值范围：0 ~ 4096</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "horizontalOffsetInPixel", NullValueHandling = NullValueHandling.Ignore)]
        public int? HorizontalOffsetInPixel { get => horizontalOffsetInPixel; set => horizontalOffsetInPixel = value; }
        /// <summary>
        /// 水印有效显示起止时间
        /// <para>仅当watermarkId被设置到Preset.watermarks.image多水印参数中时该字段可生效</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "timeline", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaWatermarkTimeline Timeline { get => timeline; set => timeline = value; }
        /// <summary>
        /// （动态）水印重复显示次数
        /// <para>0表示无限循环（仅当watermarkId被设置到Preset.watermarks.image多水印参数中时该字段可生效）</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "repeated", NullValueHandling = NullValueHandling.Ignore)]
        public int? Repeated { get => repeated; set => repeated = value; }
        /// <summary>
        /// 是否允许自动进行缩放
        /// <para>仅当watermarkId被设置到Preset.watermarks.image多水印参数中时该字段可生效</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "allowScaling", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AllowScaling { get => allowScaling; set => allowScaling = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
