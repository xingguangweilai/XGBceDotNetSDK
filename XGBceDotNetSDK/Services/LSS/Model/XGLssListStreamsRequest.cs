using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using static XGBceDotNetSDK.Services.LSS.Model.XGLssEnum;

namespace XGBceDotNetSDK.Services.LSS.Model
{
    /// <summary>
    /// 查询所有Stream请求类
    /// </summary>
    public class XGLssListStreamsRequest: XGAbstractLssRequest
    {
        private string playDomain;
        private XGLssStreamStatus? status;
        private string marker;
        private int? maxSize;

        public XGLssListStreamsRequest()
        {
        }

        /// <summary>
        /// 直播域名
        /// <para>必需</para>
        /// </summary>
        [JsonIgnore]
        public string PlayDomain { get => playDomain; set => playDomain = value; }
        /// <summary>
        /// Stream状态
        /// <para>可选</para>
        /// </summary>
        [JsonIgnore]
        public XGLssStreamStatus? Status { get => status; set => status = value; }
        /// <summary>
        /// 本次请求的marker
        /// <para>标记查询的起始位置</para>
        /// <para>可选</para>
        /// </summary>
        [JsonIgnore]
        public string Marker { get => marker; set => marker = value; }
        /// <summary>
        /// 本次请求的Stream数目
        /// <para>不超过200。默认值：200</para>
        /// <para>可选</para>
        /// </summary>
        [JsonIgnore]
        public int? MaxSize { get => maxSize; set => maxSize = value; }

    }
}
