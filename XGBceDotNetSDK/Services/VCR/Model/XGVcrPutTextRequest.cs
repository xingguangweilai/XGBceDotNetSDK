using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.VCR.Model
{
    /// <summary>
    /// 提交文本审核请求类
    /// </summary>
    public class XGVcrPutTextRequest: XGAbstractVcrRequest
    {
        private string text;
        private string preset;
        public XGVcrPutTextRequest()
        {
        }

        /// <summary>
        /// 审核文本
        /// <para>必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "text")]
        public string Text { get => text; set => text = value; }
        /// <summary>
        /// 模板
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "preset", NullValueHandling = NullValueHandling.Ignore)]
        public string Preset { get => preset; set => preset = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
