using System;
using Newtonsoft.Json;
using XGBceDotNetSDK.Sign;

namespace XGBceDotNetSDK.BaseClass
{
    public abstract class XGAbstractBceRequest
    {
        private XGBceCredentials credentials;
        public XGAbstractBceRequest()
        {
        }

        [JsonIgnore]
        public XGBceCredentials Credentials { get => credentials; set => credentials = value; }

    }
}
