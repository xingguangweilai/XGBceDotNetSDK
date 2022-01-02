using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace XGBceDotNetSDK.Services.YUQING.Model
{
    /// <summary>
    /// 获取监测任务详情响应类
    /// </summary>
    public class XGYuqingQueryTaskDetailResponse:XGYuqingResponse
    {
        private List<int> geoIds;
        private List<string> filterKeywords;
        private List<string> requiredKeywords;
        private int? taskPattern;
        private int? system_task;
        private List<string> optionalKeywords;
        private List<List<int>> oldGeoIds;
        private XGYuqingTaskType? taskType;
        private string taskTags;
        private long? createTime;
        private int? keywordNum;
        private string taskName;
        private int? id;
        private bool? selected;

        public XGYuqingQueryTaskDetailResponse()
        {
        }

        /// <summary>
        /// 任务监测地域
        /// </summary>
        [JsonProperty(PropertyName = "geoIds", NullValueHandling = NullValueHandling.Ignore)]
        public List<int> GeoIds { get => geoIds; set => geoIds = value; }
        /// <summary>
        ///任务排除词
        /// </summary>
        [JsonProperty(PropertyName = "filterKeywords", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> FilterKeywords { get => filterKeywords; set => filterKeywords = value; }
        /// <summary>
        /// 任务主监控词
        /// </summary>
        [JsonProperty(PropertyName = "requiredKeywords", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> RequiredKeywords { get => requiredKeywords; set => requiredKeywords = value; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "taskPattern", NullValueHandling = NullValueHandling.Ignore)]
        public int? TaskPattern { get => taskPattern; set => taskPattern = value; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "system_task", NullValueHandling = NullValueHandling.Ignore)]
        public int? System_task { get => system_task; set => system_task = value; }
        /// <summary>
        /// 任务搭配词
        /// </summary>
        [JsonProperty(PropertyName = "optionalKeywords", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> OptionalKeywords { get => optionalKeywords; set => optionalKeywords = value; }
        /// <summary>
        /// 老版本任务监测地域
        /// </summary>
        [JsonProperty(PropertyName = "oldGeoIds", NullValueHandling = NullValueHandling.Ignore)]
        public List<List<int>> OldGeoIds { get => oldGeoIds; set => oldGeoIds = value; }
        /// <summary>
        /// 监测方案类别
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)), JsonProperty(PropertyName = "taskType", NullValueHandling = NullValueHandling.Ignore)]
        public XGYuqingTaskType? TaskType { get => taskType; set => taskType = value; }
        /// <summary>
        /// 任务标签
        /// </summary>
        [JsonProperty(PropertyName = "taskTags", NullValueHandling = NullValueHandling.Ignore)]
        public string TaskTags { get => taskTags; set => taskTags = value; }
        /// <summary>
        /// 任务创建时间
        /// </summary>
        [JsonProperty(PropertyName = "createTime", NullValueHandling = NullValueHandling.Ignore)]
        public long? CreateTime { get => createTime; set => createTime = value; }
        /// <summary>
        /// 关键词数量
        /// </summary>
        [JsonProperty(PropertyName = "keywordNum", NullValueHandling = NullValueHandling.Ignore)]
        public int? KeywordNum { get => keywordNum; set => keywordNum = value; }
        /// <summary>
        /// 任务名称
        /// </summary>
        [JsonProperty(PropertyName = "taskName", NullValueHandling = NullValueHandling.Ignore)]
        public string TaskName { get => taskName; set => taskName = value; }
        /// <summary>
        /// 任务id
        /// </summary>
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
        public int? Id { get => id; set => id = value; }
        /// <summary>
        /// 是否选中
        /// </summary>
        [JsonProperty(PropertyName = "selected", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Selected { get => selected; set => selected = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
