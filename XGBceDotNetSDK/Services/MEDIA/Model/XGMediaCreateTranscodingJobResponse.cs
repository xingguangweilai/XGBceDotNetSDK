using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.MEDIA.Model
{
    /// <summary>
    /// 创建视频转码任务响应类
    /// </summary>
    public class XGMediaCreateTranscodingJobResponse:XGMediaResponse
    {
        private string jobId;

        public XGMediaCreateTranscodingJobResponse()
        {
        }

        /// <summary>
        /// 系统生成的Job的唯一标示jobId
        /// </summary>
        [JsonProperty(PropertyName = "jobId", NullValueHandling = NullValueHandling.Ignore)]
        public string JobId { get => jobId; set => jobId = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
