using System;
using Newtonsoft.Json;
using XGBceDotNetSDK.Sign;

namespace XGBceDotNetSDK.Services.VCA.Model
{
    /// <summary>
    /// face库集素材列表请求类
    /// </summary>
    public class XGListFaceLibBriefSourceRequest:XGAbstractVcaRequest
    {
        private string lib;
        private string brief;
        public XGListFaceLibBriefSourceRequest()
        {
        }

        /// <summary>
        /// logo库名
        /// 必需
        /// </summary>
        [JsonIgnore]
        public string Lib { get => lib; set => lib = value; }
        /// <summary>
        /// 图片描述
        /// 必需
        /// </summary>
        [JsonIgnore]
        public string Brief { get => brief; set => brief = value; }
    }
}
