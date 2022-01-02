using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.LSS.Model
{
    /// <summary>
    /// 查询所有App请求类
    /// </summary>
    public class XGLssListAppsRequest: XGAbstractLssRequest
    {
        private string playDomain;
        public XGLssListAppsRequest()
        {
        }

        /// <summary>
        /// 直播域名
        /// <para>必需</para>
        /// </summary>
        [JsonIgnore]
        public string PlayDomain { get => playDomain; set => playDomain = value; }
    }
}
