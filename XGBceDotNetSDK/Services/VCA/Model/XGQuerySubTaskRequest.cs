using System;
using Newtonsoft.Json;
using XGBceDotNetSDK.BaseClass;
using XGBceDotNetSDK.Sign;

namespace XGBceDotNetSDK.Services.VCA.Model
{
    
    public class XGQuerySubTaskRequest: XGAbstractVcaRequest
    {
        private string source;
        private XGVcaSubTaskType? subTaskType;
        private string version;

        public XGQuerySubTaskRequest()
        {
        }

        /// <summary>
        /// 视频路径，需要对source进行urlEncode
        /// 必需
        /// </summary>
        [JsonIgnore]
        public string Source { get => source; set => source = value; }
        /// <summary>
        /// 中间任务类型
        /// 必需
        /// </summary>
        [JsonIgnore]
        public XGVcaSubTaskType? SubTaskType { get => subTaskType; set => subTaskType = value; }
        /// <summary>
        /// 中间任务版本，不填时基于默认版本查询
        /// 非必需
        /// </summary>
        [JsonIgnore]
        public string Version { get => version; set => version = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
