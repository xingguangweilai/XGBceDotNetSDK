using System;
namespace XGBceDotNetSDK.BaseClass
{
    public class XGBceClientException:Exception
    {
        private static long serialVersionUID = -12306000000000000L;

        public XGBceClientException(string message) : base(message) { }

        public XGBceClientException(string message, Exception ex) : base(message, ex) { }

    }
}
