using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.VCR.Model
{
    /// <summary>
    /// 自定义库请求抽象类
    /// </summary>
    public abstract class XGAbstractVcrCustomLibRequest: XGAbstractVcrRequest
    {
        private string libType;
        public XGAbstractVcrCustomLibRequest(string libtype)
        {
            libType = libtype;
        }

        /// <summary>
        /// 库类型
        /// <para>face、logo、text、image</para>
        /// </summary>
        [JsonIgnore]
        public string LibType { get => libType; }
    }
}
