using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.MEDIA.Model
{
    /// <summary>
    /// 查询指定水印请求类
    /// </summary>
    public class XGMediaQueryWatermarkRequest:XGAbstractMediaRequest
    {
        private string watermarkId;

        public XGMediaQueryWatermarkRequest()
        {
        }

        /// <summary>
        /// 水印的唯一标识
        /// <para>必需</para>
        /// </summary>
        [JsonIgnore]
        public string WatermarkId { get => watermarkId; set => watermarkId = value; }
    }
}
