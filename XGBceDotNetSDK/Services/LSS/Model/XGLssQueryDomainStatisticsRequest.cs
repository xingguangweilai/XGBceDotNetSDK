using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.LSS.Model
{
    /// <summary>
    /// 查询特定域名统计数据请求类
    /// </summary>
    public class XGLssQueryDomainStatisticsRequest:XGAbstractLssRequest
    {
        private string playDomain;
        private string startDate;
        private string endDate;
        private bool? aggregate;

        public XGLssQueryDomainStatisticsRequest()
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
        /// <para>示例：20160202</para>
        /// <para>必需</para>
        /// </summary>
        [JsonIgnore]
        public string StartDate { get => startDate; set => startDate = value; }
        /// <summary>
        /// 结束时间
        /// <para>示例：20160205</para>
        /// <para>必需</para>
        /// </summary>
        [JsonIgnore]
        public string EndDate { get => endDate; set => endDate = value; }
        /// <summary>
        /// 指定是否聚合，即数据聚合统计或按日统计
        /// <para>有效值：true、false，默认值: false。为true时聚合统计；否则按日统计</para>
        /// <para>可选</para>
        /// </summary>
        [JsonIgnore]
        public bool? Aggregate { get => aggregate; set => aggregate = value; }
    }
}
