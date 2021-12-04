using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using XGBceDotNetSDK.BaseClass;

namespace XGBceDotNetSDK.Services.VCA.Model
{
    /// <summary>
    /// face库摘要
    /// </summary>
    public class XGFaceLibSummary
    {
        private string userId;
        private string lib;
        private DateTime? createTime;
        private string description;

        public XGFaceLibSummary() { }

        /// <summary>
        /// 用户id
        /// </summary>
        [JsonProperty(PropertyName = "userId", NullValueHandling = NullValueHandling.Ignore)]
        public string UserId { get => userId; set => userId = value; }
        /// <summary>
        /// face库名称
        /// </summary>
        [JsonProperty(PropertyName = "lib", NullValueHandling = NullValueHandling.Ignore)]
        public string Lib { get => lib; set => lib = value; }
        /// <summary>
        /// face库创建时间
        /// </summary>
        [JsonProperty(PropertyName = "createTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? CreateTime { get => createTime; set => createTime = value; }
        /// <summary>
        /// face库描述
        /// </summary>
        [JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get => description; set => description = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
    public class XGListFaceLibResponse: XGAbstractBceResponse
    {
        private List<XGFaceLibSummary> libs;
        public XGListFaceLibResponse() { }

        /// <summary>
        /// face库列表
        /// </summary>
        [JsonProperty(PropertyName = "libs", NullValueHandling = NullValueHandling.Ignore)]
        public List<XGFaceLibSummary> Libs { get => libs; set => libs = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
