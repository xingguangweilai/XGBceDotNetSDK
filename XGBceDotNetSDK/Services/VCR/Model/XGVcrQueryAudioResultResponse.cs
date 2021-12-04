using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using XGBceDotNetSDK.BaseClass;

namespace XGBceDotNetSDK.Services.VCR.Model
{
    /// <summary>
    /// 查询音频审核结果响应类
    /// </summary>
    public class XGVcrQueryAudioResultResponse : XGAbstractBceResponse
    {
        private string source;
        private string mediaId;
        private string description;
        private string preset;
        private XGVcrStatus status;
        private int percent;
        private string notification;
        private DateTime? createTime;
        private DateTime? finishTime;
        private string label;
        private List<XGVcrAudioResult> results;
        private XGVcrError error;

        public XGVcrQueryAudioResultResponse()
        {
        }

        /// <summary>
        /// 音频路径
        /// </summary>
        [JsonProperty(PropertyName = "source", NullValueHandling = NullValueHandling.Ignore)]
        public string Source { get => source; set => source = value; }
        /// <summary>
        /// VOD媒资id，source为VOD路径时存在
        /// </summary>
        [JsonProperty(PropertyName = "mediaId", NullValueHandling = NullValueHandling.Ignore)]
        public string MediaId { get => mediaId; set => mediaId = value; }
        /// <summary>
        /// 视频描述
        /// </summary>
        [JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get => description; set => description = value; }
        /// <summary>
        /// 审核模板名称
        /// </summary>
        [JsonProperty(PropertyName = "preset", NullValueHandling = NullValueHandling.Ignore)]
        public string Preset { get => preset; set => preset = value; }
        /// <summary>
        /// 审核状态
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)), JsonProperty(PropertyName = "status", NullValueHandling = NullValueHandling.Ignore)]
        public XGVcrStatus Status { get => status; set => status = value; }
        /// <summary>
        /// 审核进度，0 ~ 100整数；仅status=PROCESSING时存在
        /// </summary>
        [JsonProperty(PropertyName = "percent", NullValueHandling = NullValueHandling.Ignore)]
        public int Percent { get => percent; set => percent = value; }
        /// <summary>
        /// 通知名称
        /// </summary>
        [JsonProperty(PropertyName = "notification", NullValueHandling = NullValueHandling.Ignore)]
        public string Notification { get => notification; set => notification = value; }
        /// <summary>
        /// 审核创建时间
        /// </summary>
        [JsonProperty(PropertyName = "createTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? CreateTime { get => createTime; set => createTime = value; }
        /// <summary>
        /// 审核结束时间，仅当status=FINISHED/ERROR时存在
        /// </summary>
        [JsonProperty(PropertyName = "finishTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? FinishTime { get => finishTime; set => finishTime = value; }
        /// <summary>
        /// 审核结果标记，仅当status=FINISHED时存在
        /// <para> 其可选值包括NORMAL/REVIEW/REJECT，分别表示正常/疑似违规/确认违规。 </para>
        /// <para> 审核标记是根据 VCR 审核结果的置信度和用户审核视频时指定的审核模板中疑似置信度阈值和确认置信度阈值生成的。 </para>
        /// </summary>
        [JsonProperty(PropertyName = "label", NullValueHandling = NullValueHandling.Ignore)]
        public string Label { get => label; set => label = value; }
        /// <summary>
        /// 审核结果，仅当status=FINISHED且音频中有疑似涉黄/暴恐/涉政/广告/违禁成分时存在
        /// </summary>
        [JsonProperty(PropertyName = "results", NullValueHandling = NullValueHandling.Ignore)]
        public List<XGVcrAudioResult> Results { get => results; set => results = value; }
        /// <summary>
        /// 审核失败信息，仅当status=ERROR时存在
        /// </summary>
        [JsonProperty(PropertyName = "error", NullValueHandling = NullValueHandling.Ignore)]
        public XGVcrError Error { get => error; set => error = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
