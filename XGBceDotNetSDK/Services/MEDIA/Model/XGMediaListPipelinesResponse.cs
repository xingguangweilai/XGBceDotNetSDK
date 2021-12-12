using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.MEDIA.Model
{
    /// <summary>
    /// 列举用户所有队列响应类
    /// </summary>
    public class XGMediaListPipelinesResponse:XGMediaResponse
    {
        private List<XGMediaQueryPipelineResponse> pipelines;

        public XGMediaListPipelinesResponse()
        {
        }

        /// <summary>
        ///用户队列的集合
        /// </summary>
        [JsonProperty(PropertyName = "pipelines", NullValueHandling = NullValueHandling.Ignore)]
        public List<XGMediaQueryPipelineResponse> Pipelines { get => pipelines; set => pipelines = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
