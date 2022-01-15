using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.LSS.Model
{
    /// <summary>
    /// 通知信息
    /// </summary>
    public class XGLssNotification
    {
        private string name;
        private string endpoint;

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
    /// <summary>
    /// 通知列表响应类
    /// </summary>
    public class XGLssListNotificationsResponse:XGLssResponse
    {
        private List<XGLssNotification> notifications;

        public XGLssListNotificationsResponse()
        {
        }

        /// <summary>
        /// 通知列表
        /// </summary>
        [JsonProperty(PropertyName = "notifications", NullValueHandling = NullValueHandling.Ignore)]
        public List<XGLssNotification> Notifications { get => notifications; set => notifications = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
