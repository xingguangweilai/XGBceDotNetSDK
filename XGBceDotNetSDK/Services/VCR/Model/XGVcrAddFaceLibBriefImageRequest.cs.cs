using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.VCR.Model
{
    /// <summary>
    /// 添加face库集素材
    /// </summary>
    public class XGVcrAddFaceLibBriefImageRequest: XGAbstractVcrLibBriefImageRequest
    {
        private string brief;
        public XGVcrAddFaceLibBriefImageRequest():base("face")
        {
        }

        /// <summary>
        /// 库集名称
        /// <para>必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "brief", NullValueHandling = NullValueHandling.Ignore)]
        public string Brief { get => brief; set => brief = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
