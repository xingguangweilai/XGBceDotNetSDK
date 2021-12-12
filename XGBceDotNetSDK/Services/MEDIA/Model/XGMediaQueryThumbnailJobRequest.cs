using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.MEDIA.Model
{
    /// <summary>
    /// 查询指定缩略图任务
    /// </summary>
    public class XGMediaQueryThumbnailJobRequest:XGAbstractMediaRequest
    {
        private string jobId;

        public XGMediaQueryThumbnailJobRequest()
        {
        }

        /// <summary>
        /// 任务ID
        /// </summary>
        [JsonIgnore]
        public string JobId { get => jobId; set => jobId = value; }
    }
}
