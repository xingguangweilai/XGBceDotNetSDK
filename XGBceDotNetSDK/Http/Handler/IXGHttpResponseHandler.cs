using System;
using XGBceDotNetSDK.BaseClass;

namespace XGBceDotNetSDK.Http.Handler
{
    public interface IXGHttpResponseHandler
    {
        /// <summary>
        /// 处理响应对象
        /// </summary>
        /// <param name="bceHttpResponse"></param>
        /// <param name="bceResponse"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        bool Handler<T>(XGBceHttpResponse bceHttpResponse,ref T bceResponse) where T : XGAbstractBceResponse;

    }
}
