using System;
using XGBceDotNetSDK.BaseClass;
using XGBceDotNetSDK.Services.VCR;
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
        }

        public void ListItems()
        {

        }
    }
}
