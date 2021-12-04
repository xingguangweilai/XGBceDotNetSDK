using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using XGBceDotNetSDK.BaseClass;
using XGBceDotNetSDK.Utils;

namespace XGBceDotNetSDK.Services.VCR.Model
{
    /// <summary>
    /// face库类
    /// </summary>
    public class XGVcrFaceLib
    {
        private string name;
        private string userId;
        private string description;
        private DateTime createTime;

        /// <summary>
        /// 自定义人脸库名称
        /// </summary>
        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get => name; set => name = value; }
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
        [JsonConverter(typeof(UnixTimestampJsonConverter)),JsonProperty(PropertyName = "createTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime CreateTime { get => createTime; set => createTime = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
    /// <summary>
    /// 列出所有face库响应类
    /// </summary>
    public class XGVcrListFaceLibResponse: XGAbstractBceResponse
    {
        private List<XGVcrFaceLib> libs;
        public XGVcrListFaceLibResponse()
        {
        }

        /// <summary>
        /// 自定义人脸库集合
        /// </summary>
        [JsonProperty(PropertyName = "libs", NullValueHandling = NullValueHandling.Ignore)]
        public List<XGVcrFaceLib> Libs { get => libs; set => libs = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
