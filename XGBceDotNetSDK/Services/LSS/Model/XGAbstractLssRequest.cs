using System;
using Newtonsoft.Json;
using XGBceDotNetSDK.BaseClass;
using static XGBceDotNetSDK.Services.LSS.Model.XGLssEnum;

namespace XGBceDotNetSDK.Services.LSS.Model
{
    /// <summary>
    /// 音视频直播抽象请求类
    /// </summary>
    public abstract class XGAbstractLssRequest: XGAbstractBceRequest
    {
        private XGLssVersion lssVersion = XGLssVersion.v5;  //默认v5

        public XGAbstractLssRequest()
        {
        }

        /// <summary>
        /// 音视频直播API版本
        /// </summary>
        [JsonIgnore]
        public XGLssVersion LssVersion { get => lssVersion; set => lssVersion = value; }
    }
}
