using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.VCR.Model
{
    /// <summary>
    /// 添加logo库集素材响应类
    /// </summary>
    public class XGVcrAddLogoLibBriefImageResponse: XGVcrResponse
    {
        private string imageId;
        public XGVcrAddLogoLibBriefImageResponse()
        {
        }

        /// <summary>
        /// 图片id
        /// <para>必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "imageId", NullValueHandling = NullValueHandling.Ignore)]
        public string ImageId { get => imageId; set => imageId = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
