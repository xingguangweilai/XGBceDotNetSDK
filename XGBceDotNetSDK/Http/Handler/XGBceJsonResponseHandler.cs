using System;
using System.IO;
using Newtonsoft.Json;
using XGBceDotNetSDK.BaseClass;

namespace XGBceDotNetSDK.Http.Handler
{
    public class XGBceJsonResponseHandler:IXGHttpResponseHandler
    {
        public XGBceJsonResponseHandler()
        {
        }
        /// <summary>
        /// Handler
        /// </summary>
        /// <param name="bceHttpResponse"></param>
        /// <param name="bceResponse"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool Handler(XGBceHttpResponse bceHttpResponse,XGAbstractBceResponse bceResponse)
        {
            Stream content = bceHttpResponse.Content;
            if (content != null)
            {
                using (StreamReader streamReader = new StreamReader(content, System.Text.Encoding.UTF8))
                {
                    if(bceResponse.Metadata.ContentLength>0|| "chunked".Equals(bceResponse.Metadata.TransferEncoding))
                    {
                        //TODO 处理bceResponse更新问题
                        bceResponse = JsonConvert.DeserializeObject<XGAbstractBceResponse>(streamReader.ReadToEnd());
                    }
                }
            }
            return true;
        }
    }
}
