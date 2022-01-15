using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.LSS.Model
{
    /// <summary>
    /// 图片水印模板
    /// </summary>
    public class XGLssWatermarkPreset
    {
        private string name;
        private string imageUrl;
        private XGLssWatermarkSize size;
        private XGLssWatermarkPosition position;
        private DateTime? createTime;
        private long? lastUpdateTime;

        /// <summary>
        /// 水印名称
        /// </summary>
        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get => name; set => name = value; }
        /// <summary>
        /// 存于BOS Bucket中的图片文件URL
        /// </summary>
        [JsonProperty(PropertyName = "imageUrl", NullValueHandling = NullValueHandling.Ignore)]
        public string ImageUrl { get => imageUrl; set => imageUrl = value; }
        /// <summary>
        /// 水印尺寸
        /// </summary>
        [JsonProperty(PropertyName = "size", NullValueHandling = NullValueHandling.Ignore)]
        public XGLssWatermarkSize Size { get => size; set => size = value; }
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

    /// <summary>
    /// 查询图片水印列表
    /// </summary>
    public class XGLssListWatermarksResponse:XGLssResponse
    {
        private List<XGLssWatermarkPreset> imageWatermarks;
        public XGLssListWatermarksResponse()
        {
        }

        /// <summary>
        /// 水印模板列表
        /// </summary>
        [JsonProperty(PropertyName = "imageWatermarks", NullValueHandling = NullValueHandling.Ignore)]
        public List<XGLssWatermarkPreset> ImageWatermarks { get => imageWatermarks; set => imageWatermarks = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
