using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.MEDIA.Model
{
    /// <summary>
    /// 查询通知请求类
    /// </summary>
    public class XGMediaQueryNotificationRequest:XGAbstractMediaRequest
    {
        private string name;

        public XGMediaQueryNotificationRequest()
        {
        }

        /// <summary>
        /// 通知名称
        /// <para>必需</para>
        /// </summary>
        [JsonIgnore]
        public string Name { get => name; set => name = value; }
    }
}
