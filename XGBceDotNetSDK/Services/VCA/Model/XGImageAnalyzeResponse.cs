using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using XGBceDotNetSDK.BaseClass;

namespace XGBceDotNetSDK.Services.VCA.Model
{
    /// <summary>
    /// 图片分析结果类
    /// </summary>
    public class XGImageResult
    {
        private string type;
        private string data;

        public XGImageResult() { }

        /// <summary>
        /// 图片url
        /// </summary>
        [JsonProperty(PropertyName = "type", NullValueHandling = NullValueHandling.Ignore)]
        public string Source { get => type; set => type = value; }
        /// <summary>
        /// 图片分析模版
        /// </summary>
        [JsonProperty(PropertyName = "preset", NullValueHandling = NullValueHandling.Ignore)]
        public string Preset { get => data; set => data = value; }

    }
    /// <summary>
    /// 图片分析响应体
    /// 文档：https://cloud.baidu.com/doc/VCA/s/ukmbxecsp
    /// </summary>
    public class XGImageAnalyzeResponse: XGAbstractBceResponse
    {
        private string source;
        private string preset;
        private string title;
        private XGVcaAnalyzeStatus status;
        private string publishTime;
        private List<XGImageResult> results;
        private XGVcaError error;

        public XGImageAnalyzeResponse() { }

        /// <summary>
        /// 图片url
        /// </summary>
        [JsonProperty(PropertyName = "source", NullValueHandling = NullValueHandling.Ignore)]
        public string Source { get => source; set => source = value; }
        /// <summary>
        /// 图片分析模版
        /// </summary>
        [JsonProperty(PropertyName = "preset", NullValueHandling = NullValueHandling.Ignore)]
        public string Preset { get => preset; set => preset = value; }
        /// <summary>
        /// 标题
        /// </summary>
        [JsonProperty(PropertyName = "title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get => title; set => title = value; }
        /// <summary>
        /// 结果列表，仅仅当status=FINISHED时返回
        /// </summary>
        [JsonProperty(PropertyName = "results", NullValueHandling = NullValueHandling.Ignore)]
        public List<XGImageResult> Results { get => results; set => results = value; }
        /// <summary>
        /// 失败结果，仅仅当status=Error时返回
        /// </summary>
        [JsonProperty(PropertyName = "error", NullValueHandling = NullValueHandling.Ignore)]
        public XGVcaError Error { get => error; set => error = value; }
        /// <summary>
        /// 发布时间
        /// </summary>
        [JsonProperty(PropertyName = "publishTime", NullValueHandling = NullValueHandling.Ignore)]
        public string PublishTime { get => publishTime; set => publishTime = value; }
        /// <summary>
        /// 任务状态
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)),JsonProperty(PropertyName ="status",NullValueHandling =NullValueHandling.Ignore)]
        public XGVcaAnalyzeStatus Status { get => status; set => status = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
