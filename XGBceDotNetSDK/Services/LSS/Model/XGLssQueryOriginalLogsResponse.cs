using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.LSS.Model
{
    /// <summary>
    /// 日志信息
    /// </summary>
    public class XGLssLogEntry
    {
        private string key;
        private string url;
        private DateTime? startTime;
        private DateTime? endTime;
        private int? size;

        /// <summary>
        /// 日志文件名
        /// </summary>
        [JsonProperty(PropertyName = "key", NullValueHandling = NullValueHandling.Ignore)]
        public string Key { get => key; set => key = value; }
        /// <summary>
        /// 日志文件下载url
        /// </summary>
        [JsonProperty(PropertyName = "url", NullValueHandling = NullValueHandling.Ignore)]
        public string Url { get => url; set => url = value; }
        /// <summary>
        /// 日志文件开始时间，UTC时间
        /// </summary>
        [JsonProperty(PropertyName = "startTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? StartTime { get => startTime; set => startTime = value; }
        /// <summary>
        /// 日志文件结束时间，UTC时间
        /// </summary>
        [JsonProperty(PropertyName = "endTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? EndTime { get => endTime; set => endTime = value; }
        /// <summary>
        /// 日志大小
        /// </summary>
        [JsonProperty(PropertyName = "size", NullValueHandling = NullValueHandling.Ignore)]
        public int? Size { get => size; set => size = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
    /// <summary>
    /// 获取日志下载地址响应类
    /// </summary>
    public class XGLssQueryOriginalLogsResponse:XGLssResponse
    {
        private string playdomain;
        private int? totalCount;
        private List<XGLssLogEntry> logEntries;

        public XGLssQueryOriginalLogsResponse()
        {
        }

        /// <summary>
        /// 查询的域名
        /// </summary>
        [JsonProperty(PropertyName = "playdomain", NullValueHandling = NullValueHandling.Ignore)]
        public string Playdomain { get => playdomain; set => playdomain = value; }
        /// <summary>
        /// 日志文件总个数
        /// </summary>
        [JsonProperty(PropertyName = "totalCount", NullValueHandling = NullValueHandling.Ignore)]
        public int? TotalCount { get => totalCount; set => totalCount = value; }
        /// <summary>
        /// 日志下载列表
        /// </summary>
        [JsonProperty(PropertyName = "logEntries", NullValueHandling = NullValueHandling.Ignore)]
        public List<XGLssLogEntry> LogEntries { get => logEntries; set => logEntries = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
