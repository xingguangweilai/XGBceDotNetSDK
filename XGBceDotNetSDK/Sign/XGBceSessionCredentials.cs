using System;
namespace XGBceDotNetSDK.Sign
{
    public class XGBceSessionCredentials:XGBceCredentials
    {
        public string SessionToken { get; }

        public string AccessKeyId { get; }

        public string SecretKey { get; }
    }
}
