using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using XGBceDotNetSDK.BaseClass;

namespace XGBceDotNetSDK.Services.DOC.Model
{
    /// <summary>
    /// 注册文档请求类
    /// </summary>
    public class XGDocRegisterDocumentRequest: XGAbstractDocRequest
    {
        private string title;
        private XGDocFileFormat? format=null;
        private XGDocTargetType? targetType=null;
        private string notification;
        private XGDocAccess? access=null;

        public XGDocRegisterDocumentRequest()
        {
        }

        /// <summary>
        /// 文档标题
        /// <para>不超过50字符</para>
        /// <para>必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get => title; set => title = value; }
        /// <summary>
        /// 文档格式
        /// <para>必需</para>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)),JsonProperty(PropertyName = "format", NullValueHandling = NullValueHandling.Ignore)]
        public XGDocFileFormat? Format { get => format; set => format = value; }
        /// <summary>
        /// 转码结果类型
        /// <para>非必需</para>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)),JsonProperty(PropertyName = "targetType", NullValueHandling = NullValueHandling.Ignore)]
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
        [JsonConverter(typeof(StringEnumConverter)),JsonProperty(PropertyName = "access", NullValueHandling = NullValueHandling.Ignore)]
        public XGDocAccess? Access { get => access; set => access = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
