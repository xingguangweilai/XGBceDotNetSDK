using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace XGBceDotNetSDK.Services.MEDIA.Model
{
    /// <summary>
    /// 队列配置
    /// </summary>
    public class XGMediaPipelineConfig
    {
        private int? capacity;
        private string notification;
        private XGMediaPipelineType? pipelineType;

        /// <summary>
        /// 队列的并发能力(默认20)
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "capacity", NullValueHandling = NullValueHandling.Ignore)]
        public int? Capacity { get => capacity; set => capacity = value; }
        /// <summary>
        /// 通知名称
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "notification", NullValueHandling = NullValueHandling.Ignore)]
        public string Notification { get => notification; set => notification = value; }
        /// <summary>
        /// 队列类型
        /// <para>非必需</para>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)),JsonProperty(PropertyName = "pipelineType", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaPipelineType? PipelineType { get => pipelineType; set => pipelineType = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
    /// <summary>
    /// 创建队列请求类
    /// </summary>
    public class XGMediaCreatePipelineRequest:XGAbstractMediaRequest
    {
        private string pipelineName;
        private string description;
        private string sourceBucket;
        private string targetBucket;
        private XGMediaPipelineConfig config;

        public XGMediaCreatePipelineRequest()
        {
        }

        /// <summary>
        /// 队列名称
        /// <para>允许小写字母、数字以及下划线且必须以字母开头，长度小于40个字符</para>
        /// <para>必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "pipelineName", NullValueHandling = NullValueHandling.Ignore)]
        public string PipelineName { get => pipelineName; set => pipelineName = value; }
        /// <summary>
        /// 队列描述
        /// <para>长度小于128个字符</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get => description; set => description = value; }
        /// <summary>
        /// 输入Bucket
        /// <para>必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "sourceBucket", NullValueHandling = NullValueHandling.Ignore)]
        public string SourceBucket { get => sourceBucket; set => sourceBucket = value; }
        /// <summary>
        /// 输出Bucket
        /// <para>必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "targetBucket", NullValueHandling = NullValueHandling.Ignore)]
        public string TargetBucket { get => targetBucket; set => targetBucket = value; }
        /// <summary>
        /// 队列的配置
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "config", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaPipelineConfig Config { get => config; set => config = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
