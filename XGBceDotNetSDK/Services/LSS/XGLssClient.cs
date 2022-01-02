using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using XGBceDotNetSDK.BaseClass;
using XGBceDotNetSDK.Http;
using XGBceDotNetSDK.Http.Handler;
using XGBceDotNetSDK.Services.LSS.Model;
using XGBceDotNetSDK.Utils;
using static XGBceDotNetSDK.Services.LSS.Model.XGLssEnum;

namespace XGBceDotNetSDK.Services.LSS
{
    /// <summary>
    /// 音视频直播LSS 客户端类
    /// <para>LSS 的服务域名是 lss.bj.baidubce.com</para>
    /// <para>接口文档：https://cloud.baidu.com/doc/LSS/s/9jwvyyxfh </para>
    /// </summary>
    public class XGLssClient: XGAbstractBceClient
    {
        private static readonly string DOMAIN = "domain";
        private static readonly string STREAM = "stream";
        private static readonly string STREAMING = "streaming";
        private static readonly string APP = "app";

        /// <summary>
        /// 为适配奇葩应答包体而生
        /// </summary>
        private static readonly IXGHttpResponseHandler[] LSS_HANDLERS = { new XGBceMetadataResponseHandler(), new XGBceErrorResponseHandler(), new XGBceLssListResponseHandler() };


        public XGLssClient() : this(new XGBceClientConfiguration()) { }

        public XGLssClient(XGBceClientConfiguration configuration) : base(configuration) { }

        #region Stream接口

        /// <summary>
        /// 查询所有Stream
        /// <para>接口文档：https://cloud.baidu.com/doc/LSS/s/ejwvyywbt#%E6%9F%A5%E8%AF%A2%E6%89%80%E6%9C%89stream </para>
        /// </summary>
        /// <param name="playDomain">直播域名</param>
        /// <param name="status">Stream状态</param>
        /// <param name="marker">本次请求的marker</param>
        /// <param name="maxSize">本次请求的Stream数目</param>
        /// <returns>XGLssListStreamsResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGLssListStreamsResponse ListStreams(string playDomain, XGLssStreamStatus? status=null, string marker=null, int? maxSize=null)
        {
            AssertStringNotNullOrEmpty(playDomain, nameof(playDomain));

            XGLssListStreamsRequest request = new XGLssListStreamsRequest()
            {
                PlayDomain = playDomain,
                Status=status,
                Marker=marker,
                MaxSize=maxSize
            };
            return ListStreams(request);
        }

        /// <summary>
        /// 查询所有Stream
        /// </summary>
        /// <param name="playDomain">直播域名</param>
        /// <param name="status">Stream状态</param>
        /// <param name="marker">本次请求的marker</param>
        /// <param name="maxSize">本次请求的Stream数目</param>
        /// <returns>异步任务XGLssListStreamsResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGLssListStreamsResponse> ListStreamsAsync(string playDomain, XGLssStreamStatus? status = null, string marker = null, int? maxSize = null)
        {
            AssertStringNotNullOrEmpty(playDomain, nameof(playDomain));

            XGLssListStreamsRequest request = new XGLssListStreamsRequest()
            {
                PlayDomain = playDomain,
                Status = status,
                Marker = marker,
                MaxSize = maxSize
            };
            return await ListStreamsAsync(request);
        }

        /// <summary>
        /// 查询所有Stream
        /// <para>接口文档：https://cloud.baidu.com/doc/LSS/s/ejwvyywbt#%E6%9F%A5%E8%AF%A2%E6%89%80%E6%9C%89stream </para>
        /// </summary>
        /// <param name="request">XGLssListStreamsRequest</param>
        /// <returns>XGLssListStreamsResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGLssListStreamsResponse ListStreams(XGLssListStreamsRequest request)
        {
            AssertNotNullOrEmpty(request,nameof(request));
            AssertStringNotNullOrEmpty(request.PlayDomain, nameof(request.PlayDomain));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.LssVersion.ToString(), DOMAIN,request.PlayDomain.Trim(),STREAM);
            if (request.Status != null)
                iternalRequest.AddParameter("status",request.Status.Value.ToString());
            if (!string.IsNullOrEmpty(request.Marker) && !string.IsNullOrWhiteSpace(request.Marker))
                iternalRequest.AddParameter("marker",request.Marker.Trim());
            if (request.MaxSize != null)
                iternalRequest.AddParameter("maxSize",request.MaxSize.Value.ToString());
            XGLssListStreamsResponse response = InvokeHttpClient<XGLssListStreamsResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询所有Stream
        /// <para>接口文档：https://cloud.baidu.com/doc/LSS/s/ejwvyywbt#%E6%9F%A5%E8%AF%A2%E6%89%80%E6%9C%89stream </para>
        /// </summary>
        /// <param name="request">XGLssListStreamsRequest</param>
        /// <returns>异步任务XGLssListStreamsResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGLssListStreamsResponse> ListStreamsAsync(XGLssListStreamsRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.PlayDomain, nameof(request.PlayDomain));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.LssVersion.ToString(), DOMAIN, request.PlayDomain.Trim(), STREAM);
            if (request.Status != null)
                iternalRequest.AddParameter("status", request.Status.Value.ToString());
            if (!string.IsNullOrEmpty(request.Marker) && !string.IsNullOrWhiteSpace(request.Marker))
                iternalRequest.AddParameter("marker", request.Marker.Trim());
            if (request.MaxSize != null)
                iternalRequest.AddParameter("maxSize", request.MaxSize.Value.ToString());
            XGLssListStreamsResponse response = await InvokeHttpClientAsync<XGLssListStreamsResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询所有App
        /// <para>查询特定Domain下所有App（不包括默认App）</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/LSS/s/ejwvyywbt#%E6%9F%A5%E8%AF%A2%E6%89%80%E6%9C%89app </para>
        /// </summary>
        /// <param name="playDomain">播放域名</param>
        /// <returns>XGLssListAppsResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGLssListAppsResponse ListApps(string playDomain)
        {
            AssertStringNotNullOrEmpty(playDomain,nameof(playDomain));
            XGLssListAppsRequest request = new XGLssListAppsRequest()
            {
                PlayDomain=playDomain
            };
            return ListApps(request);
        }

        /// <summary>
        /// 查询所有App
        /// <para>查询特定Domain下所有App（不包括默认App）</para>
        /// </summary>
        /// <param name="playDomain">播放域名</param>
        /// <returns>异步任务XGLssListAppsResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGLssListAppsResponse> ListAppsAsync(string playDomain)
        {
            AssertStringNotNullOrEmpty(playDomain, nameof(playDomain));
            XGLssListAppsRequest request = new XGLssListAppsRequest()
            {
                PlayDomain = playDomain
            };
            return await ListAppsAsync(request);
        }

        /// <summary>
        /// 查询所有App
        /// <para>查询特定Domain下所有App（不包括默认App）</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/LSS/s/ejwvyywbt#%E6%9F%A5%E8%AF%A2%E6%89%80%E6%9C%89app </para>
        /// </summary>
        /// <param name="request">XGLssListAppsRequest</param>
        /// <returns>XGLssListAppsResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGLssListAppsResponse ListApps(XGLssListAppsRequest request)
        {
            AssertNotNullOrEmpty(request,nameof(request));
            AssertStringNotNullOrEmpty(request.PlayDomain, nameof(request.PlayDomain));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.LssVersion.ToString(), DOMAIN, request.PlayDomain.Trim(), APP);
            XGLssListAppsResponse response = InvokeHttpClient<XGLssListAppsResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询所有App
        /// <para>查询特定Domain下所有App（不包括默认App）</para>
        /// </summary>
        /// <param name="request">XGLssListAppsRequest</param>
        /// <returns>异步任务XGLssListAppsResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGLssListAppsResponse> ListAppsAsync(XGLssListAppsRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.PlayDomain, nameof(request.PlayDomain));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.LssVersion.ToString(), DOMAIN, request.PlayDomain.Trim(), APP);
            XGLssListAppsResponse response = await InvokeHttpClientAsync<XGLssListAppsResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询特定Stream
        /// <para>查询特定Domain下的特定Stream</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/LSS/s/ejwvyywbt#%E6%9F%A5%E8%AF%A2%E7%89%B9%E5%AE%9Astream </para>
        /// </summary>
        /// <param name="playDomain">播放域名</param>
        /// <param name="app">App</param>
        /// <param name="stream">流ID</param>
        /// <returns>XGLssQueryStreamResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGLssQueryStreamResponse QueryStream(string playDomain, string app, string stream)
        {
            AssertStringNotNullOrEmpty(playDomain,nameof(playDomain));
            AssertStringNotNullOrEmpty(app,nameof(app));
            AssertStringNotNullOrEmpty(stream,nameof(stream));
            XGLssStreamRequest request = new XGLssStreamRequest()
            {
                PlayDomain=playDomain,
                App=app,
                Stream=stream
            };
            return QueryStream(request);
        }

        /// <summary>
        /// 查询特定Stream
        /// <para>查询特定Domain下的特定Stream</para>
        /// </summary>
        /// <param name="playDomain">播放域名</param>
        /// <param name="app">App</param>
        /// <param name="stream">流ID</param>
        /// <returns>异步任务XGLssQueryStreamResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGLssQueryStreamResponse> QueryStreamAsync(string playDomain, string app, string stream)
        {
            AssertStringNotNullOrEmpty(playDomain, nameof(playDomain));
            AssertStringNotNullOrEmpty(app, nameof(app));
            AssertStringNotNullOrEmpty(stream, nameof(stream));
            XGLssStreamRequest request = new XGLssStreamRequest()
            {
                PlayDomain = playDomain,
                App = app,
                Stream = stream
            };
            return await QueryStreamAsync(request);
        }

        /// <summary>
        /// 查询特定Stream
        /// <para>查询特定Domain下的特定Stream</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/LSS/s/ejwvyywbt#%E6%9F%A5%E8%AF%A2%E7%89%B9%E5%AE%9Astream </para>
        /// </summary>
        /// <param name="request">XGLssQueryStreamRequest</param>
        /// <returns>XGLssQueryStreamResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGLssQueryStreamResponse QueryStream(XGLssStreamRequest request)
        {
            AssertNotNullOrEmpty(request,nameof(request));
            AssertStringNotNullOrEmpty(request.PlayDomain,nameof(request.PlayDomain));
            AssertStringNotNullOrEmpty(request.App,nameof(request.App));
            AssertStringNotNullOrEmpty(request.Stream,nameof(request.Stream));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.LssVersion.ToString(), DOMAIN, request.PlayDomain.Trim(), APP,request.App.Trim(),STREAM,request.Stream.Trim());
            XGLssQueryStreamResponse response = InvokeHttpClient<XGLssQueryStreamResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询特定Stream
        /// <para>查询特定Domain下的特定Stream</para>
        /// </summary>
        /// <param name="request">XGLssQueryStreamRequest</param>
        /// <returns>异步任务XGLssQueryStreamResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGLssQueryStreamResponse> QueryStreamAsync(XGLssStreamRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.PlayDomain, nameof(request.PlayDomain));
            AssertStringNotNullOrEmpty(request.App, nameof(request.App));
            AssertStringNotNullOrEmpty(request.Stream, nameof(request.Stream));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.LssVersion.ToString(), DOMAIN, request.PlayDomain.Trim(), APP, request.App.Trim(), STREAM, request.Stream.Trim());
            XGLssQueryStreamResponse response = await InvokeHttpClientAsync<XGLssQueryStreamResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询活跃的Stream
        /// <para>查询指定的播放domain下所有推流中的Stream（活跃Stream）</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/LSS/s/ejwvyywbt#%E6%9F%A5%E8%AF%A2%E6%B4%BB%E8%B7%83%E7%9A%84stream </para>
        /// </summary>
        /// <param name="playDomain">查询的域名</param>
        /// <returns>XGLssListStreamingsResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGLssListStreamingsResponse ListStreamings(string playDomain)
        {
            AssertNotNullOrEmpty(playDomain, nameof(playDomain));
            XGLssListStreamingsRequest request = new XGLssListStreamingsRequest()
            {
                PlayDomain=playDomain
            };
            return ListStreamings(request);
        }

        /// <summary>
        /// 查询活跃的Stream
        /// <para>查询指定的播放domain下所有推流中的Stream（活跃Stream）</para>
        /// </summary>
        /// <param name="playDomain">查询的域名</param>
        /// <returns>异步任务XGLssListStreamingsResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGLssListStreamingsResponse> ListStreamingsAsync(string playDomain)
        {
            AssertNotNullOrEmpty(playDomain, nameof(playDomain));
            XGLssListStreamingsRequest request = new XGLssListStreamingsRequest()
            {
                PlayDomain = playDomain
            };
            return await ListStreamingsAsync(request);
        }

        /// <summary>
        /// 查询活跃的Stream
        /// <para>查询指定的播放domain下所有推流中的Stream（活跃Stream）</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/LSS/s/ejwvyywbt#%E6%9F%A5%E8%AF%A2%E6%B4%BB%E8%B7%83%E7%9A%84stream </para>
        /// </summary>
        /// <param name="request">XGLssListStreamingsRequest</param>
        /// <returns>XGLssListStreamingsResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGLssListStreamingsResponse ListStreamings(XGLssListStreamingsRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.PlayDomain, nameof(request.PlayDomain));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.LssVersion.ToString(), DOMAIN, request.PlayDomain.Trim(), STREAMING);
            XGLssListStreamingsResponse response = InvokeHttpClient<XGLssListStreamingsResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询活跃的Stream
        /// <para>查询指定的播放domain下所有推流中的Stream（活跃Stream）</para>
        /// </summary>
        /// <param name="request">XGLssListStreamingsRequest</param>
        /// <returns>异步任务XGLssListStreamingsResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGLssListStreamingsResponse> ListStreamingsAsync(XGLssListStreamingsRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.PlayDomain, nameof(request.PlayDomain));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.LssVersion.ToString(), DOMAIN, request.PlayDomain.Trim(), STREAMING);
            XGLssListStreamingsResponse response = await InvokeHttpClientAsync<XGLssListStreamingsResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 封禁特定Stream
        /// <para>封禁播放domain下特定播放stream时，将直接封禁该条直播流，无法推流和播放</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/LSS/s/ejwvyywbt#%E5%B0%81%E7%A6%81%E7%89%B9%E5%AE%9Astream </para>
        /// </summary>
        /// <param name="playDomain">播放域名</param>
        /// <param name="app">App</param>
        /// <param name="stream">流名称</param>
        /// <returns>XGLssResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGLssResponse PauseStream(string playDomain, string app, string stream)
        {
            AssertStringNotNullOrEmpty(playDomain, nameof(playDomain));
            AssertStringNotNullOrEmpty(app, nameof(app));
            AssertStringNotNullOrEmpty(stream, nameof(stream));
            XGLssStreamRequest request = new XGLssStreamRequest()
            {
                PlayDomain=playDomain,
                App=app,
                Stream=stream
            };
            return PauseStream(request);
        }

        /// <summary>
        /// 封禁特定Stream
        /// <para>封禁播放domain下特定播放stream时，将直接封禁该条直播流，无法推流和播放</para>
        /// </summary>
        /// <param name="playDomain">播放域名</param>
        /// <param name="app">App</param>
        /// <param name="stream">流名称</param>
        /// <returns>XGLssResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGLssResponse> PauseStreamAsync(string playDomain, string app, string stream)
        {
            AssertStringNotNullOrEmpty(playDomain, nameof(playDomain));
            AssertStringNotNullOrEmpty(app, nameof(app));
            AssertStringNotNullOrEmpty(stream, nameof(stream));
            XGLssStreamRequest request = new XGLssStreamRequest()
            {
                PlayDomain = playDomain,
                App = app,
                Stream = stream
            };
            return await PauseStreamAsync(request);
        }

        /// <summary>
        /// 封禁特定Stream
        /// <para>封禁播放domain下特定播放stream时，将直接封禁该条直播流，无法推流和播放</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/LSS/s/ejwvyywbt#%E5%B0%81%E7%A6%81%E7%89%B9%E5%AE%9Astream </para>
        /// </summary>
        /// <param name="request">XGLssStreamRequest</param>
        /// <returns>XGLssResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGLssResponse PauseStream(XGLssStreamRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.PlayDomain, nameof(request.PlayDomain));
            AssertStringNotNullOrEmpty(request.App, nameof(request.App));
            AssertStringNotNullOrEmpty(request.Stream, nameof(request.Stream));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.PUT, request.LssVersion.ToString(), DOMAIN, request.PlayDomain.Trim(), APP, request.App.Trim(), STREAM, request.Stream.Trim());
            iternalRequest.AddParameter("pause");
            XGLssResponse response = InvokeHttpClient<XGLssResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 封禁特定Stream
        /// <para>封禁播放domain下特定播放stream时，将直接封禁该条直播流，无法推流和播放</para>
        /// </summary>
        /// <param name="request">XGLssStreamRequest</param>
        /// <returns>异步任务XGLssResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGLssResponse> PauseStreamAsync(XGLssStreamRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.PlayDomain, nameof(request.PlayDomain));
            AssertStringNotNullOrEmpty(request.App, nameof(request.App));
            AssertStringNotNullOrEmpty(request.Stream, nameof(request.Stream));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.PUT, request.LssVersion.ToString(), DOMAIN, request.PlayDomain.Trim(), APP, request.App.Trim(), STREAM, request.Stream.Trim());
            iternalRequest.AddParameter("pause");
            XGLssResponse response = await InvokeHttpClientAsync<XGLssResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 解禁特定Stream
        /// <para>解禁特定Domain下的特定Stream</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/LSS/s/ejwvyywbt#%E8%A7%A3%E7%A6%81%E7%89%B9%E5%AE%9Astream </para>
        /// </summary>
        /// <param name="playDomain">播放域名</param>
        /// <param name="app">App</param>
        /// <param name="stream">流名称</param>
        /// <returns>XGLssResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGLssResponse ResumeStream(string playDomain, string app, string stream)
        {
            AssertStringNotNullOrEmpty(playDomain, nameof(playDomain));
            AssertStringNotNullOrEmpty(app, nameof(app));
            AssertStringNotNullOrEmpty(stream, nameof(stream));
            XGLssStreamRequest request = new XGLssStreamRequest()
            {
                PlayDomain = playDomain,
                App = app,
                Stream = stream
            };
            return ResumeStream(request);
        }

        /// <summary>
        /// 解禁特定Stream
        /// <para>解禁特定Domain下的特定Stream</para>
        /// </summary>
        /// <param name="playDomain">播放域名</param>
        /// <param name="app">App</param>
        /// <param name="stream">流名称</param>
        /// <returns>异步任务XGLssResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGLssResponse> ResumeStreamAsync(string playDomain, string app, string stream)
        {
            AssertStringNotNullOrEmpty(playDomain, nameof(playDomain));
            AssertStringNotNullOrEmpty(app, nameof(app));
            AssertStringNotNullOrEmpty(stream, nameof(stream));
            XGLssStreamRequest request = new XGLssStreamRequest()
            {
                PlayDomain = playDomain,
                App = app,
                Stream = stream
            };
            return await ResumeStreamAsync(request);
        }

        /// <summary>
        /// 解禁特定Stream
        /// <para>解禁特定Domain下的特定Stream</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/LSS/s/ejwvyywbt#%E8%A7%A3%E7%A6%81%E7%89%B9%E5%AE%9Astream </para>
        /// </summary>
        /// <param name="request">XGLssStreamRequest</param>
        /// <returns>XGLssResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGLssResponse ResumeStream(XGLssStreamRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.PlayDomain, nameof(request.PlayDomain));
            AssertStringNotNullOrEmpty(request.App, nameof(request.App));
            AssertStringNotNullOrEmpty(request.Stream, nameof(request.Stream));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.PUT, request.LssVersion.ToString(), DOMAIN, request.PlayDomain.Trim(), APP, request.App.Trim(), STREAM, request.Stream.Trim());
            iternalRequest.AddParameter("resume");
            XGLssResponse response = InvokeHttpClient<XGLssResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 解禁特定Stream
        /// <para>解禁特定Domain下的特定Stream</para>
        /// </summary>
        /// <param name="request">XGLssStreamRequest</param>
        /// <returns>异步任务XGLssResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGLssResponse> ResumeStreamAsync(XGLssStreamRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.PlayDomain, nameof(request.PlayDomain));
            AssertStringNotNullOrEmpty(request.App, nameof(request.App));
            AssertStringNotNullOrEmpty(request.Stream, nameof(request.Stream));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.PUT, request.LssVersion.ToString(), DOMAIN, request.PlayDomain.Trim(), APP, request.App.Trim(), STREAM, request.Stream.Trim());
            iternalRequest.AddParameter("resume");
            XGLssResponse response = await InvokeHttpClientAsync<XGLssResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 删除特定Stream
        /// <para>接口文档：https://cloud.baidu.com/doc/LSS/s/ejwvyywbt#%E5%88%A0%E9%99%A4%E7%89%B9%E5%AE%9Astream </para>
        /// </summary>
        /// <param name="playDomain">播放域名</param>
        /// <param name="app">App</param>
        /// <param name="stream">流名称</param>
        /// <returns>XGLssResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGLssResponse DeleteStream(string playDomain, string app, string stream)
        {
            AssertStringNotNullOrEmpty(playDomain, nameof(playDomain));
            AssertStringNotNullOrEmpty(app, nameof(app));
            AssertStringNotNullOrEmpty(stream, nameof(stream));
            XGLssStreamRequest request = new XGLssStreamRequest()
            {
                PlayDomain = playDomain,
                App = app,
                Stream = stream
            };
            return DeleteStream(request);
        }

        /// <summary>
        /// 删除特定Stream
        /// </summary>
        /// <param name="playDomain">播放域名</param>
        /// <param name="app">App</param>
        /// <param name="stream">流名称</param>
        /// <returns>异步任务XGLssResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGLssResponse> DeleteStreamAsync(string playDomain, string app, string stream)
        {
            AssertStringNotNullOrEmpty(playDomain, nameof(playDomain));
            AssertStringNotNullOrEmpty(app, nameof(app));
            AssertStringNotNullOrEmpty(stream, nameof(stream));
            XGLssStreamRequest request = new XGLssStreamRequest()
            {
                PlayDomain = playDomain,
                App = app,
                Stream = stream
            };
            return await DeleteStreamAsync(request);
        }

        /// <summary>
        /// 删除特定Stream
        /// <para>接口文档：https://cloud.baidu.com/doc/LSS/s/ejwvyywbt#%E5%88%A0%E9%99%A4%E7%89%B9%E5%AE%9Astream </para>
        /// </summary>
        /// <param name="request">XGLssStreamRequest</param>
        /// <returns>XGLssResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGLssResponse DeleteStream(XGLssStreamRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.PlayDomain, nameof(request.PlayDomain));
            AssertStringNotNullOrEmpty(request.App, nameof(request.App));
            AssertStringNotNullOrEmpty(request.Stream, nameof(request.Stream));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.DELETE, request.LssVersion.ToString(), DOMAIN, request.PlayDomain.Trim(), APP, request.App.Trim(), STREAM, request.Stream.Trim());
            XGLssResponse response = InvokeHttpClient<XGLssResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 删除特定Stream
        /// </summary>
        /// <param name="request">XGLssStreamRequest</param>
        /// <returns>异步任务XGLssResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGLssResponse> DeleteStreamAsync(XGLssStreamRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.PlayDomain, nameof(request.PlayDomain));
            AssertStringNotNullOrEmpty(request.App, nameof(request.App));
            AssertStringNotNullOrEmpty(request.Stream, nameof(request.Stream));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.DELETE, request.LssVersion.ToString(), DOMAIN, request.PlayDomain.Trim(), APP, request.App.Trim(), STREAM, request.Stream.Trim());
            XGLssResponse response = await InvokeHttpClientAsync<XGLssResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 重置特定stream
        /// <para>中断当前直播流，并保证下次可以再次推流成功</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/LSS/s/ejwvyywbt#%E9%87%8D%E7%BD%AE%E7%89%B9%E5%AE%9Astream </para>
        /// </summary>
        /// <param name="playDomain">播放域名</param>
        /// <param name="app">App</param>
        /// <param name="stream">流名称</param>
        /// <returns>XGLssResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGLssResponse ResetStream(string playDomain, string app, string stream)
        {
            AssertStringNotNullOrEmpty(playDomain, nameof(playDomain));
            AssertStringNotNullOrEmpty(app, nameof(app));
            AssertStringNotNullOrEmpty(stream, nameof(stream));
            XGLssStreamRequest request = new XGLssStreamRequest()
            {
                PlayDomain = playDomain,
                App = app,
                Stream = stream
            };
            return DeleteStream(request);
        }

        /// <summary>
        /// 重置特定stream
        /// <para>中断当前直播流，并保证下次可以再次推流成功</para>
        /// </summary>
        /// <param name="playDomain">播放域名</param>
        /// <param name="app">App</param>
        /// <param name="stream">流名称</param>
        /// <returns>异步任务XGLssResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGLssResponse> ResetStreamAsync(string playDomain, string app, string stream)
        {
            AssertStringNotNullOrEmpty(playDomain, nameof(playDomain));
            AssertStringNotNullOrEmpty(app, nameof(app));
            AssertStringNotNullOrEmpty(stream, nameof(stream));
            XGLssStreamRequest request = new XGLssStreamRequest()
            {
                PlayDomain = playDomain,
                App = app,
                Stream = stream
            };
            return await ResetStreamAsync(request);
        }

        /// <summary>
        /// 重置特定stream
        /// <para>中断当前直播流，并保证下次可以再次推流成功</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/LSS/s/ejwvyywbt#%E9%87%8D%E7%BD%AE%E7%89%B9%E5%AE%9Astream </para>
        /// </summary>
        /// <param name="request">XGLssStreamRequest</param>
        /// <returns>XGLssResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGLssResponse ResetStream(XGLssStreamRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.PlayDomain, nameof(request.PlayDomain));
            AssertStringNotNullOrEmpty(request.App, nameof(request.App));
            AssertStringNotNullOrEmpty(request.Stream, nameof(request.Stream));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.PUT, request.LssVersion.ToString(), DOMAIN, request.PlayDomain.Trim(), APP, request.App.Trim(), STREAM, request.Stream.Trim());
            iternalRequest.AddParameter("reset");
            XGLssResponse response = InvokeHttpClient<XGLssResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 重置特定stream
        /// <para>中断当前直播流，并保证下次可以再次推流成功</para>
        /// </summary>
        /// <param name="request">XGLssStreamRequest</param>
        /// <returns>异步任务XGLssResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGLssResponse> ResetStreamAsync(XGLssStreamRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.PlayDomain, nameof(request.PlayDomain));
            AssertStringNotNullOrEmpty(request.App, nameof(request.App));
            AssertStringNotNullOrEmpty(request.Stream, nameof(request.Stream));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.PUT, request.LssVersion.ToString(), DOMAIN, request.PlayDomain.Trim(), APP, request.App.Trim(), STREAM, request.Stream.Trim());
            iternalRequest.AddParameter("reset");
            XGLssResponse response = await InvokeHttpClientAsync<XGLssResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 添加metadata信息
        /// <para>为某个直播中的流添加metadata信息，本接口仅对streamingStatus=STREAMING的stream</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/LSS/s/ejwvyywbt#%E6%B7%BB%E5%8A%A0metadata%E4%BF%A1%E6%81%AF </para>
        /// </summary>
        /// <param name="playDomain">播放域名</param>
        /// <param name="app">App</param>
        /// <param name="stream">流名称</param>
        /// <param name="metadata"></param>
        /// <returns>XGLssResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGLssResponse AddStreamMetaData(string playDomain, string app, string stream,Dictionary<string,string> metadata=null)
        {
            AssertStringNotNullOrEmpty(playDomain, nameof(playDomain));
            AssertStringNotNullOrEmpty(app, nameof(app));
            AssertStringNotNullOrEmpty(stream, nameof(stream));
            XGLssAddStreamMetaDataRequest request = new XGLssAddStreamMetaDataRequest()
            {
                PlayDomain = playDomain,
                App = app,
                Stream = stream,
                Metadata=metadata
            };
            return AddStreamMetaData(request);
        }

        /// <summary>
        /// 添加metadata信息
        /// <para>为某个直播中的流添加metadata信息，本接口仅对streamingStatus=STREAMING的stream</para>
        /// </summary>
        /// <param name="playDomain">播放域名</param>
        /// <param name="app">App</param>
        /// <param name="stream">流名称</param>
        /// <param name="metadata"></param>
        /// <returns>异步任务XGLssResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGLssResponse> AddStreamMetaDataAsync(string playDomain, string app, string stream, Dictionary<string, string> metadata = null)
        {
            AssertStringNotNullOrEmpty(playDomain, nameof(playDomain));
            AssertStringNotNullOrEmpty(app, nameof(app));
            AssertStringNotNullOrEmpty(stream, nameof(stream));
            XGLssAddStreamMetaDataRequest request = new XGLssAddStreamMetaDataRequest()
            {
                PlayDomain = playDomain,
                App = app,
                Stream = stream,
                Metadata = metadata
            };
            return await AddStreamMetaDataAsync(request);
        }

        /// <summary>
        /// 添加metadata信息
        /// <para>为某个直播中的流添加metadata信息，本接口仅对streamingStatus=STREAMING的stream</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/LSS/s/ejwvyywbt#%E6%B7%BB%E5%8A%A0metadata%E4%BF%A1%E6%81%AF </para>
        /// </summary>
        /// <param name="request">XGLssAddStreamMetaDataRequest</param>
        /// <returns>XGLssResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGLssResponse AddStreamMetaData(XGLssAddStreamMetaDataRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.PlayDomain, nameof(request.PlayDomain));
            AssertStringNotNullOrEmpty(request.App, nameof(request.App));
            AssertStringNotNullOrEmpty(request.Stream, nameof(request.Stream));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.PUT, request.LssVersion.ToString(), DOMAIN, request.PlayDomain.Trim(), APP, request.App.Trim(), STREAM, request.Stream.Trim());
            XGLssResponse response = InvokeHttpClient<XGLssResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 添加metadata信息
        /// <para>为某个直播中的流添加metadata信息，本接口仅对streamingStatus=STREAMING的stream</para>
        /// </summary>
        /// <param name="request">XGLssAddStreamMetaDataRequest</param>
        /// <returns>异步任务XGLssResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGLssResponse> AddStreamMetaDataAsync(XGLssAddStreamMetaDataRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.PlayDomain, nameof(request.PlayDomain));
            AssertStringNotNullOrEmpty(request.App, nameof(request.App));
            AssertStringNotNullOrEmpty(request.Stream, nameof(request.Stream));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.PUT, request.LssVersion.ToString(), DOMAIN, request.PlayDomain.Trim(), APP, request.App.Trim(), STREAM, request.Stream.Trim());
            XGLssResponse response = await InvokeHttpClientAsync<XGLssResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 更新Stream水印模版
        /// <para>更新Stream水印模版的配置</para>
        /// <para>默认继承域名下配置的水印模板，也可以通过本接口，对某个Stream单独设置水印模板。</para>
        /// <para>如果watermarks为空，则更新结果为null，继承域名下的水印模板配置。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/LSS/s/ejwvyywbt#%E6%9B%B4%E6%96%B0stream%E6%B0%B4%E5%8D%B0%E6%A8%A1%E7%89%88 </para>
        /// </summary>
        /// <param name="playDomain">播放域名</param>
        /// <param name="app">App</param>
        /// <param name="stream">流名称</param>
        /// <param name="image">图片水印模版名称列表</param>
        /// <param name="timestamp">时间戳水印模版名称列表</param>
        /// <returns>XGLssResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGLssResponse StreamUpdateWatermarks(string playDomain, string app, string stream, List<string> image=null, List<string> timestamp=null)
        {
            AssertStringNotNullOrEmpty(playDomain, nameof(playDomain));
            AssertStringNotNullOrEmpty(app, nameof(app));
            AssertStringNotNullOrEmpty(stream, nameof(stream));
            XGLssStreamUpdateWatermarksRequest request = new XGLssStreamUpdateWatermarksRequest()
            {
                PlayDomain = playDomain,
                App = app,
                Stream = stream,
                Watermarks = new XGLssStreamWatermarks() {
                    Image=image,
                    Timestamp=timestamp
                }
            };
            return StreamUpdateWatermarks(request);
        }

        /// <summary>
        /// 更新Stream水印模版
        /// <para>更新Stream水印模版的配置</para>
        /// <para>默认继承域名下配置的水印模板，也可以通过本接口，对某个Stream单独设置水印模板。</para>
        /// <para>如果watermarks为空，则更新结果为null，继承域名下的水印模板配置。</para>
        /// </summary>
        /// <param name="playDomain">播放域名</param>
        /// <param name="app">App</param>
        /// <param name="stream">流名称</param>
        /// <param name="image">图片水印模版名称列表</param>
        /// <param name="timestamp">时间戳水印模版名称列表</param>
        /// <returns>XGLssResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGLssResponse> StreamUpdateWatermarksAsync(string playDomain, string app, string stream, List<string> image = null, List<string> timestamp = null)
        {
            AssertStringNotNullOrEmpty(playDomain, nameof(playDomain));
            AssertStringNotNullOrEmpty(app, nameof(app));
            AssertStringNotNullOrEmpty(stream, nameof(stream));
            XGLssStreamUpdateWatermarksRequest request = new XGLssStreamUpdateWatermarksRequest()
            {
                PlayDomain = playDomain,
                App = app,
                Stream = stream,
                Watermarks = new XGLssStreamWatermarks()
                {
                    Image = image,
                    Timestamp = timestamp
                }
            };
            return await StreamUpdateWatermarksAsync(request);
        }

        /// <summary>
        /// 更新Stream水印模版
        /// <para>更新Stream水印模版的配置</para>
        /// <para>默认继承域名下配置的水印模板，也可以通过本接口，对某个Stream单独设置水印模板。</para>
        /// <para>如果watermarks为空，则更新结果为null，继承域名下的水印模板配置。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/LSS/s/ejwvyywbt#%E6%9B%B4%E6%96%B0stream%E6%B0%B4%E5%8D%B0%E6%A8%A1%E7%89%88 </para>
        /// </summary>
        /// <param name="request">XGLssStreamUpdateWatermarksRequest</param>
        /// <returns>XGLssResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGLssResponse StreamUpdateWatermarks(XGLssStreamUpdateWatermarksRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.PlayDomain, nameof(request.PlayDomain));
            AssertStringNotNullOrEmpty(request.App, nameof(request.App));
            AssertStringNotNullOrEmpty(request.Stream, nameof(request.Stream));
            AssertNotNullOrEmpty(request.Watermarks,nameof(request.Watermarks));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.POST, request.LssVersion.ToString(), DOMAIN, request.PlayDomain.Trim(), APP, request.App.Trim(), STREAM, request.Stream.Trim());
            iternalRequest.AddParameter("watermark");
            XGLssResponse response = InvokeHttpClient<XGLssResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 更新Stream水印模版
        /// <para>更新Stream水印模版的配置</para>
        /// <para>默认继承域名下配置的水印模板，也可以通过本接口，对某个Stream单独设置水印模板。</para>
        /// <para>如果watermarks为空，则更新结果为null，继承域名下的水印模板配置。</para>
        /// </summary>
        /// <param name="request">XGLssStreamUpdateWatermarksRequest</param>
        /// <returns>异步任务XGLssResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGLssResponse> StreamUpdateWatermarksAsync(XGLssStreamUpdateWatermarksRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.PlayDomain, nameof(request.PlayDomain));
            AssertStringNotNullOrEmpty(request.App, nameof(request.App));
            AssertStringNotNullOrEmpty(request.Stream, nameof(request.Stream));
            AssertNotNullOrEmpty(request.Watermarks, nameof(request.Watermarks));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.POST, request.LssVersion.ToString(), DOMAIN, request.PlayDomain.Trim(), APP, request.App.Trim(), STREAM, request.Stream.Trim());
            iternalRequest.AddParameter("watermark");
            XGLssResponse response = await InvokeHttpClientAsync<XGLssResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 更新Stream录制模版
        /// <para>更新Stream录制模版的配置</para>
        /// <para>默认继承域名下配置的录制模版，也可以通过本接口，对某个Stream单独设置录制模板。</para>
        /// <para>如果本接口recording为空，则更新结果为null，继承域名下的录制模板配置。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/LSS/s/ejwvyywbt#%E6%9B%B4%E6%96%B0stream%E5%BD%95%E5%88%B6%E6%A8%A1%E7%89%88 </para>
        /// </summary>
        /// <param name="playDomain">播放域名</param>
        /// <param name="app">App</param>
        /// <param name="stream">流名称</param>
        /// <param name="recording">更新录制模板</param>
        /// <returns>XGLssResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGLssResponse UpdateStreamRecording(string playDomain, string app, string stream, string recording)
        {
            AssertStringNotNullOrEmpty(playDomain, nameof(playDomain));
            AssertStringNotNullOrEmpty(app, nameof(app));
            AssertStringNotNullOrEmpty(stream, nameof(stream));
            AssertStringNotNullOrEmpty(recording, nameof(recording));
            XGLssUpdateStreamRecordingRequest request = new XGLssUpdateStreamRecordingRequest()
            {
                PlayDomain = playDomain,
                App = app,
                Stream = stream,
                Recording=recording
            };
            return UpdateStreamRecording(request);
        }

        /// <summary>
        /// 更新Stream录制模版
        /// <para>更新Stream录制模版的配置</para>
        /// <para>默认继承域名下配置的录制模版，也可以通过本接口，对某个Stream单独设置录制模板。</para>
        /// <para>如果本接口recording为空，则更新结果为null，继承域名下的录制模板配置。</para>
        /// </summary>
        /// <param name="playDomain">播放域名</param>
        /// <param name="app">App</param>
        /// <param name="stream">流名称</param>
        /// <param name="recording">更新录制模板</param>
        /// <returns>异步任务XGLssResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGLssResponse> UpdateStreamRecordingAsync(string playDomain, string app, string stream, string recording)
        {
            AssertStringNotNullOrEmpty(playDomain, nameof(playDomain));
            AssertStringNotNullOrEmpty(app, nameof(app));
            AssertStringNotNullOrEmpty(stream, nameof(stream));
            AssertStringNotNullOrEmpty(recording, nameof(recording));
            XGLssUpdateStreamRecordingRequest request = new XGLssUpdateStreamRecordingRequest()
            {
                PlayDomain = playDomain,
                App = app,
                Stream = stream,
                Recording = recording
            };
            return await UpdateStreamRecordingAsync(request);
        }

        /// <summary>
        /// 更新Stream录制模版
        /// <para>更新Stream录制模版的配置</para>
        /// <para>默认继承域名下配置的录制模版，也可以通过本接口，对某个Stream单独设置录制模板。</para>
        /// <para>如果本接口recording为空，则更新结果为null，继承域名下的录制模板配置。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/LSS/s/ejwvyywbt#%E6%9B%B4%E6%96%B0stream%E5%BD%95%E5%88%B6%E6%A8%A1%E7%89%88 </para>
        /// </summary>
        /// <param name="request">XGLssUpdateStreamRecordingRequest</param>
        /// <returns>XGLssResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGLssResponse UpdateStreamRecording(XGLssUpdateStreamRecordingRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.PlayDomain, nameof(request.PlayDomain));
            AssertStringNotNullOrEmpty(request.App, nameof(request.App));
            AssertStringNotNullOrEmpty(request.Stream, nameof(request.Stream));
            AssertStringNotNullOrEmpty(request.Recording, nameof(request.Recording));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.PUT, request.LssVersion.ToString(), DOMAIN, request.PlayDomain.Trim(), APP, request.App.Trim(), STREAM, request.Stream.Trim());
            iternalRequest.AddParameter("recording",request.Recording.Trim());
            XGLssResponse response = InvokeHttpClient<XGLssResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 更新Stream录制模版
        /// <para>更新Stream录制模版的配置</para>
        /// <para>默认继承域名下配置的录制模版，也可以通过本接口，对某个Stream单独设置录制模板。</para>
        /// <para>如果本接口recording为空，则更新结果为null，继承域名下的录制模板配置。</para>
        /// </summary>
        /// <param name="request">XGLssUpdateStreamRecordingRequest</param>
        /// <returns>异步任务XGLssResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGLssResponse> UpdateStreamRecordingAsync(XGLssUpdateStreamRecordingRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.PlayDomain, nameof(request.PlayDomain));
            AssertStringNotNullOrEmpty(request.App, nameof(request.App));
            AssertStringNotNullOrEmpty(request.Stream, nameof(request.Stream));
            AssertStringNotNullOrEmpty(request.Recording, nameof(request.Recording));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.PUT, request.LssVersion.ToString(), DOMAIN, request.PlayDomain.Trim(), APP, request.App.Trim(), STREAM, request.Stream.Trim());
            iternalRequest.AddParameter("recording", request.Recording.Trim());
            XGLssResponse response = await InvokeHttpClientAsync<XGLssResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 更新stream转码模版
        /// <para>更新stream转码模版的配置</para>
        /// <para>默认继承域名下配置的转码模版，也可以通过本接口，对某个Stream单独设置转码模板。</para>
        /// <para>如果本接口presets为空，则更新结果为null，继承域名下的转码模板配置。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/LSS/s/ejwvyywbt#%E6%9B%B4%E6%96%B0stream%E8%BD%AC%E7%A0%81%E6%A8%A1%E7%89%88 </para>
        /// </summary>
        /// <param name="playDomain">播放域名</param>
        /// <param name="app">App</param>
        /// <param name="stream">流名称</param>
        /// <param name="l1">L1线路下使用的转码模板名称</param>
        /// <param name="l2">L2线路下使用的转码模板名称</param>
        /// <param name="l3">L3线路下使用的转码模板名称</param>
        /// <param name="l4">L4线路下使用的转码模板名称</param>
        /// <returns>XGLssResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGLssResponse UpdateStreamTranscoding(string playDomain, string app, string stream,
            string l1=null, string l2=null, string l3=null, string l4=null)
        {
            AssertStringNotNullOrEmpty(playDomain, nameof(playDomain));
            AssertStringNotNullOrEmpty(app, nameof(app));
            AssertStringNotNullOrEmpty(stream, nameof(stream));
            XGLssUpdateStreamTranscodingRequest request = new XGLssUpdateStreamTranscodingRequest()
            {
                PlayDomain = playDomain,
                App = app,
                Stream = stream,
                Presets=new XGLssStreamTranscodingPresets() {
                    L1=l1,
                    L2=l2,
                    L3=l3,
                    L4=l4
                }
            };
            return UpdateStreamTranscoding(request);
        }

        /// <summary>
        /// 更新stream转码模版
        /// <para>更新stream转码模版的配置</para>
        /// <para>默认继承域名下配置的转码模版，也可以通过本接口，对某个Stream单独设置转码模板。</para>
        /// <para>如果本接口presets为空，则更新结果为null，继承域名下的转码模板配置。</para>
        /// </summary>
        /// <param name="playDomain">播放域名</param>
        /// <param name="app">App</param>
        /// <param name="stream">流名称</param>
        /// <param name="l1">L1线路下使用的转码模板名称</param>
        /// <param name="l2">L2线路下使用的转码模板名称</param>
        /// <param name="l3">L3线路下使用的转码模板名称</param>
        /// <param name="l4">L4线路下使用的转码模板名称</param>
        /// <returns>异步任务XGLssResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGLssResponse> UpdateStreamTranscodingAsync(string playDomain, string app, string stream,
            string l1 = null, string l2 = null, string l3 = null, string l4 = null)
        {
            AssertStringNotNullOrEmpty(playDomain, nameof(playDomain));
            AssertStringNotNullOrEmpty(app, nameof(app));
            AssertStringNotNullOrEmpty(stream, nameof(stream));
            XGLssUpdateStreamTranscodingRequest request = new XGLssUpdateStreamTranscodingRequest()
            {
                PlayDomain = playDomain,
                App = app,
                Stream = stream,
                Presets = new XGLssStreamTranscodingPresets()
                {
                    L1 = l1,
                    L2 = l2,
                    L3 = l3,
                    L4 = l4
                }
            };
            return await UpdateStreamTranscodingAsync(request);
        }

        /// <summary>
        /// 更新stream转码模版
        /// <para>更新stream转码模版的配置</para>
        /// <para>默认继承域名下配置的转码模版，也可以通过本接口，对某个Stream单独设置转码模板。</para>
        /// <para>如果本接口presets为空，则更新结果为null，继承域名下的转码模板配置。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/LSS/s/ejwvyywbt#%E6%9B%B4%E6%96%B0stream%E8%BD%AC%E7%A0%81%E6%A8%A1%E7%89%88 </para>
        /// </summary>
        /// <param name="request">XGLssUpdateStreamTranscodingRequest</param>
        /// <returns>XGLssResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGLssResponse UpdateStreamTranscoding(XGLssUpdateStreamTranscodingRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.PlayDomain, nameof(request.PlayDomain));
            AssertStringNotNullOrEmpty(request.App, nameof(request.App));
            AssertStringNotNullOrEmpty(request.Stream, nameof(request.Stream));
            AssertNotNullOrEmpty(request.Presets, nameof(request.Presets));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.POST, request.LssVersion.ToString(), DOMAIN, request.PlayDomain.Trim(), APP, request.App.Trim(), STREAM, request.Stream.Trim());
            iternalRequest.AddParameter("presets");
            XGLssResponse response = InvokeHttpClient<XGLssResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 更新stream转码模版
        /// <para>更新stream转码模版的配置</para>
        /// <para>默认继承域名下配置的转码模版，也可以通过本接口，对某个Stream单独设置转码模板。</para>
        /// <para>如果本接口presets为空，则更新结果为null，继承域名下的转码模板配置。</para>
        /// </summary>
        /// <param name="request">XGLssUpdateStreamTranscodingRequest</param>
        /// <returns>异步任务XGLssResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGLssResponse> UpdateStreamTranscodingAsync(XGLssUpdateStreamTranscodingRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.PlayDomain, nameof(request.PlayDomain));
            AssertStringNotNullOrEmpty(request.App, nameof(request.App));
            AssertStringNotNullOrEmpty(request.Stream, nameof(request.Stream));
            AssertNotNullOrEmpty(request.Presets, nameof(request.Presets));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.POST, request.LssVersion.ToString(), DOMAIN, request.PlayDomain.Trim(), APP, request.App.Trim(), STREAM, request.Stream.Trim());
            iternalRequest.AddParameter("presets");
            XGLssResponse response = await InvokeHttpClientAsync<XGLssResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 更新stream目标推流地址
        /// <para>接口文档：https://cloud.baidu.com/doc/LSS/s/ejwvyywbt#%E6%9B%B4%E6%96%B0stream%E7%9B%AE%E6%A0%87%E6%8E%A8%E6%B5%81%E5%9C%B0%E5%9D%80 </para>
        /// </summary>
        /// <param name="playDomain">播放域名</param>
        /// <param name="app">App</param>
        /// <param name="stream">流名称</param>
        /// <param name="destinationPushUrl">目标推流地址</param>
        /// <returns>XGLssResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGLssResponse UpdateStreamDestinationPushUrl(string playDomain, string app, string stream,
            string destinationPushUrl)
        {
            AssertStringNotNullOrEmpty(playDomain, nameof(playDomain));
            AssertStringNotNullOrEmpty(app, nameof(app));
            AssertStringNotNullOrEmpty(stream, nameof(stream));
            AssertStringNotNullOrEmpty(destinationPushUrl, nameof(destinationPushUrl));
            XGLssUpdateStreamDestinationPushUrlRequest request = new XGLssUpdateStreamDestinationPushUrlRequest()
            {
                PlayDomain = playDomain,
                App = app,
                Stream = stream,
                DestinationPushUrl=destinationPushUrl
            };
            return UpdateStreamDestinationPushUrl(request);
        }

        /// <summary>
        /// 更新stream目标推流地址
        /// </summary>
        /// <param name="playDomain">播放域名</param>
        /// <param name="app">App</param>
        /// <param name="stream">流名称</param>
        /// <param name="destinationPushUrl">目标推流地址</param>
        /// <returns>异步任务XGLssResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGLssResponse> UpdateStreamDestinationPushUrlAsync(string playDomain, string app, string stream,
            string destinationPushUrl)
        {
            AssertStringNotNullOrEmpty(playDomain, nameof(playDomain));
            AssertStringNotNullOrEmpty(app, nameof(app));
            AssertStringNotNullOrEmpty(stream, nameof(stream));
            AssertStringNotNullOrEmpty(destinationPushUrl, nameof(destinationPushUrl));
            XGLssUpdateStreamDestinationPushUrlRequest request = new XGLssUpdateStreamDestinationPushUrlRequest()
            {
                PlayDomain = playDomain,
                App = app,
                Stream = stream,
                DestinationPushUrl = destinationPushUrl
            };
            return await UpdateStreamDestinationPushUrlAsync(request);
        }

        /// <summary>
        /// 更新stream目标推流地址
        /// <para>接口文档：https://cloud.baidu.com/doc/LSS/s/ejwvyywbt#%E6%9B%B4%E6%96%B0stream%E7%9B%AE%E6%A0%87%E6%8E%A8%E6%B5%81%E5%9C%B0%E5%9D%80 </para>
        /// </summary>
        /// <param name="request">XGLssUpdateStreamDestinationPushUrlRequest</param>
        /// <returns>XGLssResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGLssResponse UpdateStreamDestinationPushUrl(XGLssUpdateStreamDestinationPushUrlRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.PlayDomain, nameof(request.PlayDomain));
            AssertStringNotNullOrEmpty(request.App, nameof(request.App));
            AssertStringNotNullOrEmpty(request.Stream, nameof(request.Stream));
            AssertNotNullOrEmpty(request.DestinationPushUrl, nameof(request.DestinationPushUrl));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.POST, request.LssVersion.ToString(), DOMAIN, request.PlayDomain.Trim(), APP, request.App.Trim(), STREAM, request.Stream.Trim());
            iternalRequest.AddParameter("destinationPushUrl",request.DestinationPushUrl.Trim());
            XGLssResponse response = InvokeHttpClient<XGLssResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 更新stream目标推流地址
        /// </summary>
        /// <param name="request">XGLssUpdateStreamDestinationPushUrlRequest</param>
        /// <returns>异步任务XGLssResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGLssResponse> UpdateStreamDestinationPushUrlAsync(XGLssUpdateStreamDestinationPushUrlRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.PlayDomain, nameof(request.PlayDomain));
            AssertStringNotNullOrEmpty(request.App, nameof(request.App));
            AssertStringNotNullOrEmpty(request.Stream, nameof(request.Stream));
            AssertNotNullOrEmpty(request.DestinationPushUrl, nameof(request.DestinationPushUrl));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.POST, request.LssVersion.ToString(), DOMAIN, request.PlayDomain.Trim(), APP, request.App.Trim(), STREAM, request.Stream.Trim());
            iternalRequest.AddParameter("destinationPushUrl", request.DestinationPushUrl.Trim());
            XGLssResponse response = await InvokeHttpClientAsync<XGLssResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询实时直播源信息
        /// <para>查询某条正在直播推流的直播源详细信息，本接口仅对streamingStatus=STREAMING的stream有效</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/LSS/s/ejwvyywbt#%E5%AE%9E%E6%97%B6%E7%9B%B4%E6%92%AD%E6%BA%90%E4%BF%A1%E6%81%AF </para>
        /// </summary>
        /// <param name="playDomain">播放域名</param>
        /// <param name="app">App</param>
        /// <param name="stream">流名称</param>
        /// <returns>XGLssQueryStreamSourceInfoResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGLssQueryStreamSourceInfoResponse QueryStreamSourceInfo(string playDomain, string app, string stream)
        {
            AssertStringNotNullOrEmpty(playDomain, nameof(playDomain));
            AssertStringNotNullOrEmpty(app, nameof(app));
            AssertStringNotNullOrEmpty(stream, nameof(stream));
            XGLssStreamRequest request = new XGLssStreamRequest()
            {
                PlayDomain = playDomain,
                App = app,
                Stream = stream
            };
            return QueryStreamSourceInfo(request);
        }

        /// <summary>
        /// 查询实时直播源信息
        /// <para>查询某条正在直播推流的直播源详细信息，本接口仅对streamingStatus=STREAMING的stream有效</para>
        /// </summary>
        /// <param name="playDomain">播放域名</param>
        /// <param name="app">App</param>
        /// <param name="stream">流名称</param>
        /// <returns>异步任务XGLssQueryStreamSourceInfoResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGLssQueryStreamSourceInfoResponse> QueryStreamSourceInfoAsync(string playDomain, string app, string stream)
        {
            AssertStringNotNullOrEmpty(playDomain, nameof(playDomain));
            AssertStringNotNullOrEmpty(app, nameof(app));
            AssertStringNotNullOrEmpty(stream, nameof(stream));
            XGLssStreamRequest request = new XGLssStreamRequest()
            {
                PlayDomain = playDomain,
                App = app,
                Stream = stream
            };
            return await QueryStreamSourceInfoAsync(request);
        }

        /// <summary>
        /// 查询实时直播源信息
        /// <para>查询某条正在直播推流的直播源详细信息，本接口仅对streamingStatus=STREAMING的stream有效</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/LSS/s/ejwvyywbt#%E5%AE%9E%E6%97%B6%E7%9B%B4%E6%92%AD%E6%BA%90%E4%BF%A1%E6%81%AF </para>
        /// </summary>
        /// <param name="request">XGLssStreamRequest</param>
        /// <returns>XGLssQueryStreamSourceInfoResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGLssQueryStreamSourceInfoResponse QueryStreamSourceInfo(XGLssStreamRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.PlayDomain, nameof(request.PlayDomain));
            AssertStringNotNullOrEmpty(request.App, nameof(request.App));
            AssertStringNotNullOrEmpty(request.Stream, nameof(request.Stream));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.LssVersion.ToString(), DOMAIN, request.PlayDomain.Trim(), APP, request.App.Trim(), STREAM, request.Stream.Trim());
            iternalRequest.AddParameter("sourceInfo");
            XGLssQueryStreamSourceInfoResponse response = InvokeHttpClient<XGLssQueryStreamSourceInfoResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询实时直播源信息
        /// <para>查询某条正在直播推流的直播源详细信息，本接口仅对streamingStatus=STREAMING的stream有效</para>
        /// </summary>
        /// <param name="request">XGLssStreamRequest</param>
        /// <returns>异步任务XGLssQueryStreamSourceInfoResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGLssQueryStreamSourceInfoResponse> QueryStreamSourceInfoAsync(XGLssStreamRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.PlayDomain, nameof(request.PlayDomain));
            AssertStringNotNullOrEmpty(request.App, nameof(request.App));
            AssertStringNotNullOrEmpty(request.Stream, nameof(request.Stream));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.LssVersion.ToString(), DOMAIN, request.PlayDomain.Trim(), APP, request.App.Trim(), STREAM, request.Stream.Trim());
            iternalRequest.AddParameter("sourceInfo");
            XGLssQueryStreamSourceInfoResponse response = await InvokeHttpClientAsync<XGLssQueryStreamSourceInfoResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询域名下实时直播源信息
        /// <para>查询域名下所有正在直播推流过程的直播源详细信息，本接口仅对streamingStatus=STREAMING的stream有效。</para>
        /// <para>https://cloud.baidu.com/doc/LSS/s/ejwvyywbt#%E5%9F%9F%E5%90%8D%E4%B8%8B%E5%AE%9E%E6%97%B6%E7%9B%B4%E6%92%AD%E6%BA%90%E4%BF%A1%E6%81%AF </para>
        /// </summary>
        /// <param name="domain">域名</param>
        /// <returns>XGLssDomainListStreamsSourceInfoResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGLssDomainListStreamsSourceInfoResponse ListStreamsSourceInfo(string domain)
        {
            AssertStringNotNullOrEmpty(domain, nameof(domain));
            XGLssBaseRequest request = new XGLssBaseRequest();
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.LssVersion.ToString(), DOMAIN, domain.Trim(), "sourceInfo");
            XGLssDomainListStreamsSourceInfoResponse response = InvokeHttpClient<XGLssDomainListStreamsSourceInfoResponse>(iternalRequest, LSS_HANDLERS);
            return response;
        }

        /// <summary>
        /// 查询域名下实时直播源信息
        /// <para>查询域名下所有正在直播推流过程的直播源详细信息，本接口仅对streamingStatus=STREAMING的stream有效。</para>
        /// </summary>
        /// <param name="domain">域名</param>
        /// <returns>异步任务XGLssDomainListStreamsSourceInfoResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGLssDomainListStreamsSourceInfoResponse> ListStreamsSourceInfoAsync(string domain)
        {
            AssertStringNotNullOrEmpty(domain, nameof(domain));
            XGLssBaseRequest request = new XGLssBaseRequest();
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.LssVersion.ToString(), DOMAIN, domain.Trim(), "sourceInfo");
            XGLssDomainListStreamsSourceInfoResponse response = await InvokeHttpClientAsync<XGLssDomainListStreamsSourceInfoResponse>(iternalRequest, LSS_HANDLERS);
            return response;
        }

        /// <summary>
        /// 查看实时流推流url参数
        /// <para>查询某条正在直播推流的推流url参数信息</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/LSS/s/ejwvyywbt#%E6%9F%A5%E7%9C%8B%E5%AE%9E%E6%97%B6%E6%B5%81%E6%8E%A8%E6%B5%81url%E5%8F%82%E6%95%B0 </para>
        /// </summary>
        /// <param name="playDomain">播放域名</param>
        /// <param name="app">App</param>
        /// <param name="stream">流名称</param>
        /// <returns>XGLssQueryPushUrlParamsResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGLssQueryPushUrlParamsResponse QueryPushUrlParams(string playDomain, string app, string stream)
        {
            AssertStringNotNullOrEmpty(playDomain, nameof(playDomain));
            AssertStringNotNullOrEmpty(app, nameof(app));
            AssertStringNotNullOrEmpty(stream, nameof(stream));
            XGLssStreamRequest request = new XGLssStreamRequest()
            {
                PlayDomain = playDomain,
                App = app,
                Stream = stream
            };
            return QueryPushUrlParams(request);
        }

        /// <summary>
        /// 查看实时流推流url参数
        /// <para>查询某条正在直播推流的推流url参数信息</para>
        /// </summary>
        /// <param name="playDomain">播放域名</param>
        /// <param name="app">App</param>
        /// <param name="stream">流名称</param>
        /// <returns>异步任务XGLssQueryPushUrlParamsResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGLssQueryPushUrlParamsResponse> QueryPushUrlParamsAsync(string playDomain, string app, string stream)
        {
            AssertStringNotNullOrEmpty(playDomain, nameof(playDomain));
            AssertStringNotNullOrEmpty(app, nameof(app));
            AssertStringNotNullOrEmpty(stream, nameof(stream));
            XGLssStreamRequest request = new XGLssStreamRequest()
            {
                PlayDomain = playDomain,
                App = app,
                Stream = stream
            };
            return await QueryPushUrlParamsAsync(request);
        }

        /// <summary>
        /// 查看实时流推流url参数
        /// <para>查询某条正在直播推流的推流url参数信息</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/LSS/s/ejwvyywbt#%E6%9F%A5%E7%9C%8B%E5%AE%9E%E6%97%B6%E6%B5%81%E6%8E%A8%E6%B5%81url%E5%8F%82%E6%95%B0 </para>
        /// </summary>
        /// <param name="request">XGLssStreamRequest</param>
        /// <returns>XGLssQueryPushUrlParamsResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGLssQueryPushUrlParamsResponse QueryPushUrlParams(XGLssStreamRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.PlayDomain, nameof(request.PlayDomain));
            AssertStringNotNullOrEmpty(request.App, nameof(request.App));
            AssertStringNotNullOrEmpty(request.Stream, nameof(request.Stream));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.LssVersion.ToString(), DOMAIN, request.PlayDomain.Trim(), APP, request.App.Trim(), STREAM, request.Stream.Trim(), "params");
            XGLssQueryPushUrlParamsResponse response = InvokeHttpClient<XGLssQueryPushUrlParamsResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查看实时流推流url参数
        /// <para>查询某条正在直播推流的推流url参数信息</para>
        /// </summary>
        /// <param name="request">XGLssStreamRequest</param>
        /// <returns>异步任务XGLssQueryPushUrlParamsResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGLssQueryPushUrlParamsResponse> QueryPushUrlParamsAsync(XGLssStreamRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.PlayDomain, nameof(request.PlayDomain));
            AssertStringNotNullOrEmpty(request.App, nameof(request.App));
            AssertStringNotNullOrEmpty(request.Stream, nameof(request.Stream));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.LssVersion.ToString(), DOMAIN, request.PlayDomain.Trim(), APP, request.App.Trim(), STREAM, request.Stream.Trim(), "params");
            XGLssQueryPushUrlParamsResponse response = await InvokeHttpClientAsync<XGLssQueryPushUrlParamsResponse>(iternalRequest);
            return response;
        }

        #endregion

        #region 模板接口



        #endregion

        #region 统计接口



        #endregion

        #region 通知接口



        #endregion

        #region 录制视频裁剪接口



        #endregion

        #region 日志下载接口



        #endregion

        #region

        protected XGBceIternalRequest CreateRequest(XGAbstractBceRequest bceRequest, BceHttpMethod httpMethod, params string[] pathVariables)
        {
            List<string> pathComponents = new List<string>() { };
            if (pathVariables != null)
                pathComponents.AddRange(pathVariables);

            XGBceIternalRequest iternalRequest = new XGBceIternalRequest(httpMethod, HttpUtil.AppendUri(Endpoint, pathComponents.ToArray()))
            {
                Credentials = bceRequest.Credentials
            };
            iternalRequest.AddMoreHeader(XGBceHeaders.USER_AGENT, config.UserAgent);
            if (httpMethod == BceHttpMethod.POST || httpMethod == BceHttpMethod.PUT)
                FillRequestPayload(iternalRequest, bceRequest);
            return iternalRequest;
        }

        protected XGBceIternalRequest FillRequestPayload(XGBceIternalRequest iternalRequest, XGAbstractBceRequest bceRequest)
        {
            string strJson = JsonConvert.SerializeObject(bceRequest);
            byte[] requestJson;
            try
            {
                requestJson = System.Text.Encoding.UTF8.GetBytes(strJson);
            }
            catch (Exception ex)
            {
                throw new XGBceClientException("不支持编码：", ex);
            }

            iternalRequest.Content = new StringContent(strJson);
            iternalRequest.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(mediaType: "application/json") { CharSet = "utf-8" };
            iternalRequest.AddMoreHeader(XGBceHeaders.BCE_DATE, HttpUtil.FormatUTCTime(DateTime.Now));
            return iternalRequest;
        }

        #endregion

        #region

        private static void AssertNotNullOrEmpty(object param, string nameofParam = null, string errorMessage = " 不能为空")
        {
            if (param == null)
            {
                if (string.IsNullOrEmpty(nameofParam) || string.IsNullOrWhiteSpace(nameofParam))
                    nameofParam = nameof(param);
                errorMessage = nameofParam + errorMessage;
                throw new ArgumentNullException(nameofParam, errorMessage);
            }
        }

        private static void AssertStringNotNullOrEmpty(string param, string nameofParam=null,  string errorMessage= " 不能为空")
        {
            
            if (string.IsNullOrEmpty(param) || string.IsNullOrWhiteSpace(param))
            {
                if (string.IsNullOrEmpty(nameofParam) || string.IsNullOrWhiteSpace(nameofParam))
                    nameofParam = nameof(param);
                errorMessage = nameofParam + errorMessage;
                throw new ArgumentNullException(nameofParam, errorMessage);
            }
        }

        private static void AssertDicNotNullOrEmpty(IDictionary param, string nameofParam = null, string errorMessage= " 不能为空")
        {
            if (param == null || param.Count < 1)
            {
                if (string.IsNullOrEmpty(nameofParam) || string.IsNullOrWhiteSpace(nameofParam))
                    nameofParam = nameof(param);
                errorMessage = nameofParam + errorMessage;
                throw new ArgumentNullException(nameof(param), errorMessage);
            }
        }

        private static void AssertStringArrayNotNullOrEmpty(string[] param, string nameofParam = null, string errorMessage= " 不能为空")
        {
            if (!(param != null&& param.Length>0))
            {
                if (string.IsNullOrEmpty(nameofParam) || string.IsNullOrWhiteSpace(nameofParam))
                    nameofParam = nameof(param);
                errorMessage = nameofParam + errorMessage;
                throw new ArgumentNullException(nameof(param),errorMessage);
            }
        }

        private static void AssertStringListNotNullOrEmpty(List<string> param, string nameofParam = null, string errorMessage= " 不能为空")
        {
            if (param != null && param.Count > 0)
            {
                return;
            }
            if (string.IsNullOrEmpty(nameofParam) || string.IsNullOrWhiteSpace(nameofParam))
                nameofParam = nameof(param);
            errorMessage = nameofParam + errorMessage;
            param.ForEach((s) => { if (string.IsNullOrEmpty(s) || string.IsNullOrWhiteSpace(s)) throw new ArgumentNullException(nameof(param), errorMessage); });
            throw new ArgumentNullException(nameof(param), errorMessage);
        }

        private static void AssertIntListNotNullOrEmpty(List<int> param, string nameofParam = null, string errorMessage= " 不能为空")
        {
            if (!(param != null&& param.Count>0))
            {
                if (string.IsNullOrEmpty(nameofParam) || string.IsNullOrWhiteSpace(nameofParam))
                    nameofParam = nameof(param);
                errorMessage = nameofParam + errorMessage;
                throw new ArgumentNullException(nameof(param), errorMessage);
            }
        }

        #endregion
    }
}
