using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using XGBceDotNetSDK.BaseClass;

namespace XGBceDotNetSDK.Services.VCA.Model
{
    /// <summary>
    /// 视频分析结果
    /// </summary>
    public class XGQueryResultResponse: XGAbstractBceResponse
    {
        private string source;
        private string mediaId;
        private string title;
        private string description;
        private XGVcaAnalyzeStatus status;
        private int? duration;
        private DateTime? createTime;
        private DateTime? startTime;
        private string preset;
        private string notification;
        private int percent;
        private DateTime? publishTime;
        private List<XGTagsResult> results;
        private XGVcaError error;

        public XGQueryResultResponse()
        {
        }

        /// <summary>
        /// 视频路径
        /// </summary>
        [JsonProperty(PropertyName = "source", NullValueHandling = NullValueHandling.Ignore)]
        public string Source { get => source; set => source = value; }
        /// <summary>
        /// VOD媒资id，source为VOD路径时存在
        /// </summary>
        [JsonProperty(PropertyName = "mediaId", NullValueHandling = NullValueHandling.Ignore)]
        public string MediaId { get => mediaId; set => mediaId = value; }
        /// <summary>
        /// 视频标题
        /// </summary>
        [JsonProperty(PropertyName = "title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get => title; set => title = value; }
        /// <summary>
        /// 视频描述
        /// </summary>
        [JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get => description; set => description = value; }
        /// <summary>
        /// 分析状态
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)), JsonProperty(PropertyName = "status", NullValueHandling = NullValueHandling.Ignore)]
        public XGVcaAnalyzeStatus Status { get => status; set => status = value; }
        /// <summary>
        /// 视频时长，仅当status!=PROVISIONING时存在
        /// </summary>
        [JsonProperty(PropertyName = "duration", NullValueHandling = NullValueHandling.Ignore)]
        public int? Duration { get => duration; set => duration = value; }
        /// <summary>
        /// 分析创建时间
        /// </summary>
        [JsonProperty(PropertyName = "createTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? CreateTime { get => createTime; set => createTime = value; }
        /// <summary>
        /// 分析开始时间，仅当status!=RPOVISIONING/CANCELLED时存在
        /// </summary>
        [JsonProperty(PropertyName = "startTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? StartTime { get => startTime; set => startTime = value; }
        /// <summary>
        /// 分析模板名称
        /// </summary>
        [JsonProperty(PropertyName = "preset", NullValueHandling = NullValueHandling.Ignore)]
        public string Preset { get => preset; set => preset = value; }
        /// <summary>
        /// 通知名称
        /// </summary>
        [JsonProperty(PropertyName = "notification", NullValueHandling = NullValueHandling.Ignore)]
        public string Notification { get => notification; set => notification = value; }
        /// <summary>
        /// 分析进度，0 ~ 100整数
        /// </summary>
        [JsonProperty(PropertyName = "percent", NullValueHandling = NullValueHandling.Ignore)]
        public int Percent { get => percent; set => percent = value; }
        /// <summary>
        /// 分析结束时间，仅当status=FINISHED/ERROR/CANCELLED时存在
        /// </summary>
        [JsonProperty(PropertyName = "publishTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? PublishTime { get => publishTime; set => publishTime = value; }
        /// <summary>
        /// 分析结果，仅当status=PROCESSING/FINISHED时存在
        /// </summary>
        [JsonProperty(PropertyName = "results", NullValueHandling = NullValueHandling.Ignore)]
        public List<XGTagsResult> Results { get => results; set => results = value; }
        /// <summary>
        /// 视频路径
        /// </summary>
        [JsonProperty(PropertyName = "error", NullValueHandling = NullValueHandling.Ignore)]
        public XGVcaError Error { get => error; set => error = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
