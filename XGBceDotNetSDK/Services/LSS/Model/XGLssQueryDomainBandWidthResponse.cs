using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using static XGBceDotNetSDK.Services.LSS.Model.XGLssEnum;

namespace XGBceDotNetSDK.Services.LSS.Model
{
    /// <summary>
    /// 带宽统计数据
    /// </summary>
    public class XGLssStatisticsBandWidth
    {
        private DateTime? timestamp;
        private int? bandwidthInBps;

        /// <summary>
        /// 数据时间点
        /// </summary>
        [JsonProperty(PropertyName = "timestamp", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? Timestamp { get => timestamp; set => timestamp = value; }
        /// <summary>
        /// 平均带宽
        /// <para>单位：bps (bit per second)</para>
        /// </summary>
        [JsonProperty(PropertyName = "bandwidthInBps", NullValueHandling = NullValueHandling.Ignore)]
        public int? BandwidthInBps { get => bandwidthInBps; set => bandwidthInBps = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
    /// <summary>
    /// 查询总带宽响应类
    /// </summary>
    public class XGLssQueryDomainBandWidthResponse:XGLssResponse
    {
        private string domain;
        private DateTime? startDate;
        private DateTime? endDate;
        private XGLssStatisticsTimeInterval? timeInterval;
        private List<XGLssStatisticsBandWidth> statistics;

        public XGLssQueryDomainBandWidthResponse()
        {
        }

        /// <summary>
        /// 直播域名
        /// </summary>
        [JsonProperty(PropertyName = "domain", NullValueHandling = NullValueHandling.Ignore)]
        public string Domain { get => domain; set => domain = value; }
        /// <summary>
        /// 统计数据起始时间
        /// </summary>
        [JsonProperty(PropertyName = "startDate", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? StartDate { get => startDate; set => startDate = value; }
        /// <summary>
        /// 统计数据截止时间
        /// </summary>
        [JsonProperty(PropertyName = "endDate", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? EndDate { get => endDate; set => endDate = value; }
        /// <summary>
        /// 时间间隔
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)), JsonProperty(PropertyName = "timeInterval", NullValueHandling = NullValueHandling.Ignore)]
        public XGLssStatisticsTimeInterval? TimeInterval { get => timeInterval; set => timeInterval = value; }
        /// <summary>
        /// 统计数据数组
        /// </summary>
        [JsonProperty(PropertyName = "statistics", NullValueHandling = NullValueHandling.Ignore)]
        public List<XGLssStatisticsBandWidth> Statistics { get => statistics; set => statistics = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
