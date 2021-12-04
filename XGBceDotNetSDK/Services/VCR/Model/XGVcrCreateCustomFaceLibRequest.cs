using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.VCR.Model
{
    /// <summary>
    /// 创建自定义face库请求类
    /// </summary>
    public class XGVcrCreateCustomFaceLibRequest: XGAbstractVcrCreateCustomLibRequest
    {
        private string lib;

        public XGVcrCreateCustomFaceLibRequest():base("face")
        {
        }
        /// <summary>
        /// 自定义人脸库名称库名称
        /// <para>必需</para>
        /// </summary>
        [JsonProperty("lib")]
        public string Lib { get => lib; set => lib = value; }
        

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
