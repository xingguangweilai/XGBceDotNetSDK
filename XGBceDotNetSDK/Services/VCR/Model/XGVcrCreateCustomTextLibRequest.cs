using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.VCR.Model
{
    /// <summary>
    /// 创建自定义文本库请求类
    /// </summary>
    public class XGVcrCreateCustomTextLibRequest: XGAbstractVcrCreateCustomLibRequest
    {
        private string name;
        public XGVcrCreateCustomTextLibRequest():base("text")
        {
        }

        /// <summary>
        /// 自定义文本库名称，最长40个字符
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
