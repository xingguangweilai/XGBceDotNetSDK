using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.VCR.Model
{
    /// <summary>
    /// 删除自定义face库请求类
    /// </summary>
    public class XGVcrDeleteCustomFaceLibRequest: XGAbstractVcrDeleteCustomLibRequest
    {
        private string lib;

        public XGVcrDeleteCustomFaceLibRequest():base("face")
        {
        }

        /// <summary>
        /// 自定义人脸库名称库名称
        /// <para>必需</para>
        /// </summary>
        [JsonIgnore]
        public string Lib { get => Libname; set => Libname = value; }


        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
