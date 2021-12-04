using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.VCR.Model
{
    /// <summary>
    /// 删除自定义图片黑库请求类
    /// </summary>
    public class XGVcrDeleteCustomImageLibRequest: XGAbstractVcrDeleteCustomLibRequest
    {

        public XGVcrDeleteCustomImageLibRequest() : base("image")
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
