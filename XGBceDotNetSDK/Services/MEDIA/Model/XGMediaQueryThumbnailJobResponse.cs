using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace XGBceDotNetSDK.Services.MEDIA.Model
{
    /// <summary>
    /// 查询指定缩略图任务响应类
    /// </summary>
    public class XGMediaQueryThumbnailJobResponse:XGMediaResponse
    {
        private string jobId;
        private XGMediaJobStatus? jobStatus;
        private string pipelineName;
        private string presetName;
        private XGMediaThumbnailVideoSource source;
        private XGMediaThumbnailTargetInfo target;
        private XGMediaThumbnailCapture capture;
        private XGMediaDelogoArea delogoAreas;
        private XGMediaCrop crop;
        private DateTime? createTime;
        private DateTime? endTime;

        public XGMediaQueryThumbnailJobResponse()
        {
        }

        /// <summary>
        /// 缩略图的唯一标识
        /// </summary>
        [JsonProperty(PropertyName = "jobId", NullValueHandling = NullValueHandling.Ignore)]
        public string JobId { get => jobId; set => jobId = value; }
        /// <summary>
        /// 缩略图生成状态
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)), JsonProperty(PropertyName = "jobStatus", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaJobStatus? JobStatus { get => jobStatus; set => jobStatus = value; }
        /// <summary>
        /// 任务开始时间
        /// </summary>
        [JsonProperty(PropertyName = "createTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? CreateTime { get => createTime; set => createTime = value; }
        /// <summary>
        /// 任务完成时间
        /// </summary>
        [JsonProperty(PropertyName = "endTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? EndTime { get => endTime; set => endTime = value; }
        /// <summary>
        /// 任务所属的pipelineName	
        /// </summary>
        [JsonProperty(PropertyName = "pipelineName", NullValueHandling = NullValueHandling.Ignore)]
        public string PipelineName { get => pipelineName; set => pipelineName = value; }
        /// <summary>
        /// 任务的模板名称（模板和job中重复内容以job中为准）
        /// </summary>
        [JsonProperty(PropertyName = "presetName", NullValueHandling = NullValueHandling.Ignore)]
        public string PresetName { get => presetName; set => presetName = value; }
        /// <summary>
        /// 输入视频信息的集合
        /// </summary>
        [JsonProperty(PropertyName = "source", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaThumbnailVideoSource Source { get => source; set => source = value; }
        /// <summary>
        /// 目标缩略图信息的集合
        /// </summary>
        [JsonProperty(PropertyName = "target", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaThumbnailTargetInfo Target { get => target; set => target = value; }
        /// <summary>
        /// 生成缩略图的规则
        /// </summary>
        [JsonProperty(PropertyName = "capture", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaThumbnailCapture Capture { get => capture; set => capture = value; }
        /// <summary>
        /// 去水印参数，描述水印位置区域。
        /// </summary>
        [JsonProperty(PropertyName = "delogoAreas", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaDelogoArea DelogoAreas { get => delogoAreas; set => delogoAreas = value; }
        /// <summary>
        /// 黑边裁剪参数
        /// <para>描述除去黑边后的有效区域（不可同时设置crop和shrinkToFit）</para>
        /// </summary>
        [JsonProperty(PropertyName = "crop", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaCrop Crop { get => crop; set => crop = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
