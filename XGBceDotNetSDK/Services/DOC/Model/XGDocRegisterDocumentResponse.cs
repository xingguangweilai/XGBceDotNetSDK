using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.DOC.Model
{
    /// <summary>
    /// 注册文档响应类
    /// </summary>
    public class XGDocRegisterDocumentResponse:XGDocResponse
    {
        private string documentId;
        private string bucket;
        private string bosobject;
        private string bosEndpoint;

        public XGDocRegisterDocumentResponse()
        {
        }

        /// <summary>
        /// 系统生成的文档的唯一标识
        /// </summary>
        [JsonProperty(PropertyName = "documentId", NullValueHandling = NullValueHandling.Ignore)]
        public string DocumentId { get => documentId; set => documentId = value; }
        /// <summary>
        /// 该文档对应的源文件上传地址在BOS存储中的Bucket
        /// </summary>
        [JsonProperty(PropertyName = "bucket", NullValueHandling = NullValueHandling.Ignore)]
        public string Bucket { get => bucket; set => bucket = value; }
        /// <summary>
        /// 该文档对应的源文件上传地址在BOS存储中的Object
        /// </summary>
        [JsonProperty(PropertyName = "object", NullValueHandling = NullValueHandling.Ignore)]
        public string BosObject { get => bosobject; set => bosobject = value; }
        /// <summary>
        /// 该文档对应的源文件上传地址对应的BOS存储的Endpoint
        /// </summary>
        [JsonProperty(PropertyName = "bosEndpoint", NullValueHandling = NullValueHandling.Ignore)]
        public string BosEndpoint { get => bosEndpoint; set => bosEndpoint = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
