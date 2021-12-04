using System;
using Newtonsoft.Json;
using XGBceDotNetSDK.Sign;

namespace XGBceDotNetSDK.Services.VCA.Model
{
    /// <summary>
    /// 删除face库集素材请求类
    /// </summary>
    public class XGDeleteFaceLibBriefSourceRequest: XGAbstractVcaRequest
    {
        private string lib;
        private string image;
        private string brief;
        public XGDeleteFaceLibBriefSourceRequest()
        {
        }

        /// <summary>
        /// logo库名
        /// 必需
        /// </summary>
        [JsonIgnore]
        public string Lib { get => lib; set => lib = value; }
        /// <summary>
        /// 图片URL
        /// 必需
        /// </summary>
        [JsonIgnore]
        public string Image { get => image; set => image = value; }
        /// <summary>
        /// 图片描述
        /// 必需
        /// </summary>
        [JsonIgnore]
        public string Brief { get => brief; set => brief = value; }
    }
}
