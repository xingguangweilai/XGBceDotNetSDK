using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.VCR.Model
{
    /// <summary>
    /// 删除自定义库抽象请求类
    /// </summary>
    public abstract class XGAbstractVcrDeleteCustomLibRequest: XGAbstractVcrCustomLibRequest
    {
        private string libname;
        public XGAbstractVcrDeleteCustomLibRequest(string libtype):base(libtype)
        {
        }

        /// <summary>
        /// 库名称
        /// </summary>
        [JsonIgnore]
        public string Libname { get => libname; set => libname = value; }
    }
}
