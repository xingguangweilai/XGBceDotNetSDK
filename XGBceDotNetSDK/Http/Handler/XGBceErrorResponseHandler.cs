using System;
using System.IO;
using Newtonsoft.Json;
using XGBceDotNetSDK.BaseClass;

namespace XGBceDotNetSDK.Http.Handler
{
    public class XGBceErrorResponseHandler:IXGHttpResponseHandler
    {
        public XGBceErrorResponseHandler()
        {
        }

        /// <summary>X
        /// 处理响应
        /// </summary>
        /// <param name="bceHttpResponse"></param>
        /// <param name="bceResponse"></param>
        /// <returns></returns>
        /// <exception cref="XGBceServiceException"></exception>
        public bool Handler<T>(XGBceHttpResponse bceHttpResponse,ref T bceResponse) where T:XGAbstractBceResponse
        {
            if (bceHttpResponse.StatusCode / 100 == 2)
                return false;
            else
            {
                XGBceServiceException bceServiceException = null;
                Stream content = bceHttpResponse.Content.ReadAsStreamAsync().Result;
                
                if (content != null)
                {
                    using (StreamReader streamReader = new StreamReader(content, System.Text.Encoding.UTF8))
                    {
                        if (streamReader != null)
                        {
                            XGBceErrorResponse bceErrorResponse = JsonConvert.DeserializeObject<XGBceErrorResponse>(streamReader.ReadToEnd());
                            if (bceErrorResponse!=null&&bceErrorResponse.Message != null)
                            {
                                bceServiceException = new XGBceServiceException(bceErrorResponse.Message)
                                {
                                    ErrorCode = bceErrorResponse.Code,
                                    RequestId = bceErrorResponse.RequestId
                                };
                            }
                            content.Close();
                        }
                    }

                }

                if (bceServiceException == null)
                {
                    bceServiceException = new XGBceServiceException(bceHttpResponse.StatusText)
                    {
                        RequestId = bceResponse.Metadata.BceRequestId
                    };
                }

                bceServiceException.StatusCode = bceHttpResponse.StatusCode;
                if (bceServiceException.StatusCode >= 500)
                {
                    bceServiceException.ErrorType = XGBceErrorType.Service;
                }
                else
                {
                    bceServiceException.ErrorType = XGBceErrorType.Client;
                }

                throw bceServiceException;
            }
        }
    }
}
