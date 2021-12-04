using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.VCR.Model
{
    /// <summary>
    /// 创建自定义logo库请求类
    /// </summary>
    public class XGVcrCreateCustomLogoLibRequest: XGAbstractVcrCreateCustomLibRequest
    {
        private string lib;

        public XGVcrCreateCustomLogoLibRequest() : base("logo")
        {
        }

        /// <summary>
        /// 自定义logo库名称
        /// <para>必需</para>
        /// </summary>
        [JsonProperty("lib")]
        public string Lib { get => lib; set => lib = value; }


        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
