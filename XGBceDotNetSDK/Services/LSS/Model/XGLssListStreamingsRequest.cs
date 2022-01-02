using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.LSS.Model
{
    /// <summary>
    /// 查询活跃的Stream请求类
    /// </summary>
    public class XGLssListStreamingsRequest:XGAbstractLssRequest
    {
        private string playDomain;
        public XGLssListStreamingsRequest()
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
