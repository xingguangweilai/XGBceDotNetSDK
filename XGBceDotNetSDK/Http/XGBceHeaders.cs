using System;
namespace XGBceDotNetSDK.Http
{
    /// <summary>
    /// BCE请求头
    /// </summary>
    public class XGBceHeaders
    {

        /*
         * Standard HTTP Headers
         */
        public const string ALLOW = "Allow";

        public const string ACCEPT = "Accept";

        public const string AUTHORIZATION = "Authorization";

        public const string CACHE_CONTROL = "Cache-Control";

        public const string CONTENT_DISPOSITION = "Content-Disposition";

        public const string CONTENT_ENCODING = "Content-Encoding";

        public const string CONTENT_LENGTH = "Content-Length";

        public const string CONTENT_LANGUAGE = "Content-Language";

        public const string CONTENT_MD5 = "Content-MD5";

        public const string CONTENT_RANGE = "Content-Range";

        public const string CONTENT_TYPE = "Content-Type";

        public const string DATE = "Date";

        public const string ETAG = "ETag";

        public const string EXPIRES = "Expires";

        public const string HOST = "Host";

        public const string LAST_MODIFIED = "Last-Modified";

        public const string LOCATION = "Location";

        public const string RANGE = "Range";

        public const string SERVER = "Server";

        public const string TRANSFER_ENCODING = "Transfer-Encoding";

        public const string USER_AGENT = "User-Agent";


        /*
         * BCE Common HTTP Headers
         */

        public const string BCE_ACL = "x-bce-acl";

        public const string BCE_ACL_GRANT_READ = "x-bce-grant-read";

        public const string BCE_ACL_GRANT_FULL_CONTROL = "x-bce-grant-full-control";

        public const string BCE_CONTENT_SHA256 = "x-bce-content-sha256";

        public const string BCE_COPY_METADATA_DIRECTIVE = "x-bce-metadata-directive";

        public const string BCE_COPY_SOURCE_IF_MATCH = "x-bce-copy-source-if-match";

        public const string BCE_DATE = "x-bce-date";

        public const string BCE_PREFIX = "x-bce-";

        public const string BCE_REQUEST_ID = "x-bce-request-id";

        public const string BCE_SECURITY_TOKEN = "x-bce-security-token";

        public const string BCE_USER_METADATA_PREFIX = "x-bce-meta-";

        public const string BCE_CONTENT_CRC32 = "x-bce-content-crc32";

        /*
         * BOS HTTP Headers
         */

        public const string BCE_COPY_SOURCE = "x-bce-copy-source";

        public const string BCE_COPY_SOURCE_RANGE = "x-bce-copy-source-range";

        public const string BCE_COPY_SOURCE_IF_MODIFIED_SINCE = "x-bce-copy-source-if-modified-since";

        public const string BCE_COPY_SOURCE_IF_NONE_MATCH = "x-bce-copy-source-if-none-match";

        public const string BCE_COPY_SOURCE_IF_UNMODIFIED_SINCE = "x-bce-copy-source-if-unmodified-since";

        public const string BCE_FETCH_SOURCE = "x-bce-fetch-source";

        public const string BCE_FETCH_MODE = "x-bce-fetch-mode";

        public const string BCE_DEBUG_ID = "x-bce-debug-id";

        public const string BCE_NEXT_APPEND_OFFSET = "x-bce-next-append-offset";

        public const string BCE_OBJECT_TYPE = "x-bce-object-type";

        public const string BCE_STORAGE_CLASS = "x-bce-storage-class";

        public const string BCE_RESTORE_TIER = "x-bce-restore-tier";

        public const string BCE_RESTORE_DAYS = "x-bce-restore-days";

        public const string BCE_SYMLINK_TARGET = "x-bce-symlink-target";

        public const string BCE_FORBID_OVERWRITE = "x-bce-forbid-overwrite";

        public const string BCE_RESTORE = "x-bce-restore";
        /*
         * CFC HTTP Headers
         */

        public const string BCE_LOG_RESULT = "X-Bce-Log-Result";
    }
}
