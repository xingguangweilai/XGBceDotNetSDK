using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.VCR.Model
{
    /// <summary>
    /// 删除face库集请求类
    /// </summary>
    public class XGVcrDeleteFaceLibBriefRequest: XGAbstractVcrRequest
    {
        private string libName;
        private string brief;
        public XGVcrDeleteFaceLibBriefRequest()
        {
        }

        /// <summary>
        /// face库名称
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
