using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.LSS.Model
{
    /// <summary>
    /// 查看实时流推流url参数响应类
    /// </summary>
    public class XGLssQueryPushUrlParamsResponse:XGLssResponse
    {
        private Dictionary<string,string> lssParams;
        public XGLssQueryPushUrlParamsResponse()
        {
        }

        /// <summary>
        /// 推流参数列表
        /// </summary>
        [JsonProperty(PropertyName = "params", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, string> LssParams { get => lssParams; set => lssParams = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
