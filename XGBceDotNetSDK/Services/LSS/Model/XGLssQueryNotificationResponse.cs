using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.LSS.Model
{
    /// <summary>
    /// 查询通知响应类
    /// </summary>
    public class XGLssQueryNotificationResponse:XGLssResponse
    {
        private string name;
        private string endpoint;

        public XGLssQueryNotificationResponse()
        {
        }

        /// <summary>
        /// 接口名称
        /// </summary>
        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get => name; set => name = value; }
        /// <summary>
        /// 通知消息接口地址
        /// </summary>
        [JsonProperty(PropertyName = "endpoint", NullValueHandling = NullValueHandling.Ignore)]
        public string Endpoint { get => endpoint; set => endpoint = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
