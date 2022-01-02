using System;
using System.IO;
using XGBceDotNetSDK.BaseClass;
using XGBceDotNetSDK.Services.YUQING.Model;

namespace XGBceDotNetSDK.Http.Handler
{
    /// <summary>
    /// 处理舆情服务API的奇葩应答包
    /// </summary>
    public class XGBceYuqingResponseHandler: IXGHttpResponseHandler
    {
        public XGBceYuqingResponseHandler()
        {
        }
        /// <summary>
        /// 处理响应结果
        /// </summary>
        /// <param name="bceHttpResponse"></param>
        /// <param name="bceResponse"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool Handler<T>(XGBceHttpResponse bceHttpResponse, ref T bceResponse) where T : XGAbstractBceResponse
        {
            Stream content = bceHttpResponse.Content.ReadAsStreamAsync().Result;
            if (content != null)
            {
                using (StreamReader streamReader = new StreamReader(content, System.Text.Encoding.UTF8))
                {
                    if (bceHttpResponse.Content.Headers.ContentLength > 0 || (bceHttpResponse.HttpResponse.Headers.TransferEncodingChunked != null && bceHttpResponse.HttpResponse.Headers.TransferEncodingChunked.Value))
                    {
                        string metaStr = streamReader.ReadToEnd();

                        if (bceResponse is XGYuqingStringResponse stringResponse)
                            stringResponse.Result = metaStr;
                    }
                }

            }
            return true;
        }
    }
}
