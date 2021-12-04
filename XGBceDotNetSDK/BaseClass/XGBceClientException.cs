using System;
namespace XGBceDotNetSDK.BaseClass
{
    public class XGBceClientException:Exception
    { 
        public XGBceClientException(string message) : base(message) { }

        public XGBceClientException(string message, Exception ex) : base(message, ex) { }

    }
}
