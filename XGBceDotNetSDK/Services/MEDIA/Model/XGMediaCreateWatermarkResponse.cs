using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.MEDIA.Model
{
    /// <summary>
    /// 创建水印响应类
    /// </summary>
    public class XGMediaCreateWatermarkResponse:XGMediaResponse
    {
        private string watermarkId;

        public XGMediaCreateWatermarkResponse()
        {
        }

        /// <summary>
        /// 水印的唯一标识
        /// </summary>
        [JsonProperty(PropertyName = "watermarkId", NullValueHandling = NullValueHandling.Ignore)]
        public string WatermarkId { get => watermarkId; set => watermarkId = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
