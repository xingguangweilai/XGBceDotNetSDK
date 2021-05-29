using System;
namespace XGBceDotNetSDK.Sign
{
    public interface XGBceCredentials
    {
        /// <summary>
        /// 获取AccessKeyId
        /// </summary>
        /// <returns></returns>
        string AccessKeyId { get; }

        /// <summary>
        /// 获取SecretKey
        /// </summary>
        /// <returns></returns>
        string SecretKey { get; }
    }
}
