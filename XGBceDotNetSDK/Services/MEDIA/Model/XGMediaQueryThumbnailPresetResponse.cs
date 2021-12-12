using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace XGBceDotNetSDK.Services.MEDIA.Model
{
    /// <summary>
    /// 查询指定缩略图模板响应类
    /// </summary>
    public class XGMediaQueryThumbnailPresetResponse:XGMediaResponse
    {
        private string presetName;
        private string description;
        private XGMediaThumbnailTarget target;
        private XGMediaPresetState? state;
        private DateTime? createdTime;

        public XGMediaQueryThumbnailPresetResponse()
        {
        }

        /// <summary>
        /// 缩略图模板名称
        /// </summary>
        [JsonProperty(PropertyName = "presetName", NullValueHandling = NullValueHandling.Ignore)]
        public string PresetName { get => presetName; set => presetName = value; }
        /// <summary>
        /// 缩略图模板描述
        /// </summary>
        [JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get => description; set => description = value; }
        /// <summary>
        ///目标缩略图信息的集合
        /// </summary>
        [JsonProperty(PropertyName = "target", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaThumbnailTarget Target { get => target; set => target = value; }
        /// <summary>
        ///模板状态
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)), JsonProperty(PropertyName = "state", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaPresetState? State { get => state; set => state = value; }
        /// <summary>
        ///模板创建的UTC格式的时间
        /// </summary>
        [JsonProperty(PropertyName = "createdTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? CreatedTime { get => createdTime; set => createdTime = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
