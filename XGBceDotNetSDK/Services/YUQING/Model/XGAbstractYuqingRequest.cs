using System;
using Newtonsoft.Json;
using XGBceDotNetSDK.BaseClass;

namespace XGBceDotNetSDK.Services.YUQING.Model
{
    /// <summary>
    /// 舆情服务抽象请求类
    /// </summary>
    public abstract class XGAbstractYuqingRequest: XGAbstractBceRequest
    {
        private XGYuqingVersion yuqingVersion = XGYuqingVersion.v1;  //默认v1

        public XGAbstractYuqingRequest()
        {
        }

        /// <summary>
        /// 舆情服务API版本
        /// </summary>
        [JsonIgnore]
        public XGYuqingVersion YuqingVersion { get => yuqingVersion; set => yuqingVersion = value; }
    }
}
