using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace XGBceDotNetSDK.Services.DOC.Model
{
    /// <summary>
    /// 重新发布文档请求类
    /// <para>重新发布文档，仅对状态为FAILED/PUBLISHED的文档有效。</para>
    /// <para>对转码失败的文档进行重新转码（适用转码超时或者内部错误的文档，对于无法进行转码的文档在百度智能云转码服务升级后也可尝试进行重新发布）。</para>
    /// <para>对转码成功的文档进行重新转码，可以通过该接口修改文档标题、转码结果类型、文档权限等配置，然后重新转码。</para>
    /// </summary>
    public class XGDocRepublishDocumentRequest:XGAbstractDocRequest
    {
        private string documentId;
        private string title;
        private XGDocFileFormat? format = null;
        private XGDocTargetType? targetType = null;
        private string notification;
        private XGDocAccess? access = null;
        public XGDocRepublishDocumentRequest()
        {
        }

        /// <summary>
        /// 系统生成的文档的唯一标识
        /// <para>必需</para>
        /// </summary>
        [JsonIgnore]
        public string DocumentId { get => documentId; set => documentId = value; }
        /// <summary>
        /// 文档标题
        /// <para>不超过50字符</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get => title; set => title = value; }
        /// <summary>
        /// 文档格式
        /// <para>非必需</para>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)), JsonProperty(PropertyName = "format", NullValueHandling = NullValueHandling.Ignore)]
        public XGDocFileFormat? Format { get => format; set => format = value; }
        /// <summary>
        /// 转码结果类型
        /// <para>非必需</para>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)), JsonProperty(PropertyName = "targetType", NullValueHandling = NullValueHandling.Ignore)]
        public XGDocTargetType? TargetType { get => targetType; set => targetType = value; }
        /// <summary>
        /// 通知名称
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "notification", NullValueHandling = NullValueHandling.Ignore)]
        public string Notification { get => notification; set => notification = value; }
        /// <summary>
        /// 文档权限
        /// <para>非必需</para>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)), JsonProperty(PropertyName = "access", NullValueHandling = NullValueHandling.Ignore)]
        public XGDocAccess? Access { get => access; set => access = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
