using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.VCA.Model
{
    /// <summary>
    /// 分析失败信息类
    /// </summary>
    public class XGVcaError
    {
        private string code;
        private string message;

        public XGVcaError()
        {
        }

        /// <summary>
        /// 错误码
        /// </summary>
        [JsonProperty(PropertyName = "code", NullValueHandling = NullValueHandling.Ignore)]
        public string Code { get => code; set => code = value; }
        /// <summary>
        /// 错误信息
        /// </summary>
        [JsonProperty(PropertyName = "message", NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get => message; set => message = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
