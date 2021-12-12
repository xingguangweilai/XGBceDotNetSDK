using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.MEDIA.Model
{
    /// <summary>
    /// 查询指定队列请求类
    /// </summary>
    public class XGMediaQueryPipelineRequest:XGAbstractMediaRequest
    {
        private string pipelineName;
        public XGMediaQueryPipelineRequest()
        {
        }

        /// <summary>
        /// 队列名称
        /// </summary>
        [JsonIgnore]
        public string PipelineName { get => pipelineName; set => pipelineName = value; }
    }
}
