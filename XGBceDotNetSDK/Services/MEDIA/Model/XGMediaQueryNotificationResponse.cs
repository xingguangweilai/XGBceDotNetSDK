using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.MEDIA.Model
{
    /// <summary>
    /// 查询通知响应类
    /// </summary>
    public class XGMediaQueryNotificationResponse:XGMediaResponse
    {
        private string name;
        private string endpoint;

        public XGMediaQueryNotificationResponse()
        {
        }

        /// <summary>
        /// 通知名称
        /// <para>必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get => name; set => name = value; }
        /// <summary>
        /// 通知消息接收地址
        /// <para>必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "endpoint", NullValueHandling = NullValueHandling.Ignore)]
        public string Endpoint { get => endpoint; set => endpoint = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
