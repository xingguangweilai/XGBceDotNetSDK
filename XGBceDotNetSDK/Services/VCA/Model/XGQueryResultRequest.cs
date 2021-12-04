using System;
using Newtonsoft.Json;
using XGBceDotNetSDK.BaseClass;
using XGBceDotNetSDK.Sign;

namespace XGBceDotNetSDK.Services.VCA.Model
{
    public class XGQueryResultRequest : XGAbstractVcaRequest
    {
        private string source;
        public XGQueryResultRequest()
        {
        }

        /// <summary>
        /// 视频路径，需要对source进行urlEncode
        /// 必需
        /// </summary>
        [JsonIgnore]
        public string Source{ get => source; set => source = value;}

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
