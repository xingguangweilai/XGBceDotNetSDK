using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.MEDIA.Model
{
    /// <summary>
    /// 查询指定缩略图模板请求类
    /// </summary>
    public class XGMediaQueryThumbnailPresetRequest:XGAbstractMediaRequest
    {
        private string presetName;

        public XGMediaQueryThumbnailPresetRequest()
        {
        }

        /// <summary>
        /// 模板名称
        /// </summary>
        [JsonIgnore]
        public string PresetName { get => presetName; set => presetName = value; }
    }
}
