using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.VCR.Model
{
    /// <summary>
    /// 删除logo库集素材请求类
    /// </summary>
    public class XGVcrDeleteLogoLibBriefImageRequest: XGAbstractVcrLibBriefImageRequest
    {
        private string imageId;
        public XGVcrDeleteLogoLibBriefImageRequest():base("logo")
        {
        }

        /// <summary>
        /// 图片id
        /// <para>当imageId不为空时，image值可为空</para>
        /// </summary>
        [JsonIgnore]
        public string ImageId { get => imageId; set => imageId = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
