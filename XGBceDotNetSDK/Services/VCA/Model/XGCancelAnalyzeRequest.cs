using System;
using Newtonsoft.Json;
using XGBceDotNetSDK.BaseClass;
using XGBceDotNetSDK.Sign;

namespace XGBceDotNetSDK.Services.VCA.Model
{
    public class XGCancelAnalyzeRequest: XGAbstractVcaRequest
    {
        private string source;
        /// <summary>
        /// 标志参数，不需要取值
        /// 必需
        /// </summary>
        [JsonIgnore]
        public readonly string Cancel="cancel";

        /// <summary>
        /// 视频路径，需要对source进行urlEncode
        /// 必需
        /// </summary>
        [JsonIgnore]
        public string Source { get => source; set => source = value; }

        public XGCancelAnalyzeRequest()
        {
        }
    }
}
