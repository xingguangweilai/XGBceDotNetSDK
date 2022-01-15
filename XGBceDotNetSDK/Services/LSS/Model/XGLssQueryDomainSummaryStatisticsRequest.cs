using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.LSS.Model
{
    /// <summary>
    /// 查询统计概要请求类
    /// </summary>
    public class XGLssQueryDomainSummaryStatisticsRequest:XGAbstractLssRequest
    {
        private DateTime? startTime;
        private DateTime? endTime;

        public XGLssQueryDomainSummaryStatisticsRequest()
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
    }
}
