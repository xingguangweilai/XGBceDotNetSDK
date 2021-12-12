using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.MEDIA.Model
{
    /// <summary>
    /// 更新指定缩略图模板
    /// </summary>
    public class XGMediaUpdateThumbnailPresetRequest:XGAbstractMediaRequest
    {
        private string presetName;
        private string description;
        private XGMediaThumbnailTarget target;

        public XGMediaUpdateThumbnailPresetRequest()
        {
        }

        /// <summary>
        /// 缩略图模板名称
        /// <para>必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "presetName", NullValueHandling = NullValueHandling.Ignore)]
        public string PresetName { get => presetName; set => presetName = value; }
        /// <summary>
        /// 缩略图模板描述
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get => description; set => description = value; }
        /// <summary>
        ///目标缩略图信息的集合
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "target", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaThumbnailTarget Target { get => target; set => target = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
