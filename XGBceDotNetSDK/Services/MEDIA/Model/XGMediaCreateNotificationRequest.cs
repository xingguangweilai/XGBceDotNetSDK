using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace XGBceDotNetSDK.Services.MEDIA.Model
{
    /// <summary>
    /// 创建通知请求类
    /// </summary>
    public class XGMediaCreateNotificationRequest:XGAbstractMediaRequest
    {
        private string name;
        private string endpoint;
        private XGMediaNotificationType? type;
        private string token;
        
        public XGMediaCreateNotificationRequest()
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
        /// <summary>
        /// 通知消息类型
        /// <para>非必需</para>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)),JsonProperty(PropertyName = "type", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaNotificationType? Type { get => type; set => type = value; }
        /// <summary>
        /// 通知消息鉴权token
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "token", NullValueHandling = NullValueHandling.Ignore)]
        public string Token { get => token; set => token = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
