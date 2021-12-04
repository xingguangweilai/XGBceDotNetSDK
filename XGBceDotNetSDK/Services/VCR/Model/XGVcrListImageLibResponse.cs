using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using XGBceDotNetSDK.BaseClass;
using XGBceDotNetSDK.Utils;

namespace XGBceDotNetSDK.Services.VCR.Model
{
    /// <summary>
    /// 图片黑库类
    /// </summary>
    public class XGVcrImageLib
    {
        private string name;
        private int count;
        private string description;
        private DateTime createTime;

        /// <summary>
        /// 库名称
        /// </summary>
        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get => name; set => name = value; }
        /// <summary>
        /// 库内图片个数
        /// </summary>
        [JsonProperty(PropertyName = "count", NullValueHandling = NullValueHandling.Ignore)]
        public int Count { get => count; set => count = value; }
        /// <summary>
        /// 描述信息
        /// </summary>
        [JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get => description; set => description = value; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [JsonProperty(PropertyName = "createTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime CreateTime { get => createTime; set => createTime = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }

    /// <summary>
    /// 列出所有图片黑库响应类
    /// </summary>
    public class XGVcrListImageLibResponse : XGAbstractBceResponse
    {
        private List<XGVcrImageLib> libs;
        public XGVcrListImageLibResponse()
        {
        }

        /// <summary>
        /// 自定义图片黑库集合
        /// </summary>
        [JsonProperty(PropertyName = "libs", NullValueHandling = NullValueHandling.Ignore)]
        public List<XGVcrImageLib> Libs { get => libs; set => libs = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
