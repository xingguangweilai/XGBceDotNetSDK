using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using XGBceDotNetSDK.BaseClass;

namespace XGBceDotNetSDK.Services.VCA.Model
{
    /// <summary>
    /// logo库摘要
    /// </summary>
    public class XGLogoLibSummary
    {
        private string userId;
        private string lib;
        private DateTime? createTime;
        private string description;

        public XGLogoLibSummary() { }

        /// <summary>
        /// 用户id
        /// </summary>
        [JsonProperty(PropertyName = "userId", NullValueHandling = NullValueHandling.Ignore)]
        public string UserId { get => userId; set => userId = value; }
        /// <summary>
        /// logo库名称
        /// </summary>
        [JsonProperty(PropertyName = "lib", NullValueHandling = NullValueHandling.Ignore)]
        public string Lib { get => lib; set => lib = value; }
        /// <summary>
        /// logo库创建时间
        /// </summary>
        [JsonProperty(PropertyName = "createTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? CreateTime { get => createTime; set => createTime = value; }
        /// <summary>
        /// logo库描述
        /// </summary>
        [JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get => description; set => description = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }

    public class XGListLogoLibResponse : XGAbstractBceResponse
    {
        private List<XGFaceLibSummary> libs;

        public XGListLogoLibResponse()
        {
        }

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
