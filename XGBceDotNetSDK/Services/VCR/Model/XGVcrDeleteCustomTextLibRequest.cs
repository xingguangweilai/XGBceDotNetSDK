using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.VCR.Model
{
    /// <summary>
    /// 删除自定义文本库请求类
    /// </summary>
    public class XGVcrDeleteCustomTextLibRequest: XGAbstractVcrDeleteCustomLibRequest
    {

        public XGVcrDeleteCustomTextLibRequest():base("text")
        {
        }

        /// <summary>
        /// 自定义人脸库名称库名称
        /// <para>必需</para>
        /// </summary>
        [JsonIgnore]
        public string Name { get => Libname; set => Libname = value; }


        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
