using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.DOC.Model
{
    /// <summary>
    /// 禁用阅读Token请求类
    /// </summary>
    public class XGDocDisableReadTokenRequest:XGAbstractDocRequest
    {
        private string documentId;
        private string token;

        public XGDocDisableReadTokenRequest()
        {
        }

        /// <summary>
        /// 系统生成的文档的唯一标识
        /// <para>必需</para>
        /// </summary>
        [JsonIgnore]
        public string DocumentId { get => documentId; set => documentId = value; }
        /// <summary>
        /// 阅读token
        /// <para>非必需</para>
        /// </summary>
        [JsonIgnore]
        public string Token { get => token; set => token = value; }
    }
}
