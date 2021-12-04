using System;
using XGBceDotNetSDK.BaseClass;

namespace XGBceDotNetSDK.Sign
{
    public interface IXGBceSigner
    {
        void Sign(XGBceIternalRequest request, XGBceCredentials credentials);
    }
}
