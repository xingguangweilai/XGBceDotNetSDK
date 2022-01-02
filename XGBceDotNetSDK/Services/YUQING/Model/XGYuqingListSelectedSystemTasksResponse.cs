using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.YUQING.Model
{
    /// <summary>
    /// 获取用户选中的系统监测任务列表响应类
    /// </summary>
    public class XGYuqingListSelectedSystemTasksResponse:XGYuqingResponse
    {
        private List<XGYuqingTaskModel> list;
        public XGYuqingListSelectedSystemTasksResponse()
        {
        }

        /// <summary>
        /// 任务列表
        /// </summary>
        [JsonProperty(PropertyName = "list", NullValueHandling = NullValueHandling.Ignore)]
        public List<XGYuqingTaskModel> List { get => list; set => list = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
