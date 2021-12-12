using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.MEDIA.Model
{
    /// <summary>
    /// 查询指定队列的视频转码任务信息请求类
    /// </summary>
    public class XGMediaQueryPipelineTranscodingJobRequest:XGAbstractMediaRequest
    {
        private string pipelineName;
        private XGMediaJobStatus? jobStatus;
        private DateTime? begin;
        private DateTime? end;
        private string marker;
        private int? maxSize;

        public XGMediaQueryPipelineTranscodingJobRequest()
        {
        }

        /// <summary>
        /// 任务所属的队列名
        /// <para>必需</para>
        /// </summary>
        [JsonIgnore]
        public string PipelineName { get => pipelineName; set => pipelineName = value; }
        /// <summary>
        /// 所选任务的状态
        /// <para>非必需</para>
        /// </summary>
        [JsonIgnore]
        public XGMediaJobStatus? JobStatus { get => jobStatus; set => jobStatus = value; }
        /// <summary>
        /// 任务创建时间的上限
        /// <para>所选任务开始时间要大于等于begin</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonIgnore]
        public DateTime? Begin { get => begin; set => begin = value; }
        /// <summary>
        /// 任务创建时间的下限
        /// <para>所选任务开始时间要小于等于end</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonIgnore]
        public DateTime? End { get => end; set => end = value; }
        /// <summary>
        /// 本次请求的marker，标记查询的起始位置，此处为jobId
        /// <para>非必需</para>
        /// </summary>
        [JsonIgnore]
        public string Marker { get => marker; set => marker = value; }
        /// <summary>
        /// 本次请求返回的任务列表的最大元素个数
        /// <para>1 ~ 1000</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonIgnore]
        public int? MaxSize { get => maxSize; set => maxSize = value; }
    }
}
