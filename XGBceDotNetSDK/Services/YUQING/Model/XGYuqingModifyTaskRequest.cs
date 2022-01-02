using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.YUQING.Model
{
    /// <summary>
    /// 修改自定义监测任务请求类
    /// </summary>
    public class XGYuqingModifyTaskRequest: XGYuqingAddTaskRequest
    {
        private string taskId;

        public XGYuqingModifyTaskRequest()
        {
        }

        /// <summary>
        /// 任务ID
        /// </summary>
        [JsonIgnore]
        public string TaskId { get => taskId; set => taskId = value; }
    }
}
