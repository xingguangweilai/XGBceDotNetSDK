using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.MEDIA.Model
{
    /// <summary>
    /// 查询当前用户模板及所有系统模板响应类
    /// </summary>
    public class XGMediaListPresetsResponse:XGMediaResponse
    {
        private List<XGMediaQueryPresetResponse> presets;

        public XGMediaListPresetsResponse()
        {
        }

        /// <summary>
        /// 模板列表
        /// </summary>
        [JsonProperty(PropertyName = "presets", NullValueHandling = NullValueHandling.Ignore)]
        public List<XGMediaQueryPresetResponse> Presets { get => presets; set => presets = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
