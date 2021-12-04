using System;
using Newtonsoft.Json;
namespace XGBceDotNetSDK.BaseClass
{
    /// <summary>
    /// 公共响应体
    /// </summary>
    public class XGBaseResponse:XGAbstractBceResponse
    {
        private string requestId;
        private string code="0";
        private string message;
        public XGBaseResponse()
        {
        }

        /// <summary>
        /// 是否成功
        /// </summary>
        [JsonIgnore]
        public virtual bool IsSuccess { get => "0".Equals(Code); }

        /// <summary>
        /// 导致该错误的requestId
        /// </summary>
        [JsonProperty(PropertyName = "requestId", NullValueHandling = NullValueHandling.Ignore)]
        public string RequestId { get {
                if (!string.IsNullOrEmpty(requestId)) return requestId;
                else
                 {
                    if(Metadata != null && !string.IsNullOrEmpty(Metadata.BceRequestId))
                        requestId = Metadata.BceRequestId;
                    return requestId;
                }
            } set => requestId = value; }
        /// <summary>
        /// 表示具体错误类型
        /// </summary>
        [JsonProperty(PropertyName = "code", NullValueHandling = NullValueHandling.Ignore)]
        public string Code { get => code; set => code = value; }
        /// <summary>
        /// 有关该错误的详细说明
        /// </summary>
        [JsonProperty(PropertyName = "message", NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get => message; set => message = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
