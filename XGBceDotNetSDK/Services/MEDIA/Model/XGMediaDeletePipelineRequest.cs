using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.MEDIA.Model
{
    /// <summary>
    /// 删除指定队列请求类
    /// </summary>
    public class XGMediaDeletePipelineRequest:XGAbstractMediaRequest
    {
        private string pipelineName;
        public XGMediaDeletePipelineRequest()
        {
        }

        /// <summary>
        /// 队列名称
        /// </summary>
        [JsonIgnore]
        public string PipelineName { get => pipelineName; set => pipelineName = value; }
    }
}
