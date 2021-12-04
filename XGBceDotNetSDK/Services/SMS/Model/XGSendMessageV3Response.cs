using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using XGBceDotNetSDK.BaseClass;

namespace XGBceDotNetSDK.Services.SMS.Model
{
    /// <summary>
    /// 短信下发响应类
    /// <para> https://cloud.baidu.com/doc/SMS/s/lkijy5wvf </para>
    /// </summary>
    public class XGSendMessageV3Response:XGBaseResponse
    {
        public XGSendMessageV3Response()
        {
        }

        [JsonProperty("data")]
        public List<XGSendMessageItem> Data { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        [JsonIgnore]
        public override bool IsSuccess { get => "1000".Equals(Code); }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
