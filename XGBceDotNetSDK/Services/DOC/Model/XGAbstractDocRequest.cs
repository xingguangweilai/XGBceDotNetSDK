using System;
using Newtonsoft.Json;
using XGBceDotNetSDK.BaseClass;

namespace XGBceDotNetSDK.Services.DOC.Model
{
    /// <summary>
    /// 文档服务DOC抽象请求类
    /// </summary>
    public abstract class XGAbstractDocRequest: XGAbstractBceRequest
    {
        private XGDocVersion docVersion = XGDocVersion.v2;  //默认v2
        public XGAbstractDocRequest()
        {
        }

        /// <summary>
        /// DOC接口版本
        /// </summary>
        [JsonIgnore]
        public XGDocVersion DocVersion { get => docVersion; set => docVersion = value; }
    }
}
