using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using XGBceDotNetSDK.BaseClass;

namespace XGBceDotNetSDK.Services.VCA.Model
{
    /// <summary>
    /// 视频分析中间任务结果
    /// </summary>
    public class XGQuerySubTaskResponse: XGAbstractBceResponse
    {
        private string source;
        private XGVcaAnalyzeStatus status;
        private XGVcaSubTaskType subTaskType;
        private string result;

        public XGQuerySubTaskResponse()
        {
        }

        /// <summary>
        /// 视频路径
        /// </summary>
        [JsonProperty(PropertyName = "source", NullValueHandling = NullValueHandling.Ignore)]
        public string Source { get => source; set => source = value; }
        /// <summary>
        /// 中间任务状态
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)), JsonProperty(PropertyName = "status", NullValueHandling = NullValueHandling.Ignore)]
        public XGVcaAnalyzeStatus Status { get => status; set => status = value; }
        /// <summary>
        /// 中间任务类型
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)), JsonProperty(PropertyName = "type", NullValueHandling = NullValueHandling.Ignore)]
        public XGVcaSubTaskType SubTaskType { get => subTaskType; set => subTaskType = value; }
        /// <summary>
        /// 中间任务结果
        /// </summary>
        [JsonProperty(PropertyName = "result", NullValueHandling = NullValueHandling.Ignore)]
        public string Result { get => result; set => result = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
