using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.VCR.Model
{
    /// <summary>
    /// 列举face库集名称集合请求类
    /// </summary>
    public class XGVcrListFaceLibBriefsRequest: XGAbstractVcrRequest
    {
        private string libName;
        public XGVcrListFaceLibBriefsRequest()
        {
        }

        /// <summary>
        /// 库名称
        /// </summary>
        [JsonIgnore]
        public string LibName { get => libName; set => libName = value; }
    }
}
