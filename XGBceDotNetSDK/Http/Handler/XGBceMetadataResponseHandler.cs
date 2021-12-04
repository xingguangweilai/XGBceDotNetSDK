using System;
using XGBceDotNetSDK.BaseClass;

namespace XGBceDotNetSDK.Http.Handler
{
    public class XGBceMetadataResponseHandler:IXGHttpResponseHandler
    {
        public XGBceMetadataResponseHandler()
        {
        }

        /// <summary>
        /// 转换
        /// </summary>
        /// <param name="bceHttpResponse"></param>
        /// <param name="bceResponse"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool Handler<T>(XGBceHttpResponse bceHttpResponse,ref T bceResponse) where T: XGAbstractBceResponse
        {
            XGBceResponseMetadata metadata = bceResponse.Metadata;
            metadata.BceRequestId = bceHttpResponse.GetHeader("x-bce-request-id");
            metadata.BceContentSha256 = bceHttpResponse.GetHeader("x-bce-content-sha256");
            metadata.ContentDisposition = bceHttpResponse.Content.Headers.ContentDisposition;
            metadata.ContentEncoding = bceHttpResponse.Content.Headers.ContentEncoding;
            metadata.ContentLength = bceHttpResponse.Content.Headers.ContentLength;
            metadata.ContentType = bceHttpResponse.Content.Headers.ContentType;
            metadata.ContentMd5 = bceHttpResponse.Content.Headers.ContentMD5;
            metadata.ContentRange = bceHttpResponse.Content.Headers.ContentRange;
            //metadata.Date = bceHttpResponse.GetHeaderAsRfc822Date("Date");
            metadata.Date = bceHttpResponse.HttpResponse.Headers.Date;
            metadata.TransferEncoding = bceHttpResponse.HttpResponse.Headers.TransferEncoding;
            metadata.SymlinkTarget = bceHttpResponse.GetHeader("x-bce-symlink-target");
            metadata.ETag = bceHttpResponse.HttpResponse.Headers.ETag;
            //TODO 日期格式化
            metadata.Expires = bceHttpResponse.Content.Headers.Expires;
            metadata.LastModified = bceHttpResponse.Content.Headers.LastModified;
            metadata.Server = bceHttpResponse.HttpResponse.Headers.Server;

            return false;
        }
    }
}
