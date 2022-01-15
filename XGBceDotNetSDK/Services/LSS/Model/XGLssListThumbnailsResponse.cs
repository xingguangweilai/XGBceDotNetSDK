using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.LSS.Model
{
    /// <summary>
    /// 缩略图模板
    /// </summary>
    public class XGLssThumbnailPreset
    {
        private string name;
        private string description;
        private string pattern;
        private XGLssThumbnailBos bos;
        private XGLssThumbnailTarget target;
        private XGLssThumbnailCapture capture;
        private DateTime? createTime;
        private long? lastUpdateTime;
        private List<XGLsstTag> tagList;

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
        /// <summary>
        /// 标签列表
        /// </summary>
        [JsonProperty(PropertyName = "tagList", NullValueHandling = NullValueHandling.Ignore)]
        public List<XGLsstTag> TagList { get => tagList; set => tagList = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
    /// <summary>
    /// 列举缩略图响应类
    /// </summary>
    public class XGLssListThumbnailsResponse:XGLssResponse
    {
        private List<XGLssThumbnailPreset> thumbnails;

        public XGLssListThumbnailsResponse()
        {
        }

        /// <summary>
        /// 缩略图模板列表
        /// </summary>
        [JsonProperty(PropertyName = "thumbnails", NullValueHandling = NullValueHandling.Ignore)]
        public List<XGLssThumbnailPreset> Thumbnails { get => thumbnails; set => thumbnails = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
