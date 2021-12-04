using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.SMS.Model
{
    public class XGQueryMessageDetailResponse:XGSmsResponse
    {
        private string messageId;
        private string content;
        private List<string> receiver;
        private DateTime? sendTime;

        public XGQueryMessageDetailResponse()
        {
        }

        /// <summary>
        /// 短信ID
        /// </summary>
        [JsonProperty(PropertyName = "messageId", NullValueHandling = NullValueHandling.Ignore)]
        public string MessageId { get => messageId; set => messageId = value; }
        /// <summary>
        /// 短信内容
        /// </summary>
        [JsonProperty(PropertyName = "content", NullValueHandling = NullValueHandling.Ignore)]
        public string Content { get => content; set => content = value; }
        /// <summary>
        /// 接收者列表
        /// </summary>
        [JsonProperty(PropertyName = "receiver", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Receiver { get => receiver; set => receiver = value; }
        /// <summary>
        /// 发送时间
        /// </summary>
        [JsonConverter(typeof(XGSmsDateTimeConverter)),JsonProperty(PropertyName = "sendTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? SendTime { get => sendTime; set => sendTime = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
