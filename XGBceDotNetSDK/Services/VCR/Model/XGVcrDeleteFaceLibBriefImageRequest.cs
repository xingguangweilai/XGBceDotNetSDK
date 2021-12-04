using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.VCR.Model
{
    /// <summary>
    /// 删除face库集素材
    /// </summary>
    public class XGVcrDeleteFaceLibBriefImageRequest:XGAbstractVcrLibBriefImageRequest
    {
        private string brief;
        public XGVcrDeleteFaceLibBriefImageRequest():base("face")
        {
        }

        /// <summary>
        /// 库集名称
        /// <para>必需</para>
        /// </summary>
        [JsonIgnore]
        public string Brief { get => brief; set => brief = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
