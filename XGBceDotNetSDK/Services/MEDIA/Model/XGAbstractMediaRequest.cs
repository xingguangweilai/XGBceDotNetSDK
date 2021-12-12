using System;
using Newtonsoft.Json;
using XGBceDotNetSDK.BaseClass;

namespace XGBceDotNetSDK.Services.MEDIA.Model
{
    /// <summary>
    /// 音视频MCP抽象请求类
    /// </summary>
    public abstract class XGAbstractMediaRequest: XGAbstractBceRequest
    {
        private XGMediaVersion mediaVersion = XGMediaVersion.v3;  //默认v3
        public XGAbstractMediaRequest()
        {
        }

        /// <summary>
        /// DOC接口版本
        /// </summary>
        [JsonIgnore]
        public XGMediaVersion MediaVersion { get => mediaVersion; set => mediaVersion = value; }
    }
}
