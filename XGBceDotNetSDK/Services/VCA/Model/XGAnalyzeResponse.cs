using System;
using Newtonsoft.Json;
using XGBceDotNetSDK.BaseClass;

namespace XGBceDotNetSDK.Services.VCA.Model
{
    public class XGAnalyzeResponse: XGAbstractBceResponse
    {
        private string taskId;
        private string source;
        private string mediaId;
        private string title;
        private string description;
        private string status;
        private int duration;
        private DateTime? createTime;
        private string subTitle;
        private string preset;
        private string notification;
        private int percent;

        public XGAnalyzeResponse()
        {
        }

        /// <summary>
        /// 任务ID
        /// </summary>
        [JsonProperty(PropertyName = "taskId", NullValueHandling = NullValueHandling.Ignore)]
        public string TaskId { get => taskId; set => taskId = value; }
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
        [JsonProperty(PropertyName = "status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get => status; set => status = value; }
        /// <summary>
        /// 视频时长，仅当status!=PROVISIONING时存在
        /// </summary>
        [JsonProperty(PropertyName = "duration", NullValueHandling = NullValueHandling.Ignore)]
        public int Duration { get => duration; set => duration = value; }
        /// <summary>
        /// 分析创建时间
        /// </summary>
        [JsonProperty(PropertyName = "createTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? CreateTime { get => createTime; set => createTime = value; }
        /// <summary>
        /// 视频子标题
        /// </summary>
        [JsonProperty(PropertyName = "subTitle", NullValueHandling = NullValueHandling.Ignore)]
        public string SubTitle { get => subTitle; set => subTitle = value; }
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

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
