using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.VCR.Model
{
    /// <summary>
    /// 查询直播流审核状态请求类
    /// </summary>
    public class XGVcrQueryStreamStatusRequest: XGAbstractVcrRequest
    {
        private string source;

        public XGVcrQueryStreamStatusRequest()
        {
            VcrVersion = XGVcrVersion.v2;
        }

        /// <summary>
        /// 直播流地址
        /// <para>需要对source进行urlEncode。</para>
        /// <para> 必需 </para>
        /// </summary>
        [JsonIgnore]
        public string Source { get => source; set => source = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
