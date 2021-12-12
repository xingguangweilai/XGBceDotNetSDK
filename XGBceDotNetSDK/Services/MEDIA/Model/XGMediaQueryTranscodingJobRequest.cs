using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.MEDIA.Model
{
    /// <summary>
    /// 查询指定视频转码任务请求类
    /// </summary>
    public class XGMediaQueryTranscodingJobRequest:XGAbstractMediaRequest
    {
        private string jobId;
        public XGMediaQueryTranscodingJobRequest()
        {
        }

        /// <summary>
        /// 任务的唯一标示
        /// </summary>
        [JsonIgnore]
        public string JobId { get => jobId; set => jobId = value; }
    }
}
