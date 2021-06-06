using System;
using System.Net.Http;
using XGBceDotNetSDK.Http.Handler;
using XGBceDotNetSDK.Sign;

namespace XGBceDotNetSDK.BaseClass
{
    public class XGBceHttpClient
    {
        private static readonly object lockClient = new object();
        protected static HttpClient httpClient=null;
        protected XGBceClientConfiguration clientConfig;
        protected XGBceSigner clientSigner;
        private bool _isHttpAsyncPutEnabled = false;
        //private HttpClientConnectionManager connectionManager;
        //private NHttpClientConnectionManager nioConnectionManager;
        //private Builder requestConfigBuilder;
        //private CredentialsProvider credentialsProvider;
        //private HttpHost proxyHttpHost;
        
        //private static ConcurrentHashMap<String, CloseableHttpAsyncClient> asyncClientMap = new ConcurrentHashMap();
        //private static ConcurrentHashMap<String, NHttpClientConnectionManager> managerMap = new ConcurrentHashMap();

        /// <summary>
        /// 单例模式
        /// </summary>
        /// <returns></returns>
        private static HttpClient GetHttpClient()
        {
            if (httpClient == null)
            {
                lock (lockClient)
                {
                    if (httpClient == null)
                    {
                        httpClient = new HttpClient();
                    }
                }
            }
            return httpClient;
        }

        public XGBceHttpClient(XGBceClientConfiguration config, XGBceSigner signer)
        {
            if (config == null)
                throw new ArgumentNullException("config不能为null");
            if (signer == null)
                throw new ArgumentNullException("config不能为null");
            clientConfig = config;
            clientSigner = signer;
            httpClient = GetHttpClient();

        }

        public XGBceHttpClient(XGBceClientConfiguration config,XGBceSigner signer,bool isHttpAsyncPutEnabled):this(config,signer)
        {
            //if (isHttpAsyncPutEnabled)
            //{
            //}
            _isHttpAsyncPutEnabled = isHttpAsyncPutEnabled;
        }

        //public T execute<T>(XGBceIternalRequest request, object responseClass , IXGHttpResponseHandler[] responseHandlers) where T: XGAbstractBceResponse
        //{
        //    request.AddHeader()
        //}
    }
}
