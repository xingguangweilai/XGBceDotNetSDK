using System;
namespace XGBceDotNetSDK.Sign
{
    /// <summary>
    /// 默认凭证类
    /// </summary>
    public class XGBceDefaultBceCredentials : XGBceCredentials
    {
        private readonly string accessKeyId;
        private readonly string secretKey;

        public XGBceDefaultBceCredentials(string accesskeyid, string secretkey)
        {
            if (string.IsNullOrEmpty(accesskeyid))
                throw new ArgumentNullException(nameof(accesskeyid), "accesskeyid 不能为空");
            if (string.IsNullOrEmpty(secretkey))
                throw new ArgumentNullException(nameof(secretkey), "secretkey 不能为空");
            accessKeyId = accesskeyid;
            secretKey = secretkey;
        }

        /// <summary>
        /// 获取AccessKeyId
        /// </summary>
        /// <returns></returns>
        public string AccessKeyId => accessKeyId;

        /// <summary>
        /// 获取SecretKey
        /// </summary>
        /// <returns></returns>
        public string SecretKey => secretKey;
    }
}
