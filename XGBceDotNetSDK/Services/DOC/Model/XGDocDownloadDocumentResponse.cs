using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.DOC.Model
{
    /// <summary>
    /// 下载文档响应类
    /// </summary>
    public class XGDocDownloadDocumentResponse:XGDocResponse
    {
        private string documentId;
        private string downloadUrl;
        private DateTime createTime;
        private DateTime expireTime;

        public XGDocDownloadDocumentResponse()
        {
        }

        /// <summary>
        /// 系统生成的文档的唯一标识
        /// </summary>
        [JsonProperty(PropertyName = "documentId", NullValueHandling = NullValueHandling.Ignore)]
        public string DocumentId { get => documentId; set => documentId = value; }
        /// <summary>
        /// 源文档Url
        /// </summary>
        [JsonProperty(PropertyName = "downloadUrl", NullValueHandling = NullValueHandling.Ignore)]
        public string DownloadUrl { get => downloadUrl; set => downloadUrl = value; }
        /// <summary>
        /// 源文档Url生成时间
        /// </summary>
        [JsonProperty(PropertyName = "createTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime CreateTime { get => createTime; set => createTime = value; }
        /// <summary>
        /// 源文档Url过期时间
        /// <para>仅当expireInSeconds不等于-1时有效</para>
        /// </summary>
        [JsonProperty(PropertyName = "expireTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime ExpireTime { get => expireTime; set => expireTime = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
