using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace XGBceDotNetSDK.Services.DOC.Model
{
    /// <summary>
    /// 列出所有文档请求类
    /// </summary>
    public class XGDocListDocumentsRequest:XGAbstractDocRequest
    {
        private XGDocStatus? status;
        private string marker;
        private int? maxSize;

        public XGDocListDocumentsRequest()
        {
        }

        /// <summary>
        /// 文档状态
        /// <para>非必需</para>
        /// </summary>
        [JsonIgnore]
        public XGDocStatus? Status { get => status; set => status = value; }
        /// <summary>
        /// 本次请求的marker，标记查询的起始位置
        /// <para>默认值：空字符串</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonIgnore]
        public string Marker { get => marker; set => marker = value; }
        /// <summary>
        /// 本次请求的文档数目，不超过200。
        /// <para>非必需</para>
        /// </summary>
        [JsonIgnore]
        public int? MaxSize { get => maxSize; set => maxSize = value; }
    }
}
