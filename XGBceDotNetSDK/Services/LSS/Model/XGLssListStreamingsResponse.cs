using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.LSS.Model
{
    public class XGLssStreamingInfo
    {
        private string sessionId;
        private string app;
        private string playDomain;
        private string stream;
        private string userId;

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
        /// 推流stream
        /// </summary>
        [JsonProperty(PropertyName = "stream", NullValueHandling = NullValueHandling.Ignore)]
        public string Stream { get => stream; set => stream = value; }
        /// <summary>
        /// 用户Id
        /// </summary>
        [JsonProperty(PropertyName = "userId", NullValueHandling = NullValueHandling.Ignore)]
        public string UserId { get => userId; set => userId = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }

    /// <summary>
    /// 查询活跃的Stream响应类
    /// </summary>
    public class XGLssListStreamingsResponse:XGLssResponse
    {
        private List<XGLssStreamingInfo> streams;
        public XGLssListStreamingsResponse()
        {
        }

        /// <summary>
        /// 活跃流的信息
        /// </summary>
        [JsonProperty(PropertyName = "streams", NullValueHandling = NullValueHandling.Ignore)]
        public List<XGLssStreamingInfo> Streams { get => streams; set => streams = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
