using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.DOC.Model
{
    /// <summary>
    /// 删除文档请求类
    /// </summary>
    public class XGDocDeleteDocumentRequest:XGAbstractDocRequest
    {
        private string documentId;

        public XGDocDeleteDocumentRequest()
        {
        }

        /// <summary>
        /// 系统生成的文档的唯一标识
        /// </summary>
        [JsonIgnore]
        public string DocumentId { get => documentId; set => documentId = value; }
    }
}
