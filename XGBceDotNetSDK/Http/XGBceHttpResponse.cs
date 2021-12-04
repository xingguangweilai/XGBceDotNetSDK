using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using XGBceDotNetSDK.Utils;

namespace XGBceDotNetSDK.Http
{
    public class XGBceHttpResponse
    {
        private readonly HttpResponseMessage _httpResponse;
        private readonly HttpContent _content;
        private Dictionary<string, string> _headers;
        public XGBceHttpResponse() { }

        #region HttpResponseHeaders
        private HttpHeaderValueCollection<string> acceptRanges;
        private TimeSpan? age;
        private CacheControlHeaderValue cacheControl;
        private HttpHeaderValueCollection<string> connection;
        private bool? connectionClose;
        private DateTimeOffset? date;
        private EntityTagHeaderValue eTag;
        private Uri location;
        private HttpHeaderValueCollection<NameValueHeaderValue> pragma;
        private HttpHeaderValueCollection<AuthenticationHeaderValue> proxyAuthenticate;
        private RetryConditionHeaderValue retryAfter;
        private HttpHeaderValueCollection<ProductInfoHeaderValue> server;
        private HttpHeaderValueCollection<string> trailer;
        private HttpHeaderValueCollection<TransferCodingHeaderValue> transferEncoding;
        private bool? transferEncodingChunked;
        private HttpHeaderValueCollection<ProductHeaderValue> upgrade;
        private HttpHeaderValueCollection<string> vary;
        private HttpHeaderValueCollection<ViaHeaderValue> via;
        private HttpHeaderValueCollection<WarningHeaderValue> warning;
        private HttpHeaderValueCollection<AuthenticationHeaderValue> wwwAuthenticate;
        #endregion

        /// <summary>
        /// XGBceHttpResponse
        /// </summary>
        /// <param name="HttpResponseMessage"></param>
        /// <exception cref="IOException"></exception>
        public XGBceHttpResponse(HttpResponseMessage httpResponse)
        {
            _httpResponse = httpResponse;
            _content = httpResponse.Content;

            //字典忽略大小写
            Dictionary<string, string> headers = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            IEnumerator<KeyValuePair<string, IEnumerable<string>>> enumeratorheaderN = _httpResponse.Headers.GetEnumerator();
            while (enumeratorheaderN.MoveNext())
            {
                KeyValuePair<string, IEnumerable<string>> kvp = enumeratorheaderN.Current;

                string headerv = "";
                IEnumerator<string> iString = kvp.Value.GetEnumerator();
                while (iString.MoveNext())
                {
                    headerv += iString.Current + ";";
                }
                if (headerv.EndsWith(";"))
                    headerv= headerv.Remove(headerv.Length-1);

                headers.Add(kvp.Key, headerv);
            }
            _headers = headers;

        }

        public HttpResponseMessage HttpResponse { get => _httpResponse;  }
        public HttpContent Content { get => _content;}

        /// <summary>
        /// 状态描述
        /// </summary>
        public string StatusText { get => HttpResponse.ReasonPhrase; }
        /// <summary>
        /// 状态码
        /// </summary>
        public int StatusCode { get => (int)HttpResponse.StatusCode; }
        /// <summary>
        /// 请求头
        /// </summary>
        public Dictionary<string,string> Headers
        {
            get=>_headers;
        }

        public string GetHeader(string name)
        {
            return _headers.ContainsKey(name) ? _headers[name]:null;
        }

        public long GetHeaderAsLong(string name)
        {
            string value = GetHeader(name);
            if (value == null)
                return -1L;
            else
            {
                try
                {
                    return long.Parse(value);
                }
                catch
                {
                    //TODO  日志
                    return -1;
                }
            }
        }

        public DateTime? GetHeaderAsRfc822Date(string dateStr)
        {
            string value = GetHeader(dateStr);
            if (value == null)
                return null;
            else
            {
                try
                {
                    return XGDateUtils.ParseRfc822Date(dateStr);
                }
                catch
                {
                    //TODO
                    Console.WriteLine(dateStr+"："+value + " 无效");
                    return null;
                }
            }
        }

        #region HttpResponseHeaders 属性
        public HttpHeaderValueCollection<string> AcceptRanges { get => acceptRanges; set => acceptRanges = value; }
        public TimeSpan? Age { get => age; set => age = value; }
        public CacheControlHeaderValue CacheControl { get => cacheControl; set => cacheControl = value; }
        public HttpHeaderValueCollection<string> Connection { get => connection; set => connection = value; }
        public bool? ConnectionClose { get => connectionClose; set => connectionClose = value; }
        public DateTimeOffset? Date { get => date; set => date = value; }
        public EntityTagHeaderValue ETag { get => eTag; set => eTag = value; }
        public Uri Location { get => location; set => location = value; }
        public HttpHeaderValueCollection<NameValueHeaderValue> Pragma { get => pragma; set => pragma = value; }
        public HttpHeaderValueCollection<AuthenticationHeaderValue> ProxyAuthenticate { get => proxyAuthenticate; set => proxyAuthenticate = value; }
        public RetryConditionHeaderValue RetryAfter { get => retryAfter; set => retryAfter = value; }
        public HttpHeaderValueCollection<ProductInfoHeaderValue> Server { get => server; set => server = value; }
        public HttpHeaderValueCollection<string> Trailer { get => trailer; set => trailer = value; }
        public HttpHeaderValueCollection<TransferCodingHeaderValue> TransferEncoding { get => transferEncoding; set => transferEncoding = value; }
        public bool? TransferEncodingChunked { get => transferEncodingChunked; set => transferEncodingChunked = value; }
        public HttpHeaderValueCollection<ProductHeaderValue> Upgrade { get => upgrade; set => upgrade = value; }
        public HttpHeaderValueCollection<string> Vary { get => vary; set => vary = value; }
        public HttpHeaderValueCollection<ViaHeaderValue> Via { get => via; set => via = value; }
        public HttpHeaderValueCollection<WarningHeaderValue> Warning { get => warning; set => warning = value; }
        public HttpHeaderValueCollection<AuthenticationHeaderValue> WwwAuthenticate { get => wwwAuthenticate; set => wwwAuthenticate = value; }


        #endregion
    }
}
