using System;
using Newtonsoft.Json;
using XGBceDotNetSDK.BaseClass;
using XGBceDotNetSDK.Sign;

namespace XGBceDotNetSDK.Services.VCA.Model
{
    /// <summary>
    /// 提交图片分析类（同步）
    /// </summary>
    public class XGImageAnalyzeRequest: XGAbstractVcaRequest
    {
        private static readonly string sync= "sync";
        private string source;
        private string preset;
        private string title;

        public XGImageAnalyzeRequest() { }

        /// <summary>
        /// 标志参数，无须取值
        /// 必需
        /// </summary>
        [JsonIgnore]
        public static string Sync => sync;
        /// <summary>
        /// 图片url
        /// 必需
        /// </summary>
        [JsonProperty("source")]
        public string Source { get => source; set => source = value; }
        /// <summary>
        /// 图片分析模版
        /// 不设置时使用默认图片模版
        /// 非必需
        /// </summary>
        [JsonProperty(PropertyName = "preset", NullValueHandling = NullValueHandling.Ignore)]
        public string Preset { get => preset; set => preset = value; }
        /// <summary>
        /// 标题, 长度不超过256
        /// 非必需
        /// </summary>
        [JsonProperty(PropertyName = "title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get => title; set => title = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
