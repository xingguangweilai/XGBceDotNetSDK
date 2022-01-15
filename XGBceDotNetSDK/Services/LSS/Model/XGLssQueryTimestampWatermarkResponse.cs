using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using static XGBceDotNetSDK.Services.LSS.Model.XGLssEnum;

namespace XGBceDotNetSDK.Services.LSS.Model
{
    /// <summary>
    /// 查询时间戳水印响应类
    /// </summary>
    public class XGLssQueryTimestampWatermarkResponse:XGLssResponse
    {
        private string name;
        private XGLssTimezone? timezone;
        private float? alpha;
        private XGLssWatermarkFont font;
        private XGLssWatermarkBackground background;
        private XGLssWatermarkPosition position;
        private DateTime? createTime;
        private long? lastUpdateTime;

        public XGLssQueryTimestampWatermarkResponse()
        {
        }

        /// <summary>
        /// 水印名称
        /// <para>可由小写字母、数字、下划线组成，必须以小写字母开头，最长40个字符。</para>
        /// </summary>
        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get => name; set => name = value; }
        /// <summary>
        /// 时区
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)), JsonProperty(PropertyName = "timezone", NullValueHandling = NullValueHandling.Ignore)]
        public XGLssTimezone? Timezone { get => timezone; set => timezone = value; }
        /// <summary>
        /// 水印透明度
        /// <para>有效值：[0-1]间的小数，小数点后最多保留两位，0表示完全透明，1表示完全不透明</para>
        /// </summary>
        [JsonProperty(PropertyName = "alpha", NullValueHandling = NullValueHandling.Ignore)]
        public float? Alpha { get => alpha; set => alpha = value; }
        /// <summary>
        /// 水印文字
        /// </summary>
        [JsonProperty(PropertyName = "font", NullValueHandling = NullValueHandling.Ignore)]
        public XGLssWatermarkFont Font { get => font; set => font = value; }
        /// <summary>
        /// 水印背景
        /// </summary>
        [JsonProperty(PropertyName = "background", NullValueHandling = NullValueHandling.Ignore)]
        public XGLssWatermarkBackground Background { get => background; set => background = value; }
        /// <summary>
        /// 水印位置
        /// </summary>
        [JsonProperty(PropertyName = "position", NullValueHandling = NullValueHandling.Ignore)]
        public XGLssWatermarkPosition Position { get => position; set => position = value; }
        /// <summary>
        /// 水印模板创建时间
        /// </summary>
        [JsonProperty(PropertyName = "createTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? CreateTime { get => createTime; set => createTime = value; }
        /// <summary>
        /// 水印模板最后更新时间
        /// </summary>
        [JsonProperty(PropertyName = "lastUpdateTime", NullValueHandling = NullValueHandling.Ignore)]
        public long? LastUpdateTime { get => lastUpdateTime; set => lastUpdateTime = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
