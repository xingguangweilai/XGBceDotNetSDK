using System;
namespace XGBceDotNetSDK.BaseClass
{
    /// <summary>
    /// 重试策略
    /// </summary>
    public abstract class XGRetryPolicy
    {
        private int maxErrorRetry = 3;
        private int maxDelayInMillis = 20000;

        /// <summary>
        /// 默认策略
        /// </summary>
        public static XGDefaultRetryPolicy DefaultRetryPolicy = new();

        public abstract int getMaxErrorRetry();

        public abstract  long getMaxDelayInMillis();

        public abstract long getDelayBeforeNextRetryInMillis(XGBceClientException var1, int var2);
    }
}
