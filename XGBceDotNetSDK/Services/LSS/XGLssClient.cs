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
        private static readonly string RECORDING = "recording";  //录制模板
        private static readonly string WATERMARK = "watermark";  //水印模板
        private static readonly string THUMBNAIL = "thumbnail";  //缩略图模板
        private static readonly string STATISTICS = "statistics";  //统计
        private static readonly string NOTIFICATION = "notification";  //通知

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

        /// <summary>
        /// 查询录制模板
        /// <para>查询用户指定录制模板的详情。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/LSS/s/Sjwvyyuxb#%E6%9F%A5%E8%AF%A2%E5%BD%95%E5%88%B6%E6%A8%A1%E6%9D%BF </para>
        /// </summary>
        /// <param name="name">录制模板名称</param>
        /// <returns>XGLssQueryRecordingResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGLssQueryRecordingResponse QueryRecording(string name)
        {
            AssertStringNotNullOrEmpty(name, nameof(name));
            XGLssBaseRequest request = new XGLssBaseRequest();
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.LssVersion.ToString(), RECORDING, name.Trim());
            XGLssQueryRecordingResponse response = InvokeHttpClient<XGLssQueryRecordingResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询录制模板
        /// <para>查询用户指定录制模板的详情。</para>
        /// </summary>
        /// <param name="name">录制模板名称</param>
        /// <returns>异步任务XGLssQueryRecordingResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGLssQueryRecordingResponse> QueryRecordingAsync(string name)
        {
            AssertStringNotNullOrEmpty(name, nameof(name));
            XGLssBaseRequest request = new XGLssBaseRequest();
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.LssVersion.ToString(), RECORDING, name.Trim());
            XGLssQueryRecordingResponse response = await InvokeHttpClientAsync<XGLssQueryRecordingResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 录制模板列表
        /// <para>查询用户已创建的所有录制模板详情。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/LSS/s/Sjwvyyuxb#%E5%BD%95%E5%88%B6%E6%A8%A1%E6%9D%BF%E5%88%97%E8%A1%A8 </para>
        /// </summary>
        /// <returns>XGLssListRecordingsResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGLssListRecordingsResponse ListRecordings()
        {
            XGLssBaseRequest request = new XGLssBaseRequest();
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.LssVersion.ToString(), RECORDING);
            XGLssListRecordingsResponse response = InvokeHttpClient<XGLssListRecordingsResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 录制模板列表
        /// <para>查询用户已创建的所有录制模板详情。</para>
        /// </summary>
        /// <returns>异步任务XGLssListRecordingsResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGLssListRecordingsResponse> ListRecordingsAsync()
        {
            XGLssBaseRequest request = new XGLssBaseRequest();
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.LssVersion.ToString(), RECORDING);
            XGLssListRecordingsResponse response = await InvokeHttpClientAsync<XGLssListRecordingsResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 创建图片水印模板
        /// <para>通过定义水印的详细参数集合（大小、位置等）来创建图片水印模板。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/LSS/s/Sjwvyyuxb#%E5%88%9B%E5%BB%BA%E5%9B%BE%E7%89%87%E6%B0%B4%E5%8D%B0%E6%A8%A1%E6%9D%BF </para>
        /// </summary>
        /// <param name="name">水印名称</param>
        /// <param name="content">图片文件base64编码后字符串</param>
        /// <returns>XGLssResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGLssResponse CreateWatermark(string name, string content)
        {
            AssertNotNullOrEmpty(name, nameof(name));
            AssertStringNotNullOrEmpty(content, nameof(content));

            XGLssCreateWatermarkRequest request = new XGLssCreateWatermarkRequest()
            {
                Name=name,
                Content=content
            };
            return CreateWatermark(request);
        }

        /// <summary>
        /// 创建图片水印模板
        /// <para>通过定义水印的详细参数集合（大小、位置等）来创建图片水印模板。</para>
        /// </summary>
        /// <param name="name">水印名称</param>
        /// <param name="content">图片文件base64编码后字符串</param>
        /// <returns>异步任务XGLssResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGLssResponse> CreateWatermarkAsync(string name, string content)
        {
            AssertNotNullOrEmpty(name, nameof(name));
            AssertStringNotNullOrEmpty(content, nameof(content));

            XGLssCreateWatermarkRequest request = new XGLssCreateWatermarkRequest()
            {
                Name = name,
                Content = content
            };
            return await CreateWatermarkAsync(request);
        }

        /// <summary>
        /// 创建图片水印模板
        /// <para>通过定义水印的详细参数集合（大小、位置等）来创建图片水印模板。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/LSS/s/Sjwvyyuxb#%E5%88%9B%E5%BB%BA%E5%9B%BE%E7%89%87%E6%B0%B4%E5%8D%B0%E6%A8%A1%E6%9D%BF </para>
        /// </summary>
        /// <param name="request">XGLssCreateWatermarkRequest</param>
        /// <returns>XGLssResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGLssResponse CreateWatermark(XGLssCreateWatermarkRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.Name,nameof(request.Name));
            AssertStringNotNullOrEmpty(request.Content, nameof(request.Content));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.POST, request.LssVersion.ToString(), WATERMARK, "image");
            XGLssQueryPushUrlParamsResponse response = InvokeHttpClient<XGLssQueryPushUrlParamsResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 创建图片水印模板
        /// <para>通过定义水印的详细参数集合（大小、位置等）来创建图片水印模板。</para>
        /// </summary>
        /// <param name="request">XGLssCreateWatermarkRequest</param>
        /// <returns>异步任务XGLssResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGLssResponse> CreateWatermarkAsync(XGLssCreateWatermarkRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.Name, nameof(request.Name));
            AssertStringNotNullOrEmpty(request.Content, nameof(request.Content));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.POST, request.LssVersion.ToString(), WATERMARK, "image");
            XGLssQueryPushUrlParamsResponse response = await InvokeHttpClientAsync<XGLssQueryPushUrlParamsResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询图片水印
        /// <para>通过指定水印名称查询特定图片水印的详细信息，包括图片URL、大小、位置、创建时间等。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/LSS/s/Sjwvyyuxb#%E6%9F%A5%E8%AF%A2%E5%9B%BE%E7%89%87%E6%B0%B4%E5%8D%B0 </para>
        /// </summary>
        /// <param name="name">水印名称</param>
        /// <returns>XGLssQueryWatermarkResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGLssQueryWatermarkResponse QueryWatermark(string name)
        {
            AssertNotNullOrEmpty(name, nameof(name));

            XGLssBaseRequest request = new XGLssBaseRequest();
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.LssVersion.ToString(), WATERMARK, "image",name.Trim());
            XGLssQueryWatermarkResponse response = InvokeHttpClient<XGLssQueryWatermarkResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询图片水印
        /// <para>通过指定水印名称查询特定图片水印的详细信息，包括图片URL、大小、位置、创建时间等。</para>
        /// </summary>
        /// <param name="name">水印名称</param>
        /// <returns>异步任务XGLssQueryWatermarkResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGLssQueryWatermarkResponse> QueryWatermarkAsync(string name)
        {
            AssertNotNullOrEmpty(name, nameof(name));

            XGLssBaseRequest request = new XGLssBaseRequest();
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.LssVersion.ToString(), WATERMARK, "image", name.Trim());
            XGLssQueryWatermarkResponse response = await InvokeHttpClientAsync<XGLssQueryWatermarkResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询图片水印列表
        /// <para>查询用户的所有图片水印模板的详细信息。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/LSS/s/Sjwvyyuxb#%E6%9F%A5%E8%AF%A2%E5%9B%BE%E7%89%87%E6%B0%B4%E5%8D%B0%E5%88%97%E8%A1%A8 </para>
        /// </summary>
        /// <returns>XGLssListWatermarksResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGLssListWatermarksResponse ListWatermarks()
        {
            XGLssBaseRequest request = new XGLssBaseRequest();
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.LssVersion.ToString(), WATERMARK, "image");
            XGLssListWatermarksResponse response = InvokeHttpClient<XGLssListWatermarksResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询图片水印列表
        /// <para>查询用户的所有图片水印模板的详细信息。</para>
        /// </summary>
        /// <returns>异步任务XGLssListWatermarksResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGLssListWatermarksResponse> ListWatermarksAsync()
        {
            XGLssBaseRequest request = new XGLssBaseRequest();
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.LssVersion.ToString(), WATERMARK, "image");
            XGLssListWatermarksResponse response = await InvokeHttpClientAsync<XGLssListWatermarksResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 删除图片水印
        /// <para>通过指定水印名称删除特定图片水印模板。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/LSS/s/Sjwvyyuxb#%E5%88%A0%E9%99%A4%E5%9B%BE%E7%89%87%E6%B0%B4%E5%8D%B0 </para>
        /// </summary>
        /// <param name="name">水印名称</param>
        /// <returns>XGLssResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGLssResponse DeleteWatermark(string name)
        {
            AssertNotNullOrEmpty(name, nameof(name));

            XGLssBaseRequest request = new XGLssBaseRequest();
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.DELETE, request.LssVersion.ToString(), WATERMARK, "image", name.Trim());
            XGLssResponse response = InvokeHttpClient<XGLssResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 删除图片水印
        /// <para>通过指定水印名称删除特定图片水印模板。</para>
        /// </summary>
        /// <param name="name">水印名称</param>
        /// <returns>异步任务XGLssResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGLssResponse> DeleteWatermarkAsync(string name)
        {
            AssertNotNullOrEmpty(name, nameof(name));

            XGLssBaseRequest request = new XGLssBaseRequest();
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.DELETE, request.LssVersion.ToString(), WATERMARK, "image", name.Trim());
            XGLssResponse response = await InvokeHttpClientAsync<XGLssResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 创建时间戳水印
        /// <para>通过定义水印的详细参数集合（时区、文字、背景、位置等）来创建时间戳水印模板。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/LSS/s/Sjwvyyuxb#%E5%88%9B%E5%BB%BA%E6%97%B6%E9%97%B4%E6%88%B3%E6%B0%B4%E5%8D%B0 </para>
        /// </summary>
        /// <param name="name">水印名称</param>
        /// <param name="timezone">时区</param>
        /// <param name="alpha">水印透明度</param>
        /// <param name="request">XGLssCreateTimestampWatermarkRequest</param>
        /// <returns>XGLssResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGLssResponse CreateTimestampWatermark(string name, XGLssTimezone? timezone=null, float? alpha=null)
        {
            AssertStringNotNullOrEmpty(name, nameof(name));
            XGLssCreateTimestampWatermarkRequest request = new XGLssCreateTimestampWatermarkRequest()
            {
                Name=name,
                Timezone=timezone,
                Alpha=alpha
            };
            return CreateTimestampWatermark(request);
        }

        /// <summary>
        /// 创建时间戳水印
        /// <para>通过定义水印的详细参数集合（时区、文字、背景、位置等）来创建时间戳水印模板。</para>
        /// </summary>
        /// <param name="name">水印名称</param>
        /// <param name="timezone">时区</param>
        /// <param name="alpha">水印透明度</param>
        /// <param name="request">XGLssCreateTimestampWatermarkRequest</param>
        /// <returns>异步任务XGLssResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGLssResponse> CreateTimestampWatermarkAsync(string name, XGLssTimezone? timezone = null, float? alpha = null)
        {
            AssertStringNotNullOrEmpty(name, nameof(name));
            XGLssCreateTimestampWatermarkRequest request = new XGLssCreateTimestampWatermarkRequest()
            {
                Name = name,
                Timezone = timezone,
                Alpha = alpha
            };
            return await CreateTimestampWatermarkAsync(request);
        }

        /// <summary>
        /// 创建时间戳水印
        /// <para>通过定义水印的详细参数集合（时区、文字、背景、位置等）来创建时间戳水印模板。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/LSS/s/Sjwvyyuxb#%E5%88%9B%E5%BB%BA%E6%97%B6%E9%97%B4%E6%88%B3%E6%B0%B4%E5%8D%B0 </para>
        /// </summary>
        /// <param name="request">XGLssCreateTimestampWatermarkRequest</param>
        /// <returns>XGLssResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGLssResponse CreateTimestampWatermark(XGLssCreateTimestampWatermarkRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.Name, nameof(request.Name));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.POST, request.LssVersion.ToString(), WATERMARK, "timestamp");
            XGLssResponse response = InvokeHttpClient<XGLssResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 创建时间戳水印
        /// <para>通过定义水印的详细参数集合（时区、文字、背景、位置等）来创建时间戳水印模板。</para>
        /// </summary>
        /// <param name="request">XGLssCreateTimestampWatermarkRequest</param>
        /// <returns>异步任务XGLssResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGLssResponse> CreateTimestampWatermarkAsync(XGLssCreateTimestampWatermarkRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.Name, nameof(request.Name));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.POST, request.LssVersion.ToString(), WATERMARK, "timestamp");
            XGLssResponse response = await InvokeHttpClientAsync<XGLssResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询时间戳水印
        /// <para>通过指定水印名称查询特定时间戳水印的详细信息，包括时间戳的时区、文字、位置、创建时间等。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/LSS/s/Sjwvyyuxb#%E6%9F%A5%E8%AF%A2%E6%97%B6%E9%97%B4%E6%88%B3%E6%B0%B4%E5%8D%B0 </para>
        /// </summary>
        /// <param name="name">水印名称</param>
        /// <returns>XGLssQueryTimestampWatermarkResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGLssQueryTimestampWatermarkResponse QueryTimestampWatermark(string name)
        {
            AssertNotNullOrEmpty(name, nameof(name));

            XGLssBaseRequest request = new XGLssBaseRequest();
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.LssVersion.ToString(), WATERMARK, "timestamp", name.Trim());
            XGLssQueryTimestampWatermarkResponse response = InvokeHttpClient<XGLssQueryTimestampWatermarkResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询时间戳水印
        /// <para>通过指定水印名称查询特定时间戳水印的详细信息，包括时间戳的时区、文字、位置、创建时间等。</para>
        /// </summary>
        /// <param name="name">水印名称</param>
        /// <returns>异步任务XGLssQueryTimestampWatermarkResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGLssQueryTimestampWatermarkResponse> QueryTimestampWatermarkAsync(string name)
        {
            AssertNotNullOrEmpty(name, nameof(name));

            XGLssBaseRequest request = new XGLssBaseRequest();
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.LssVersion.ToString(), WATERMARK, "timestamp", name.Trim());
            XGLssQueryTimestampWatermarkResponse response = await InvokeHttpClientAsync<XGLssQueryTimestampWatermarkResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询时间戳水印列表
        /// <para>查询用户的所有时间戳水印模板的详细信息。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/LSS/s/Sjwvyyuxb#%E6%9F%A5%E8%AF%A2%E6%97%B6%E9%97%B4%E6%88%B3%E5%88%97%E8%A1%A8 </para>
        /// </summary>
        /// <returns>XGLssListTimestampWatermarksResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGLssListTimestampWatermarksResponse ListTimestampWatermarks()
        {
            XGLssBaseRequest request = new XGLssBaseRequest();
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.LssVersion.ToString(), WATERMARK, "timestamp");
            XGLssListTimestampWatermarksResponse response = InvokeHttpClient<XGLssListTimestampWatermarksResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询时间戳水印列表
        /// <para>查询用户的所有时间戳水印模板的详细信息。</para>
        /// </summary>
        /// <returns>异步任务XGLssListTimestampWatermarksResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGLssListTimestampWatermarksResponse> ListTimestampWatermarksAsync()
        {
            XGLssBaseRequest request = new XGLssBaseRequest();
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.LssVersion.ToString(), WATERMARK, "timestamp");
            XGLssListTimestampWatermarksResponse response = await InvokeHttpClientAsync<XGLssListTimestampWatermarksResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 删除时间戳水印
        /// <para>通过指定水印名称删除特定时间戳水印模板。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/LSS/s/Sjwvyyuxb#%E5%88%A0%E9%99%A4%E6%97%B6%E9%97%B4%E6%88%B3 </para>
        /// </summary>
        /// <param name="name">水印名称</param>
        /// <returns>XGLssResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGLssResponse DeleteTimestampWatermark(string name)
        {
            AssertNotNullOrEmpty(name, nameof(name));

            XGLssBaseRequest request = new XGLssBaseRequest();
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.DELETE, request.LssVersion.ToString(), WATERMARK, "timestamp", name.Trim());
            XGLssResponse response = InvokeHttpClient<XGLssResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 删除时间戳水印
        /// <para>通过指定水印名称删除特定时间戳水印模板。</para>
        /// </summary>
        /// <param name="name">水印名称</param>
        /// <returns>异步任务XGLssResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGLssResponse> DeleteTimestampWatermarkAsync(string name)
        {
            AssertNotNullOrEmpty(name, nameof(name));

            XGLssBaseRequest request = new XGLssBaseRequest();
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.DELETE, request.LssVersion.ToString(), WATERMARK, "timestamp", name.Trim());
            XGLssResponse response = await InvokeHttpClientAsync<XGLssResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询缩略图模板
        /// <para>接口文档：https://cloud.baidu.com/doc/LSS/s/Sjwvyyuxb#%E6%9F%A5%E8%AF%A2%E7%BC%A9%E7%95%A5%E5%9B%BE%E6%A8%A1%E6%9D%BF </para>
        /// </summary>
        /// <param name="name">水印名称</param>
        /// <returns>XGLssQueryThumbnailResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGLssQueryThumbnailResponse QueryThumbnail(string name)
        {
            AssertNotNullOrEmpty(name, nameof(name));

            XGLssBaseRequest request = new XGLssBaseRequest();
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.LssVersion.ToString(), THUMBNAIL, name.Trim());
            XGLssQueryThumbnailResponse response = InvokeHttpClient<XGLssQueryThumbnailResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询缩略图模板
        /// </summary>
        /// <param name="name">水印名称</param>
        /// <returns>异步任务XGLssQueryThumbnailResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGLssQueryThumbnailResponse> QueryThumbnailAsync(string name)
        {
            AssertNotNullOrEmpty(name, nameof(name));

            XGLssBaseRequest request = new XGLssBaseRequest();
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.LssVersion.ToString(), THUMBNAIL, name.Trim());
            XGLssQueryThumbnailResponse response = await InvokeHttpClientAsync<XGLssQueryThumbnailResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 列举缩略图模板
        /// <para>接口文档：https://cloud.baidu.com/doc/LSS/s/Sjwvyyuxb#%E7%BC%A9%E7%95%A5%E5%9B%BE%E5%88%97%E8%A1%A8 </para>
        /// </summary>
        /// <returns>XGLssListThumbnailsResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGLssListThumbnailsResponse ListThumbnails()
        {
            XGLssBaseRequest request = new XGLssBaseRequest();
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.LssVersion.ToString(), THUMBNAIL);
            XGLssListThumbnailsResponse response = InvokeHttpClient<XGLssListThumbnailsResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 列举缩略图模板
        /// </summary>
        /// <returns>异步任务XGLssListThumbnailsResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGLssListThumbnailsResponse> ListThumbnailsAsync()
        {
            XGLssBaseRequest request = new XGLssBaseRequest();
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.LssVersion.ToString(), THUMBNAIL);
            XGLssListThumbnailsResponse response = await InvokeHttpClientAsync<XGLssListThumbnailsResponse>(iternalRequest);
            return response;
        }

        #endregion

        #region 统计接口

        /// <summary>
        /// 查询统计数据
        /// <para>查询特定Domain的统计数据。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/LSS/s/bjwvyyujl#%E6%9F%A5%E8%AF%A2%E7%BB%9F%E8%AE%A1%E6%95%B0%E6%8D%AE </para>
        /// </summary>
        /// <param name="playDomain">直播域名</param>
        /// <param name="startDate">起始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="aggregate">指定是否聚合，即数据聚合统计或按日统计</param>
        /// <returns>XGLssQueryDomainStatisticsResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGLssQueryDomainStatisticsResponse QueryDomainStatistics(string playDomain, string startDate, string endDate, bool? aggregate=null)
        {
            XGLssQueryDomainStatisticsRequest request = new XGLssQueryDomainStatisticsRequest()
            {
                PlayDomain=playDomain,
                StartDate=startDate,
                EndDate=endDate,
                Aggregate=aggregate
            };
            return QueryDomainStatistics(request);
        }

        /// <summary>
        /// 查询统计数据
        /// <para>查询特定Domain的统计数据。</para>
        /// </summary>
        /// <param name="playDomain">直播域名</param>
        /// <param name="startDate">起始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="aggregate">指定是否聚合，即数据聚合统计或按日统计</param>
        /// <returns>异步任务XGLssQueryDomainStatisticsResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGLssQueryDomainStatisticsResponse> QueryDomainStatisticsAsync(string playDomain, string startDate, string endDate, bool? aggregate = null)
        {
            XGLssQueryDomainStatisticsRequest request = new XGLssQueryDomainStatisticsRequest()
            {
                PlayDomain = playDomain,
                StartDate = startDate,
                EndDate = endDate,
                Aggregate = aggregate
            };
            return await QueryDomainStatisticsAsync(request);
        }

        /// <summary>
        /// 查询统计数据
        /// <para>查询特定Domain的统计数据。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/LSS/s/bjwvyyujl#%E6%9F%A5%E8%AF%A2%E7%BB%9F%E8%AE%A1%E6%95%B0%E6%8D%AE </para>
        /// </summary>
        /// <param name="request">XGLssQueryDomainStatisticsRequest</param>
        /// <returns>XGLssQueryDomainStatisticsResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGLssQueryDomainStatisticsResponse QueryDomainStatistics(XGLssQueryDomainStatisticsRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.StartDate, nameof(request.StartDate));
            AssertStringNotNullOrEmpty(request.EndDate, nameof(request.EndDate));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.LssVersion.ToString(), STATISTICS, DOMAIN,request.PlayDomain.Trim());
            iternalRequest.AddParameter("startDate",request.StartDate.Trim());
            iternalRequest.AddParameter("endDate",request.EndDate.Trim());
            if (request.Aggregate != null)
                iternalRequest.AddParameter("aggregate",request.Aggregate.Value.ToString().Trim());
            XGLssQueryDomainStatisticsResponse response = InvokeHttpClient<XGLssQueryDomainStatisticsResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询统计数据
        /// <para>查询特定Domain的统计数据。</para>
        /// </summary>
        /// <param name="request">XGLssQueryDomainStatisticsRequest</param>
        /// <returns>异步任务XGLssQueryDomainStatisticsResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGLssQueryDomainStatisticsResponse> QueryDomainStatisticsAsync(XGLssQueryDomainStatisticsRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.StartDate, nameof(request.StartDate));
            AssertStringNotNullOrEmpty(request.EndDate, nameof(request.EndDate));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.LssVersion.ToString(), STATISTICS, DOMAIN, request.PlayDomain.Trim());
            iternalRequest.AddParameter("startDate", request.StartDate.Trim());
            iternalRequest.AddParameter("endDate", request.EndDate.Trim());
            if (request.Aggregate != null)
                iternalRequest.AddParameter("aggregate", request.Aggregate.Value.ToString().Trim());
            XGLssQueryDomainStatisticsResponse response = await InvokeHttpClientAsync<XGLssQueryDomainStatisticsResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询统计概要
        /// <para>查询当前用户所有Domain的统计概要。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/LSS/s/bjwvyyujl#%E6%9F%A5%E8%AF%A2%E7%BB%9F%E8%AE%A1%E6%A6%82%E8%A6%81 </para>
        /// </summary>
        /// <param name="startTime">起始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns>XGLssQueryDomainSummaryStatisticsResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGLssQueryDomainSummaryStatisticsResponse QueryDomainSummaryStatistics(DateTime startTime, DateTime? endTime=null)
        {
            XGLssQueryDomainSummaryStatisticsRequest request = new XGLssQueryDomainSummaryStatisticsRequest()
            {
                StartTime=startTime,
                EndTime=endTime
            };

            return QueryDomainSummaryStatistics(request);
        }

        /// <summary>
        /// 查询统计概要
        /// <para>查询当前用户所有Domain的统计概要。</para>
        /// </summary>
        /// <param name="startTime">起始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns>异步任务XGLssQueryDomainSummaryStatisticsResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGLssQueryDomainSummaryStatisticsResponse> QueryDomainSummaryStatisticsAsync(DateTime startTime, DateTime? endTime = null)
        {
            XGLssQueryDomainSummaryStatisticsRequest request = new XGLssQueryDomainSummaryStatisticsRequest()
            {
                StartTime = startTime,
                EndTime = endTime
            };

            return await QueryDomainSummaryStatisticsAsync(request);
        }

        /// <summary>
        /// 查询统计概要
        /// <para>查询当前用户所有Domain的统计概要。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/LSS/s/bjwvyyujl#%E6%9F%A5%E8%AF%A2%E7%BB%9F%E8%AE%A1%E6%A6%82%E8%A6%81 </para>
        /// </summary>
        /// <param name="request">XGLssQueryDomainSummaryStatisticsRequest</param>
        /// <returns>XGLssQueryDomainSummaryStatisticsResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGLssQueryDomainSummaryStatisticsResponse QueryDomainSummaryStatistics(XGLssQueryDomainSummaryStatisticsRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertNotNullOrEmpty(request.StartTime, nameof(request.StartTime));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.LssVersion.ToString(), STATISTICS, DOMAIN, "summary");
            iternalRequest.AddParameter("startTime", request.StartTime.Value.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ"));
            if(request.EndTime!=null)
                iternalRequest.AddParameter("endTime", request.EndTime.Value.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ"));
            XGLssQueryDomainSummaryStatisticsResponse response = InvokeHttpClient<XGLssQueryDomainSummaryStatisticsResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询统计概要
        /// <para>查询当前用户所有Domain的统计概要。</para>
        /// </summary>
        /// <param name="request">XGLssQueryDomainSummaryStatisticsRequest</param>
        /// <returns>异步任务XGLssQueryDomainSummaryStatisticsResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGLssQueryDomainSummaryStatisticsResponse> QueryDomainSummaryStatisticsAsync(XGLssQueryDomainSummaryStatisticsRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertNotNullOrEmpty(request.StartTime, nameof(request.StartTime));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.LssVersion.ToString(), STATISTICS, DOMAIN, "summary");
            iternalRequest.AddParameter("startTime", request.StartTime.Value.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ"));
            if (request.EndTime != null)
                iternalRequest.AddParameter("endTime", request.EndTime.Value.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ"));
            XGLssQueryDomainSummaryStatisticsResponse response = await InvokeHttpClientAsync<XGLssQueryDomainSummaryStatisticsResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询总请求数
        /// <para>查询当前用户所有Domain的总请求数。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/LSS/s/bjwvyyujl#%E6%9F%A5%E8%AF%A2%E6%80%BB%E8%AF%B7%E6%B1%82%E6%95%B0 </para>
        /// </summary>
        /// <param name="startTime">起始时间</param>
        /// <param name="timeInterval">时间间隔</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="playDomain">直播域名，查询总请求数可不填</param>
        /// <returns>XGLssQueryDomainPlayCountResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGLssQueryDomainPlayCountResponse QueryDomainPlayCount(DateTime startTime, XGLssStatisticsTimeInterval? timeInterval, DateTime? endTime=null, string playDomain=null)
        {
            AssertNotNullOrEmpty(startTime, nameof(startTime));
            AssertNotNullOrEmpty(timeInterval, nameof(timeInterval));
            XGLssQueryDomainPlayCountRequest request = new XGLssQueryDomainPlayCountRequest()
            {
                StartTime=startTime,
                EndTime=endTime,
                TimeInterval=timeInterval,
                PlayDomain=playDomain
            };

            return QueryDomainPlayCount(request);
        }

        /// <summary>
        /// 查询总请求数
        /// <para>查询当前用户所有Domain的总请求数。</para>
        /// </summary>
        /// <param name="startTime">起始时间</param>
        /// <param name="timeInterval">时间间隔</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="playDomain">直播域名，查询总请求数可不填</param>
        /// <returns>异步任务XGLssQueryDomainPlayCountResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGLssQueryDomainPlayCountResponse> QueryDomainPlayCountAsync(DateTime startTime, XGLssStatisticsTimeInterval? timeInterval, DateTime? endTime = null, string playDomain = null)
        {
            AssertNotNullOrEmpty(startTime, nameof(startTime));
            AssertNotNullOrEmpty(timeInterval, nameof(timeInterval));
            XGLssQueryDomainPlayCountRequest request = new XGLssQueryDomainPlayCountRequest()
            {
                StartTime = startTime,
                EndTime = endTime,
                TimeInterval = timeInterval,
                PlayDomain=playDomain
            };

            return await QueryDomainPlayCountAsync(request);
        }

        /// <summary>
        /// 查询总请求数
        /// <para>查询当前用户所有Domain的总请求数。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/LSS/s/bjwvyyujl#%E6%9F%A5%E8%AF%A2%E6%80%BB%E8%AF%B7%E6%B1%82%E6%95%B0 </para>
        /// </summary>
        /// <param name="request">XGLssQueryAllDomainPlayCountRequest</param>
        /// <returns>XGLssQueryDomainPlayCountResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGLssQueryDomainPlayCountResponse QueryDomainPlayCount(XGLssQueryDomainPlayCountRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertNotNullOrEmpty(request.StartTime, nameof(request.StartTime));
            AssertNotNullOrEmpty(request.TimeInterval, nameof(request.TimeInterval));
            XGBceIternalRequest iternalRequest;
            if (!string.IsNullOrEmpty(request.PlayDomain) && !string.IsNullOrWhiteSpace(request.PlayDomain))
            {
                iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.LssVersion.ToString(), STATISTICS, DOMAIN, request.PlayDomain.Trim(), "playcount");
            }
            else
            {
                iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.LssVersion.ToString(), STATISTICS, DOMAIN, "playcount");
            }
            
            iternalRequest.AddParameter("startTime", request.StartTime.Value.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ"));
            if (request.EndTime != null)
                iternalRequest.AddParameter("endTime", request.EndTime.Value.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ"));
            iternalRequest.AddParameter("timeInterval",request.TimeInterval.Value.ToString());
            XGLssQueryDomainPlayCountResponse response = InvokeHttpClient<XGLssQueryDomainPlayCountResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询总请求数
        /// <para>查询当前用户所有Domain的总请求数。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/LSS/s/bjwvyyujl#%E6%9F%A5%E8%AF%A2%E6%80%BB%E8%AF%B7%E6%B1%82%E6%95%B0 </para>
        /// </summary>
        /// <param name="request">XGLssQueryAllDomainPlayCountRequest</param>
        /// <returns>异步任务XGLssQueryDomainPlayCountResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGLssQueryDomainPlayCountResponse> QueryDomainPlayCountAsync(XGLssQueryDomainPlayCountRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertNotNullOrEmpty(request.StartTime, nameof(request.StartTime));
            AssertNotNullOrEmpty(request.TimeInterval, nameof(request.TimeInterval));
            XGBceIternalRequest iternalRequest;
            if (!string.IsNullOrEmpty(request.PlayDomain) && !string.IsNullOrWhiteSpace(request.PlayDomain))
            {
                iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.LssVersion.ToString(), STATISTICS, DOMAIN, request.PlayDomain.Trim(), "playcount");
            }
            else
            {
                iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.LssVersion.ToString(), STATISTICS, DOMAIN, "playcount");
            }
            iternalRequest.AddParameter("startTime", request.StartTime.Value.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ"));
            if (request.EndTime != null)
                iternalRequest.AddParameter("endTime", request.EndTime.Value.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ"));
            iternalRequest.AddParameter("timeInterval", request.TimeInterval.Value.ToString());
            XGLssQueryDomainPlayCountResponse response = await InvokeHttpClientAsync<XGLssQueryDomainPlayCountResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询总带宽
        /// <para>查询当前用户所有Domain的总带宽。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/LSS/s/bjwvyyujl#%E6%9F%A5%E8%AF%A2%E6%80%BB%E5%B8%A6%E5%AE%BD </para>
        /// </summary>
        /// <param name="startTime">起始时间</param>
        /// <param name="timeInterval">时间间隔</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="playDomain">直播域名，查询总带宽可不填</param>
        /// <returns>XGLssQueryDomainBandWidthResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGLssQueryDomainBandWidthResponse QueryDomainBandWidth(DateTime startTime, XGLssStatisticsTimeInterval? timeInterval, DateTime? endTime = null, string playDomain = null)
        {
            AssertNotNullOrEmpty(startTime, nameof(startTime));
            AssertNotNullOrEmpty(timeInterval, nameof(timeInterval));
            XGLssQueryDomainBandWidthRequest request = new XGLssQueryDomainBandWidthRequest()
            {
                StartTime = startTime,
                EndTime = endTime,
                TimeInterval = timeInterval,
                PlayDomain = playDomain
            };

            return QueryDomainBandWidth(request);
        }

        /// <summary>
        /// 查询总带宽
        /// <para>查询当前用户所有Domain的总带宽。</para>
        /// </summary>
        /// <param name="startTime">起始时间</param>
        /// <param name="timeInterval">时间间隔</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="playDomain">直播域名，查询总带宽可不填</param>
        /// <returns>异步任务XGLssQueryDomainBandWidthResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGLssQueryDomainBandWidthResponse> QueryDomainBandWidthAsync(DateTime startTime, XGLssStatisticsTimeInterval? timeInterval, DateTime? endTime = null, string playDomain = null)
        {
            AssertNotNullOrEmpty(startTime, nameof(startTime));
            AssertNotNullOrEmpty(timeInterval, nameof(timeInterval));
            XGLssQueryDomainBandWidthRequest request = new XGLssQueryDomainBandWidthRequest()
            {
                StartTime = startTime,
                EndTime = endTime,
                TimeInterval = timeInterval,
                PlayDomain = playDomain
            };

            return await QueryDomainBandWidthAsync(request);
        }

        /// <summary>
        /// 查询总带宽
        /// <para>查询当前用户所有Domain的总带宽。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/LSS/s/bjwvyyujl#%E6%9F%A5%E8%AF%A2%E6%80%BB%E5%B8%A6%E5%AE%BD </para>
        /// </summary>
        /// <param name="request">XGLssQueryDomainBandWidthRequest</param>
        /// <returns>XGLssQueryDomainBandWidthResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGLssQueryDomainBandWidthResponse QueryDomainBandWidth(XGLssQueryDomainBandWidthRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertNotNullOrEmpty(request.StartTime, nameof(request.StartTime));
            AssertNotNullOrEmpty(request.TimeInterval, nameof(request.TimeInterval));
            XGBceIternalRequest iternalRequest;
            if (!string.IsNullOrEmpty(request.PlayDomain) && !string.IsNullOrWhiteSpace(request.PlayDomain))
            {
                iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.LssVersion.ToString(), STATISTICS, DOMAIN, request.PlayDomain.Trim(), "bandwidth");
            }
            else
            {
                iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.LssVersion.ToString(), STATISTICS, DOMAIN, "bandwidth");
            }

            iternalRequest.AddParameter("startTime", request.StartTime.Value.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ"));
            if (request.EndTime != null)
                iternalRequest.AddParameter("endTime", request.EndTime.Value.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ"));
            iternalRequest.AddParameter("timeInterval", request.TimeInterval.Value.ToString());
            XGLssQueryDomainBandWidthResponse response = InvokeHttpClient<XGLssQueryDomainBandWidthResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询总带宽
        /// <para查询当前用户所有Domain的总带宽。</para>
        /// </summary>
        /// <param name="request">XGLssQueryDomainBandWidthRequest</param>
        /// <returns>异步任务XGLssQueryDomainBandWidthResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGLssQueryDomainBandWidthResponse> QueryDomainBandWidthAsync(XGLssQueryDomainBandWidthRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertNotNullOrEmpty(request.StartTime, nameof(request.StartTime));
            AssertNotNullOrEmpty(request.TimeInterval, nameof(request.TimeInterval));
            XGBceIternalRequest iternalRequest;
            if (!string.IsNullOrEmpty(request.PlayDomain) && !string.IsNullOrWhiteSpace(request.PlayDomain))
            {
                iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.LssVersion.ToString(), STATISTICS, DOMAIN, request.PlayDomain.Trim(), "bandwidth");
            }
            else
            {
                iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.LssVersion.ToString(), STATISTICS, DOMAIN, "bandwidth");
            }

            iternalRequest.AddParameter("startTime", request.StartTime.Value.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ"));
            if (request.EndTime != null)
                iternalRequest.AddParameter("endTime", request.EndTime.Value.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ"));
            iternalRequest.AddParameter("timeInterval", request.TimeInterval.Value.ToString());
            XGLssQueryDomainBandWidthResponse response = await InvokeHttpClientAsync<XGLssQueryDomainBandWidthResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询总流量
        /// <para>查询当前用户所有Domain的总流量。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/LSS/s/bjwvyyujl#%E6%9F%A5%E8%AF%A2%E6%80%BB%E6%B5%81%E9%87%8F </para>
        /// </summary>
        /// <param name="startTime">起始时间</param>
        /// <param name="timeInterval">时间间隔</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="playDomain">直播域名，查询总流量可不填</param>
        /// <returns>XGLssQueryDomainTrafficResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGLssQueryDomainTrafficResponse QueryDomainTraffic(DateTime startTime, XGLssStatisticsTimeInterval? timeInterval, DateTime? endTime = null, string playDomain = null)
        {
            AssertNotNullOrEmpty(startTime, nameof(startTime));
            AssertNotNullOrEmpty(timeInterval, nameof(timeInterval));
            XGLssQueryDomainTrafficRequest request = new XGLssQueryDomainTrafficRequest()
            {
                StartTime = startTime,
                EndTime = endTime,
                TimeInterval = timeInterval,
                PlayDomain = playDomain
            };

            return QueryDomainTraffic(request);
        }

        /// <summary>
        /// 查询总流量
        /// <para>查询当前用户所有Domain的总流量。</para>
        /// </summary>
        /// <param name="startTime">起始时间</param>
        /// <param name="timeInterval">时间间隔</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="playDomain">直播域名，查询总流量可不填</param>
        /// <returns>异步任务XGLssQueryDomainTrafficResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGLssQueryDomainTrafficResponse> QueryDomainTrafficAsync(DateTime startTime, XGLssStatisticsTimeInterval? timeInterval, DateTime? endTime = null, string playDomain = null)
        {
            AssertNotNullOrEmpty(startTime, nameof(startTime));
            AssertNotNullOrEmpty(timeInterval, nameof(timeInterval));
            XGLssQueryDomainTrafficRequest request = new XGLssQueryDomainTrafficRequest()
            {
                StartTime = startTime,
                EndTime = endTime,
                TimeInterval = timeInterval,
                PlayDomain = playDomain
            };

            return await QueryDomainTrafficAsync(request);
        }

        /// <summary>
        /// 查询总流量
        /// <para>查询当前用户所有Domain的总流量。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/LSS/s/bjwvyyujl#%E6%9F%A5%E8%AF%A2%E6%80%BB%E6%B5%81%E9%87%8F </para>
        /// </summary>
        /// <param name="request">XGLssQueryDomainTrafficRequest</param>
        /// <returns>XGLssQueryDomainTrafficResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGLssQueryDomainTrafficResponse QueryDomainTraffic(XGLssQueryDomainTrafficRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertNotNullOrEmpty(request.StartTime, nameof(request.StartTime));
            AssertNotNullOrEmpty(request.TimeInterval, nameof(request.TimeInterval));
            XGBceIternalRequest iternalRequest;
            if (!string.IsNullOrEmpty(request.PlayDomain) && !string.IsNullOrWhiteSpace(request.PlayDomain))
            {
                iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.LssVersion.ToString(), STATISTICS, DOMAIN, request.PlayDomain.Trim(), "traffic");
            }
            else
            {
                iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.LssVersion.ToString(), STATISTICS, DOMAIN, "traffic");
            }

            iternalRequest.AddParameter("startTime", request.StartTime.Value.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ"));
            if (request.EndTime != null)
                iternalRequest.AddParameter("endTime", request.EndTime.Value.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ"));
            iternalRequest.AddParameter("timeInterval", request.TimeInterval.Value.ToString());
            XGLssQueryDomainTrafficResponse response = InvokeHttpClient<XGLssQueryDomainTrafficResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询总流量
        /// <para>查询当前用户所有Domain的总流量。</para>
        /// </summary>
        /// <param name="request">XGLssQueryDomainTrafficRequest</param>
        /// <returns>异步任务XGLssQueryDomainTrafficResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGLssQueryDomainTrafficResponse> QueryDomainTrafficAsync(XGLssQueryDomainTrafficRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertNotNullOrEmpty(request.StartTime, nameof(request.StartTime));
            AssertNotNullOrEmpty(request.TimeInterval, nameof(request.TimeInterval));
            XGBceIternalRequest iternalRequest;
            if (!string.IsNullOrEmpty(request.PlayDomain) && !string.IsNullOrWhiteSpace(request.PlayDomain))
            {
                iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.LssVersion.ToString(), STATISTICS, DOMAIN, request.PlayDomain.Trim(), "traffic");
            }
            else
            {
                iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.LssVersion.ToString(), STATISTICS, DOMAIN, "traffic");
            }

            iternalRequest.AddParameter("startTime", request.StartTime.Value.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ"));
            if (request.EndTime != null)
                iternalRequest.AddParameter("endTime", request.EndTime.Value.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ"));
            iternalRequest.AddParameter("timeInterval", request.TimeInterval.Value.ToString());
            XGLssQueryDomainTrafficResponse response = await InvokeHttpClientAsync<XGLssQueryDomainTrafficResponse>(iternalRequest);
            return response;
        }

        #endregion

        #region 通知接口

        /// <summary>
        /// 创建通知
        /// <para>通过用户提供的回调地址创建通知，在创建域名时可以指定通知接口，则直播过程中直播状态改变等情况下，LSS会向您指定的回调地址推送通知消息。</para>
        /// <para>默认情况下，同一个域名下的流使用同一个通知接口。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/LSS/s/3jwvyyvkw#%E5%88%9B%E5%BB%BA%E9%80%9A%E7%9F%A5 </para>
        /// </summary>
        /// <param name="name">接口名称，开头必须是小写字母</param>
        /// <param name="endpoint">通知消息接口地址，不超过256字符</param>
        /// <returns>XGLssResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGLssResponse CreateNotification(string name, string endpoint)
        {
            AssertStringNotNullOrEmpty(name, nameof(name));
            AssertStringNotNullOrEmpty(endpoint, nameof(endpoint));
            XGLssCreateNotificationRequest request = new XGLssCreateNotificationRequest()
            {
                Name=name,
                Endpoint=endpoint
            };
            return CreateNotification(request);
        }

        /// <summary>
        /// 创建通知
        /// <para>通过用户提供的回调地址创建通知，在创建域名时可以指定通知接口，则直播过程中直播状态改变等情况下，LSS会向您指定的回调地址推送通知消息。</para>
        /// <para>默认情况下，同一个域名下的流使用同一个通知接口。</para>
        /// </summary>
        /// <param name="name">接口名称，开头必须是小写字母</param>
        /// <param name="endpoint">通知消息接口地址，不超过256字符</param>
        /// <returns>异步任务XGLssResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGLssResponse> CreateNotificationAsync(string name, string endpoint)
        {
            AssertStringNotNullOrEmpty(name, nameof(name));
            AssertStringNotNullOrEmpty(endpoint, nameof(endpoint));
            XGLssCreateNotificationRequest request = new XGLssCreateNotificationRequest()
            {
                Name = name,
                Endpoint = endpoint
            };
            return await CreateNotificationAsync(request);
        }

        /// <summary>
        /// 创建通知
        /// <para>通过用户提供的回调地址创建通知，在创建域名时可以指定通知接口，则直播过程中直播状态改变等情况下，LSS会向您指定的回调地址推送通知消息。</para>
        /// <para>默认情况下，同一个域名下的流使用同一个通知接口。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/LSS/s/3jwvyyvkw#%E5%88%9B%E5%BB%BA%E9%80%9A%E7%9F%A5 </para>
        /// </summary>
        /// <param name="request">XGLssCreateNotificationRequest</param>
        /// <returns>XGLssResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGLssResponse CreateNotification(XGLssCreateNotificationRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.Name, nameof(request.Name));
            AssertStringNotNullOrEmpty(request.Endpoint, nameof(request.Endpoint));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.POST, request.LssVersion.ToString(), NOTIFICATION);
            XGLssResponse response = InvokeHttpClient<XGLssResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 创建通知
        /// <para>通过用户提供的回调地址创建通知，在创建域名时可以指定通知接口，则直播过程中直播状态改变等情况下，LSS会向您指定的回调地址推送通知消息。</para>
        /// <para>默认情况下，同一个域名下的流使用同一个通知接口。</para>
        /// </summary>
        /// <param name="request">XGLssCreateNotificationRequest</param>
        /// <returns>异步任务XGLssResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGLssResponse> CreateNotificationAsync(XGLssCreateNotificationRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.Name, nameof(request.Name));
            AssertStringNotNullOrEmpty(request.Endpoint, nameof(request.Endpoint));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.POST, request.LssVersion.ToString(), NOTIFICATION);
            XGLssResponse response = await InvokeHttpClientAsync<XGLssResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询通知
        /// <para>查询通知的接口名称和接口地址。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/LSS/s/3jwvyyvkw#%E6%9F%A5%E8%AF%A2%E9%80%9A%E7%9F%A5 </para>
        /// </summary>
        /// <param name="name">通知名称</param>
        /// <returns>XGLssResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGLssQueryNotificationResponse QueryNotification(string name)
        {
            AssertStringNotNullOrEmpty(name, nameof(name));
            XGLssBaseRequest request = new XGLssBaseRequest();
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.LssVersion.ToString(), NOTIFICATION,name.Trim());
            XGLssQueryNotificationResponse response = InvokeHttpClient<XGLssQueryNotificationResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询通知
        /// <para>查询通知的接口名称和接口地址。</para>
        /// </summary>
        /// <param name="name">通知名称</param>
        /// <returns>异步任务XGLssResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGLssQueryNotificationResponse> QueryNotificationAsync(string name)
        {
            AssertStringNotNullOrEmpty(name, nameof(name));
            XGLssBaseRequest request = new XGLssBaseRequest();
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.LssVersion.ToString(), NOTIFICATION, name.Trim());
            XGLssQueryNotificationResponse response = await InvokeHttpClientAsync<XGLssQueryNotificationResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 列举通知
        /// <para>获取已创建的全部通知。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/LSS/s/3jwvyyvkw#%E9%80%9A%E7%9F%A5%E5%88%97%E8%A1%A8 </para>
        /// </summary>
        /// <returns>XGLssListNotificationsResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGLssListNotificationsResponse ListNotifications()
        {
            XGLssBaseRequest request = new XGLssBaseRequest();
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.LssVersion.ToString(), NOTIFICATION);
            XGLssListNotificationsResponse response = InvokeHttpClient<XGLssListNotificationsResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 列举通知
        /// <para>获取已创建的全部通知。</para>
        /// </summary>
        /// <returns>异步任务XGLssListNotificationsResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGLssListNotificationsResponse> ListNotificationsAsync()
        {
            XGLssBaseRequest request = new XGLssBaseRequest();
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.LssVersion.ToString(), NOTIFICATION);
            XGLssListNotificationsResponse response = await InvokeHttpClientAsync<XGLssListNotificationsResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 删除通知
        /// <para>删除指定的直播通知。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/LSS/s/3jwvyyvkw#%E5%88%A0%E9%99%A4%E9%80%9A%E7%9F%A5 </para>
        /// </summary>
        /// <param name="name">通知名称</param>
        /// <returns>XGLssResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGLssResponse DeleteNotification(string name)
        {
            AssertStringNotNullOrEmpty(name, nameof(name));
            XGLssBaseRequest request = new XGLssBaseRequest();
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.DELETE, request.LssVersion.ToString(), NOTIFICATION, name.Trim());
            XGLssQueryNotificationResponse response = InvokeHttpClient<XGLssQueryNotificationResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 删除通知
        /// <para>删除指定的直播通知。</para>
        /// </summary>
        /// <param name="name">通知名称</param>
        /// <returns>异步任务XGLssResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGLssResponse> DeleteNotificationAsync(string name)
        {
            AssertStringNotNullOrEmpty(name, nameof(name));
            XGLssBaseRequest request = new XGLssBaseRequest();
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.DELETE, request.LssVersion.ToString(), NOTIFICATION, name.Trim());
            XGLssResponse response = await InvokeHttpClientAsync<XGLssResponse>(iternalRequest);
            return response;
        }

        #endregion

        #region 录制视频裁剪接口

        /// <summary>
        /// 录制视频裁剪
        /// <para>裁剪录制视频接口，输入绝对开始时间和结束时间，可以获取视频回放。</para>
        /// <para>本接口仅支持已经录制的m3u8视频， 裁剪后输出可以是m3u8或mp4格式。</para>
        /// <para>只能剪裁已经录制完成的视频，不能干预直播中正在录制的或即将录制的视频。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/LSS/s/Ejwvyyx2z </para>
        /// </summary>
        /// <param name="request">XGLssRecordingClipRequest</param>
        /// <returns>XGLssRecordingClipResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGLssRecordingClipResponse RecordingClip(XGLssRecordingClipRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.PlayDomain, nameof(request.PlayDomain));
            AssertStringNotNullOrEmpty(request.App, nameof(request.App));
            AssertStringNotNullOrEmpty(request.Stream, nameof(request.Stream));
            AssertStringNotNullOrEmpty(request.SourceFile, nameof(request.SourceFile));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.POST, request.LssVersion.ToString(), "recording", "clip");
            XGLssRecordingClipResponse response = InvokeHttpClient<XGLssRecordingClipResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 录制视频裁剪
        /// <para>裁剪录制视频接口，输入绝对开始时间和结束时间，可以获取视频回放。</para>
        /// <para>本接口仅支持已经录制的m3u8视频， 裁剪后输出可以是m3u8或mp4格式。</para>
        /// <para>只能剪裁已经录制完成的视频，不能干预直播中正在录制的或即将录制的视频。</para>
        /// </summary>
        /// <param name="request">XGLssRecordingClipRequest</param>
        /// <returns>异步任务XGLssRecordingClipResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGLssRecordingClipResponse> RecordingClipAsync(XGLssRecordingClipRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.PlayDomain, nameof(request.PlayDomain));
            AssertStringNotNullOrEmpty(request.App, nameof(request.App));
            AssertStringNotNullOrEmpty(request.Stream, nameof(request.Stream));
            AssertStringNotNullOrEmpty(request.SourceFile, nameof(request.SourceFile));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.POST, request.LssVersion.ToString(), "recording", "clip");
            XGLssRecordingClipResponse response = await InvokeHttpClientAsync<XGLssRecordingClipResponse>(iternalRequest);
            return response;
        }

        #endregion

        #region  生成推拉流地址



        #endregion

        #region 日志下载接口

        /// <summary>
        /// 获取日志下载地址
        /// <para>提供日志下载URL。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/LSS/s/lk2zv7chu#%E6%97%A5%E5%BF%97%E4%B8%8B%E8%BD%BD%E6%8E%A5%E5%8F%A3 </para>
        /// </summary>
        /// <param name="playDomain">直播域名</param>
        /// <param name="startTime">起始时间，UTC时间</param>
        /// <param name="endTime">结束时间，UTC时间</param>
        /// <returns>XGLssQueryOriginalLogsResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGLssQueryOriginalLogsResponse QueryOriginalLogs(string playDomain, DateTime startTime, DateTime endTime)
        {
            AssertStringNotNullOrEmpty(playDomain, nameof(playDomain));
            AssertNotNullOrEmpty(startTime, nameof(startTime));
            AssertNotNullOrEmpty(endTime, nameof(endTime));
            XGLssQueryOriginalLogsRequest request = new XGLssQueryOriginalLogsRequest()
            {
                PlayDomain=playDomain,
                StartTime=startTime,
                EndTime=endTime
            };
            return QueryOriginalLogs(request);
        }

        /// <summary>
        /// 获取日志下载地址
        /// <para>提供日志下载URL。</para>
        /// </summary>
        /// <param name="playDomain">直播域名</param>
        /// <param name="startTime">起始时间，UTC时间</param>
        /// <param name="endTime">结束时间，UTC时间</param>
        /// <returns>异步任务XGLssQueryOriginalLogsResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGLssQueryOriginalLogsResponse> QueryOriginalLogsAsync(string playDomain, DateTime startTime, DateTime endTime)
        {
            AssertStringNotNullOrEmpty(playDomain, nameof(playDomain));
            AssertNotNullOrEmpty(startTime, nameof(startTime));
            AssertNotNullOrEmpty(endTime, nameof(endTime));
            XGLssQueryOriginalLogsRequest request = new XGLssQueryOriginalLogsRequest()
            {
                PlayDomain = playDomain,
                StartTime = startTime,
                EndTime = endTime
            };
            return await QueryOriginalLogsAsync(request);
        }

        /// <summary>
        /// 获取日志下载地址
        /// <para>提供日志下载URL。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/LSS/s/lk2zv7chu#%E6%97%A5%E5%BF%97%E4%B8%8B%E8%BD%BD%E6%8E%A5%E5%8F%A3 </para>
        /// </summary>
        /// <param name="request">XGLssQueryOriginalLogsRequest</param>
        /// <returns>XGLssQueryOriginalLogsResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGLssQueryOriginalLogsResponse QueryOriginalLogs(XGLssQueryOriginalLogsRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.PlayDomain,nameof(request.PlayDomain));
            AssertNotNullOrEmpty(request.StartTime, nameof(request.StartTime));
            AssertNotNullOrEmpty(request.EndTime, nameof(request.EndTime));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.LssVersion.ToString(), STATISTICS,DOMAIN,request.PlayDomain.Trim(), "originallogs");
            iternalRequest.AddParameter("startTime",request.StartTime.Value.ToString("yyyy-MM-dd'T'HH:mm:ss'Z'"));
            iternalRequest.AddParameter("endTime",request.EndTime.Value.ToString("yyyy-MM-dd'T'HH:mm:ss'Z'"));
            XGLssQueryOriginalLogsResponse response = InvokeHttpClient<XGLssQueryOriginalLogsResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 获取日志下载地址
        /// <para>提供日志下载URL。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/LSS/s/lk2zv7chu#%E6%97%A5%E5%BF%97%E4%B8%8B%E8%BD%BD%E6%8E%A5%E5%8F%A3 </para>
        /// </summary>
        /// <param name="request">XGLssQueryOriginalLogsRequest</param>
        /// <returns>异步任务XGLssQueryOriginalLogsResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGLssQueryOriginalLogsResponse> QueryOriginalLogsAsync(XGLssQueryOriginalLogsRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.PlayDomain, nameof(request.PlayDomain));
            AssertNotNullOrEmpty(request.StartTime, nameof(request.StartTime));
            AssertNotNullOrEmpty(request.EndTime, nameof(request.EndTime));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.LssVersion.ToString(), STATISTICS, DOMAIN, request.PlayDomain.Trim(), "originallogs");
            iternalRequest.AddParameter("startTime", request.StartTime.Value.ToString("yyyy-MM-dd'T'HH:mm:ss'Z'"));
            iternalRequest.AddParameter("endTime", request.EndTime.Value.ToString("yyyy-MM-dd'T'HH:mm:ss'Z'"));
            XGLssQueryOriginalLogsResponse response = await InvokeHttpClientAsync<XGLssQueryOriginalLogsResponse>(iternalRequest);
            return response;
        }

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
