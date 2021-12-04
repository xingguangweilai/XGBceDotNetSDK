using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.DOC.Model
{
    /// <summary>
    /// 阅读文档响应类
    /// </summary>
    public class XGDocReadDocumentResponse:XGDocResponse
    {
        private string documentId;
        private string docId;
        private string host;
        private string token;
        private DateTime createTime;
        private DateTime expireTime;

        public XGDocReadDocumentResponse()
        {
        }

        /// <summary>
        /// 系统生成的文档的唯一标识
        /// </summary>
        [JsonProperty(PropertyName = "documentId", NullValueHandling = NullValueHandling.Ignore)]
        public string DocumentId { get => documentId; set => documentId = value; }
        /// <summary>
        /// 文档阅读ID，与documentId取值相同
        /// </summary>
        [JsonProperty(PropertyName = "docId", NullValueHandling = NullValueHandling.Ignore)]
        public string DocId { get => docId; set => docId = value; }
        /// <summary>
        /// 文档阅读Host，用于阅读器SDK，取固定值BCEDOC
        /// </summary>
        [JsonProperty(PropertyName = "host", NullValueHandling = NullValueHandling.Ignore)]
        public string Host { get => host; set => host = value; }
        /// <summary>
        /// 文档阅读Token
        /// <para>对于公开文档（"access" : "PUBLIC"）会返回固定值"TOKEN"，对于私有文档（"access" : "PRIVATE"）会返回随机字符串</para>
        /// </summary>
        [JsonProperty(PropertyName = "token", NullValueHandling = NullValueHandling.Ignore)]
        public string Token { get => token; set => token = value; }
        /// <summary>
        /// 阅读Token创建时间
        /// <para>仅当阅读私有文档时返回</para>
        /// </summary>
        [JsonProperty(PropertyName = "createTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime CreateTime { get => createTime; set => createTime = value; }
        /// <summary>
        /// 阅读Token失效时间
        /// <para>仅当阅读私有文档时返回</para>
        /// </summary>
        [JsonProperty(PropertyName = "expireTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime ExpireTime { get => expireTime; set => expireTime = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
