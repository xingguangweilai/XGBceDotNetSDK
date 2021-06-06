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
        public bool Handler(XGBceHttpResponse bceHttpResponse, XGAbstractBceResponse bceResponse)
        {
            XGBceResponseMetadata metadata = bceResponse.Metadata;
            metadata.BceRequestId = bceHttpResponse.GetHeader("x-bce-request-id");
            metadata.BceContentSha256 = bceHttpResponse.GetHeader("x-bce-content-sha256");
            metadata.ContentDisposition = bceHttpResponse.GetHeader("Content-Disposition");
            metadata.ContentEncoding = bceHttpResponse.HttpResponse.ContentEncoding;
            metadata.ContentLength = bceHttpResponse.HttpResponse.ContentLength;
            metadata.ContentType = bceHttpResponse.HttpResponse.ContentType;
            metadata.ContentMd5 = bceHttpResponse.GetHeader("Content-MD5");
            metadata.ContentRange = bceHttpResponse.GetHeader("Content-Range");
            metadata.Date = bceHttpResponse.GetHeaderAsRfc822Date("Date");
            metadata.TransferEncoding = bceHttpResponse.GetHeader("Transfer-Encoding");
            metadata.SymlinkTarget = bceHttpResponse.GetHeader("x-bce-symlink-target");
            string eTag = bceHttpResponse.GetHeader("ETag");
            if (eTag != null)
            {
                //TODO
                //metadata.setETag(CharMatcher.is ('"').trimFrom(eTag));
                metadata.ETag = eTag.Trim('"');
            }
            //TODO 日期格式化
            metadata.Expires = bceHttpResponse.GetHeaderAsRfc822Date("Expires");
            metadata.LastModified = bceHttpResponse.HttpResponse.LastModified;
            metadata.Server = bceHttpResponse.HttpResponse.Server;

            return false;
        }
    }
}
