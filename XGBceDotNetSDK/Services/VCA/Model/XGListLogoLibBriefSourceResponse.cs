using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using XGBceDotNetSDK.BaseClass;

namespace XGBceDotNetSDK.Services.VCA.Model
{
    public class XGListLogoLibBriefSourceResponse: XGAbstractBceResponse
    {
        private List<string> images;
        public XGListLogoLibBriefSourceResponse()
        {
        }

        /// <summary>
        /// 图片url列表
        /// </summary>
        [JsonProperty(PropertyName = "images", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Images { get => images; set => images = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
