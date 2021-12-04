using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using XGBceDotNetSDK.BaseClass;
using XGBceDotNetSDK.Utils;

namespace XGBceDotNetSDK.Services.VCR.Model
{
    /// <summary>
    /// 文本库类
    /// </summary>
    public class XGVcrTextLib
    {
        private string name;
        private int itemCount;
        private string matchType;
        private string description;
        private DateTime createTime;

        /// <summary>
        /// 自定义文本库名称
        /// </summary>
        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get => name; set => name = value; }
        /// <summary>
        /// 匹配类型，默认切词包含
        /// </summary>
        [JsonProperty(PropertyName = "matchType", NullValueHandling = NullValueHandling.Ignore)]
        public string MatchType { get => matchType; set => matchType = value; }
        /// <summary>
        /// 文本个数
        /// </summary>
        [JsonProperty(PropertyName = "itemCount", NullValueHandling = NullValueHandling.Ignore)]
        public int ItemCount { get => itemCount; set => itemCount = value; }
        /// <summary>
        /// 描述，最大支持256字符	
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
    /// 列出所有文本库响应类
    /// </summary>
    public class XGVcrListTextLibResponse : XGAbstractBceResponse
    {
        private List<XGVcrTextLib> textLibList;
        public XGVcrListTextLibResponse()
        {
        }

        /// <summary>
        /// 自定义文本库集合
        /// </summary>
        [JsonProperty(PropertyName = "textLibList", NullValueHandling = NullValueHandling.Ignore)]
        public List<XGVcrTextLib> TextLibList { get => textLibList; set => textLibList = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
