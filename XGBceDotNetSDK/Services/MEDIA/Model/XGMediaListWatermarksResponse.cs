using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.MEDIA.Model
{
    /// <summary>
    /// 列举当前用户水印响应类
    /// </summary>
    public class XGMediaListWatermarksResponse: XGMediaResponse
    {
        private List<XGMediaQueryWatermarkResponse> watermarks;

        public XGMediaListWatermarksResponse()
        {
        }

        /// <summary>
        /// 水印的唯一标识
        /// </summary>
        [JsonProperty(PropertyName = "watermarks", NullValueHandling = NullValueHandling.Ignore)]
        public List<XGMediaQueryWatermarkResponse> Watermarks { get => watermarks; set => watermarks = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
