using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace XGBceDotNetSDK.Services.MEDIA.Model
{
    public class XGMediaJobError
    {
        private string code;
        private string message;

        /// <summary>
        /// 错误码
        /// </summary>
        [JsonProperty(PropertyName = "code", NullValueHandling = NullValueHandling.Ignore)]
        public string Code { get => code; set => code = value; }
        /// <summary>
        /// 错误原因
        /// </summary>
        [JsonProperty(PropertyName = "message", NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get => message; set => message = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }

    /// <summary>
    /// 转码任务信息
    /// <para>与[创建视频转码任务/请求/请求参数]保持一致，不返回inserts、crop信息</para>
    /// </summary>
    public class XGMediaPipelineTranscodingJob
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

    /// <summary>
    /// 查询指定队列的视频转码任务信息响应类
    /// </summary>
    public class XGMediaQueryPipelineTranscodingJobResponse:XGMediaResponse
    {
        private List<XGMediaPipelineTranscodingJob> jobs;
        private string marker;
        private bool? isTruncated;
        private string nextMarker;

        public XGMediaQueryPipelineTranscodingJobResponse()
        {
        }

        /// <summary>
        /// 转码任务信息列表
        /// </summary>
        [JsonProperty(PropertyName = "jobs", NullValueHandling = NullValueHandling.Ignore)]
        public List<XGMediaPipelineTranscodingJob> Jobs { get => jobs; set => jobs = value; }
        /// <summary>
        /// 本次请求的marker，标记查询的起始位置，此处为jobId
        /// </summary>
        [JsonProperty(PropertyName = "marker", NullValueHandling = NullValueHandling.Ignore)]
        public string Marker { get => marker; set => marker = value; }
        /// <summary>
        /// 指明返回数据是否被截断
        /// <para>true表示本页后面还有数据，即数据未全部返回；false表示已是最后一页，即数据已全部返回</para>
        /// </summary>
        [JsonProperty(PropertyName = "isTruncated", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsTruncated { get => isTruncated; set => isTruncated = value; }
        /// <summary>
        /// 获取下一页所需要传递的marker值（此处为jobId）
        /// <para>仅当isTruncated为true时（数据未全部返回）出现</para>
        /// </summary>
        [JsonProperty(PropertyName = "nextMarker", NullValueHandling = NullValueHandling.Ignore)]
        public string NextMarker { get => nextMarker; set => nextMarker = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
