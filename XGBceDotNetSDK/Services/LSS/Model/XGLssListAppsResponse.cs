using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.LSS.Model
{
    /// <summary>
    /// 查询所有App响应类
    /// </summary>
    public class XGLssListAppsResponse: XGLssResponse
    {
        private List<string> appList;
        public XGLssListAppsResponse()
        {
        }

        /// <summary>
        /// App列表
        /// </summary>
        [JsonProperty(PropertyName = "appList", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> AppList { get => appList; set => appList = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
