using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace XGBceDotNetSDK.Services.MEDIA.Model
{
    /// <summary>
    /// 查询指定视频转码任务响应类
    /// </summary>
    public class XGMediaQueryTranscodingJobResponse:XGMediaResponse
    {
        private string jobId;
        private string pipelineName;
        private XGMediaSourceInfo source;
        private XGMediaTargetInfo target;
        private XGMediaJobStatus? jobStatus;
        private XGMediaJobError error;
        private DateTime? createTime;
        private DateTime? startTime;
        private DateTime? endTime;

        public XGMediaQueryTranscodingJobResponse()
        {
        }

        /// <summary>
        /// 任务的唯一标示
        /// </summary>
        [JsonProperty(PropertyName = "jobId", NullValueHandling = NullValueHandling.Ignore)]
        public string JobId { get => jobId; set => jobId = value; }
        /// <summary>
        /// 输入的原始信息的集合
        /// </summary>
        [JsonProperty(PropertyName = "source", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaSourceInfo Source { get => source; set => source = value; }
        /// <summary>
        /// 输出信息的集合
        /// </summary>
        [JsonProperty(PropertyName = "target", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaTargetInfo Target { get => target; set => target = value; }
        /// <summary>
        /// 任务状态
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)),JsonProperty(PropertyName = "jobStatus", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaJobStatus? JobStatus { get => jobStatus; set => jobStatus = value; }
        /// <summary>
        /// job失败时的错误信息
        /// </summary>
        [JsonProperty(PropertyName = "error", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaJobError Error { get => error; set => error = value; }
        /// <summary>
        /// 任务创建的时间
        /// </summary>
        [JsonProperty(PropertyName = "createTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? CreateTime { get => createTime; set => createTime = value; }
        /// <summary>
        /// 任务开始处理的时间
        /// </summary>
        [JsonProperty(PropertyName = "startTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? StartTime { get => startTime; set => startTime = value; }
        /// <summary>
        /// 任务完成处理的时间
        /// </summary>
        [JsonProperty(PropertyName = "endTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? EndTime { get => endTime; set => endTime = value; }
        /// <summary>
        /// 队列名称
        /// </summary>
        [JsonProperty(PropertyName = "pipelineName", NullValueHandling = NullValueHandling.Ignore)]
        public string PipelineName { get => pipelineName; set => pipelineName = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
