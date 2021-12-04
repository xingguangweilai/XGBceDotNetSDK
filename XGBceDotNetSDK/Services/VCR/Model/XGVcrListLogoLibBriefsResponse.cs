using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.VCR.Model
{
    /// <summary>
    /// 列举logo库集名称集合响应类
    /// </summary>
    public class XGVcrListLogoLibBriefsResponse : XGVcrResponse
    {
        private List<string> briefs;
        public XGVcrListLogoLibBriefsResponse()
        {
        }
        /// <summary>
        /// logo库集名称集合
        /// </summary>
        [JsonProperty(PropertyName = "briefs", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Briefs { get => briefs; set => briefs = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
