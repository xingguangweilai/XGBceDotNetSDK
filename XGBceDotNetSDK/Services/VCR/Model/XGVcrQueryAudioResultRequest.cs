using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.VCR.Model
{
    /// <summary>
    /// 查询音频审核结果请求类
    /// </summary>
    public class XGVcrQueryAudioResultRequest : XGAbstractVcrRequest
    {
        private string source;

        public XGVcrQueryAudioResultRequest()
        {
        }

        /// <summary>
        /// 音频路径，需要对source进行urlEncode。
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
