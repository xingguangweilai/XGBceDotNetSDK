using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.VCR.Model
{
    /// <summary>
    /// 审核证据位置信息
    /// </summary>
    public class XGVcrEvidenceLocation
    {
        private int leftOffsetInPixel;
        private int topOffsetInPixel;
        private int widthInPixel;
        private int heightInPixel;

        public XGVcrEvidenceLocation()
        {
        }

        /// <summary>
        /// 左偏移
        /// </summary>
        [JsonProperty(PropertyName = "leftOffsetInPixel", NullValueHandling = NullValueHandling.Ignore)]
        public int LeftOffsetInPixel { get => leftOffsetInPixel; set => leftOffsetInPixel = value; }
        /// <summary>
        /// 上偏移
        /// </summary>
        [JsonProperty(PropertyName = "topOffsetInPixel", NullValueHandling = NullValueHandling.Ignore)]
        public int TopOffsetInPixel { get => topOffsetInPixel; set => topOffsetInPixel = value; }
        /// <summary>
        /// 宽度
        /// </summary>
        [JsonProperty(PropertyName = "widthInPixel", NullValueHandling = NullValueHandling.Ignore)]
        public int WidthInPixel { get => widthInPixel; set => widthInPixel = value; }
        /// <summary>
        /// 高度
        /// </summary>
        [JsonProperty(PropertyName = "heightInPixel", NullValueHandling = NullValueHandling.Ignore)]
        public int HeightInPixel { get => heightInPixel; set => heightInPixel = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
