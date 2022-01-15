using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using static XGBceDotNetSDK.Services.LSS.Model.XGLssEnum;

namespace XGBceDotNetSDK.Services.LSS.Model
{
    /// <summary>
    /// 水印位置
    /// </summary>
    public class XGLssWatermarkPosition
    {
        private XGLssVerticalAlignment? verticalAlignment;
        private XGLssHorizontalAlignment? horizontalAlignment;
        private int? verticalOffsetInPixel;
        private int? horizontalOffsetInPixel;

        /// <summary>
        /// 垂直对齐
        /// <para>可选</para>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)), JsonProperty(PropertyName = "verticalAlignment", NullValueHandling = NullValueHandling.Ignore)]
        public XGLssVerticalAlignment? VerticalAlignment { get => verticalAlignment; set => verticalAlignment = value; }
        /// <summary>
        /// 水平对齐
        /// <para>可选</para>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)), JsonProperty(PropertyName = "horizontalAlignment", NullValueHandling = NullValueHandling.Ignore)]
        public XGLssHorizontalAlignment? HorizontalAlignment { get => horizontalAlignment; set => horizontalAlignment = value; }
        /// <summary>
        /// 垂直偏移量
        /// <para>仅当verticalAlignment设置为top或bottom时有效。单位：像素，有效值：[0-3072]</para>
        /// <para>可选</para>
        /// </summary>
        [JsonProperty(PropertyName = "verticalOffsetInPixel", NullValueHandling = NullValueHandling.Ignore)]
        public int? VerticalOffsetInPixel { get => verticalOffsetInPixel; set => verticalOffsetInPixel = value; }
        /// <summary>
        /// 水平偏移量
        /// <para>仅当horizontalAlignment设置为left或right时有效。单位：像素，有效值：[0-4096]</para>
        /// <para>可选</para>
        /// </summary>
        [JsonProperty(PropertyName = "horizontalOffsetInPixel", NullValueHandling = NullValueHandling.Ignore)]
        public int? HorizontalOffsetInPixel { get => horizontalOffsetInPixel; set => horizontalOffsetInPixel = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }

    /// <summary>
    /// 水印尺寸
    /// </summary>
    public class XGLssWatermarkSize
    {
        private int? maxWidthInPixel;
        private int? maxHeightInPixel;
        private XGLssSizingPolicy? sizingPolicy;

        /// <summary>
        /// 水印最大宽度
        /// <para>有效值：[10-4096]间的偶数。</para>
        /// <para>不设置时，如果设置了最大高度则会根据原始图片宽高比计算水印宽度，否则和原始图片宽度保持一致</para>
        /// <para>可选</para>
        /// </summary>
        [JsonProperty(PropertyName = "maxWidthInPixel", NullValueHandling = NullValueHandling.Ignore)]
        public int? MaxWidthInPixel { get => maxWidthInPixel; set => maxWidthInPixel = value; }
        /// <summary>
        /// 水印最大高度
        /// <para>有效值：[10-3072]间的偶数。</para>
        /// <para>不设置时，如果设置了最大宽度则会根据原始图片宽高比计算水印高度，否则和原始图片高度保持一致</para>
        /// <para>可选</para>
        /// </summary>
        [JsonProperty(PropertyName = "maxHeightInPixel", NullValueHandling = NullValueHandling.Ignore)]
        public int? MaxHeightInPixel { get => maxHeightInPixel; set => maxHeightInPixel = value; }
        /// <summary>
        /// 水印的尺寸伸缩策略
        /// <para>有效值：keep</para>
        /// <para>可选</para>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)),  JsonProperty(PropertyName = "sizingPolicy", NullValueHandling = NullValueHandling.Ignore)]
        public XGLssSizingPolicy? SizingPolicy { get => sizingPolicy; set => sizingPolicy = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }

    /// <summary>
    /// 创建图片水印模板请求类
    /// </summary>
    public class XGLssCreateWatermarkRequest: XGLssBaseRequest
    {
        private string name;
        private string content;
        private XGLssWatermarkSize size;
        private XGLssWatermarkPosition position;

        public XGLssCreateWatermarkRequest()
        {
        }

        /// <summary>
        /// 水印名称
        /// <para>必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get => name; set => name = value; }
        /// <summary>
        /// 图片文件base64编码后字符串
        /// <para>必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "content", NullValueHandling = NullValueHandling.Ignore)]
        public string Content { get => content; set => content = value; }
        /// <summary>
        /// 水印尺寸
        /// <para>可选</para>
        /// </summary>
        [JsonProperty(PropertyName = "size", NullValueHandling = NullValueHandling.Ignore)]
        public XGLssWatermarkSize Size { get => size; set => size = value; }
        /// <summary>
        /// 水印位置
        /// <para>可选</para>
        /// </summary>
        [JsonProperty(PropertyName = "position", NullValueHandling = NullValueHandling.Ignore)]
        public XGLssWatermarkPosition Position { get => position; set => position = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
