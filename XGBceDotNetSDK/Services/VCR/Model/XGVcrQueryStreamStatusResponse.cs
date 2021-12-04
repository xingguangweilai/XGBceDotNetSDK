using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using XGBceDotNetSDK.BaseClass;

namespace XGBceDotNetSDK.Services.VCR.Model
{
    /// <summary>
    /// 查询直播流审核状态响应类
    /// </summary>
    public class XGVcrQueryStreamStatusResponse: XGAbstractBceResponse
    {
        private string source;
        private XGVcrStreamStatus status;
        private string notification;
        private XGVcrError error;

        private DateTime? createTime;
        private DateTime? startTime;
        private DateTime? finishTime;
        private int duration;
        private string streamId;
        private string mediaId;
        private string description;
        private XGVcrStreamParams streamParams;

        public XGVcrQueryStreamStatusResponse()
        {
        }

        /// <summary>
        /// 直播流地址
        /// </summary>
        [JsonProperty(PropertyName = "source", NullValueHandling = NullValueHandling.Ignore)]
        public string Source { get => source; set => source = value; }
        /// <summary>
        /// 直播流当前状态
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)), JsonProperty(PropertyName = "status", NullValueHandling = NullValueHandling.Ignore)]
        public XGVcrStreamStatus Status { get => status; set => status = value; }
        /// <summary>
        /// 通知名称
        /// </summary>
        [JsonProperty(PropertyName = "notification", NullValueHandling = NullValueHandling.Ignore)]
        public string Notification { get => notification; set => notification = value; }
        /// <summary>
        /// 错误信息
        /// <para>仅status=ERROR时存在</para>
        /// </summary>
        [JsonProperty(PropertyName = "error", NullValueHandling = NullValueHandling.Ignore)]
        public XGVcrError Error { get => error; set => error = value; }
        /// <summary>
        /// 直播审核创建时间
        /// </summary>
        [JsonProperty(PropertyName = "createTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? CreateTime { get => createTime; set => createTime = value; }
        /// <summary>
        /// 直播审核开始时间
        /// </summary>
        [JsonProperty(PropertyName = "startTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? StartTime { get => startTime; set => startTime = value; }
        /// <summary>
        /// 直播审核完成时间
        /// <para>仅status=FINISHED/ERROR时存在</para>
        /// </summary>
        [JsonProperty(PropertyName = "finishTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? FinishTime { get => finishTime; set => finishTime = value; }
        /// <summary>
        /// 审核持续时长
        /// <para>单位：秒</para>
        /// </summary>
        [JsonProperty(PropertyName = "duration", NullValueHandling = NullValueHandling.Ignore)]
        public int Duration { get => duration; set => duration = value; }
        /// <summary>
        /// 直播审核任务ID
        /// </summary>
        [JsonProperty(PropertyName = "streamId", NullValueHandling = NullValueHandling.Ignore)]
        public string StreamId { get => streamId; set => streamId = value; }
        /// <summary>
        /// 直播流ID
        /// </summary>
        [JsonProperty(PropertyName = "mediaId", NullValueHandling = NullValueHandling.Ignore)]
        public string MediaId { get => mediaId; set => mediaId = value; }
        /// <summary>
        /// 描述信息
        /// </summary>
        [JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get => description; set => description = value; }
        /// <summary>
        /// 直播审核参数
        /// </summary>
        [JsonProperty(PropertyName = "streamParams", NullValueHandling = NullValueHandling.Ignore)]
        public XGVcrStreamParams StreamParams { get => streamParams; set => streamParams = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
