using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.DOC.Model
{
    /// <summary>
    /// 文档图片
    /// </summary>
    public class XGDocDocumentImage
    {
        private int? pageIndex;
        private string url;

        /// <summary>
        /// 页码，从1开始
        /// </summary>
        [JsonProperty(PropertyName = "pageIndex", NullValueHandling = NullValueHandling.Ignore)]
        public int? PageIndex { get => pageIndex; set => pageIndex = value; }
        /// <summary>
        /// 图片URL
        /// </summary>
        [JsonProperty(PropertyName = "url", NullValueHandling = NullValueHandling.Ignore)]
        public string Url { get => url; set => url = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
    /// <summary>
    /// 查询文档转码结果图片列表响应类
    /// </summary>
    public class XGDocListDocumentImagesResponse:XGDocResponse
    {
        private List<XGDocDocumentImage> images;

        public XGDocListDocumentImagesResponse()
        {
        }

        /// <summary>
        /// 图片URL
        /// </summary>
        [JsonProperty(PropertyName = "images", NullValueHandling = NullValueHandling.Ignore)]
        public List<XGDocDocumentImage> Images { get => images; set => images = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
