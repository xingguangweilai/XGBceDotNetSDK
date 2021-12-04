using System;
using Newtonsoft.Json;
using XGBceDotNetSDK.Sign;

namespace XGBceDotNetSDK.Services.VCA.Model
{
    /// <summary>
    /// face库集列表请求类
    /// </summary>
    public class XGListFaceLibBriefRequest:XGAbstractVcaRequest
    {
        private string lib;
        public XGListFaceLibBriefRequest()
        {
        }

        /// <summary>
        /// logo库名
        /// 必需
        /// </summary>
        [JsonIgnore]
        public string Lib { get => lib; set => lib = value; }
    }
}
