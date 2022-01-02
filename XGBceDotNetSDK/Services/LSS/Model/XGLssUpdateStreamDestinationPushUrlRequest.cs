using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.LSS.Model
{
    /// <summary>
    /// 更新stream目标推流地址
    /// </summary>
    public class XGLssUpdateStreamDestinationPushUrlRequest : XGLssStreamRequest
    {
        private string destinationPushUrl;
        public XGLssUpdateStreamDestinationPushUrlRequest()
        {
        }

        /// <summary>
        /// 目标推流地址
        /// <para>必需</para>
        /// </summary>
        [JsonIgnore]
        public string DestinationPushUrl { get => destinationPushUrl; set => destinationPushUrl = value; }
    }
}
