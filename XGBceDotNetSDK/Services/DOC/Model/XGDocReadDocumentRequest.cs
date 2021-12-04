using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.DOC.Model
{
    /// <summary>
    /// 阅读文档请求类
    /// </summary>
    public class XGDocReadDocumentRequest:XGAbstractDocRequest
    {
        private string documentId;
        private long? expireInSeconds;

        public XGDocReadDocumentRequest()
        {
        }

        /// <summary>
        /// 系统生成的文档的唯一标识
        /// <para>必需</para>
        /// </summary>
        [JsonIgnore]
        public string DocumentId { get => documentId; set => documentId = value; }
        /// <summary>
        /// 阅读Token有效期
        /// <para>仅当阅读私有文档（"access" : "PRIVATE"）时有效</para>
        /// <para>单位：秒，默认值：3600</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonIgnore]
        public long? ExpireInSeconds { get => expireInSeconds; set => expireInSeconds = value; }
    }
}
