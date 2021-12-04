using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using XGBceDotNetSDK.BaseClass;

namespace XGBceDotNetSDK.Services.VCR.Model
{
    /// <summary>
    /// 提交图片审核（同步）结果响应类
    /// </summary>
    public class XGVcrPutImageResponse: XGAbstractBceResponse
    {
        private string source;
        private string label;
        private List<XGVcrMediaResult> results;

        public XGVcrPutImageResponse()
        {
        }

        /// <summary>
        /// 图片路径
        /// </summary>
        [JsonProperty(PropertyName = "source", NullValueHandling = NullValueHandling.Ignore)]
        public string Source { get => source; set => source = value; }
        /// <summary>
        /// 图片审核结果标记label，简称审核标记
        /// <para> 其可选值包括NORMAL/REVIEW/REJECT，分别表示正常/疑似违规/确认违规。 </para>
        /// <para> 图片审核标记是根据 VCR 审核结果的置信度和VCR内部配置疑似置信度阈值和确认置信度阈值生成的。 </para>
        /// <para>说明文档： https://cloud.baidu.com/doc/VCR/s/xjwvyaxsd#%E5%9B%BE%E7%89%87%E5%AE%A1%E6%A0%B8%E6%A0%87%E8%AE%B0 </para>
        /// </summary>
        [JsonProperty(PropertyName = "label", NullValueHandling = NullValueHandling.Ignore)]
        public string Label { get => label; set => label = value; }
        /// <summary>
        /// 审核结果，仅当label=REJECT时存在
        /// </summary>
        [JsonProperty(PropertyName = "results", NullValueHandling = NullValueHandling.Ignore)]
        public List<XGVcrMediaResult> Results { get => results; set => results = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
