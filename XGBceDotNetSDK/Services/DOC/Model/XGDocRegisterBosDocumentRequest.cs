using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace XGBceDotNetSDK.Services.DOC.Model
{
    /// <summary>
    /// 根据BOS Object创建文档请求类
    /// <para>源文档所在BOS Bucket所属地域须为"华北-北京(bj)"。</para>
    /// <para>源文档所在BOS Bucket权限须设置为公共读，或在自定义权限设置中为DOC文档服务账号（183db8cd3d5a4bf9a94459f89a7a3a91）添加READ权限。</para>
    /// </summary>
    public class XGDocRegisterBosDocumentRequest: XGAbstractDocRequest
    {
        private string bucket;
        private string bosObject;
        private string title;
        private XGDocFileFormat? format = null;
        private XGDocTargetType? targetType = null;
        private string notification;
        private XGDocAccess? access = null;

        public XGDocRegisterBosDocumentRequest()
        {
        }

        /// <summary>
        /// BOS Bucket
        /// <para>必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "bucket", NullValueHandling = NullValueHandling.Ignore)]
        public string Bucket { get => bucket; set => bucket = value; }
        /// <summary>
        /// BOS Object
        /// <para>必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "object", NullValueHandling = NullValueHandling.Ignore)]
        public string BosObject { get => bosObject; set => bosObject = value; }
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
