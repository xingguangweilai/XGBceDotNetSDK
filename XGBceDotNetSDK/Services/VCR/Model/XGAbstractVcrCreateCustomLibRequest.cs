using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.VCR.Model
{
    /// <summary>
    /// 创建自定义库请求类抽象方法
    /// </summary>
    public abstract class XGAbstractVcrCreateCustomLibRequest: XGAbstractVcrCustomLibRequest
    {
        private string description;
        

        public XGAbstractVcrCreateCustomLibRequest(string libtype):base(libtype)
        {
        }
        

        /// <summary>
        /// 描述，最大支持256字符	
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get => description; set => description = value; }
        
    }
}
