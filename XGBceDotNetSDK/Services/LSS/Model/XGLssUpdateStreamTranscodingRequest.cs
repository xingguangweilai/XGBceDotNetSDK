using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.LSS.Model
{
    /// <summary>
    /// 更新转码模板
    /// </summary>
    public class XGLssStreamTranscodingPresets
    {
        private string l1;
        private string l2;
        private string l3;
        private string l4;

        /// <summary>
        /// L1线路下使用的转码模板名称
        /// <para>可选</para>
        /// </summary>
        [JsonProperty(PropertyName = "L1", NullValueHandling = NullValueHandling.Ignore)]
        public string L1 { get => l1; set => l1 = value; }
        /// <summary>
        /// L2线路下使用的转码模板名称
        /// <para>可选</para>
        /// </summary>
        [JsonProperty(PropertyName = "L2", NullValueHandling = NullValueHandling.Ignore)]
        public string L2 { get => l2; set => l2 = value; }
        /// <summary>
        /// L3线路下使用的转码模板名称
        /// <para>可选</para>
        /// </summary>
        [JsonProperty(PropertyName = "L3", NullValueHandling = NullValueHandling.Ignore)]
        public string L3 { get => l3; set => l3 = value; }
        /// <summary>
        /// L4线路下使用的转码模板名称
        /// <para>可选</para>
        /// </summary>
        [JsonProperty(PropertyName = "L4", NullValueHandling = NullValueHandling.Ignore)]
        public string L4 { get => l4; set => l4 = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
    /// <summary>
    /// 更新stream转码模版请求类
    /// </summary>
    public class XGLssUpdateStreamTranscodingRequest : XGLssStreamRequest
    {
        private XGLssStreamTranscodingPresets presets;
        public XGLssUpdateStreamTranscodingRequest()
        {
        }

        /// <summary>
        /// L4线路下使用的转码模板名称
        /// <para>必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "presets", NullValueHandling = NullValueHandling.Ignore)]
        public XGLssStreamTranscodingPresets Presets { get => presets; set => presets = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
