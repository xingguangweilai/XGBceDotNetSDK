using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.LSS.Model
{
    /// <summary>
    /// 统计概要
    /// </summary>
    public class XGLssSummaryStatistics
    {
        private long? downStreamInByte;
        private int? durationInMinute;
        private int? playCount;
        private int? transcoding;

        /// <summary>
        /// 累计总流量
        /// </summary>
        [JsonProperty(PropertyName = "downStreamInByte", NullValueHandling = NullValueHandling.Ignore)]
        public long? DownStreamInByte { get => downStreamInByte; set => downStreamInByte = value; }
        /// <summary>
        /// 累计直播时长
        /// </summary>
        [JsonProperty(PropertyName = "durationInMinute", NullValueHandling = NullValueHandling.Ignore)]
        public int? DurationInMinute { get => durationInMinute; set => durationInMinute = value; }
        /// <summary>
        /// 累计播放时长
        /// </summary>
        [JsonProperty(PropertyName = "playCount", NullValueHandling = NullValueHandling.Ignore)]
        public int? PlayCount { get => playCount; set => playCount = value; }
        /// <summary>
        /// 累计转码时长（分钟）
        /// </summary>
        [JsonProperty(PropertyName = "transcoding", NullValueHandling = NullValueHandling.Ignore)]
        public int? Transcoding { get => transcoding; set => transcoding = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
    /// <summary>
    /// 查询统计概要响应类
    /// </summary>
    public class XGLssQueryDomainSummaryStatisticsResponse:XGLssResponse
    {
        private DateTime? startTime;
        private DateTime? endTime;
        private XGLssSummaryStatistics summary;

        public XGLssQueryDomainSummaryStatisticsResponse()
        {
        }

        /// <summary>
        /// 统计数据起始时间
        /// </summary>
        [JsonProperty(PropertyName = "startTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? StartTime { get => startTime; set => startTime = value; }
        /// <summary>
        /// 统计数据截止时间
        /// </summary>
        [JsonProperty(PropertyName = "endTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? EndTime { get => endTime; set => endTime = value; }
        /// <summary>
        /// 统计概要
        /// </summary>
        [JsonProperty(PropertyName = "summary", NullValueHandling = NullValueHandling.Ignore)]
        public XGLssSummaryStatistics Summary { get => summary; set => summary = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
