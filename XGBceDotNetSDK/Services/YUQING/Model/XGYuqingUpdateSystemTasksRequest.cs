using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.YUQING.Model
{
    /// <summary>
    /// 更新系统监测任务列表请求类
    /// </summary>
    public class XGYuqingUpdateSystemTasksRequest:XGAbstractYuqingRequest
    {
        private List<int> ids;
        public XGYuqingUpdateSystemTasksRequest()
        {
        }

        /// <summary>
        /// 系统任务id列表
        /// </summary>
        [JsonProperty(PropertyName = "ids", NullValueHandling = NullValueHandling.Ignore)]
        public List<int> Ids { get => ids; set => ids = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
