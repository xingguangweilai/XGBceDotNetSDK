using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using XGBceDotNetSDK.BaseClass;
using XGBceDotNetSDK.Utils;

namespace XGBceDotNetSDK.Services.VCR.Model
{
    /// <summary>
    /// logo库类
    /// </summary>
    public class XGVcrLogoLib
    {
        private string lib;
        private string userId;
        private string description;
        private DateTime createTime;

        /// <summary>
        /// 自定义logo库名称
        /// </summary>
        [JsonProperty(PropertyName = "lib", NullValueHandling = NullValueHandling.Ignore)]
        public string Lib { get => lib; set => lib = value; }
        /// <summary>
        /// 用户id
        /// </summary>
        [JsonProperty(PropertyName = "userId", NullValueHandling = NullValueHandling.Ignore)]
        public string UserId { get => userId; set => userId = value; }
        /// <summary>
        /// 描述，最大支持256字符	
        /// </summary>
        [JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get => description; set => description = value; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [JsonConverter(typeof(UnixTimestampJsonConverter)), JsonProperty(PropertyName = "createTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime CreateTime { get => createTime; set => createTime = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }

    /// <summary>
    /// 列出所有Logo库响应类
    /// </summary>
    public class XGVcrListLogoLibResponse: XGAbstractBceResponse
    {
        private List<XGVcrLogoLib> libs;
        public XGVcrListLogoLibResponse()
        {
        }

        /// <summary>
        /// 自定义logo库集合
        /// </summary>
        [JsonProperty(PropertyName = "libs", NullValueHandling = NullValueHandling.Ignore)]
        public List<XGVcrLogoLib> Libs { get => libs; set => libs = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
