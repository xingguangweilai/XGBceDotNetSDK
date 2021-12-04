using System;
using Newtonsoft.Json;
using XGBceDotNetSDK.Sign;

namespace XGBceDotNetSDK.Services.VCA.Model
{
    /// <summary>
    /// 删除logo库集素材请求类
    /// </summary>
    public class XGDeleteLogoLibBriefSourceRequest: XGAbstractVcaRequest
    {
        private string lib;
        private string image;
        public XGDeleteLogoLibBriefSourceRequest()
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
    }
}
