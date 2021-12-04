using System;
using System.Text;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.SMS.Model
{
    public class XGSendMessageItem
    {
        /// <summary>
        /// 对应手机号的提交状态，1000表示成功
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        [JsonProperty("mobile")]
        public string Mobile {get; set; }
        /// <summary>
        /// 对应手机号的消息ID
        /// </summary>
        [JsonProperty("messageId")]
        public string MessageId { get; set; }
        /// <summary>
        /// 对应手机号的响应结果描述
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }
        public XGSendMessageItem()
        {
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder("{");
            builder.AppendLine("\"code\":\"" + Code + "\",");
            builder.AppendLine("\"message\":\"" + Message + "\",");
            builder.AppendLine("\"mobile\":\"" + Mobile + "\",");
            builder.AppendLine("\"messageId\":\"" + MessageId + "\"");
            builder.AppendLine("}");
            return builder.ToString();
        }
    }
}
