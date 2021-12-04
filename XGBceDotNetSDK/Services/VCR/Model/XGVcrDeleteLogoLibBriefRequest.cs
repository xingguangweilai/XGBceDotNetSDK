using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.VCR.Model
{
    /// <summary>
    /// 删除logo库集素材
    /// </summary>
    public class XGVcrDeleteLogoLibBriefRequest : XGAbstractVcrRequest
    {
        private string libName;
        private string brief;
        public XGVcrDeleteLogoLibBriefRequest()
        {
        }

        /// <summary>
        /// logo库名称
        /// </summary>
        [JsonIgnore]
        public string LibName { get => libName; set => libName = value; }
        /// <summary>
        /// 库集名称
        /// </summary>
        [JsonIgnore]
        public string Brief { get => brief; set => brief = value; }
    }
}
