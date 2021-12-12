using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.MEDIA.Model
{
    /// <summary>
    /// 删除指定模板请求类
    /// </summary>
    public class XGMediaDeletePresetRequest:XGAbstractMediaRequest
    {
        private string presetName;

        public XGMediaDeletePresetRequest()
        {
        }

        /// <summary>
        /// 模板名称
        /// </summary>
        [JsonIgnore]
        public string PresetName { get => presetName; set => presetName = value; }
    }
}
