using System;
using System.Collections.Generic;

namespace XGBceDotNetSDK.Services.YUQING.Model
{
    /// <summary>
    /// 获取监测任务结果请求类
    /// </summary>
    public class XGYuqingQueryTaskResultRequest:XGAbstractYuqingRequest
    {
        private string taskId;
        private int? autoRefresh;
        private List<int> geoIds;
        private XGYuqingHitTypes? hitTypes;

        public XGYuqingQueryTaskResultRequest()
        {
        }
    }
}
