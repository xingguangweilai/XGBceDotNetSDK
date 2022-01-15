using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.LSS.Model
{
    /// <summary>
    /// 按日统计数据
    /// </summary>
    public class XGLssDayStatistics
    {
        private string date;
        private int? durationInMinute;
        private int? peakPlayCount;
        private int? peakBandwidthInBps;
        private long? downstreamInByte;
        private int? playCount;

        /// <summary>
        /// 数据日期
        /// </summary>
        [JsonProperty(PropertyName = "date", NullValueHandling = NullValueHandling.Ignore)]
        public string Date { get => date; set => date = value; }
        /// <summary>
        /// 直播总时长
        /// </summary>
        [JsonProperty(PropertyName = "durationInMinute", NullValueHandling = NullValueHandling.Ignore)]
        public int? DurationInMinute { get => durationInMinute; set => durationInMinute = value; }
        /// <summary>
        /// 当天峰值播放人数
        /// </summary>
        [JsonProperty(PropertyName = "peakPlayCount", NullValueHandling = NullValueHandling.Ignore)]
        public int? PeakPlayCount { get => peakPlayCount; set => peakPlayCount = value; }
        /// <summary>
        /// 峰值带宽
        /// </summary>
        [JsonProperty(PropertyName = "peakBandwidthInBps", NullValueHandling = NullValueHandling.Ignore)]
        public int? PeakBandwidthInBps { get => peakBandwidthInBps; set => peakBandwidthInBps = value; }
        /// <summary>
        /// 总下行流量
        /// </summary>
        [JsonProperty(PropertyName = "downstreamInByte", NullValueHandling = NullValueHandling.Ignore)]
        public long? DownstreamInByte { get => downstreamInByte; set => downstreamInByte = value; }
        /// <summary>
        /// 累计播放请求数
        /// <para>等于用户累计播放时长，单位：分钟</para>
        /// </summary>
        [JsonProperty(PropertyName = "playCount", NullValueHandling = NullValueHandling.Ignore)]
        public int? PlayCount { get => playCount; set => playCount = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
    /// <summary>
    /// 聚合统计数据
    /// </summary>
    public class XGLssAggregate
    {
        private int? durationInMinute;
        private int? peakPlayCount;
        private int? peakBandwidthInBps;
        private long? downstreamInByte;
        private int? playCount;

        /// <summary>
        /// 直播总时长
        /// </summary>
        [JsonProperty(PropertyName = "durationInMinute", NullValueHandling = NullValueHandling.Ignore)]
        public int? DurationInMinute { get => durationInMinute; set => durationInMinute = value; }
        /// <summary>
        /// 当天峰值播放人数
        /// </summary>
        [JsonProperty(PropertyName = "peakPlayCount", NullValueHandling = NullValueHandling.Ignore)]
        public int? PeakPlayCount { get => peakPlayCount; set => peakPlayCount = value; }
        /// <summary>
        /// 峰值带宽
        /// </summary>
        [JsonProperty(PropertyName = "peakBandwidthInBps", NullValueHandling = NullValueHandling.Ignore)]
        public int? PeakBandwidthInBps { get => peakBandwidthInBps; set => peakBandwidthInBps = value; }
        /// <summary>
        /// 总下行流量
        /// </summary>
        [JsonProperty(PropertyName = "downstreamInByte", NullValueHandling = NullValueHandling.Ignore)]
        public long? DownstreamInByte { get => downstreamInByte; set => downstreamInByte = value; }
        /// <summary>
        /// 累计播放请求数
        /// <para>等于用户累计播放时长，单位：分钟</para>
        /// </summary>
        [JsonProperty(PropertyName = "playCount", NullValueHandling = NullValueHandling.Ignore)]
        public int? PlayCount { get => playCount; set => playCount = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
    /// <summary>
    /// 查询特定域名的统计数据响应类
    /// </summary>
    public class XGLssQueryDomainStatisticsResponse:XGLssResponse
    {
        private string playDomain;
        private string startDate;
        private string endDate;
        private XGLssAggregate aggregate;
        private List<XGLssDayStatistics> statistics;

        public XGLssQueryDomainStatisticsResponse()
        {
        }

        /// <summary>
        /// 直播域名
        /// </summary>
        [JsonProperty(PropertyName = "playDomain", NullValueHandling = NullValueHandling.Ignore)]
        public string PlayDomain { get => playDomain; set => playDomain = value; }
        /// <summary>
        /// 起始日期
        /// </summary>
        [JsonProperty(PropertyName = "startDate", NullValueHandling = NullValueHandling.Ignore)]
        public string StartDate { get => startDate; set => startDate = value; }
        /// <summary>
        /// 结束日期
        /// </summary>
        [JsonProperty(PropertyName = "endDate", NullValueHandling = NullValueHandling.Ignore)]
        public string EndDate { get => endDate; set => endDate = value; }
        /// <summary>
        /// 聚合统计数据，仅当aggregate=true时存在
        /// </summary>
        [JsonProperty(PropertyName = "aggregate", NullValueHandling = NullValueHandling.Ignore)]
        public XGLssAggregate Aggregate { get => aggregate; set => aggregate = value; }
        /// <summary>
        /// 按日统计数据
        /// </summary>
        [JsonProperty(PropertyName = "statistics", NullValueHandling = NullValueHandling.Ignore)]
        public List<XGLssDayStatistics> Statistics { get => statistics; set => statistics = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
