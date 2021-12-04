using System;
using XGBceDotNetSDK.Utils;

namespace XGBceDotNetSDK.BaseClass
{
    /// <summary>
    /// 默认重试策略
    /// </summary>
    public class XGDefaultRetryPolicy:XGRetryPolicy
    {
        private XGBceLog logger = XGBceLog.GetLog();
        public XGDefaultRetryPolicy() : this(3,20)
        {
        }

        public XGDefaultRetryPolicy(int maxErrorRetry,int maxDelay):base(maxErrorRetry,maxDelay)
        {
        }

        public override long GetDelayBeforeNextRetry(XGBceClientException var1, int var2)
        {
            if (!ShouldRetry(var1, var2))
            {
                return -1;
            }
            return var2 < 0 ? 0 : (1 << var2 + 1)*2;
        }

        protected bool ShouldRetry(XGBceClientException exception, int retriesAttempted)
        {
            if(exception is XGBceServiceException serviceException)
            {
                if (serviceException.StatusCode == 500)
                {
                    logger.Debug(GetType().ToString(), "内部服务器错误，重试.");
                    return true;
                }else if (serviceException.StatusCode == 502)
                {
                    logger.Debug(GetType().ToString(), "网关错误，重试.");
                    return true;
                }else if (serviceException.StatusCode == 503)
                {
                    logger.Debug(GetType().ToString(), "服务不可用，重试.");
                    return true;
                }
            }
            return false;
        }
    }
}
