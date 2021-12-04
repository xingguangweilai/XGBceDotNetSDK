using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.VCR.Model
{
    /// <summary>
    /// 库集素材请求抽象类
    /// </summary>
    public abstract class XGAbstractVcrLibBriefImageRequest: XGAbstractVcrRequest
    {
        private string libType;
        private string image;
        private string libName;
        public XGAbstractVcrLibBriefImageRequest(string libtype)
        {
            libType = libtype;
        }

        /// <summary>
        /// 库类型
        /// <para>face、logo、text、image</para>
        /// </summary>
        [JsonIgnore]
        public string LibType { get => libType; }
        /// <summary>
        /// 图片URL
        /// <para>必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "image", NullValueHandling = NullValueHandling.Ignore)]
        public string Image { get => image; set => image = value; }
        /// <summary>
        /// 库名称
        /// </summary>
        [JsonIgnore]
        public string LibName { get => libName; set => libName = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
