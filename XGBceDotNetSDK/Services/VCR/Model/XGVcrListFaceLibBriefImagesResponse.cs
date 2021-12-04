using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.VCR.Model
{
    /// <summary>
    /// 列举face库集素材响应类
    /// </summary>
    public class XGVcrListFaceLibBriefImagesResponse: XGVcrResponse
    {
        private List<string> images;
        public XGVcrListFaceLibBriefImagesResponse()
        {
        }

        /// <summary>
        /// face库集素材数组
        /// </summary>
        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Images { get => images; set => images = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
