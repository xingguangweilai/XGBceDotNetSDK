using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.VCR.Model
{
    /// <summary>
    /// 自定义文本请求类
    /// </summary>
    public class XGVcrTextLibTextsRequest: XGAbstractVcrRequest
    {
        private string name;
        private List<string> items;
        public XGVcrTextLibTextsRequest()
        {
        }

        /// <summary>
        /// 自定义文本库名称 
        /// <para>必需</para>
        /// </summary>
        [JsonIgnore]
        public string Name { get => name; set => name = value; }

        /// <summary>
        /// 文本集合
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
