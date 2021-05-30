using System;
using System.Runtime.Serialization;

namespace XGBceDotNetSDK.BaseClass
{
    [Serializable]
    public class XGBceResponseMetadata:ISerializable
    {
        private string bceRequestId;
        private string bceContentSha256;
        private string contentDisposition;
        private string transferEncoding;
        private string contentEncoding;
        private long contentLength = -1L;
        private string contentMd5;
        private string contentRange;
        private string contentType;
        private DateTime? date;
        private string eTag;
        private DateTime? expires;
        private DateTime? lastModified;
        private string server;
        private string location;
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
        public string ContentDisposition { get => contentDisposition; set => contentDisposition = value; }
        /// <summary>
        /// TransferEncoding
        /// </summary>
        public string TransferEncoding { get => transferEncoding; set => transferEncoding = value; }
        /// <summary>
        /// ContentEncoding
        /// </summary>
        public string ContentEncoding { get => contentEncoding; set => contentEncoding = value; }
        /// <summary>
        /// ContentLength
        /// </summary>
        public long ContentLength { get => contentLength; set => contentLength = value; }
        /// <summary>
        /// ContentMd5
        /// </summary>
        public string ContentMd5 { get => contentMd5; set => contentMd5 = value; }
        /// <summary>
        /// ContentRange
        /// </summary>
        public string ContentRange { get => contentRange; set => contentRange = value; }
        /// <summary>
        /// ContentType
        /// </summary>
        public string ContentType { get => contentType; set => contentType = value; }
        /// <summary>
        /// Date
        /// </summary>
        public DateTime? Date { get => date; set => date = value; }
        /// <summary>
        /// ETag
        /// </summary>
        public string ETag { get => eTag; set => eTag = value; }
        /// <summary>
        /// Expires
        /// </summary>
        public DateTime? Expires { get => expires; set => expires = value; }
        /// <summary>
        /// LastModified
        /// </summary>
        public DateTime? LastModified { get => lastModified; set => lastModified = value; }
        /// <summary>
        /// Server
        /// </summary>
        public string Server { get => server; set => server = value; }
        /// <summary>
        /// Location
        /// </summary>
        public string Location { get => location; set => location = value; }
        /// <summary>
        /// SymlinkTarget
        /// </summary>
        public string SymlinkTarget { get => symlinkTarget; set => symlinkTarget = value; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {

        }

        public override string ToString()
        {
            //return base.ToString();
            return "BceResponseMetadata [\n  bceRequestId=" + bceRequestId + ", \n  bceContentSha256=" + bceContentSha256 + ", \n  contentDisposition=" + contentDisposition + ", \n  contentEncoding=" + contentEncoding + ", \n  contentLength=" + contentLength + ", \n  contentMd5=" + contentMd5 + ", \n  contentRange=" + contentRange + ", \n  contentType=" + contentType + ", \n  date=" + date + ", \n  eTag=" + eTag + ", \n  expires=" + expires + ", \n  lastModified=" + lastModified + ", \n  server=" + server + ", \n  location=" + location + "]";

        }
    }
}
