using System;
using Newtonsoft.Json;
using XGBceDotNetSDK.BaseClass;

namespace XGBceDotNetSDK.Services.VCR.Model
{
    /// <summary>
    /// 媒体内容审核VCR抽象请求类
    /// </summary>
    public abstract class XGAbstractVcrRequest: XGAbstractBceRequest
    {
        private XGVcrVersion vcrVersion = XGVcrVersion.v1;  //默认v1

        public XGAbstractVcrRequest()
        {
        }

        /// <summary>
        /// VCR接口版本
        /// </summary>
        [JsonIgnore]
        public XGVcrVersion VcrVersion { get => vcrVersion; set => vcrVersion = value; }
    }
}
