using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.YUQING.Model
{
    /// <summary>
    /// 删除自定义监测任务
    /// </summary>
    public class XGYuqingDeleteTaskRequest:XGAbstractYuqingRequest
    {
        private string taskId;

        public XGYuqingDeleteTaskRequest()
        {
        }

        /// <summary>
        /// 任务ID
        /// </summary>
        [JsonIgnore]
        public string TaskId { get => taskId; set => taskId = value; }
    }
}
