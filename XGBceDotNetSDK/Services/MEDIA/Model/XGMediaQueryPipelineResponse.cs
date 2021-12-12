using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace XGBceDotNetSDK.Services.MEDIA.Model
{
    /// <summary>
    /// 队列任务状态
    /// </summary>
    public class XGMediaPipelineJobStatus
    {
        private int? total;
        private int? running;
        private int? pending;
        private int? success;
        private int? failed;

        /// <summary>
        /// 队列中的任务总数
        /// </summary>
        [JsonProperty(PropertyName = "total", NullValueHandling = NullValueHandling.Ignore)]
        public int? Total { get => total; set => total = value; }
        /// <summary>
        /// 队列中运行中的任务总数
        /// </summary>
        [JsonProperty(PropertyName = "running", NullValueHandling = NullValueHandling.Ignore)]
        public int? Running { get => running; set => running = value; }
        /// <summary>
        /// 队列中排队中的任务总数
        /// </summary>
        [JsonProperty(PropertyName = "pending", NullValueHandling = NullValueHandling.Ignore)]
        public int? Pending { get => pending; set => pending = value; }
        /// <summary>
        /// 队列中已执行成功的任务总数
        /// </summary>
        [JsonProperty(PropertyName = "success", NullValueHandling = NullValueHandling.Ignore)]
        public int? Success { get => success; set => success = value; }
        /// <summary>
        /// 队列中执行失败的任务总数
        /// </summary>
        [JsonProperty(PropertyName = "failed", NullValueHandling = NullValueHandling.Ignore)]
        public int? Failed { get => failed; set => failed = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
    /// <summary>
    /// 查询指定队列响应类
    /// </summary>
    public class XGMediaQueryPipelineResponse:XGMediaResponse
    {
        private string pipelineName;
        private string description;
        private string sourceBucket;
        private string targetBucket;
        private XGMediaPipelineConfig config;
        private XGMediaPipilineState? state;
        private DateTime createTime;
        private XGMediaPipelineJobStatus jobStatus;

        public XGMediaQueryPipelineResponse()
        {
        }

        /// <summary>
        /// 队列名称
        /// <para>允许小写字母、数字以及下划线且必须以字母开头，长度小于40个字符</para>
        /// </summary>
        [JsonProperty(PropertyName = "pipelineName", NullValueHandling = NullValueHandling.Ignore)]
        public string PipelineName { get => pipelineName; set => pipelineName = value; }
        /// <summary>
        /// 队列描述
        /// <para>长度小于128个字符</para>
        /// </summary>
        [JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get => description; set => description = value; }
        /// <summary>
        /// 输入Bucket
        /// </summary>
        [JsonProperty(PropertyName = "sourceBucket", NullValueHandling = NullValueHandling.Ignore)]
        public string SourceBucket { get => sourceBucket; set => sourceBucket = value; }
        /// <summary>
        /// 输出Bucket
        /// </summary>
        [JsonProperty(PropertyName = "targetBucket", NullValueHandling = NullValueHandling.Ignore)]
        public string TargetBucket { get => targetBucket; set => targetBucket = value; }
        /// <summary>
        /// 队列的配置
        /// </summary>
        [JsonProperty(PropertyName = "config", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaPipelineConfig Config { get => config; set => config = value; }
        /// <summary>
        ///队列状态
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)),JsonProperty(PropertyName = "state", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaPipilineState? State { get => state; set => state = value; }
        /// <summary>
        /// 创建时间，UTC格式
        /// </summary>
        [JsonProperty(PropertyName = "createTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime CreateTime { get => createTime; set => createTime = value; }
        /// <summary>
        /// 队列中任务的状态集合
        /// </summary>
        [JsonProperty(PropertyName = "jobStatus", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaPipelineJobStatus JobStatus { get => jobStatus; set => jobStatus = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
