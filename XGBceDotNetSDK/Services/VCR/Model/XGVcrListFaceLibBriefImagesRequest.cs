using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.VCR.Model
{
    /// <summary>
    /// 列举face库集素材请求类
    /// </summary>
    public class XGVcrListFaceLibBriefImagesRequest : XGAbstractVcrRequest
    {
        private string libName;
        private string brief;
        public XGVcrListFaceLibBriefImagesRequest()
        {
        }

        /// <summary>
        /// 库名称
        /// <para>必需</para>
        /// </summary>
        [JsonIgnore]
        public string LibName { get => libName; set => libName = value; }
        /// <summary>
        /// 库集名称
        /// <para>必需</para>
        /// </summary>
        [JsonIgnore]
        public string Brief { get => brief; set => brief = value; }
    }
}
