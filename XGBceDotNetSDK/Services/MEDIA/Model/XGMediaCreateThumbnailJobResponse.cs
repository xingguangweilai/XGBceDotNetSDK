using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.MEDIA.Model
{
    /// <summary>
    /// 创建缩略图任务响应类
    /// </summary>
    public class XGMediaCreateThumbnailJobResponse:XGMediaResponse
    {
        private string jobId;

        public XGMediaCreateThumbnailJobResponse()
        {
        }

        /// <summary>
        /// 系统生成的Thumbnail的唯一标示thumbnailId
        /// </summary>
        [JsonProperty(PropertyName = "height", NullValueHandling = NullValueHandling.Ignore)]
        public string JobId { get => jobId; set => jobId = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
