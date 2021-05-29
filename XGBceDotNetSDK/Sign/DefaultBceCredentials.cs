using System;
namespace XGBceDotNetSDK.Sign
{
    public class DefaultBceCredentials:XGBceCredentials
    {
        private readonly string accessKeyId;
        private readonly string secretKey;

        public DefaultBceCredentials(string accesskeyid, string secretkey)
        {
            accessKeyId = accesskeyid;
            secretKey = secretkey;
        }

        public string AccessKeyId => accessKeyId;

        /// <summary>
        /// 获取SecretKey
        /// </summary>
        /// <returns></returns>
        public string SecretKey => secretKey;
    }
}
