using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.VCR.Model
{
    /// <summary>
    /// 列举logo库集名称集合请求类
    /// </summary>
    public class XGVcrListLogoLibBriefsRequest : XGAbstractVcrRequest
    {
        private string libName;
        public XGVcrListLogoLibBriefsRequest()
        {
        }

        /// <summary>
        /// 库名称
        /// </summary>
        [JsonIgnore]
        public string LibName { get => libName; set => libName = value; }
    }
}
