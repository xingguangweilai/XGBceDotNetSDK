using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.LSS.Model
{
    /// <summary>
    /// 添加metadata信息请求类
    /// </summary>
    public class XGLssAddStreamMetaDataRequest : XGLssStreamRequest
    {
        private Dictionary<string, string> metadata;
        public XGLssAddStreamMetaDataRequest()
        {
        }

        /// <summary>
        /// 活跃流的信息
        /// </summary>
        [JsonProperty(PropertyName = "metadata", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, string> Metadata { get => metadata; set => metadata = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
