using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Runtime.Serialization;

namespace XGBceDotNetSDK.BaseClass
{
    [Serializable]
    public class XGBceResponseMetadata:ISerializable
    {
        private string bceRequestId;
        private string bceContentSha256;
        private ContentDispositionHeaderValue contentDisposition;
        private HttpHeaderValueCollection<TransferCodingHeaderValue> transferEncoding;
        private ICollection<string> contentEncoding;
        private long? contentLength = -1L;
        private byte[] contentMd5;
        private ContentRangeHeaderValue contentRange;
        private MediaTypeHeaderValue contentType;
        private DateTimeOffset? date;
        private EntityTagHeaderValue eTag;
        private DateTimeOffset? expires;
        private DateTimeOffset? lastModified;
        private HttpHeaderValueCollection<ProductInfoHeaderValue> server;
        private Uri location;
        private string symlinkTarget;
        public XGBceResponseMetadata()
        {
        }

        public XGBceResponseMetadata(SerializationInfo info,StreamingContext context)
        {

        }

        /// <summary>
        /// RequestId
        /// </summary>
        public string BceRequestId { get => bceRequestId; set => bceRequestId = value; }
        /// <summary>
        /// ContentSha256
        /// </summary>
        public string BceContentSha256 { get => bceContentSha256; set => bceContentSha256 = value; }
        /// <summary>
        /// ContentDisposition
        /// </summary>
        public ContentDispositionHeaderValue ContentDisposition { get => contentDisposition; set => contentDisposition = value; }
        /// <summary>
        /// TransferEncoding
        /// </summary>
        public HttpHeaderValueCollection<TransferCodingHeaderValue> TransferEncoding { get => transferEncoding; set => transferEncoding = value; }
        /// <summary>
        /// ContentEncoding
        /// </summary>
        public ICollection<string> ContentEncoding { get => contentEncoding; set => contentEncoding = value; }
        /// <summary>
        /// ContentLength
        /// </summary>
        public long? ContentLength { get => contentLength; set => contentLength = value; }
        /// <summary>
        /// ContentMd5
        /// </summary>
        public byte[] ContentMd5 { get => contentMd5; set => contentMd5 = value; }
        /// <summary>
        /// ContentRange
        /// </summary>
        public ContentRangeHeaderValue ContentRange { get => contentRange; set => contentRange = value; }
        /// <summary>
        /// ContentType
        /// </summary>
        public MediaTypeHeaderValue ContentType { get => contentType; set => contentType = value; }
        /// <summary>
        /// Date
        /// </summary>
        public DateTimeOffset? Date { get => date; set => date = value; }
        /// <summary>
        /// ETag
        /// </summary>
        public EntityTagHeaderValue ETag { get => eTag; set => eTag = value; }
        /// <summary>
        /// Expires
        /// </summary>
        public DateTimeOffset? Expires { get => expires; set => expires = value; }
        /// <summary>
        /// LastModified
        /// </summary>
        public DateTimeOffset? LastModified { get => lastModified; set => lastModified = value; }
        /// <summary>
        /// Server
        /// </summary>
        public HttpHeaderValueCollection<ProductInfoHeaderValue> Server { get => server; set => server = value; }
        /// <summary>
        /// Location
        /// </summary>
        public Uri Location { get => location; set => location = value; }
        /// <summary>
        /// SymlinkTarget
        /// </summary>
        public string SymlinkTarget { get => symlinkTarget; set => symlinkTarget = value; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {

        }

        public override string ToString()
        {
            return "BceResponseMetadata [\n  bceRequestId=" + bceRequestId + ", \n  bceContentSha256=" + bceContentSha256 + ", \n  contentDisposition=" + contentDisposition + ", \n  contentEncoding=" + contentEncoding + ", \n  contentLength=" + contentLength + ", \n  contentMd5=" + contentMd5 + ", \n  contentRange=" + contentRange + ", \n  contentType=" + contentType + ", \n  date=" + date + ", \n  eTag=" + eTag + ", \n  expires=" + expires + ", \n  lastModified=" + lastModified + ", \n  server=" + server + ", \n  location=" + location + "]";

        }
    }
}
