using System;
using Newtonsoft.Json;
using XGBceDotNetSDK.BaseClass;
using XGBceDotNetSDK.Sign;

namespace XGBceDotNetSDK.Services.VCA.Model
{
    public class XGStreamAnalyzeRequest: XGAbstractVcaRequest
    {
        private string source;
        private string preset;
        private string notification;
        private int? intervalInSecond=10;
        private string description;

        public XGStreamAnalyzeRequest()
        {
            VcaVersion = XGVcaVersion.v1; //直播分析接口仅支持v1
        }

        /// <summary>
        /// 直播地址
        /// 必需
        /// </summary>
        [JsonProperty("source")]
        public string Source { get => source; set => source = value; }
        /// <summary>
        /// 分析模板名称
        /// 没有用默认模版，目前仅支持文本、语音、人脸等分析项
        /// 非必需
        /// </summary>
        [JsonProperty(PropertyName = "preset", NullValueHandling = NullValueHandling.Ignore)]
        public string Preset { get => preset; set => preset = value; }
        /// <summary>
        /// 通知名称，需要先在mca控制台进行配置
        /// 必需
        /// </summary>
        [JsonProperty("notification")]
        public string Notification { get => notification; set => notification = value; }
        /// <summary>
        /// 拉流视频间隔，>=1s, 默认为10s
        /// 非必需
        /// </summary>
        [JsonProperty(PropertyName = "intervalInSecond", NullValueHandling = NullValueHandling.Ignore)]
        public int? IntervalInSecond { get => intervalInSecond; set => intervalInSecond = value; }
        /// <summary>
        /// 描述信息
        /// 长度不超过100
        /// 非必需
        /// </summary>
        [JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get => description; set => description = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }

    }
}
