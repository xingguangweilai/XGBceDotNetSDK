using System;
using System.Collections.Generic;

namespace XGBceDotNetSDK.Sign
{
    /// <summary>
    /// 签名配置
    /// </summary>
    public class BceSignOption
    {
        /// <summary>
        /// </summary>
        public static readonly int DEFAULT_EXPIRATION_IN_SECONDS = 1800;
        private DateTime? timeStamp=null;
        private int expirationPeriodInSeconds= DEFAULT_EXPIRATION_IN_SECONDS;
        private List<string> headersToSign=null;

        public readonly static BceSignOption defaultBceSignOption = new BceSignOption() { timeStamp=DateTime.Now};

        public BceSignOption()
        {
        }

        /// <summary>
        /// 时间戳
        /// </summary>
        public DateTime? TimeStamp { get => timeStamp; set => timeStamp = value; }
        /// <summary>
        /// 过期时间
        /// </summary>
        public int ExpirationPeriodInSeconds { get => expirationPeriodInSeconds; set => expirationPeriodInSeconds = value; }
        /// <summary>
        /// 待签名请求头
        /// </summary>
        public List<string> HeadersToSign { get => headersToSign; set => headersToSign = value; }
    }
}
