using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.YUQING.Model
{
    /// <summary>
    /// 获取监测任务详情请求类
    /// </summary>
    public class XGYuqingQueryTaskDetailRequest:XGAbstractYuqingRequest
    {
        private string taskId;
        public XGYuqingQueryTaskDetailRequest() { }

        /// <summary>
        /// 任务ID
        /// </summary>
        [JsonIgnore]
        public string TaskId { get => taskId; set => taskId = value; }
    }
}
