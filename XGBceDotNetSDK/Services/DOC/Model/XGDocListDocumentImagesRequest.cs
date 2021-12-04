using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.DOC.Model
{
    /// <summary>
    /// 查询文档转码结果图片列表请求类
    /// </summary>
    public class XGDocListDocumentImagesRequest:XGAbstractDocRequest
    {
        private string documentId;

        public XGDocListDocumentImagesRequest()
        {
        }

        /// <summary>
        /// 系统生成的文档的唯一标识
        /// </summary>
        [JsonIgnore]
        public string DocumentId { get => documentId; set => documentId = value; }
    }
}
