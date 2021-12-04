using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.DOC.Model
{
    /// <summary>
    /// 下载文档请求类
    /// </summary>
    public class XGDocDownloadDocumentRequest:XGAbstractDocRequest
    {
        private string documentId;
        private int? expireInSeconds;
        private bool? https;

        public XGDocDownloadDocumentRequest()
        {
        }

        /// <summary>
        /// 系统生成的文档的唯一标识
        /// <para>必需</para>
        /// </summary>
        [JsonIgnore]
        public string DocumentId { get => documentId; set => documentId = value; }
        /// <summary>
        /// 源文档下载地址有效时长
        /// <para>默认值：-1表示永久有效</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonIgnore]
        public int? ExpireInSeconds { get => expireInSeconds; set => expireInSeconds = value; }
        /// <summary>
        /// 是否支持https
        /// <para>默认为false。当https=true时，返回的downloadUrl是https地址</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonIgnore]
        public bool? Https { get => https; set => https = value; }
    }
}
