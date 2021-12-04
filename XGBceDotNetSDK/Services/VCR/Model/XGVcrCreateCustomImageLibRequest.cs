using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.VCR.Model
{
    /// <summary>
    /// 创建自定义图片黑库请求类
    /// </summary>
    public class XGVcrCreateCustomImageLibRequest: XGAbstractVcrCreateCustomLibRequest
    {
        private string name;
        public XGVcrCreateCustomImageLibRequest() : base("image")
        {
        }

        /// <summary>
        /// 自定义图片黑库名称，最长40个字符
        /// <para>必需</para>
        /// </summary>
        [JsonProperty("name")]
        public string Name { get => name; set => name = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
