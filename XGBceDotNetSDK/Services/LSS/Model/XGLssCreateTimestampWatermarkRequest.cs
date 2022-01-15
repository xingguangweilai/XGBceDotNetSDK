using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using static XGBceDotNetSDK.Services.LSS.Model.XGLssEnum;

namespace XGBceDotNetSDK.Services.LSS.Model
{
    /// <summary>
    /// 水印背景
    /// </summary>
    public class XGLssWatermarkBackground
    {
        private string color;

        /// <summary>
        /// 背景颜色
        /// <para>有效值：#开头的十六进制颜色代码，默认值：#000000</para>
        /// <para>可选</para>
        /// </summary>
        [JsonProperty(PropertyName = "color", NullValueHandling = NullValueHandling.Ignore)]
        public string Color { get => color; set => color = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }

    /// <summary>
    /// 水印文字
    /// </summary>
    public class XGLssWatermarkFont
    {
        private XGLssFontFamily? family;
        private int? sizeInPoint;
        private string color;

        /// <summary>
        /// 文字字体
        /// <para>可选</para>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)), JsonProperty(PropertyName = "family", NullValueHandling = NullValueHandling.Ignore)]
        public XGLssFontFamily? Family { get => family; set => family = value; }
        /// <summary>
        /// 文字大小
        /// <para>有效值：[1-72]，默认值：16</para>
        /// <para>可选</para>
        /// </summary>
        [JsonProperty(PropertyName = "sizeInPoint", NullValueHandling = NullValueHandling.Ignore)]
        public int? SizeInPoint { get => sizeInPoint; set => sizeInPoint = value; }
        /// <summary>
        /// 文字颜色
        /// <para>有效值：#开头的十六进制颜色代码，默认值：#FFFFFF</para>
        /// <para>可选</para>
        /// </summary>
        [JsonProperty(PropertyName = "color", NullValueHandling = NullValueHandling.Ignore)]
        public string Color { get => color; set => color = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }

    /// <summary>
    /// 创建时间戳水印请求类
    /// </summary>
    public class XGLssCreateTimestampWatermarkRequest:XGAbstractLssRequest
    {
        private string name;
        private XGLssTimezone? timezone;
        private float? alpha;
        private XGLssWatermarkFont font;
        private XGLssWatermarkBackground background;
        private XGLssWatermarkPosition position;

        public XGLssCreateTimestampWatermarkRequest()
        {
        }

        /// <summary>
        /// 水印名称
        /// <para>可由小写字母、数字、下划线组成，必须以小写字母开头，最长40个字符。</para>
        /// <para>必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get => name; set => name = value; }
        /// <summary>
        /// 时区
        /// <para>可选</para>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)), JsonProperty(PropertyName = "timezone", NullValueHandling = NullValueHandling.Ignore)]
        public XGLssTimezone? Timezone { get => timezone; set => timezone = value; }
        /// <summary>
        /// 水印透明度
        /// <para>有效值：[0-1]间的小数，小数点后最多保留两位，0表示完全透明，1表示完全不透明</para>
        /// <para>可选</para>
        /// </summary>
        [JsonProperty(PropertyName = "alpha", NullValueHandling = NullValueHandling.Ignore)]
        public float? Alpha { get => alpha; set => alpha = value; }
        /// <summary>
        /// 水印文字
        /// <para>可选</para>
        /// </summary>
        [JsonProperty(PropertyName = "font", NullValueHandling = NullValueHandling.Ignore)]
        public XGLssWatermarkFont Font { get => font; set => font = value; }
        /// <summary>
        /// 水印背景
        /// <para>可选</para>
        /// </summary>
        [JsonProperty(PropertyName = "background", NullValueHandling = NullValueHandling.Ignore)]
        public XGLssWatermarkBackground Background { get => background; set => background = value; }
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
