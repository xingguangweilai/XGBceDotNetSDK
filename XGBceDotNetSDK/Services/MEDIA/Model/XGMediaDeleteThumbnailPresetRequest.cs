using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.MEDIA.Model
{
    /// <summary>
    /// 删除指定的缩略图模板请求类
    /// </summary>
    public class XGMediaDeleteThumbnailPresetRequest:XGAbstractMediaRequest
    {
        private string presetName;
        public XGMediaDeleteThumbnailPresetRequest()
        {
        }

        /// <summary>
        /// 模板名称
        /// </summary>
        [JsonIgnore]
        public string PresetName { get => presetName; set => presetName = value; }
    }
}
