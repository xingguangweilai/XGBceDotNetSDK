using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.MEDIA.Model
{
    /// <summary>
    /// 删除通知请求类
    /// </summary>
    public class XGMediaDeleteNotificationRequest:XGAbstractMediaRequest
    {
        private string name;

        public XGMediaDeleteNotificationRequest()
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
