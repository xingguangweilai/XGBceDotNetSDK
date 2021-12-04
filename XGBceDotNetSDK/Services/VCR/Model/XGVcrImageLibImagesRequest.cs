using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.VCR.Model
{
    /// <summary>
    /// 黑库图片集合请求类
    /// </summary>
    public class XGVcrImageLibImagesRequest: XGAbstractVcrRequest
    {
        private string name;
        private List<string> items;
        public XGVcrImageLibImagesRequest()
        {
        }

        /// <summary>
        /// 自定义黑库名称 
        /// <para>必需</para>
        /// </summary>
        [JsonIgnore]
        public string Name { get => name; set => name = value; }

        /// <summary>
        /// 图片集合，最多100张
        /// <para>必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "items", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Items { get => items; set => items = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
