using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace XGBceDotNetSDK.Services.DOC.Model
{
    /// <summary>
    /// 文档上传信息
    /// </summary>
    public class XGDocUploadInfo
    {
        private string bucket;
        private string bosobject;
        private string bosEndpoint;

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

    /// <summary>
    /// 文档发布信息
    /// </summary>
    public class XGDocPublishInfo
    {
        private int pageCount;
        private int sizeInBytes;
        private string coverUrl;
        private DateTime publishTime;

        /// <summary>
        /// 文档总页数
        /// </summary>
        [JsonProperty(PropertyName = "pageCount", NullValueHandling = NullValueHandling.Ignore)]
        public int PageCount { get => pageCount; set => pageCount = value; }
        /// <summary>
        /// 源文档字节数
        /// </summary>
        [JsonProperty(PropertyName = "sizeInBytes", NullValueHandling = NullValueHandling.Ignore)]
        public int SizeInBytes { get => sizeInBytes; set => sizeInBytes = value; }
        /// <summary>
        /// 文档封面图
        /// </summary>
        [JsonProperty(PropertyName = "coverUrl", NullValueHandling = NullValueHandling.Ignore)]
        public string CoverUrl { get => coverUrl; set => coverUrl = value; }
        /// <summary>
        /// 文档发布时间
        /// </summary>
        [JsonProperty(PropertyName = "publishTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime PublishTime { get => publishTime; set => publishTime = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }

    /// <summary>
    /// 文档转码错误信息
    /// </summary>
    public class XGDocError
    {
        private string code;
        private string message;

        /// <summary>
        /// 错误代码
        /// </summary>
        [JsonProperty(PropertyName = "code", NullValueHandling = NullValueHandling.Ignore)]
        public string Code { get => code; set => code = value; }
        /// <summary>
        /// 错误信息
        /// </summary>
        [JsonProperty(PropertyName = "message", NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get => message; set => message = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }

    /// <summary>
    /// 查询文档响应类
    /// </summary>
    public class XGDocQueryDocumentResponse: XGDocResponse
    {
        private string documentId;
        private string title;
        private XGDocFileFormat format;
        private XGDocTargetType targetType;
        private XGDocStatus status;
        private XGDocUploadInfo uploadInfo;
        private XGDocPublishInfo publishInfo;
        private XGDocError error;
        private string notification;
        private XGDocAccess access;
        private DateTime createTime;

        public XGDocQueryDocumentResponse()
        {
        }

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
        [JsonConverter(typeof(StringEnumConverter)),JsonProperty(PropertyName = "format", NullValueHandling = NullValueHandling.Ignore)]
        public XGDocFileFormat Format { get => format; set => format = value; }
        /// <summary>
        /// 转码结果类型
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)),JsonProperty(PropertyName = "targetType", NullValueHandling = NullValueHandling.Ignore)]
        public XGDocTargetType TargetType { get => targetType; set => targetType = value; }
        /// <summary>
        /// 文档状态
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)),JsonProperty(PropertyName = "status", NullValueHandling = NullValueHandling.Ignore)]
        public XGDocStatus Status { get => status; set => status = value; }
        /// <summary>
        /// 文档上传信息
        /// <para>仅当status=UPLOADING时有效</para>
        /// </summary>
        [JsonProperty(PropertyName = "uploadInfo", NullValueHandling = NullValueHandling.Ignore)]
        public XGDocUploadInfo UploadInfo { get => uploadInfo; set => uploadInfo = value; }
        /// <summary>
        /// 文档发布信息
        /// <para>仅当status=PUBLISHED时有效</para>
        /// </summary>
        [JsonProperty(PropertyName = "publishInfo", NullValueHandling = NullValueHandling.Ignore)]
        public XGDocPublishInfo PublishInfo { get => publishInfo; set => publishInfo = value; }
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
        [JsonConverter(typeof(StringEnumConverter)),JsonProperty(PropertyName = "access", NullValueHandling = NullValueHandling.Ignore)]
        public XGDocAccess Access { get => access; set => access = value; }
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
}
