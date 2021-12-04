using System;
using Newtonsoft.Json;
using XGBceDotNetSDK.BaseClass;
using XGBceDotNetSDK.Sign;

namespace XGBceDotNetSDK.Services.VCA.Model
{
    /// <summary>
    /// 删除自定义face库请求类
    /// </summary>
    public class XGDeleteCustomFaceLibRequest: XGAbstractVcaRequest
    {
        private string lib;
        private string version;

        public XGDeleteCustomFaceLibRequest() { }

        /// <summary>
        /// face库名
        /// 必需
        /// </summary>
        [JsonIgnore]
        public string Lib { get => lib; set => lib = value; }
        /// <summary>
        /// 版本
        /// 必需
        /// </summary>
        [JsonIgnore]
        public string Version { get => version; set => version = value; }



    }
}
