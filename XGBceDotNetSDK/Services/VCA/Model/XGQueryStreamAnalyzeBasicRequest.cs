using System;
using Newtonsoft.Json;
using XGBceDotNetSDK.BaseClass;
using XGBceDotNetSDK.Sign;

namespace XGBceDotNetSDK.Services.VCA.Model
{
    /// <summary>
    /// 查询直播分析基本信息
    /// </summary>
    public class XGQueryStreamAnalyzeBasicRequest: XGAbstractVcaRequest
    {
        private string source;

        public XGQueryStreamAnalyzeBasicRequest()
        {
            VcaVersion = XGVcaVersion.v1; //直播分析接口仅支持v1
        }

        /// <summary>
        /// 直播路径
        /// 必需
        /// </summary>
        [JsonIgnore]
        public string Source { get => source; set => source = value; }



    }
}
