using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace XGBceDotNetSDK.Services.YUQING.Model
{
    /// <summary>
    /// 添加自定义监测任务请求类
    /// </summary>
    public class XGYuqingAddTaskRequest:XGAbstractYuqingRequest
    {
        private List<string> filterKeywords;
        private List<int> geoIds;
        private string name;
        private List<string> optionalKeywords;
        private List<string> requiredKeywords;
        private XGYuqingTaskType? taskType;

        public XGYuqingAddTaskRequest()
        {
        }

        /// <summary>
        /// 任务排除词
        /// </summary>
        [JsonProperty(PropertyName = "filterKeywords", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> FilterKeywords { get => filterKeywords; set => filterKeywords = value; }
        /// <summary>
        /// 任务监测地域
        /// </summary>
        [JsonProperty(PropertyName = "geoIds", NullValueHandling = NullValueHandling.Ignore)]
        public List<int> GeoIds { get => geoIds; set => geoIds = value; }
        /// <summary>
        /// 监测任务名称
        /// </summary>
        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get => name; set => name = value; }
        /// <summary>
        /// 任务搭配词
        /// </summary>
        [JsonProperty(PropertyName = "optionalKeywords", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> OptionalKeywords { get => optionalKeywords; set => optionalKeywords = value; }
        /// <summary>
        /// 任务主监控词
        /// </summary>
        [JsonProperty(PropertyName = "requiredKeywords", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> RequiredKeywords { get => requiredKeywords; set => requiredKeywords = value; }
        /// <summary>
        /// 监测方案类别
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)) ,JsonProperty(PropertyName = "taskType", NullValueHandling = NullValueHandling.Ignore)]
        public XGYuqingTaskType? TaskType { get => taskType; set => taskType = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
