using System;
using Newtonsoft.Json;
using static XGBceDotNetSDK.Services.LSS.Model.XGLssEnum;

namespace XGBceDotNetSDK.Services.LSS.Model
{
    /// <summary>
    /// 查询总带宽请求类
    /// </summary>
    public class XGLssQueryDomainBandWidthRequest:XGAbstractLssRequest
    {
        private DateTime? startTime;
        private DateTime? endTime;
        private XGLssStatisticsTimeInterval? timeInterval;
        private string playDomain;

        public XGLssQueryDomainBandWidthRequest()
        {
        }

        /// <summary>
        /// 起始时间
        /// <para>必需</para>
        /// </summary>
        [JsonIgnore]
        public DateTime? StartTime { get => startTime; set => startTime = value; }
        /// <summary>
        /// 结束时间
        /// <para>可选</para>
        /// </summary>
        [JsonIgnore]
        public DateTime? EndTime { get => endTime; set => endTime = value; }
        /// <summary>
        /// 时间间隔
        /// <para>必需</para>
        /// </summary>
        [JsonIgnore]
        public XGLssStatisticsTimeInterval? TimeInterval { get => timeInterval; set => timeInterval = value; }
        /// <summary>
        /// 直播域名
        /// <para>查询总的请求数可不填</para>
        /// </summary>
        [JsonIgnore]
        public string PlayDomain { get => playDomain; set => playDomain = value; }
    }
}
