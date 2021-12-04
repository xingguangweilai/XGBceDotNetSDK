using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.VCR.Model
{
    /// <summary>
    /// 查询视频审核结果请求类
    /// </summary>
    public class XGVcrQueryMediaResultRequest: XGAbstractVcrRequest
    {
        private string source;

        public XGVcrQueryMediaResultRequest()
        {
            VcrVersion = XGVcrVersion.v2;
        }

        /// <summary>
        /// 视频路径，需要对source进行urlEncode。
        /// <para> 必需 </para>
        /// </summary>
        [JsonIgnore]
        public string Source { get => source; set => source = value; }
    }
}
