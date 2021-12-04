using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.VCR.Model
{
    /// <summary>
    /// 直播流审核列表页
    /// </summary>
    public class XGVcrListStreamStatusRequest: XGAbstractVcrRequest
    {
        private int? maxKeys;
        private string marker;
        private XGVcrStreamStatus? status;

        public XGVcrListStreamStatusRequest()
        {
        }

        /// <summary>
        /// 本次请求返回的任务列表的最大元素个数
        /// <para>合法取值范围为[1-100]，默认值为10</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonIgnore]
        public int? MaxKeys { get => maxKeys; set => maxKeys = value; }
        /// <summary>
        /// 本次请求的marker
        /// <para>标记查询的起始位置，是上次marker机制查询返回的nextMarker，首次查询不提供本字段</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonIgnore]
        public string Marker { get => marker; set => marker = value; }
        /// <summary>
        /// 直播流状态
        /// <para>非必需</para>
        /// </summary>
        [JsonIgnore]
        public XGVcrStreamStatus? Status { get => status; set => status = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
