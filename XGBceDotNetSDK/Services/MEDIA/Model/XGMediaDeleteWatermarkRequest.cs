using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.MEDIA.Model
{
    /// <summary>
    /// 删除水印请求类
    /// </summary>
    public class XGMediaDeleteWatermarkRequest:XGAbstractMediaRequest
    {
        private string watermarkId;

        public XGMediaDeleteWatermarkRequest()
        {
        }

        /// <summary>
        /// 水印的唯一标识
        /// </summary>
        [JsonIgnore]
        public string WatermarkId { get => watermarkId; set => watermarkId = value; }
    }
}
