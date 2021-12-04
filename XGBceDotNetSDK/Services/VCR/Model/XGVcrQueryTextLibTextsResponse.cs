using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.VCR.Model
{
    /// <summary>
    /// 查看自定义文本库内容响应类
    /// </summary>
    public class XGVcrQueryTextLibTextsResponse: XGVcrResponse
    {
        private int pageNo;
        private int pageSize;
        private List<string> items;
        public XGVcrQueryTextLibTextsResponse()
        {
        }

        /// <summary>
        /// 分页页数
        /// <para>必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "pageNo", NullValueHandling = NullValueHandling.Ignore)]
        public int PageNo { get => pageNo; set => pageNo = value; }
        /// <summary>
        /// 分页显示条数
        /// <para>必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "pageSize", NullValueHandling = NullValueHandling.Ignore)]
        public int PageSize { get => pageSize; set => pageSize = value; }
        /// <summary>
        /// 文本库内容集合
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
