using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using static XGBceDotNetSDK.Services.LSS.Model.XGLssEnum;

namespace XGBceDotNetSDK.Services.LSS.Model
{
    /// <summary>
    /// 直播流错误信息
    /// </summary>
    public class XGLssStreamError
    {
        private string code;
        private string message;

        /// <summary>
        /// 错误码
        /// </summary>
        [JsonProperty(PropertyName = "code", NullValueHandling = NullValueHandling.Ignore)]
        public string Code { get => code; set => code = value; }
        /// <summary>
        /// 错误详情
        /// </summary>
        [JsonProperty(PropertyName = "message", NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get => message; set => message = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }

    /// <summary>
    /// 直播源信息
    /// </summary>
    public class XGLssStreamPublishInfo
    {
        private string region;
        private string pushStream;
        private string pushUrl;
        private string pullUrl;
        private string image;
        private string timestamp;

        /// <summary>
        /// 流所属区域
        /// </summary>
        [JsonProperty(PropertyName = "region", NullValueHandling = NullValueHandling.Ignore)]
        public string Region { get => region; set => region = value; }
        /// <summary>
        /// 推流Stream
        /// </summary>
        [JsonProperty(PropertyName = "pushStream", NullValueHandling = NullValueHandling.Ignore)]
        public string PushStream { get => pushStream; set => pushStream = value; }
        /// <summary>
        /// 推流url，仅对推流有效
        /// </summary>
        [JsonProperty(PropertyName = "pushUrl", NullValueHandling = NullValueHandling.Ignore)]
        public string PushUrl { get => pushUrl; set => pushUrl = value; }
        /// <summary>
        /// 拉流url，仅对拉流有效
        /// </summary>
        [JsonProperty(PropertyName = "pullUrl", NullValueHandling = NullValueHandling.Ignore)]
        public string PullUrl { get => pullUrl; set => pullUrl = value; }
        /// <summary>
        /// 图片水印模版名称列表
        /// </summary>
        [JsonProperty(PropertyName = "image", NullValueHandling = NullValueHandling.Ignore)]
        public string Image { get => image; set => image = value; }
        /// <summary>
        /// 时间戳水印模版名称
        /// <para>单模版支持创建一个时间戳水印</para>
        /// </summary>
        [JsonProperty(PropertyName = "timestamp", NullValueHandling = NullValueHandling.Ignore)]
        public string Timestamp { get => timestamp; set => timestamp = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }

    /// <summary>
    /// 直播流详情
    /// </summary>
    public class XGLssStreamInfo
    {
        private string sessionId;
        private string app;
        private string playDomain;
        private string description;
        private XGLssStreamPublishInfo publish;
        private XGLssStreamStatus? status;
        private XGLssStreamingStatus? streamingStatus;
        private DateTime? createTime;
        private string securityPolicy;
        private string audit;

        /// <summary>
        /// 直播流对应的会话ID
        /// </summary>
        [JsonProperty(PropertyName = "sessionId", NullValueHandling = NullValueHandling.Ignore)]
        public string SessionId { get => sessionId; set => sessionId = value; }
        /// <summary>
        /// app信息
        /// </summary>
        [JsonProperty(PropertyName = "app", NullValueHandling = NullValueHandling.Ignore)]
        public string App { get => app; set => app = value; }
        /// <summary>
        /// 直播播放域名
        /// </summary>
        [JsonProperty(PropertyName = "playDomain", NullValueHandling = NullValueHandling.Ignore)]
        public string PlayDomain { get => playDomain; set => playDomain = value; }
        /// <summary>
        /// 流描述
        /// </summary>
        [JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get => description; set => description = value; }
        /// <summary>
        /// 直播源信息
        /// </summary>
        [JsonProperty(PropertyName = "publish", NullValueHandling = NullValueHandling.Ignore)]
        public XGLssStreamPublishInfo Publish { get => publish; set => publish = value; }
        /// <summary>
        /// 直播状态
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)), JsonProperty(PropertyName = "status", NullValueHandling = NullValueHandling.Ignore)]
        public XGLssStreamStatus? Status { get => status; set => status = value; }
        /// <summary>
        /// 直播流状态
        /// <para>仅当status=ONGOING时存在</para>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)), JsonProperty(PropertyName = "streamingStatus", NullValueHandling = NullValueHandling.Ignore)]
        public XGLssStreamingStatus? StreamingStatus { get => streamingStatus; set => streamingStatus = value; }
        /// <summary>
        /// 流创建时间
        /// </summary>
        [JsonProperty(PropertyName = "createTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? CreateTime { get => createTime; set => createTime = value; }
        /// <summary>
        /// 安全策略
        /// </summary>
        [JsonProperty(PropertyName = "securityPolicy", NullValueHandling = NullValueHandling.Ignore)]
        public string SecurityPolicy { get => securityPolicy; set => securityPolicy = value; }
        /// <summary>
        /// 内容审核名称
        /// </summary>
        [JsonProperty(PropertyName = "audit", NullValueHandling = NullValueHandling.Ignore)]
        public string Audit { get => audit; set => audit = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }

    /// <summary>
    /// 查询所有Stream响应类
    /// </summary>
    public class XGLssListStreamsResponse:XGLssResponse
    {
        private string marker;
        private bool? isTruncated;
        private string nextMarker;
        private List<XGLssStreamInfo> streams;

        public XGLssListStreamsResponse()
        {
        }

        /// <summary>
        /// 本次请求的marker
        /// <para>标记查询的起始位置</para>
        /// </summary>
        [JsonProperty(PropertyName = "marker", NullValueHandling = NullValueHandling.Ignore)]
        public string Marker { get => marker; set => marker = value; }
        /// <summary>
        /// 数据是否截断
        /// <para>True表示后面还有数据，False表示已经是最后一页</para>
        /// </summary>
        [JsonProperty(PropertyName = "isTruncated", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsTruncated { get => isTruncated; set => isTruncated = value; }
        /// <summary>
        /// 获取下一页所需要传递的marker值
        /// <para>仅当"isTruncated": true时有效</para>
        /// </summary>
        [JsonProperty(PropertyName = "nextMarker", NullValueHandling = NullValueHandling.Ignore)]
        public string NextMarker { get => nextMarker; set => nextMarker = value; }
        /// <summary>
        /// 流列表
        /// </summary>
        [JsonProperty(PropertyName = "streams", NullValueHandling = NullValueHandling.Ignore)]
        public List<XGLssStreamInfo> Streams { get => streams; set => streams = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
