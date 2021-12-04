using System;
using Newtonsoft.Json;
using XGBceDotNetSDK.Sign;

namespace XGBceDotNetSDK.Services.VCA.Model
{
    /// <summary>
    /// 创建自定义face库请求类
    /// </summary>
    public class XGCreateCustomFaceLibRequest: XGAbstractVcaRequest
    {
        private string lib;
        private string description;
        public XGCreateCustomFaceLibRequest()
        {
        }

        /// <summary>
        /// 库名称
        /// 长度不超过20，支持小写字母、数字和_，以字母开头，且必须全局唯一
        /// 必需
        /// </summary>
        [JsonProperty("lib")]
        public string Lib { get => lib; set => lib = value; }
        /// <summary>
        /// 图片描述
        /// 长度不超过256
        /// 非必需
        /// </summary>
        [JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get => description; set => description = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }

    }
}
