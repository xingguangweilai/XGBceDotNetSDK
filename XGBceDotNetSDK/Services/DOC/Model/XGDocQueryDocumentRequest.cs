using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.DOC.Model
{
    /// <summary>
    /// 查询文档请求类
    /// </summary>
    public class XGDocQueryDocumentRequest: XGAbstractDocRequest
    {
        private string documentId;
        private bool? https;
        public XGDocQueryDocumentRequest()
        {
        }

        /// <summary>
        /// 系统生成的文档的唯一标识
        /// <para>必需</para>
        /// </summary>
        [JsonIgnore]
        public string DocumentId { get => documentId; set => documentId = value; }
        /// <summary>
        /// 是否支持https阅读
        /// <para>当https=true时，返回的coverUrl是https地址。</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonIgnore]
        public bool? Https { get => https; set => https = value; }
    }
}
