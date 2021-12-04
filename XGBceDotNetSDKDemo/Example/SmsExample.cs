using System;
using System.Collections.Generic;
using XGBceDotNetSDK.Services.SMS.Model;
using XGBceDotNetSDK.Sign;

namespace XGBceDotNetSDK.Services.SMS
{
    public class SmsExample
    {
        private string access_key_id;
        private string secret_access_key;

        public SmsExample()
        {
            XGSmsClientConfiguration smsClientConfiguration = new XGSmsClientConfiguration()
            {
                Credentials = new DefaultBceCredentials(access_key_id, secret_access_key),
                Endpoint = "http://smsv3.bj.baidubce.com/"
            };

            XGSmsClient smsClient = new XGSmsClient(smsClientConfiguration);

            //XGSendMessageV3Request request = new XGSendMessageV3Request()
            //{
            //    Mobile = "",
            //    Template = "sms-tmpl-",
            //    SignatureId = "sms-sign-",
            //    ContentVar = new Dictionary<string, string> { { "ticketNumber", "10010" }, { "ticketTitle", "测试标题" } }
            //};

            //XGSendMessageV3Response response = smsClient.SendMessage(request);
            //if (response != null && response.IsSuccess)
            //{
            //    Console.WriteLine("发送成功：" + response.ToString());
            //}
            //else
            //{
            //    Console.WriteLine("发送失败：" + response.Message);
            //}

            XGQuerySignatureRequest querySignatureRequest = new XGQuerySignatureRequest()
            {
                SignatureId = "sms-sign-"
            };

            try
            {
                XGQuerySignatureResponse querySignatureResponse = smsClient.QuerySignature(querySignatureRequest);
                Console.WriteLine("查询签名成功：" + querySignatureResponse.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("查询失败：" + ex.Message);
            }

        }
    }
}
