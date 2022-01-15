using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.LSS.Model
{
    /// <summary>
    /// 获取日志下载地址请求类
    /// </summary>
    public class XGLssQueryOriginalLogsRequest:XGAbstractLssRequest
    {
        private string playDomain;
        private DateTime? startTime;
        private DateTime? endTime;

        public XGLssQueryOriginalLogsRequest()
        {
        }

        /// <summary>
        /// 直播域名
        /// <para>必需</para>
        /// </summary>
        [JsonIgnore]
        public string PlayDomain { get => playDomain; set => playDomain = value; }
        /// <summary>
        /// 起始时间
        /// <para>UTC时间。如：2017-02-03T15:00:00Z</para>
        /// <para>必需</para>
        /// </summary>
        [JsonIgnore]
        public DateTime? StartTime { get => startTime; set => startTime = value; }
        /// <summary>
        /// 结束时间
        /// <para>UTC时间。如：2017-02-03T15:00:00Z，默认为当前时间	</para>
        /// <para>必需</para>
        /// </summary>
        [JsonIgnore]
        public DateTime? EndTime { get => endTime; set => endTime = value; }
    }
}
