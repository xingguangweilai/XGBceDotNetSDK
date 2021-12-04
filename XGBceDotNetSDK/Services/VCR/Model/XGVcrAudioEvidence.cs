using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.VCR.Model
{
    /// <summary>
    /// 审核证据
    /// <para> 根据不同的审核物料类型，审核证据也不相同。 </para>
    /// </summary>
    public class XGVcrAudioEvidence
    {
        private string text;

        public XGVcrAudioEvidence()
        {
        }

        /// <summary>
        /// 文本证据
        /// </summary>
        [JsonProperty(PropertyName = "text", NullValueHandling = NullValueHandling.Ignore)]
        public string Text { get => text; set => text = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
