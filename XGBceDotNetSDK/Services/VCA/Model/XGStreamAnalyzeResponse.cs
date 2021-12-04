using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using XGBceDotNetSDK.BaseClass;

namespace XGBceDotNetSDK.Services.VCA.Model
{
    public class XGStreamAnalyzeResponse: XGAbstractBceResponse
    {
        private string taskId;
        private string source;
        private string description;
        private XGVcaAnalyzeStatus status;
        private DateTime? createTime;
        private int? intervalInSecond;
        private string preset;
        private string notification;

        public XGStreamAnalyzeResponse()
        {
        }

        /// <summary>
        /// 任务ID
        /// </summary>
        [JsonProperty(PropertyName = "taskId", NullValueHandling = NullValueHandling.Ignore)]
        public string TaskId { get => taskId; set => taskId = value; }
        /// <summary>
        /// 直播路径
        /// </summary>
        [JsonProperty(PropertyName = "source", NullValueHandling = NullValueHandling.Ignore)]
        public string Source { get => source; set => source = value; }
        /// <summary>
        /// 描述信息
        /// </summary>
        [JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get => description; set => description = value; }
        /// <summary>
        /// 分析状态
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)), JsonProperty(PropertyName = "status", NullValueHandling = NullValueHandling.Ignore)]
        public XGVcaAnalyzeStatus Status { get => status; set => status = value; }
        /// <summary>
        /// 分析创建时间
        /// </summary>
        [JsonProperty(PropertyName = "createTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? CreateTime { get => createTime; set => createTime = value; }
        /// <summary>
        /// 拉流视频间隔
        /// </summary>
        [JsonProperty(PropertyName = "intervalInSecond", NullValueHandling = NullValueHandling.Ignore)]
        public int? IntervalInSecond { get => intervalInSecond; set => intervalInSecond = value; }
        /// <summary>
        /// 视频分析模版
        /// </summary>
        [JsonProperty(PropertyName = "preset", NullValueHandling = NullValueHandling.Ignore)]
        public string Preset { get => preset; set => preset = value; }
        /// <summary>
        /// 通知名称
        /// </summary>
        [JsonProperty(PropertyName = "notification", NullValueHandling = NullValueHandling.Ignore)]
        public string Notification { get => notification; set => notification = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
