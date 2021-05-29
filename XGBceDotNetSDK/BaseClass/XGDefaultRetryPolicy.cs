using System;
namespace XGBceDotNetSDK.BaseClass
{
    public class XGDefaultRetryPolicy:XGRetryPolicy
    {
        public XGDefaultRetryPolicy()
        {
        }

        public override int getMaxErrorRetry()
        {
            return 0;
        }

        public override long getMaxDelayInMillis()
        {
            return 0;
        }

        public override long getDelayBeforeNextRetryInMillis(XGBceClientException var1, int var2)
        {
            return 0;
        }
    }
}
