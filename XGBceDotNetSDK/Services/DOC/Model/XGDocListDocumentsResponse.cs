using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace XGBceDotNetSDK.Services.DOC.Model
{
    /// <summary>
    /// 文档信息
    /// </summary>
    public class XGDocDocumentInfo
    {
        private string documentId;
        private string title;
        private XGDocFileFormat? format;
        private XGDocTargetType? targetType;
        private XGDocStatus? status;
        private XGDocError error;
        private string notification;
        private XGDocAccess? access;
        private DateTime createTime;

        /// <summary>
        /// 系统生成的文档的唯一标识
        /// </summary>
        [JsonProperty(PropertyName = "documentId", NullValueHandling = NullValueHandling.Ignore)]
        public string DocumentId { get => documentId; set => documentId = value; }
        /// <summary>
        /// 文档标题
        /// </summary>
        [JsonProperty(PropertyName = "title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get => title; set => title = value; }
        /// <summary>
        /// 文档格式
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)), JsonProperty(PropertyName = "format", NullValueHandling = NullValueHandling.Ignore)]
        public XGDocFileFormat? Format { get => format; set => format = value; }
        /// <summary>
        /// 转码结果类型
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)), JsonProperty(PropertyName = "targetType", NullValueHandling = NullValueHandling.Ignore)]
        public XGDocTargetType? TargetType { get => targetType; set => targetType = value; }
        /// <summary>
        /// 文档状态
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)), JsonProperty(PropertyName = "status", NullValueHandling = NullValueHandling.Ignore)]
        public XGDocStatus? Status { get => status; set => status = value; }
        /// <summary>
        /// 文档转码错误信息
        /// <para>仅当status=FAILED时有效</para>
        /// </summary>
        [JsonProperty(PropertyName = "error", NullValueHandling = NullValueHandling.Ignore)]
        public XGDocError Error { get => error; set => error = value; }
        /// <summary>
        /// 通知名称
        /// </summary>
        [JsonProperty(PropertyName = "notification", NullValueHandling = NullValueHandling.Ignore)]
        public string Notification { get => notification; set => notification = value; }
        /// <summary>
        /// 文档权限
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)), JsonProperty(PropertyName = "access", NullValueHandling = NullValueHandling.Ignore)]
        public XGDocAccess? Access { get => access; set => access = value; }
        /// <summary>
        /// 文档创建时间
        /// </summary>
        [JsonProperty(PropertyName = "createTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime CreateTime { get => createTime; set => createTime = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
    /// <summary>
    /// 列出所有文档响应类
    /// </summary>
    public class XGDocListDocumentsResponse:XGDocResponse
    {
        private List<XGDocDocumentInfo> documents;
        public XGDocListDocumentsResponse()
        {
        }

        /// <summary>
        /// 文档列表
        /// </summary>
        [JsonProperty(PropertyName = "documents", NullValueHandling = NullValueHandling.Ignore)]
        public List<XGDocDocumentInfo> CreateTime { get => documents; set => documents = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
