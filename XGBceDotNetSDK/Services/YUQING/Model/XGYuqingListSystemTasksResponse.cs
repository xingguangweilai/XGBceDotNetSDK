using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.YUQING.Model
{
    /// <summary>
    /// 获取系统监测任务列表响应类
    /// </summary>
    public class XGYuqingListSystemTasksResponse:XGYuqingResponse
    {
        private int? leftNum;
        private int? totalNum;
        private int? usedNum;
        private List<XGYuqingTaskModel> list;

        public XGYuqingListSystemTasksResponse()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "leftNum", NullValueHandling = NullValueHandling.Ignore)]
        public int? LeftNum { get => leftNum; set => leftNum = value; }
        /// <summary>
        /// 总数
        /// </summary>
        [JsonProperty(PropertyName = "totalNum", NullValueHandling = NullValueHandling.Ignore)]
        public int? TotalNum { get => totalNum; set => totalNum = value; }
        /// <summary>
        /// 使用的任务
        /// </summary>
        [JsonProperty(PropertyName = "usedNum", NullValueHandling = NullValueHandling.Ignore)]
        public int? UsedNum { get => usedNum; set => usedNum = value; }
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
