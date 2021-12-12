using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace XGBceDotNetSDK.Services.MEDIA.Model
{
    /// <summary>
    /// 查询指定水印响应类
    /// </summary>
    public class XGMediaQueryWatermarkResponse:XGMediaResponse
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
        private string watermarkId;
        private DateTime? createTime;

        public XGMediaQueryWatermarkResponse()
        {
        }

        /// <summary>
        /// 水印的唯一标识
        /// </summary>
        [JsonProperty(PropertyName = "watermarkId", NullValueHandling = NullValueHandling.Ignore)]
        public string WatermarkId { get => watermarkId; set => watermarkId = value; }
        /// <summary>
        /// 水印创建时间
        /// </summary>
        [JsonProperty(PropertyName = "createTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? CreateTime { get => createTime; set => createTime = value; }
        /// <summary>
        /// BOS存储上水印文件Bucket
        /// </summary>
        [JsonProperty(PropertyName = "bucket", NullValueHandling = NullValueHandling.Ignore)]
        public string Bucket { get => bucket; set => bucket = value; }
        /// <summary>
        /// BOS存储上水印文件Key
        /// <para>支持JPG、PNG、APNG、BMP、PBM、TIF、GIF 、MOV等格式，其中MOV、GIF、APNG为动态水印</para>
        /// </summary>
        [JsonProperty(PropertyName = "key", NullValueHandling = NullValueHandling.Ignore)]
        public string Key { get => key; set => key = value; }
        /// <summary>
        /// 垂直对齐方式
        /// <para>默认：top</para>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)), JsonProperty(PropertyName = "verticalAlignment", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaVerticalAlignment? VerticalAlignment { get => verticalAlignment; set => verticalAlignment = value; }
        /// <summary>
        /// 水平对齐方式
        /// <para>默认：left</para>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)), JsonProperty(PropertyName = "horizontalAlignment", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaHorizontalAlignment? HorizontalAlignment { get => horizontalAlignment; set => horizontalAlignment = value; }
        /// <summary>
        /// 垂直偏移
        /// <para>仅在verticalAlignment设置为top或bottom时有效，单位：像素</para>
        /// </summary>
        [JsonProperty(PropertyName = "verticalOffsetInPixel", NullValueHandling = NullValueHandling.Ignore)]
        public int? VerticalOffsetInPixel { get => verticalOffsetInPixel; set => verticalOffsetInPixel = value; }
        /// <summary>
        /// 水平偏移
        /// <para>仅在horizontalAlignment设置为left或right时有效，单位：像素</para>
        /// </summary>
        [JsonProperty(PropertyName = "horizontalOffsetInPixel", NullValueHandling = NullValueHandling.Ignore)]
        public int? HorizontalOffsetInPixel { get => horizontalOffsetInPixel; set => horizontalOffsetInPixel = value; }
        /// <summary>
        /// 水印有效显示起止时间
        /// <para>仅当watermarkId被设置到Preset.watermarks.image多水印参数中时该字段可生效</para>
        /// </summary>
        [JsonProperty(PropertyName = "timeline", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaWatermarkTimeline Timeline { get => timeline; set => timeline = value; }
        /// <summary>
        /// （动态）水印重复显示次数
        /// <para>0表示无限循环（仅当watermarkId被设置到Preset.watermarks.image多水印参数中时该字段可生效）</para>
        /// </summary>
        [JsonProperty(PropertyName = "repeated", NullValueHandling = NullValueHandling.Ignore)]
        public int? Repeated { get => repeated; set => repeated = value; }
        /// <summary>
        /// 是否允许自动进行缩放
        /// <para>仅当watermarkId被设置到Preset.watermarks.image多水印参数中时该字段可生效</para>
        /// </summary>
        [JsonProperty(PropertyName = "allowScaling", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AllowScaling { get => allowScaling; set => allowScaling = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
