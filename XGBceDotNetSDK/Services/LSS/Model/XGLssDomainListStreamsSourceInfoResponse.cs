using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.LSS.Model
{
    public class XGLssDomainStreamSourceInfo
    {
        private string sessionId;
        private string playDomain;
        private string app;
        private string stream;
        private string sourceIP;
        private string publishIP;
        private int? score;
        private DateTime? captureTime;
        private long? inputBitRateInBps;
        private XGLssStreamVideoInfo video;
        private XGLssStreamAudioInfo audio;

        /// <summary>
        /// 流的唯一ID
        /// </summary>
        [JsonProperty(PropertyName = "sessionId", NullValueHandling = NullValueHandling.Ignore)]
        public string SessionId { get => sessionId; set => sessionId = value; }
        /// <summary>
        /// 返回将直播流推向媒体中心CDN的对应IP
        /// </summary>
        [JsonProperty(PropertyName = "sourceIP", NullValueHandling = NullValueHandling.Ignore)]
        public string SourceIP { get => sourceIP; set => sourceIP = value; }
        /// <summary>
        /// 推流端IP地址
        /// </summary>
        [JsonProperty(PropertyName = "publishIP", NullValueHandling = NullValueHandling.Ignore)]
        public string PublishIP { get => publishIP; set => publishIP = value; }
        /// <summary>
        /// 推流拉流质量评分
        /// <para>[0,100]，100表示质量最好，0 表示质量最差</para>
        /// </summary>
        [JsonProperty(PropertyName = "score", NullValueHandling = NullValueHandling.Ignore)]
        public int? Score { get => score; set => score = value; }
        /// <summary>
        /// 直播源信息采时间
        /// </summary>
        [JsonProperty(PropertyName = "captureTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? CaptureTime { get => captureTime; set => captureTime = value; }
        /// <summary>
        /// 实时输入总码率,包括视频/音频/数据
        /// </summary>
        [JsonProperty(PropertyName = "inputBitRateInBps", NullValueHandling = NullValueHandling.Ignore)]
        public long? InputBitRateInBps { get => inputBitRateInBps; set => inputBitRateInBps = value; }
        /// <summary>
        /// 视频信息
        /// </summary>
        [JsonProperty(PropertyName = "video", NullValueHandling = NullValueHandling.Ignore)]
        public XGLssStreamVideoInfo Video { get => video; set => video = value; }
        /// <summary>
        /// 音频信息
        /// </summary>
        [JsonProperty(PropertyName = "audio", NullValueHandling = NullValueHandling.Ignore)]
        public XGLssStreamAudioInfo Audio { get => audio; set => audio = value; }
        /// <summary>
        /// 播放域名
        /// </summary>
        [JsonProperty(PropertyName = "playDomain", NullValueHandling = NullValueHandling.Ignore)]
        public string PlayDomain { get => playDomain; set => playDomain = value; }
        /// <summary>
        /// app名称
        /// </summary>
        [JsonProperty(PropertyName = "app", NullValueHandling = NullValueHandling.Ignore)]
        public string App { get => app; set => app = value; }
        /// <summary>
        /// stream名称
        /// </summary>
        [JsonProperty(PropertyName = "stream", NullValueHandling = NullValueHandling.Ignore)]
        public string Stream { get => stream; set => stream = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
    /// <summary>
    /// 查询域名下实时直播源信息响应类
    /// </summary>
    public class XGLssDomainListStreamsSourceInfoResponse:XGLssResponse
    {
        private List<XGLssDomainStreamSourceInfo> sourceInfoList;
        public XGLssDomainListStreamsSourceInfoResponse()
        {
        }

        /// <summary>
        /// 直播源信息列表
        /// </summary>
        [JsonProperty(PropertyName = "sourceInfoList", NullValueHandling = NullValueHandling.Ignore)]
        public List<XGLssDomainStreamSourceInfo> SourceInfoList { get => sourceInfoList; set => sourceInfoList = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
