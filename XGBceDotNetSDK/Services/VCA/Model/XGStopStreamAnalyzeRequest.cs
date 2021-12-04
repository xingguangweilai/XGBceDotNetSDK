using System;
using Newtonsoft.Json;
using XGBceDotNetSDK.BaseClass;
using XGBceDotNetSDK.Sign;

namespace XGBceDotNetSDK.Services.VCA.Model
{
    /// <summary>
    /// 结束直播分析任务
    /// </summary>
    public class XGStopStreamAnalyzeRequest: XGAbstractVcaRequest
    {
        private string source;
        private readonly string stop = "stop";
        public XGStopStreamAnalyzeRequest()
        {
            VcaVersion = XGVcaVersion.v1; //直播分析仅支持v1
         }

        /// <summary>
        /// 直播路径
        /// 必需
        /// </summary>
        [JsonIgnore]
        public string Source { get => source; set => source = value; }

        /// <summary>
        /// 标志参数，不需要填值
        /// 必需
        /// </summary>
        [JsonIgnore]
        public string Stop => stop;
    }
}
