using System;
using XGBceDotNetSDK.Sign;

namespace XGBceDotNetSDK.BaseClass
{
    public abstract class XGAbstractBceRequest
    {
        private XGBceCredentials credentials;
        public XGAbstractBceRequest()
        {
        }

        public XGBceCredentials Credentials { get => credentials; set => credentials = value; }

        public abstract XGAbstractBceRequest RequestCredentials(XGBceCredentials bceCredentials);
    }
}
