using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using static XGBceDotNetSDK.Services.LSS.Model.XGLssEnum;

namespace XGBceDotNetSDK.Services.LSS.Model
{
    /// <summary>
    /// 统计数据信息
    /// </summary>
    public class XGLssStatisticsInfo
    {
        private DateTime? timestamp;
        private int? playCount;

        /// <summary>
        /// 数据时间点
        /// </summary>
        [JsonProperty(PropertyName = "timestamp", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? Timestamp { get => timestamp; set => timestamp = value; }
        /// <summary>
        /// 播放请求数
        /// </summary>
        [JsonProperty(PropertyName = "playCount", NullValueHandling = NullValueHandling.Ignore)]
        public int? PlayCount { get => playCount; set => playCount = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
    /// <summary>
    /// 查询请求数响应类
    /// </summary>
    public class XGLssQueryDomainPlayCountResponse:XGLssResponse
    {
        private string domain;
        private DateTime? startDate;
        private DateTime? endDate;
        private XGLssStatisticsTimeInterval? timeInterval;
        private List<XGLssStatisticsInfo> hlsStatistics;
        private List<XGLssStatisticsInfo> flvStatistics;
        private List<XGLssStatisticsInfo> rtmpStatistics;
        private List<XGLssStatisticsInfo> totalStatistics;

        public XGLssQueryDomainPlayCountResponse()
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
        /// hls请求数数组
        /// </summary>
        [JsonProperty(PropertyName = "hlsStatistics", NullValueHandling = NullValueHandling.Ignore)]
        public List<XGLssStatisticsInfo> HlsStatistics { get => hlsStatistics; set => hlsStatistics = value; }
        /// <summary>
        /// flv请求数数组
        /// </summary>
        [JsonProperty(PropertyName = "flvStatistics", NullValueHandling = NullValueHandling.Ignore)]
        public List<XGLssStatisticsInfo> FlvStatistics { get => flvStatistics; set => flvStatistics = value; }
        /// <summary>
        /// rtmp请求数数组
        /// </summary>
        [JsonProperty(PropertyName = "rtmpStatistics", NullValueHandling = NullValueHandling.Ignore)]
        public List<XGLssStatisticsInfo> RtmpStatistics { get => rtmpStatistics; set => rtmpStatistics = value; }
        /// <summary>
        /// 总请求数数组
        /// </summary>
        [JsonProperty(PropertyName = "totalStatistics", NullValueHandling = NullValueHandling.Ignore)]
        public List<XGLssStatisticsInfo> TotalStatistics { get => totalStatistics; set => totalStatistics = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
