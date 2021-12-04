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
        public bool Handler<T>(XGBceHttpResponse bceHttpResponse,ref T bceResponse) where T:XGAbstractBceResponse
        {
            Stream content = bceHttpResponse.Content.ReadAsStreamAsync().Result;
            if (content != null)
            {
                using (StreamReader streamReader = new StreamReader(content, System.Text.Encoding.UTF8))
                {
                    if (bceHttpResponse.Content.Headers.ContentLength > 0 || (bceHttpResponse.HttpResponse.Headers.TransferEncodingChunked!=null&&bceHttpResponse.HttpResponse.Headers.TransferEncodingChunked.Value))
                    {
                        string metaStr = streamReader.ReadToEnd();
                        //TODO 处理bceResponse更新问题
                        bceResponse = JsonConvert.DeserializeObject<T>(metaStr);
                    }
                }

                XGBceResponseMetadata metadata = bceResponse.Metadata;
                metadata.BceRequestId = bceHttpResponse.GetHeader(XGBceHeaders.BCE_REQUEST_ID);
                metadata.BceContentSha256 = bceHttpResponse.GetHeader(XGBceHeaders.BCE_CONTENT_SHA256);
                metadata.ContentDisposition = bceHttpResponse.Content.Headers.ContentDisposition;
                metadata.ContentEncoding = bceHttpResponse.Content.Headers.ContentEncoding;
                metadata.ContentLength = bceHttpResponse.Content.Headers.ContentLength;
                metadata.ContentType = bceHttpResponse.Content.Headers.ContentType;
                metadata.ContentMd5 = bceHttpResponse.Content.Headers.ContentMD5;
                metadata.ContentRange = bceHttpResponse.Content.Headers.ContentRange;
                metadata.Date = bceHttpResponse.HttpResponse.Headers.Date;
                metadata.TransferEncoding = bceHttpResponse.HttpResponse.Headers.TransferEncoding;
                metadata.SymlinkTarget = bceHttpResponse.GetHeader(XGBceHeaders.BCE_SYMLINK_TARGET);
                metadata.ETag = bceHttpResponse.HttpResponse.Headers.ETag;
                metadata.Expires = bceHttpResponse.Content.Headers.Expires;
                metadata.LastModified = bceHttpResponse.Content.Headers.LastModified;
                metadata.Server = bceHttpResponse.HttpResponse.Headers.Server;

            }
            return true;
        }
    }
}
