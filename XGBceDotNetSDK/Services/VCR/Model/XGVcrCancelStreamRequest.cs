using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.VCR.Model
{
    /// <summary>
    /// 取消直播流审核请求类
    /// </summary>
    public class XGVcrCancelStreamRequest: XGAbstractVcrRequest
    {
        private string source;
        private string notification;

        public XGVcrCancelStreamRequest()
        {
            VcrVersion = XGVcrVersion.v2;
        }

        /// <summary>
        /// 直播流地址，支持RTMP/HTTP拉流
        /// <para>长度不超过1024</para>
        /// <para>必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "source")]
        public string Source { get => source; set => source = value; }
        /// <summary>
        /// 通知名称
        /// <para>必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "notification")]
        public string Notification { get => notification; set => notification = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
