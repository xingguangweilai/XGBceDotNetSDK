using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using XGBceDotNetSDK.BaseClass;
using XGBceDotNetSDK.Services.LSS.Model;

namespace XGBceDotNetSDK.Http.Handler
{
    /// <summary>
    /// 处理音视频直播LSS响应的JSON数组
    /// </summary>
    public class XGBceLssListResponseHandler: IXGHttpResponseHandler
    {
        public XGBceLssListResponseHandler()
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

                        if (bceResponse is XGLssDomainListStreamsSourceInfoResponse DomainListStreamsSourceInfoResponse)
                        {
                            DomainListStreamsSourceInfoResponse.SourceInfoList= JsonConvert.DeserializeObject<List<XGLssDomainStreamSourceInfo>>(metaStr);
                        }
                            
                    }
                }

            }
            return true;
        }
    }
}
