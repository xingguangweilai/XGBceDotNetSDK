using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using XGBceDotNetSDK.BaseClass;

namespace XGBceDotNetSDK.Services.VCR.Model
{
    /// <summary>
    /// 黑库中的图片
    /// </summary>
    public class XGVcrImageLibImage
    {
        private string id;
        private string source;

        /// <summary>
        /// 图片ID
        /// </summary>
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get => id; set => id = value; }
        /// <summary>
        /// 图片地址
        /// </summary>
        [JsonProperty(PropertyName = "source", NullValueHandling = NullValueHandling.Ignore)]
        public string Source { get => source; set => source = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
    /// <summary>
    /// 查看黑库中图片响应类
    /// </summary>
    public class XGVcrQueryImageLibImagesResponse: XGVcrResponse
    {
        private int pageNo;
        private int pageSize;
        private int totalCount;
        private List<XGVcrImageLibImage> result;
        public XGVcrQueryImageLibImagesResponse()
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
        /// 图片总数
        /// <para>必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "totalCount", NullValueHandling = NullValueHandling.Ignore)]
        public int TotalCount { get => totalCount; set => totalCount = value; }
        /// <summary>
        /// 图片列表
        /// <para>必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "result", NullValueHandling = NullValueHandling.Ignore)]
        public List<XGVcrImageLibImage> Result { get => result; set => result = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
