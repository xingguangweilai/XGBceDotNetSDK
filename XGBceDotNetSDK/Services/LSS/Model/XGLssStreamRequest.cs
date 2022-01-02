using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.LSS.Model
{
    /// <summary>
    /// 通用Stream请求类
    /// </summary>
    public class XGLssStreamRequest: XGAbstractLssRequest
    {
        private string playDomain;
        private string app;
        private string stream;

        public XGLssStreamRequest()
        {
        }

        /// <summary>
        /// 播放域名
        /// <para>必需</para>
        /// </summary>
        [JsonIgnore]
        public string PlayDomain { get => playDomain; set => playDomain = value; }
        /// <summary>
        /// App
        /// <para>必需</para>
        /// </summary>
        [JsonIgnore]
        public string App { get => app; set => app = value; }
        /// <summary>
        /// 流名称
        /// <para>必需</para>
        /// </summary>
        [JsonIgnore]
        public string Stream { get => stream; set => stream = value; }
    }
}
