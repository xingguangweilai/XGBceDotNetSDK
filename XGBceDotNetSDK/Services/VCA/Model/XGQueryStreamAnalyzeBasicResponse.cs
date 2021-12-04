using System;
using Newtonsoft.Json;
using XGBceDotNetSDK.BaseClass;

namespace XGBceDotNetSDK.Services.VCA.Model
{
    /// <summary>
    /// 查询直播分析基本信息响应类
    /// </summary>
    public class XGQueryStreamAnalyzeBasicResponse: XGAbstractBceResponse
    {
        private string source;
        private string description;
        private string status;
        private int? intervalInSecond;
        private DateTime? createTime;
        private DateTime? startTime;
        private string preset;
        private int? durationInSecond;
        private string notification;
        private DateTime? endTime;
        private XGVcaError error;

        public XGQueryStreamAnalyzeBasicResponse()
        {
        }

        /// </summary>
        /// 直播路径
        /// </summary>
        [JsonProperty(PropertyName = "source", NullValueHandling = NullValueHandling.Ignore)]
        public string Source { get => source; set => source = value; }
        /// </summary>
        /// 描述信息
        /// </summary>
        [JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get => description; set => description = value; }
        /// <summary>
        /// 分析状态
        /// </summary>
        [JsonProperty(PropertyName = "status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get => status; set => status = value; }
        /// </summary>
        /// 拉流视频间隔
        /// </summary>
        [JsonProperty(PropertyName = "intervalInSecond", NullValueHandling = NullValueHandling.Ignore)]
        public int? IntervalInSecond { get => intervalInSecond; set => intervalInSecond = value; }
        /// </summary>
        /// 分析创建时间
        /// </summary>
        [JsonProperty(PropertyName = "createTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? CreateTime { get => createTime; set => createTime = value; }
        /// </summary>
        /// 实际开始拉流时间，仅当status=PROCESSING/FINISHED时存在
        /// </summary>
        [JsonProperty(PropertyName = "startTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? StartTime { get => startTime; set => startTime = value; }
        /// </summary>
        /// 分析模版
        /// </summary>
        [JsonProperty(PropertyName = "preset", NullValueHandling = NullValueHandling.Ignore)]
        public string Preset { get => preset; set => preset = value; }
        /// </summary>
        /// 实际已经分析的直播时长，自动将分析失败或者缺失的直播片段移除，仅当status=PROCESSING/FINISHED时存在
        /// </summary>
        [JsonProperty(PropertyName = "durationInSecond", NullValueHandling = NullValueHandling.Ignore)]
        public int? DurationInSecond { get => durationInSecond; set => durationInSecond = value; }
        /// </summary>
        /// 通知名称
        /// </summary>
        [JsonProperty(PropertyName = "notification", NullValueHandling = NullValueHandling.Ignore)]
        public string Notification { get => notification; set => notification = value; }
        /// </summary>
        /// 实际结束拉流时间,仅当status=FINISHED时存在
        /// </summary>
        [JsonProperty(PropertyName = "endTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? EndTime { get => endTime; set => endTime = value; }
        /// </summary>
        /// 分析失败信息，仅当status=ERROR时存在
        /// </summary>
        [JsonProperty(PropertyName = "error", NullValueHandling = NullValueHandling.Ignore)]
        public XGVcaError Error { get => error; set => error = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
