using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.MEDIA.Model
{
    /// <summary>
    /// 查询指定模板请求类
    /// </summary>
    public class XGMediaQueryPresetRequest:XGAbstractMediaRequest
    {
        private string presetId;

        public XGMediaQueryPresetRequest()
        {
        }

        /// <summary>
        /// 模板ID
        /// <para>必需</para>
        /// </summary>
        [JsonIgnore]
        public string PresetId { get => presetId; set => presetId = value; }
    }
}
