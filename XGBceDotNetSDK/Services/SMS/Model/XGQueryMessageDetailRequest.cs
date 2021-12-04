using System;
namespace XGBceDotNetSDK.Services.SMS.Model
{
    public class XGQueryMessageDetailRequest:XGSmsRequest
    {
        private string messageId;

        public XGQueryMessageDetailRequest()
        {
        }

        public string MessageId { get => messageId; set => messageId = value; }

    }
}
