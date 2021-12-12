using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.MEDIA.Model
{
    /// <summary>
    /// 列举通知响应类
    /// </summary>
    public class XGMediaListNotificationsResponse:XGMediaResponse
    {
        private List<XGMediaQueryNotificationResponse> notifications;

        public XGMediaListNotificationsResponse()
        {
        }

        /// <summary>
        /// 通知列表
        /// </summary>
        [JsonProperty(PropertyName = "notifications", NullValueHandling = NullValueHandling.Ignore)]
        public List<XGMediaQueryNotificationResponse> Notifications { get => notifications; set => notifications = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
