using System;
using XGBceDotNetSDK.BaseClass;
using XGBceDotNetSDK.Services.VCR;
using XGBceDotNetSDK.Services.VCR.Model;
using XGBceDotNetSDK.Sign;

namespace XGBceDotNetSDKDemo.Example
{
    public class VcrExample
    {
        private static string access_key_id = @"";
        private static string secret_access_key = @"";
        public VcrExample()
        {
            XGBceClientConfiguration vcrClientConfiguration = new XGBceClientConfiguration()
            {
                Credentials = new XGBceDefaultBceCredentials(access_key_id, secret_access_key),
                Endpoint = "vcr.bj.baidubce.com"
            };

            XGVcrClient vcrClient = new XGVcrClient(vcrClientConfiguration);
            try
            {
                XGVcrResponse response= vcrClient.AddFaceLibBriefImage("abc123", "","name0");
                Console.WriteLine("face添加成功");
            }
            catch(Exception ex)
            {
                Console.WriteLine("face添加失败：" + ex.Message);
            }
        }

        public void ListItems()
        {

        }
    }
}
