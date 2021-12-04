using System;
using Newtonsoft.Json;
using XGBceDotNetSDK.BaseClass;
using XGBceDotNetSDK.Sign;

namespace XGBceDotNetSDK.Services.VCA.Model
{
    /// <summary>
    /// 视频分析请求类
    /// </summary>
    public class XGAnalyzeRequest: XGAbstractVcaRequest
    {
        private string source;
        private string auth;
        private string preset;
        private string notification;
        private int? priority;
        private string title;
        private string subTitle;
        private string category;
        private string description;

        public XGAnalyzeRequest()
        {
        }

        /// <summary>
        /// 视频路径，不超过1024字符
        /// <para> 必需 </para>
        /// </summary>
        [JsonProperty("source")]
        public string Source { get => source; set => source = value; }
        /// <summary>
        /// 视频路径鉴权参数，仅URL视频使用
        /// <para> 必需 </para>
        /// </summary>
        [JsonProperty("auth")]
        public string Auth { get => auth; set => auth = value; }
        /// <summary>
        /// 分析模板名称，若为空会使用默认模板
        /// <para> 非必需 </para>
        /// </summary>
        [JsonProperty(PropertyName = "preset", NullValueHandling = NullValueHandling.Ignore)]
        public string Preset { get => preset; set => preset = value; }
        /// <summary>
        /// 通知名称，使用方式见通知接口
        /// <para> 非必需 </para>
        /// </summary>
        [JsonProperty(PropertyName = "notification", NullValueHandling = NullValueHandling.Ignore)]
        public string Notification { get => notification; set => notification = value; }
        /// <summary>
        /// 优先级，默认为0，范围[0, 100]，越大优先级越高
        /// <para> 非必需 </para>
        /// </summary>
        [JsonProperty(PropertyName = "priority", NullValueHandling = NullValueHandling.Ignore)]
        public int? Priority { get => priority; set {
                if (value < 0)
                    value = 0;
                priority = value;
            } }
        /// <summary>
        /// 视频标题，默认不设置，不超过256字符
        /// <para> 如果没有设置title，对于VOD媒资，MCA会主动去VOD查询标题 </para>
        /// <para> 非必需 </para>
        /// </summary>
        [JsonProperty(PropertyName = "title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get => title; set => title = value; }
        /// <summary>
        /// 视频子标题，默认不设置，不超过100字符
        /// <para> 非必需 </para>
        /// </summary>
        [JsonProperty(PropertyName = "subTitle", NullValueHandling = NullValueHandling.Ignore)]
        public string SubTitle { get => subTitle; set => subTitle = value; }
        /// <summary>
        /// 视频类别（例如电视剧/电影/综艺/动漫/记录片/游戏），默认不设置，不超过100字符
        /// <para> 非必需 </para>
        /// </summary>
        [JsonProperty(PropertyName = "category", NullValueHandling = NullValueHandling.Ignore)]
        public string Category { get => category; set => category = value; }
        /// <summary>
        /// 视频描述，默认空字符串，不超过256字符
        /// <para> 非必需 </para>
        /// </summary>
        [JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get => description; set => description = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
