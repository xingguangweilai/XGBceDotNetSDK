using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.LSS.Model
{
    /// <summary>
    /// 水印模版配置
    /// </summary>
    public class XGLssStreamWatermarks
    {
        private List<string> image;
        private List<string> timestamp;

        /// <summary>
        /// 图片水印模版名称列表
        /// <para>可选</para>
        /// </summary>
        [JsonProperty(PropertyName = "image", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Image { get => image; set => image = value; }
        /// <summary>
        /// 时间戳水印模版名称列表
        /// <para>可选</para>
        /// </summary>
        [JsonProperty(PropertyName = "timestamp", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Timestamp { get => timestamp; set => timestamp = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }

    /// <summary>
    /// 更新Stream水印模版请求类
    /// </summary>
    public class XGLssStreamUpdateWatermarksRequest:XGLssStreamRequest
    {
        private XGLssStreamWatermarks watermarks;
        public XGLssStreamUpdateWatermarksRequest()
        {
        }

        /// <summary>
        /// 更新的水印模版配置
        /// <para>必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "watermarks", NullValueHandling = NullValueHandling.Ignore)]
        public XGLssStreamWatermarks Watermarks { get => watermarks; set => watermarks = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
