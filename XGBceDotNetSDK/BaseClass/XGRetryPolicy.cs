using System;
namespace XGBceDotNetSDK.BaseClass
{
    /// <summary>
    /// 重试策略
    /// </summary>
    public abstract class XGRetryPolicy
    {
        private int _maxErrorRetry = 3;
        private int _maxDelay = 20;

        public XGRetryPolicy(int maxErrorRetry, int maxDelay)
        {
            if (maxErrorRetry < 0)
                throw new ArgumentException("maxErrorRetry需要是个非负数");
            if (maxDelay < 0)
                throw new ArgumentException("maxDelay需要是个非负数");

            _maxErrorRetry = maxErrorRetry;
            _maxDelay = maxDelay;
        }

        /// <summary>
        /// 默认策略
        /// </summary>
        public static XGDefaultRetryPolicy DefaultRetryPolicy = new XGDefaultRetryPolicy();

        /// <summary>
        /// 获取最大错误重试次数
        /// </summary>
        /// <returns></returns>
        public int MaxErrorRetry=>_maxErrorRetry;

        /// <summary>
        /// 获取最大延迟时间
        /// </summary>
        /// <returns></returns>
        public  long MaxDelay=>_maxDelay;

        /// <summary>
        /// 下次重试间隔
        /// </summary>
        /// <param name="var1"></param>
        /// <param name="var2"></param>
        /// <returns></returns>
        public abstract long GetDelayBeforeNextRetry(XGBceClientException var1, int var2);
    }
}
