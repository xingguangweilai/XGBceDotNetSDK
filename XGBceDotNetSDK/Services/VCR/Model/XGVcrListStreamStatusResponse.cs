using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using XGBceDotNetSDK.BaseClass;

namespace XGBceDotNetSDK.Services.VCR.Model
{
    /// <summary>
    /// 直播流审核列表页响应类
    /// </summary>
    public class XGVcrListStreamStatusResponse: XGAbstractBceResponse
    {
        private int maxKeys;
        private string marker;
        private string nextMarker;
        private bool isTruncated;
        private List<XGVcrQueryStreamStatusResponse> tasks;

        public XGVcrListStreamStatusResponse()
        {
        }

        /// <summary>
        /// 本次请求返回的任务列表的最大元素个数
        /// <para>合法取值范围为[1-100]，默认值为10</para>
        /// </summary>
        [JsonProperty(PropertyName = "maxKeys", NullValueHandling = NullValueHandling.Ignore)]
        public int MaxKeys { get => maxKeys; set => maxKeys = value; }
        /// <summary>
        /// 本次请求的marker，标记查询的起始位置
        /// </summary>
        [JsonProperty(PropertyName = "marker", NullValueHandling = NullValueHandling.Ignore)]
        public string Marker { get => marker; set => marker = value; }
        /// <summary>
        /// 获取下一页所需要传递的marker值
        /// <para>当isTruncated为false时，该域不出现</para>
        /// </summary>
        [JsonProperty(PropertyName = "nextMarker", NullValueHandling = NullValueHandling.Ignore)]
        public string NextMarker { get => nextMarker; set => nextMarker = value; }
        /// <summary>
        /// 指明是否所有查询都返回了
        /// <para>true表示后面还有数据，false表示已经是最后一页</para>
        /// </summary>
        [JsonProperty(PropertyName = "isTruncated", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsTruncated { get => isTruncated; set => isTruncated = value; }
        /// <summary>
        /// 任务列表
        /// </summary>
        [JsonProperty(PropertyName = "tasks", NullValueHandling = NullValueHandling.Ignore)]
        public List<XGVcrQueryStreamStatusResponse> Tasks { get => tasks; set => tasks = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
