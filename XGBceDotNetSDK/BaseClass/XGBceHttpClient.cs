using System;
using System.Net.Http;
using XGBceDotNetSDK.Http;
using XGBceDotNetSDK.Http.Handler;
using XGBceDotNetSDK.Sign;
using XGBceDotNetSDK.Utils;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.BaseClass
{
    /// <summary>
    /// XGBceHttpClient
    /// </summary>
    public class XGBceHttpClient
    {
        private static readonly string TAG = "XGBceHttpClient";
        private XGBceLog logger = XGBceLog.GetLog();
        protected XGBceClientConfiguration clientConfig;
        protected IXGBceSigner clientSigner;
        private WebProxy webProxy = null;

        private static readonly IXGHttpResponseHandler[] RESPONSE_HANDLERS = { new XGBceMetadataResponseHandler(), new XGBceErrorResponseHandler(), new XGBceJsonResponseHandler() };


        public XGBceHttpClient(XGBceClientConfiguration config, IXGBceSigner signer)
        {
            clientConfig = config?? throw new ArgumentNullException("config不能为null");
            clientSigner = signer?? throw new ArgumentNullException("signer不能为null");
            if (!string.IsNullOrEmpty(clientConfig.ProxyHost))
            {
                UriBuilder uriBuilder = new UriBuilder()
                {
                    Host = clientConfig.ProxyHost,
                };
                if (clientConfig.ProxyPort != null)
                    uriBuilder.Port = clientConfig.ProxyPort.Value;
                    webProxy = new WebProxy() { Address = uriBuilder.Uri};
                if (!string.IsNullOrEmpty(clientConfig.ProxyUsername))
                {
                    webProxy.Credentials = new NetworkCredential(clientConfig.ProxyUsername,clientConfig.ProxyPassword);
                }
            }
            else
            {
                webProxy = null;
            }
        }

        /// <summary>
        /// 发送异步请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="IternalRequest"></param>
        /// <param name="responseHandlers"></param>
        /// <returns></returns>
        public async Task<T> SendAsyny<T>(XGBceIternalRequest IternalRequest) where T : XGAbstractBceResponse,new ()
        {
            XGBceCredentials credentials = IternalRequest.Credentials ?? clientConfig.Credentials;
            HttpClient httpClient = XGHttpClientHandler.GetHttpClient(webProxy);

            long delayForNextRetry = 0;
            for (int attempt = 0; ; attempt++)
            {
                HttpResponseMessage httpresponse = null;
                HttpRequestMessage httpRequest = null;
                try
                {
                    using (var cts = new CancellationTokenSource(clientConfig.ConnectionTimeout*1000))
                    {
                        if (credentials != null)
                            clientSigner.Sign(IternalRequest, credentials);

                        httpRequest = CreateHttpRequest(IternalRequest);

                        logger.Debug(TAG, "发送请求：" + httpRequest);

                        httpresponse = await httpClient.SendAsync(httpRequest,cts.Token);

                        XGBceHttpResponse bceHttpResponse = new XGBceHttpResponse(httpresponse);

                        var response = new T();

                        IXGHttpResponseHandler[] httpResponseHandlers = RESPONSE_HANDLERS;

                        foreach (IXGHttpResponseHandler handler in httpResponseHandlers)
                        {
                            if (handler.Handler(bceHttpResponse, ref response))
                                break;
                        }

                        return response;
                    }
                }
                catch (Exception ex)
                {
                    XGBceClientException bceClientException;

                    if (ex is XGBceServiceException bceServiceException)
                    {
                        if (bceServiceException.ErrorType == XGBceErrorType.Client)
                            throw bceServiceException;
                        else
                            bceClientException = bceServiceException;
                    }
                    else
                    {
                        logger.Error(TAG, "无法执行请求 "+ex.Message);
                        throw new XGBceClientException("无法执行请求", ex);
                    }

                    delayForNextRetry = GetDelayBeforeNextRetry(httpRequest, bceClientException, attempt, clientConfig.RetryPolicy);

                    if (delayForNextRetry < 0)
                        throw bceClientException;

                    logger.Error(TAG, "检测到错误，将会在" + delayForNextRetry + "秒后，进行第" + attempt + "次重试");

                    try
                    {
                        Thread.Sleep((int)delayForNextRetry);
                    }
                    catch (ThreadInterruptedException threadEx)
                    {
                        logger.Error(TAG, "延迟终止 " + threadEx.Message);
                        throw new XGBceClientException("延迟终止", threadEx);
                    }

                    if (httpresponse != null)
                    {
                        try
                        {
                            httpresponse.Content.Dispose();
                        }
                        catch (Exception e)
                        {
                            logger.Error(TAG, e.Message);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 发送同步请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="IternalRequest"></param>
        /// <param name="responseHandlers"></param>
        /// <returns></returns>
        public T Send<T>(XGBceIternalRequest iternalRequest) where T : XGAbstractBceResponse, new ()
        {
            XGBceCredentials credentials = iternalRequest.Credentials ?? clientConfig.Credentials;
            HttpClient httpClient = XGHttpClientHandler.GetHttpClient(webProxy);

            long delayForNextRetry = 0;
            for (int attempt = 0; ; attempt++)
            {
                HttpResponseMessage httpresponse = null;
                HttpRequestMessage httpRequest = null;
                try
                {
                    using (var cts = new CancellationTokenSource(clientConfig.ConnectionTimeout * 1000))
                    {
                        if (credentials != null)
                            clientSigner.Sign(iternalRequest, credentials);

                        httpRequest = CreateHttpRequest(iternalRequest);

                        logger.Debug(TAG, "发送请求：" + httpRequest);

                        httpresponse = httpClient.SendAsync(httpRequest, cts.Token).Result;

                        XGBceHttpResponse bceHttpResponse = new XGBceHttpResponse(httpresponse);

                        var response = new T();

                        IXGHttpResponseHandler[] httpResponseHandlers = RESPONSE_HANDLERS;

                        foreach (IXGHttpResponseHandler handler in httpResponseHandlers)
                        {
                            if (handler.Handler(bceHttpResponse, ref response))
                                break;
                        }

                        return response;
                    }
                }
                catch (Exception ex)
                {
                    XGBceClientException bceClientException;

                    if (ex is XGBceServiceException bceServiceException)
                    {
                        if (bceServiceException.ErrorType == XGBceErrorType.Client)
                            throw bceServiceException;
                        else
                            bceClientException = bceServiceException;
                    }
                    else
                    {
                        logger.Error(TAG, "无法执行请求 " + ex.Message);
                        throw new XGBceClientException("无法执行请求", ex);
                    }

                    delayForNextRetry = GetDelayBeforeNextRetry(httpRequest, bceClientException, attempt, clientConfig.RetryPolicy);

                    if (delayForNextRetry < 0)
                        throw bceClientException;

                    logger.Error(TAG, "检测到错误，将会在" + delayForNextRetry + "秒后，进行第" + attempt + "次重试");

                    try
                    {
                        Thread.Sleep((int)delayForNextRetry);
                    }
                    catch (ThreadInterruptedException threadEx)
                    {
                        logger.Error(TAG, "延迟终止 " + threadEx.Message);
                        throw new XGBceClientException("延迟终止", threadEx);
                    }

                    if (httpresponse != null)
                    {
                        try
                        {
                            httpresponse.Content.Dispose();
                        }
                        catch (Exception e)
                        {
                            logger.Error(TAG, e.Message);
                        }
                    }
                }
            }
        }

        protected long GetDelayBeforeNextRetry(HttpRequestMessage requestMessage, XGBceClientException exception, int attempt, XGRetryPolicy retryPolicy)
        {
            int retries = attempt - 1;
            int maxErrorRetry = retryPolicy.MaxErrorRetry;
            if (retries >= maxErrorRetry)
                return -1;
            else
            {
                return Math.Min(retryPolicy.MaxDelay, retryPolicy.GetDelayBeforeNextRetry(exception,retries));
            }
        }

            protected HttpRequestMessage CreateHttpRequest(XGBceIternalRequest request)
        {
            string uri = request.Uri.AbsoluteUri;
            string encodeParams = HttpUtil.GetCanonicalQueryString(request.Parameters,false);

            if (encodeParams.Length > 0)
            {
                uri += "?" + encodeParams;
            }

            HttpRequestMessage httpRequest;
            if (request.HttpMethod == BceHttpMethod.GET)
                httpRequest = new HttpRequestMessage(HttpMethod.Get, uri);
            else if (request.HttpMethod == BceHttpMethod.PUT)
            {
                httpRequest = new HttpRequestMessage(HttpMethod.Put, uri);
            }
            else if (request.HttpMethod == BceHttpMethod.POST)
            {
                httpRequest = new HttpRequestMessage(HttpMethod.Post, uri);
            }
            else if (request.HttpMethod == BceHttpMethod.DELETE)
            {
                httpRequest = new HttpRequestMessage(HttpMethod.Delete, uri);
            }
            else if (request.HttpMethod == BceHttpMethod.HEAD)
            {
                httpRequest = new HttpRequestMessage(HttpMethod.Head, uri);
            }
            else if (request.HttpMethod == BceHttpMethod.OPTIONS)
            {
                httpRequest = new HttpRequestMessage(HttpMethod.Options, uri);
            }
            else
            {
                logger.Error(TAG, "未知的请求协议  " + request.HttpMethod);
                throw new XGBceClientException("未知的请求协议" + request.HttpMethod);
            }

            if (request.Content != null)
                httpRequest.Content = request.Content;

            httpRequest.Headers.Host = request.Uri.Host;
            if (request.Date != null)
                httpRequest.Headers.Date = request.Date;

            foreach (KeyValuePair<string, string> kvp in request.MoreHeaders)
            {
                httpRequest.Headers.TryAddWithoutValidation(kvp.Key,kvp.Value);
            }

            return httpRequest;
        }
    }
}
