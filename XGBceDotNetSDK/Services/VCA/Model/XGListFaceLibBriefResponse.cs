using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using XGBceDotNetSDK.BaseClass;

namespace XGBceDotNetSDK.Services.VCA.Model
{
    public class XGListFaceLibBriefResponse: XGAbstractBceResponse
    {
        private List<string> briefs;
        public XGListFaceLibBriefResponse()
        {
        }

        /// <summary>
        /// 图片描述列表
        /// </summary>
        [JsonProperty(PropertyName = "briefs", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Briefs { get => briefs; set => briefs = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
