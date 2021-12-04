using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.VCR.Model
{
    /// <summary>
    /// logo库集素材图片对象
    /// </summary>
    public class XGVcrLogoLibBriefImageContent
    {
        private string image;
        private string imageId;

        /// <summary>
        /// 图片地址
        /// </summary>
        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
        public string Image { get => image; set => image = value; }
        /// <summary>
        /// 图片id
        /// </summary>
        [JsonProperty(PropertyName = "imageId", NullValueHandling = NullValueHandling.Ignore)]
        public string ImageId { get => imageId; set => imageId = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
    /// <summary>
    /// 列举logo库集素材响应类
    /// </summary>
    public class XGVcrListLogoLibBriefImagesResponse: XGVcrResponse
    {
        private List<string> images;
        private List<XGVcrLogoLibBriefImageContent> imageContents;
        public XGVcrListLogoLibBriefImagesResponse()
        {
        }

        /// <summary>
        /// 图片数组
        /// </summary>
        [JsonProperty(PropertyName = "images", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Images { get => images; set => images = value; }
        /// <summary>
        /// 图片对象数组
        /// </summary>
        [JsonProperty(PropertyName = "imageContents", NullValueHandling = NullValueHandling.Ignore)]
        public List<XGVcrLogoLibBriefImageContent> ImageContents { get => imageContents; set => imageContents = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
