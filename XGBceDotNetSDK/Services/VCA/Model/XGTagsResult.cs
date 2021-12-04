using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.VCA.Model
{
    /// <summary>
    /// 分析结果
    /// </summary>
    public class XGTagsResult
    {
        private string type;
        private List<XGResultItem> result;
        public XGTagsResult()
        {
        }

        /// <summary>
        /// 分析场景
        /// </summary>
        [JsonProperty(PropertyName = "type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get => type; set => type = value; }
        /// <summary>
        /// 分析结果项列表
        /// </summary>
        [JsonProperty(PropertyName = "result", NullValueHandling = NullValueHandling.Ignore)]
        public List<XGResultItem> Result { get => result; set => result = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
