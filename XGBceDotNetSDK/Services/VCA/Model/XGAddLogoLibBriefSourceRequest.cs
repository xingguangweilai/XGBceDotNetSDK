using System;
using Newtonsoft.Json;
using XGBceDotNetSDK.Sign;

namespace XGBceDotNetSDK.Services.VCA.Model
{
    /// <summary>
    /// 添加logo库集素材请求类
    /// </summary>
    public class XGAddLogoLibBriefSourceRequest:XGAbstractVcaRequest
    {
        private string lib;
        private string image;
        private string brief;
        public XGAddLogoLibBriefSourceRequest()
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
        [JsonProperty(PropertyName = "image", NullValueHandling = NullValueHandling.Ignore)]
        public string Image { get => image; set => image = value; }
        /// <summary>
        /// 图片描述
        /// 非必需
        /// </summary>
        [JsonProperty(PropertyName = "brief", NullValueHandling = NullValueHandling.Ignore)]
        public string Brief { get => brief; set => brief = value; }

    }
}
