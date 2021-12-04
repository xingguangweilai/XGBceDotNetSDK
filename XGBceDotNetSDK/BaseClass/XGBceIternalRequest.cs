using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using XGBceDotNetSDK.Http;
using XGBceDotNetSDK.Sign;
using XGBceDotNetSDK.Utils;

namespace XGBceDotNetSDK.BaseClass
{
    public class XGBceIternalRequest
    {
        private Dictionary<string, string> parameters = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        //除了requestHeaders以外的请求头
        private Dictionary<string, string> moreHeaders = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        ////字典忽略大小写
        private Dictionary<string, string> headers = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        private HttpRequestHeaders requestHeaders;
        private string host;
        private Uri _uri;
        private BceHttpMethod _httpMethod;
        private HttpContent content;
        private XGBceCredentials credentials;
        private BceSignOption signOptions;
        private bool expectContinueEnabled;

        #region HttpRequestHeaders
        private HttpHeaderValueCollection<MediaTypeWithQualityHeaderValue> accept;
        private HttpHeaderValueCollection<StringWithQualityHeaderValue> acceptCharset;
        private HttpHeaderValueCollection<StringWithQualityHeaderValue> acceptEncoding;
        private HttpHeaderValueCollection<StringWithQualityHeaderValue> acceptLanguage;
        private CacheControlHeaderValue cacheControl;
        private HttpHeaderValueCollection<string> connection;
        private bool? connectionClose;
        private HttpHeaderValueCollection<NameValueWithParametersHeaderValue> expect;
        private bool? expectContinue;
        private string from;
        private HttpHeaderValueCollection<EntityTagHeaderValue> ifMatch;
        private DateTimeOffset? ifModifiedSince;
        private DateTimeOffset? date;
        private HttpHeaderValueCollection<EntityTagHeaderValue> ifNoneMatch;
        private RangeConditionHeaderValue ifRange;
        private HttpHeaderValueCollection<NameValueHeaderValue> pragma;
        private RangeHeaderValue range;
        private Uri referrer;
        private HttpHeaderValueCollection<TransferCodingHeaderValue> transferEncoding;
        private bool? transferEncodingChunked;
        private HttpHeaderValueCollection<ProductHeaderValue> upgrade;
        private HttpHeaderValueCollection<ProductInfoHeaderValue> userAgent;
        private HttpHeaderValueCollection<ViaHeaderValue> via;
        private HttpHeaderValueCollection<WarningHeaderValue> warning;
        #endregion


        #region 默认
        public XGBceIternalRequest(BceHttpMethod httpMethod,Uri uri):this(httpMethod,uri,null) {}

        /// <summary>
        /// 使用HttpContent初始化
        /// </summary>
        /// <param name="httpMethod"></param>
        /// <param name="uri"></param>
        /// <param name="httpContent"></param>
        public XGBceIternalRequest(BceHttpMethod httpMethod, Uri uri, HttpContent httpContent)
        {
            HttpMethod = httpMethod;
            Uri = uri;
            if (httpContent == null)
                content = new StringContent("");
            else
                content = httpContent;

            content.Headers.ContentType= new MediaTypeHeaderValue(mediaType: "application/json") { CharSet = "utf-8" };
        }
        /// <summary>
        /// 请求方法
        /// </summary>
        public BceHttpMethod HttpMethod { get => _httpMethod; set => _httpMethod = value; }
        /// <summary>
        /// Uri
        /// </summary>
        public Uri Uri { get => _uri; set
            {
                _uri = value;
                if (value != null)
                {
                    host = _uri.Host;
                    //Headers.Add(IXGBceHeaders.HOST, host);
                }

            } }
        /// <summary>
        /// 凭证
        /// </summary>
        public XGBceCredentials Credentials { get => credentials; set => credentials = value; }
        /// <summary>
        /// 签名配置
        /// </summary>
        public BceSignOption SignOptions { get => signOptions; set
            {
                signOptions = value;
            }
        }
        public string Host { get => host; set
            {
                host = value;
                if (Headers.ContainsKey(XGBceHeaders.HOST))
                {
                    Headers[XGBceHeaders.HOST] = value;
                }
                else
                {
                    Headers.Add(XGBceHeaders.HOST,value);
                }
            } }
        /// <summary>
        /// 请求参数
        /// </summary>
        public Dictionary<string, string> Parameters { get => parameters; set {
                parameters.Clear();
                if(value!=null)
                    foreach (KeyValuePair<string, string> kvp in value)
                    {
                        parameters.Add(kvp.Key.Trim(), kvp.Value.Trim());
                    }
            } }
        public HttpContent Content { get => content; set => content = value; }
        public HttpRequestHeaders RequestHeaders { get => requestHeaders; set => requestHeaders = value; }
        /// <summary>
        /// 发生异常后是否继续
        /// </summary>
        public bool ExpectContinueEnabled { get => expectContinueEnabled; set => expectContinueEnabled = value; }

        public string GetHttpMethodString()
        {
            return HttpUtil.BceHttpMethodToString(_httpMethod);
        }

        /// <summary>
        /// 添加请求参数
        /// </summary>
        /// <param name="name">key</param>
        /// <param name="value">value</param>
        public void AddParameter(string name,string value=null)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
                return;
            if (Parameters.ContainsKey(name.Trim()))
            {
                Parameters[name.Trim()] = value ?? "";
            }
            else
            {
                Parameters.Add(name, value);
            }
        }

        public Dictionary<string, string> MoreHeaders { get => moreHeaders; }

        /// <summary>
        /// 添加请求头
        /// </summary>
        /// <param name="name">请求头名称</param>
        /// <param name="value">值</param>
        public void AddMoreHeader(string name,string value)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
                return;

            if (MoreHeaders.ContainsKey(name.Trim()))
            {
                MoreHeaders[name.Trim()] = value ?? "";
            }
            else
            {
                MoreHeaders.Add(name, value);
            }

            if (Headers.ContainsKey(name))
                headers[name] = value;
            else
                headers.Add(name,value);
        }
        #endregion

        /// <summary>
        /// 获取所有请求头
        /// </summary>
        public Dictionary<string, string> Headers {get { if (headers == null) headers = new Dictionary<string, string>();
                //if (content != null)
                //{
                //    if (content.Headers.ContentType != null)
                //        headers[XGBceHeaders.CONTENT_TYPE] = content.Headers.ContentType.ToString();
                //    if (content.Headers.ContentLength != null)
                //        headers[XGBceHeaders.CONTENT_LENGTH] = content.Headers.ContentLength.ToString();
                //    if (content.Headers.ContentMD5 != null)
                //        headers[XGBceHeaders.CONTENT_MD5] = content.Headers.ContentMD5.ToString();
                //}
                if (date != null)
                    headers[XGBceHeaders.DATE] = date.Value.ToString("R");
                if (content != null)
                {
                    if (content.Headers.ContentLength != null) { }  //不知道为啥需要获取下ContentLength才能在GetEnumerator中遍历到
                    IEnumerator<KeyValuePair<string, IEnumerable<string>>> contentHeaders = content.Headers.GetEnumerator();
                    while (contentHeaders.MoveNext())
                    {
                        KeyValuePair<string, IEnumerable<string>> kvp = contentHeaders.Current;
                        headers[kvp.Key] = string.Join(";", kvp.Value);
                    }
                }

                return headers;
            }
        }

        #region HttpRequestHeaders属性
        public HttpHeaderValueCollection<MediaTypeWithQualityHeaderValue> Accept { get => accept; set {
                accept = value;
                IEnumerator<MediaTypeWithQualityHeaderValue> enumeratorAccept = value.GetEnumerator();
                while (enumeratorAccept.MoveNext())
                {
                    MediaTypeWithQualityHeaderValue headerValue = enumeratorAccept.Current;
#warning Accept
                }
            } }
        public HttpHeaderValueCollection<StringWithQualityHeaderValue> AcceptCharset { get => acceptCharset; set {
                acceptCharset = value;
                IEnumerator<StringWithQualityHeaderValue> enumeratorAcceptCharset = value.GetEnumerator();
                string acceptCharsetStr = "";
                while (enumeratorAcceptCharset.MoveNext())
                {
                    StringWithQualityHeaderValue headerValue = enumeratorAcceptCharset.Current;
                    acceptCharsetStr += headerValue.Value + ",";
                }
                acceptCharsetStr = acceptCharsetStr.EndsWith(",") ? acceptCharsetStr.Remove(acceptCharsetStr.Length - 1) : acceptCharsetStr;
#warning AcceptCharset
            }
        }
        public HttpHeaderValueCollection<StringWithQualityHeaderValue> AcceptEncoding { get => acceptEncoding; set => acceptEncoding = value; }
        public HttpHeaderValueCollection<StringWithQualityHeaderValue> AcceptLanguage { get => acceptLanguage; set => acceptLanguage = value; }
        public CacheControlHeaderValue CacheControl { get => cacheControl; set => cacheControl = value; }
        public HttpHeaderValueCollection<string> Connection { get => connection; set => connection = value; }
        public bool? ConnectionClose { get => connectionClose; set => connectionClose = value; }
        public HttpHeaderValueCollection<NameValueWithParametersHeaderValue> Expect { get => expect; set => expect = value; }
        public bool? ExpectContinue { get => expectContinue; set => expectContinue = value; }
        public string From { get => from; set => from = value; }
        public HttpHeaderValueCollection<EntityTagHeaderValue> IfMatch { get => ifMatch; set => ifMatch = value; }
        public DateTimeOffset? IfModifiedSince { get => ifModifiedSince; set => ifModifiedSince = value; }
        public HttpHeaderValueCollection<EntityTagHeaderValue> IfNoneMatch { get => ifNoneMatch; set => ifNoneMatch = value; }
        public RangeConditionHeaderValue IfRange { get => ifRange; set => ifRange = value; }
        public HttpHeaderValueCollection<NameValueHeaderValue> Pragma { get => pragma; set => pragma = value; }
        public RangeHeaderValue Range { get => range; set => range = value; }
        public Uri Referrer { get => referrer; set => referrer = value; }
        public HttpHeaderValueCollection<TransferCodingHeaderValue> TransferEncoding { get => transferEncoding; set => transferEncoding = value; }
        public bool? TransferEncodingChunked { get => transferEncodingChunked; set => transferEncodingChunked = value; }
        public HttpHeaderValueCollection<ProductHeaderValue> Upgrade { get => upgrade; set => upgrade = value; }
        public HttpHeaderValueCollection<ProductInfoHeaderValue> UserAgent { get => userAgent; set {
                userAgent = value;
                Headers.Add(XGBceHeaders.USER_AGENT, userAgent.ToString());
            } }

        public DateTimeOffset? Date { get => date; set =>date = value; }
        public HttpHeaderValueCollection<ViaHeaderValue> Via { get => via; set => via = value; }
        public HttpHeaderValueCollection<WarningHeaderValue> Warning { get => warning; set => warning = value; }
        #endregion

    }

}
