using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.VCR.Model
{
    /// <summary>
    /// 提交视频审核请求类
    /// </summary>
    public class XGVcrPutMediaRequest:XGAbstractVcrRequest
    {
        private string source;
        private string auth;
        private string description;
        private string preset;
        private string notification;

        public XGVcrPutMediaRequest()
        {
        }

        /// <summary>
        /// 视频路径
        /// <para> 必需 </para>
        /// <para> 对于 BOS 视频，source="bos://{bos-bucket}/{bos-object}”, 例如"bos://testbucket/dir/video.mp4"，由客户保证 BOS 路径可访问。 </para>
        /// <para> 对于 VOD 媒资原视频，source="vod://{vod-media-id}”，例如"vod://mda-fhepatsnpn4rk9z"，VCR 会内部请求VOD获取原视频地址，需要确保媒资在VOD状态为PUBLISHED。 </para>
        /// <para> 对于 VOD 媒资转码后视频，source="vod://{vod-media-id}-{preset} ", 例如"vod://mda-fhepatsnpn4rk9z-mp4"，VCR 会内部请求VOD获取转码后视频地址，需要确保媒资在VOD状态为PUBLISHED，且模板存在。注意这里VOD媒资ID和模板名称的分隔符为"-"。VCR 会自动区分同一个媒资的原视频和转码后视频，几个视频可以同时发起审核，互不影响。 </para>
        /// <para> 对于 URL 视频，source="{http(s)-url}"，例如”http://video.domain.com/dir/video.mp4”； URL source中可以包含参数，例如”http://vod.domain.com/dir/video?id=0308”， VCR 会主动拉取source对应的原视频进行审核，由客户保证视频可访问。 </para>
        /// </summary>
        [JsonProperty("source")]
        public string Source { get => source; set => source = value; }
        /// <summary>
        /// 视频路径鉴权参数，仅URL视频使用
        /// <para> 非必需 </para>
        /// <para> 对于包含鉴权参数的 URL 视频，可以将鉴权参数（大多是临时参数，且在指定时间内有效）设置到auth中， auth="key1=value1" </para>
        /// <para> 区分source和auth的好处是，客户在查询音频审核结果或处理回调时，仅需传入或解析source而可忽略鉴权参数auth。 </para>
        /// </summary>
        [JsonProperty(PropertyName = "auth", NullValueHandling = NullValueHandling.Ignore)]
        public string Auth { get => auth; set => auth = value; }
        /// <summary>
        /// 视频描述，默认空字符串，不超过256字符
        /// <para> 非必需 </para>
        /// </summary>
        [JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get => description; set => description = value; }
        /// <summary>
        /// 审核模板名称，不填写使用默认模版
        /// <para> 非必需 </para>
        /// </summary>
        [JsonProperty(PropertyName = "preset", NullValueHandling = NullValueHandling.Ignore)]
        public string Preset { get => preset; set => preset = value; }
        /// <summary>
        /// 通知名称
        /// <para> 可填写通知服务中配置的通知名称，配置后会把审核结果回调至该通知名称所对应的回调地址 </para>
        /// <para> 非必需 </para>
        /// </summary>
        [JsonProperty(PropertyName = "notification", NullValueHandling = NullValueHandling.Ignore)]
        public string Notification { get => notification; set => notification = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
