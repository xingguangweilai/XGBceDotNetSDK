using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.DOC.Model
{
    /// <summary>
    /// 发布文档请求类
    /// </summary>
    public class XGDocPublishDocumentRequest: XGAbstractDocRequest
    {
        private string documentId;
        public XGDocPublishDocumentRequest()
        {
        }

        /// <summary>
        /// 系统生成的文档的唯一标识
        /// <para>必需</para>
        /// </summary>
        [JsonIgnore]
        public string DocumentId { get => documentId; set => documentId = value; }
    }
}
