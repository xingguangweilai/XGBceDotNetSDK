using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.LSS.Model
{
    /// <summary>
    /// 创建通知请求类
    /// </summary>
    public class XGLssCreateNotificationRequest:XGAbstractLssRequest
    {
        private string name;
        private string endpoint;

        public XGLssCreateNotificationRequest()
        {
        }

        /// <summary>
        /// 接口名称
        /// <para>开头必须是小写字母，其余可以是小写字母、_或数字组成，最多不超过40个字符</para>
        /// <para>必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get => name; set => name = value; }
        /// <summary>
        /// 通知消息接口地址
        /// <para>不超过256字符</para>
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
