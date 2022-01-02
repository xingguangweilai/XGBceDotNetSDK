using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using XGBceDotNetSDK.BaseClass;
using XGBceDotNetSDK.Http;
using XGBceDotNetSDK.Http.Handler;
using XGBceDotNetSDK.Services.VCR.Model;
using XGBceDotNetSDK.Utils;

namespace XGBceDotNetSDK.Services.VCR
{
    /// <summary>
    /// 媒体内容审核VCR客户端类
    /// <para>Endpoint为：vcr.bj.baidubce.com</para>
    /// <para>接口文档：https://cloud.baidu.com/doc/VCR/index.html </para>
    /// </summary>
    public class XGVcrClient: XGAbstractBceClient
    {
        private static readonly string MEDIA = "media";       //视频审核
        private static readonly string AUDIO = "audio";       //音频审核
        private static readonly string IMAGE = "image";       //图片审核
        private static readonly string TEXT = "text";              //文本
        private static readonly string STREAM = "stream";    //直播审核
        private static readonly string FACE = "face";       //face库
        private static readonly string LOGO = "logo";    //logo库

        public XGVcrClient() : this(new XGBceClientConfiguration()) { }

        public XGVcrClient(XGBceClientConfiguration configuration) : base(configuration) { }

        #region 视频审核

        /// <summary>
        /// 提交视频审核
        /// </summary>
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCR/s/ujwvyaz4c#%E6%8F%90%E4%BA%A4%E8%A7%86%E9%A2%91%E5%AE%A1%E6%A0%B8 </para>
        /// <param name="source"> 视频路径 </param>
        /// <param name="auth"> 视频路径鉴权参数，仅URL视频使用 </param>
        /// <param name="description"> 视频描述，默认空字符串，不超过256字符 </param>
        /// <param name="preset"> 审核模板名称，不填写使用默认模版 </param>
        /// <param name="notification"> 通知名称，可填写通知服务中配置的通知名称，配置后会把审核结果回调至该通知名称所对应的回调地址 </param>
        /// <returns> XGVcrResponse </returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrResponse PutMedia(string source, string auth=null, string description=null, string preset=null, string notification=null)
        {
            AssertStringNotNullOrEmpty(source,nameof(source));
            XGVcrPutMediaRequest request = new XGVcrPutMediaRequest()
            {
                Source = source,
                Auth = auth,
                Description = description,
                Preset = preset,
                Notification = notification
            };
            return PutMedia(request);
        }

        /// <summary>
        /// 提交视频审核
        /// </summary>
        /// <param name="source"> 视频路径 </param>
        /// <param name="auth"> 视频路径鉴权参数，仅URL视频使用 </param>
        /// <param name="description"> 视频描述，默认空字符串，不超过256字符 </param>
        /// <param name="preset"> 审核模板名称，不填写使用默认模版 </param>
        /// <param name="notification"> 通知名称，可填写通知服务中配置的通知名称，配置后会把审核结果回调至该通知名称所对应的回调地址 </param>
        /// <returns> 异步任务XGVcrResponse </returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrResponse> PutMediaAsync(string source, string auth = null, string description = null, string preset = null, string notification = null)
        {
            AssertStringNotNullOrEmpty(source,nameof(source));
            XGVcrPutMediaRequest request = new XGVcrPutMediaRequest()
            {
                Source = source,
                Auth = auth,
                Description = description,
                Preset = preset,
                Notification = notification
            };
            return await PutMediaAsync(request);
        }

        /// <summary>
        /// 提交视频审核
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCR/s/ujwvyaz4c#%E6%8F%90%E4%BA%A4%E8%A7%86%E9%A2%91%E5%AE%A1%E6%A0%B8 </para>
        /// </summary>
        /// <param name="request">XGPutVcrMediaRequest</param>
        /// <returns>XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrResponse PutMedia(XGVcrPutMediaRequest request)
        {
            AssertNotNullOrEmpty(request,nameof(request));
            AssertStringNotNullOrEmpty(request.Source,nameof(request.Source));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.PUT, request.VcrVersion.ToString(), MEDIA);
            XGVcrResponse response = InvokeHttpClient<XGVcrResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 提交视频审核
        /// </summary>
        /// <param name="request">XGPutVcrMediaRequest</param>
        /// <returns>异步任务XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrResponse> PutMediaAsync(XGVcrPutMediaRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.Source, nameof(request.Source));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.PUT, request.VcrVersion.ToString(), MEDIA);
            XGVcrResponse response = await InvokeHttpClientAsync<XGVcrResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询视频审核结果
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCR/s/ujwvyaz4c#%E6%9F%A5%E8%AF%A2%E8%A7%86%E9%A2%91%E5%AE%A1%E6%A0%B8%E7%BB%93%E6%9E%9C </para>
        /// </summary>
        /// <param name="source">视频路径，需要对source进行urlEncode。</param>
        /// <returns>XGVcrQueryMediaResultResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrQueryMediaResultResponse QueryMediaResult(string source)
        {
            AssertStringNotNullOrEmpty(source,nameof(source));
            XGVcrQueryMediaResultRequest request = new XGVcrQueryMediaResultRequest()
            {
                Source = source
            };
            return QueryMediaResult(request);
        }

        /// <summary>
        /// 查询视频审核结果
        /// </summary>
        /// <param name="source">视频路径，需要对source进行urlEncode。</param>
        /// <returns>异步任务XGVcrQueryMediaResultResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrQueryMediaResultResponse> QueryMediaResultAsync(string source)
        {
            AssertStringNotNullOrEmpty(source, nameof(source));
            XGVcrQueryMediaResultRequest request = new XGVcrQueryMediaResultRequest() {
                Source=source
            };
            return await QueryMediaResultAsync(request);
        }

        /// <summary>
        /// 查询视频审核结果
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCR/s/ujwvyaz4c#%E6%9F%A5%E8%AF%A2%E8%A7%86%E9%A2%91%E5%AE%A1%E6%A0%B8%E7%BB%93%E6%9E%9C </para>
        /// </summary>
        /// <param name="request">XGVcrQueryMediaResultRequest</param>
        /// <returns>XGVcrQueryMediaResultResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrQueryMediaResultResponse QueryMediaResult(XGVcrQueryMediaResultRequest request)
        {
            AssertNotNullOrEmpty(request,nameof(request));
            AssertStringNotNullOrEmpty(request.Source,nameof(request.Source));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.VcrVersion.ToString(), MEDIA);
            iternalRequest.AddParameter("source", request.Source);
            XGVcrQueryMediaResultResponse response = InvokeHttpClient<XGVcrQueryMediaResultResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询视频审核结果
        /// </summary>
        /// <param name="request">XGVcrQueryMediaResultRequest</param>
        /// <returns>异步任务XGVcrQueryMediaResultResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrQueryMediaResultResponse> QueryMediaResultAsync(XGVcrQueryMediaResultRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.Source, nameof(request.Source));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.VcrVersion.ToString(), MEDIA);
            iternalRequest.AddParameter("source", request.Source);
            XGVcrQueryMediaResultResponse response = await InvokeHttpClientAsync<XGVcrQueryMediaResultResponse>(iternalRequest);
            return response;
        }

        #endregion

        #region 音频审核

        /// <summary>
        /// 提交音频审核
        /// <para> 用户提供音频路径，创建一次音频审核。 </para>
        /// <para> 输入限制：音频编码标准：MP1,MP2,MP3,AAC,AC-3,WMA,PCM,ADPCM,AMR,RealAudio,Vorbis,DSD等 </para>
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCR/s/fjytgq4of#%E6%8F%90%E4%BA%A4%E9%9F%B3%E9%A2%91%E5%AE%A1%E6%A0%B8 </para>
        /// </summary>
        /// <param name="source">音频路径，必需</param>
        /// <param name="auth">音频路径鉴权参数，仅URL音频使用</param>
        /// <param name="description">音频描述，默认空字符串，不超过256字符	</param>
        /// <param name="preset">审核模板名称，不填写使用默认模版</param>
        /// <param name="notification">通知名称</param>
        /// <returns>XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrResponse PutAudio(string source, string auth = null, string description = null, string preset = null, string notification = null)
        {
            AssertStringNotNullOrEmpty(source, nameof(source));
            XGVcrPutAudioRequest request = new XGVcrPutAudioRequest()
            {
                Source = source,
                Auth = auth,
                Description = description,
                Preset = preset,
                Notification = notification
            };
            return PutAudio(request);
        }

        /// <summary>
        /// 提交音频审核
        /// <para> 用户提供音频路径，创建一次音频审核。 </para>
        /// <para> 输入限制：音频编码标准：MP1,MP2,MP3,AAC,AC-3,WMA,PCM,ADPCM,AMR,RealAudio,Vorbis,DSD等 </para>
        /// </summary>
        /// <param name="source">音频路径，必需</param>
        /// <param name="auth">音频路径鉴权参数，仅URL音频使用</param>
        /// <param name="description">音频描述，默认空字符串，不超过256字符	</param>
        /// <param name="preset">审核模板名称，不填写使用默认模版</param>
        /// <param name="notification">通知名称</param>
        /// <returns>异步任务XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrResponse> PutAudioAsync(string source, string auth = null, string description = null, string preset = null, string notification = null)
        {
            AssertStringNotNullOrEmpty(source, nameof(source));
            XGVcrPutAudioRequest request = new XGVcrPutAudioRequest() {
                Source=source,
                Auth=auth,
                Description=description,
                Preset=preset,
                Notification=notification
            };
            return await PutAudioAsync(request);
        }

        // <summary>
        /// 提交音频审核
        /// <para> 用户提供音频路径，创建一次音频审核。 </para>
        /// <para> 输入限制：音频编码标准：MP1,MP2,MP3,AAC,AC-3,WMA,PCM,ADPCM,AMR,RealAudio,Vorbis,DSD等 </para>
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCR/s/fjytgq4of#%E6%8F%90%E4%BA%A4%E9%9F%B3%E9%A2%91%E5%AE%A1%E6%A0%B8 </para>
        /// </summary>
        /// <param name="request">XGVcrPutAudioRequest</param>
        /// <returns>异步任务XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrResponse PutAudio(XGVcrPutAudioRequest request)
        {
            AssertNotNullOrEmpty(request,nameof(request));
            AssertStringNotNullOrEmpty(request.Source, nameof(request.Source));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.PUT, request.VcrVersion.ToString(), AUDIO);
            XGVcrResponse response = InvokeHttpClient<XGVcrResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 提交音频审核
        /// <para> 用户提供音频路径，创建一次音频审核。 </para>
        /// <para> 输入限制：音频编码标准：MP1,MP2,MP3,AAC,AC-3,WMA,PCM,ADPCM,AMR,RealAudio,Vorbis,DSD等 </para>
        /// </summary>
        /// <param name="request">XGVcrPutAudioRequest</param>
        /// <returns>异步任务XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrResponse> PutAudioAsync(XGVcrPutAudioRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.Source, nameof(request.Source));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.PUT, request.VcrVersion.ToString(), AUDIO);
            XGVcrResponse response = await InvokeHttpClientAsync<XGVcrResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询音频审核结果
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCR/s/fjytgq4of#%E6%9F%A5%E8%AF%A2%E9%9F%B3%E9%A2%91%E5%AE%A1%E6%A0%B8%E7%BB%93%E6%9E%9C </para>
        /// </summary>
        /// <param name="source">音频路径，需要对source进行urlEncode。</param>
        /// <returns>XGVcrQueryAudioResultResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrQueryAudioResultResponse QueryAudioResult(string source)
        {
            AssertStringNotNullOrEmpty(source, nameof(source));
            XGVcrQueryAudioResultRequest request = new XGVcrQueryAudioResultRequest();
            request.Source = source;
            return QueryAudioResult(request);
        }

        /// <summary>
        /// 查询音频审核结果
        /// </summary>
        /// <param name="source">音频路径，需要对source进行urlEncode。</param>
        /// <returns>异步任务XGVcrQueryAudioResultResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrQueryAudioResultResponse> QueryAudioResultAsync(string source)
        {
            AssertStringNotNullOrEmpty(source, nameof(source));
            XGVcrQueryAudioResultRequest request = new XGVcrQueryAudioResultRequest();
            request.Source = source;
            return await QueryAudioResultAsync(request);
        }

        /// <summary>
        /// 查询音频审核结果
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCR/s/fjytgq4of#%E6%9F%A5%E8%AF%A2%E9%9F%B3%E9%A2%91%E5%AE%A1%E6%A0%B8%E7%BB%93%E6%9E%9C </para>
        /// </summary>
        /// <param name="request">XGVcrQueryMediaResultRequest</param>
        /// <returns>XGVcrQueryAudioResultResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrQueryAudioResultResponse QueryAudioResult(XGVcrQueryAudioResultRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.Source, nameof(request.Source));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.VcrVersion.ToString(), AUDIO);
            iternalRequest.AddParameter("source", request.Source);
            XGVcrQueryAudioResultResponse response = InvokeHttpClient<XGVcrQueryAudioResultResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询音频审核结果
        /// </summary>
        /// <param name="request">XGVcrQueryAudioResultRequest</param>
        /// <returns>异步任务XGVcrQueryAudioResultResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrQueryAudioResultResponse> QueryAudioResultAsync(XGVcrQueryAudioResultRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.Source, nameof(request.Source));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.VcrVersion.ToString(), AUDIO);
            iternalRequest.AddParameter("source", request.Source);
            XGVcrQueryAudioResultResponse response = await InvokeHttpClientAsync<XGVcrQueryAudioResultResponse>(iternalRequest);
            return response;
        }

        #endregion

        #region 图片审核

        /// <summary>
        /// 提交图片审核（同步）
        /// <para>该接口为同步接口，即直接在HTTP response body中返回图片审核结果。</para>
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCR/s/xjwvyaxsd#%E6%8F%90%E4%BA%A4%E5%9B%BE%E7%89%87%E5%AE%A1%E6%A0%B8%EF%BC%88%E5%90%8C%E6%AD%A5%EF%BC%89 </para>
        /// </summary>
        /// <param name="source">图片路径，支持bos或url两种格式	</param>
        /// <param name="preset">模板</param>
        /// <returns>XGVcrPutImageResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrPutImageResponse PutImage(string source, string preset = null)
        {
            AssertStringNotNullOrEmpty(source, nameof(source));
            XGVcrPutImageRequest request = new XGVcrPutImageRequest()
            {
                Source = source,
                Preset = preset
            };
            return PutImage(request);
        }

        /// <summary>
        /// 提交图片审核（同步）
        /// <para>该接口为同步接口异步调用，即直接在HTTP response body中返回图片审核结果。</para>
        /// </summary>
        /// <param name="source">图片路径，支持bos或url两种格式	</param>
        /// <param name="preset">模板</param>
        /// <returns> 异步任务XGVcrPutImageResponse </returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrPutImageResponse> PutImageAsync(string source, string preset = null)
        {
            AssertStringNotNullOrEmpty(source, nameof(source));
            XGVcrPutImageRequest request = new XGVcrPutImageRequest()
            {
                Source = source,
                Preset = preset
            };
            return await PutImageAsync(request);
        }

        /// <summary>
        /// 提交图片审核（同步）
        /// <para>该接口为同步接口，即直接在HTTP response body中返回图片审核结果。</para>
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCR/s/xjwvyaxsd#%E6%8F%90%E4%BA%A4%E5%9B%BE%E7%89%87%E5%AE%A1%E6%A0%B8%EF%BC%88%E5%90%8C%E6%AD%A5%EF%BC%89 </para>
        /// </summary>
        /// <param name="request">XGVcrPutImageRequest</param>
        /// <returns>XGVcrPutImageResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrPutImageResponse PutImage(XGVcrPutImageRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.Source, nameof(request.Source));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.PUT, request.VcrVersion.ToString(), IMAGE);
            XGVcrPutImageResponse response = InvokeHttpClient<XGVcrPutImageResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 提交图片审核（同步）
        /// <para>该接口为同步接口异步调用，即直接在HTTP response body中返回图片审核结果。</para>
        /// </summary>
        /// <param name="request">XGVcrPutImageRequest</param>
        /// <returns>异步任务XGVcrPutImageResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrPutImageResponse> PutImageAsync(XGVcrPutImageRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.Source, nameof(request.Source));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.PUT, request.VcrVersion.ToString(), IMAGE);
            XGVcrPutImageResponse response = await InvokeHttpClientAsync<XGVcrPutImageResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 提交图片审核（异步）
        /// <para>该接口为异步接口同步调用，使用通知服务将图片审核结果进行回调。用户也可在短时间内（10分钟）通过图片异步审核查询接口来查询缓存的审核结果。</para>
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCR/s/xjwvyaxsd#%E6%8F%90%E4%BA%A4%E5%9B%BE%E7%89%87%E5%AE%A1%E6%A0%B8%EF%BC%88%E5%BC%82%E6%AD%A5%EF%BC%89 </para>
        /// </summary>
        /// <param name="source">图片路径，支持bos或url两种格式	</param>
        /// <param name="preset">模板</param>
        /// <param name="notification">通知名称,如果为空则审核结果不进行回调通知	</param>
        /// <returns>XGVcrPutImageResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrResponse PutImage(string source, string preset = null, string notification = null)
        {
            AssertStringNotNullOrEmpty(source, nameof(source));
            XGVcrPutImageAsyncRequest request = new XGVcrPutImageAsyncRequest()
            {
                Source = source,
                Preset = preset,
                Notification=notification
            };
            return PutImage(request);
        }

        /// <summary>
        /// 提交图片审核（异步）
        /// <para>该接口为异步接口，使用通知服务将图片审核结果进行回调。用户也可在短时间内（10分钟）通过图片异步审核查询接口来查询缓存的审核结果。</para>
        /// </summary>
        /// <param name="source">图片路径，支持bos或url两种格式	</param>
        /// <param name="preset">模板</param>
        /// <param name="notification">通知名称,如果为空则审核结果不进行回调通知	</param>
        /// <returns>异步任务XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrResponse> PutImageAsync(string source, string preset = null, string notification = null)
        {
            AssertStringNotNullOrEmpty(source, nameof(source));
            XGVcrPutImageAsyncRequest request = new XGVcrPutImageAsyncRequest()
            {
                Source = source,
                Preset = preset,
                Notification = notification
            };
            return await PutImageAsync(request);
        }

        /// <summary>
        /// 提交图片审核（异步）
        /// <para>该接口为异步接口同步调用，使用通知服务将图片审核结果进行回调。用户也可在短时间内（10分钟）通过图片异步审核查询接口来查询缓存的审核结果。</para>
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCR/s/xjwvyaxsd#%E6%8F%90%E4%BA%A4%E5%9B%BE%E7%89%87%E5%AE%A1%E6%A0%B8%EF%BC%88%E5%BC%82%E6%AD%A5%EF%BC%89 </para>
        /// </summary>
        /// <param name="request">XGVcrPutImageAsyncRequest</param>
        /// <returns>XGVcrPutImageResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrResponse PutImage(XGVcrPutImageAsyncRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.Source, nameof(request.Source));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.PUT, request.VcrVersion.ToString(), IMAGE);
            XGVcrResponse response = InvokeHttpClient<XGVcrResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 提交图片审核（异步）
        /// <para>该接口为异步接口，使用通知服务将图片审核结果进行回调。用户也可在短时间内（10分钟）通过图片异步审核查询接口来查询缓存的审核结果。</para>
        /// </summary>
        /// <param name="request">XGVcrPutImageAsyncRequest</param>
        /// <returns>异步任务XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrResponse> PutImageAsync(XGVcrPutImageAsyncRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.Source, nameof(request.Source));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.PUT, request.VcrVersion.ToString(), IMAGE);
            XGVcrResponse response = await InvokeHttpClientAsync<XGVcrResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 图片审核查询
        /// <para>用户提供发起图片异步审核的信息，查询审核结果，结果保存时间10分钟。</para>
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCR/s/xjwvyaxsd#%E5%9B%BE%E7%89%87%E5%BC%82%E6%AD%A5%E5%AE%A1%E6%A0%B8%E6%9F%A5%E8%AF%A2 </para>
        /// </summary>
        /// <param name="source">图片路径，支持bos或url两种格式	</param>
        /// <param name="preset">模板</param>
        /// <returns>XGVcrQueryImageResultResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrQueryImageResultResponse QueryImageResult(string source, string preset = null)
        {
            AssertStringNotNullOrEmpty(source, nameof(source));
            XGVcrQueryImageResultRequest request = new XGVcrQueryImageResultRequest()
            {
                Source = source,
                Preset = preset
            };
            return QueryImageResult(request);
        }

        /// <summary>
        /// 图片审核查询
        /// <para>用户提供发起图片异步审核的信息，查询审核结果，结果保存时间10分钟。</para>
        /// </summary>
        /// <param name="source">图片路径，支持bos或url两种格式	</param>
        /// <param name="preset">模板</param>
        /// <returns> 异步任务XGVcrQueryImageResultResponse </returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrQueryImageResultResponse> QueryImageResultAsync(string source, string preset = null)
        {
            AssertStringNotNullOrEmpty(source, nameof(source));
            XGVcrQueryImageResultRequest request = new XGVcrQueryImageResultRequest()
            {
                Source = source,
                Preset = preset
            };
            return await QueryImageResultAsync(request);
        }

        /// <summary>
        /// 图片审核查询
        /// <para>用户提供发起图片异步审核的信息，查询审核结果，结果保存时间10分钟。</para>
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCR/s/xjwvyaxsd#%E5%9B%BE%E7%89%87%E5%BC%82%E6%AD%A5%E5%AE%A1%E6%A0%B8%E6%9F%A5%E8%AF%A2 </para>
        /// </summary>
        /// <param name="request">XGVcrQueryImageResultRequest</param>
        /// <returns>XGVcrQueryImageResultResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrQueryImageResultResponse QueryImageResult(XGVcrQueryImageResultRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.Source, nameof(request.Source));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.VcrVersion.ToString(), IMAGE);
            iternalRequest.AddParameter("source", request.Source);
            if (!string.IsNullOrEmpty(request.Preset) && !string.IsNullOrWhiteSpace(request.Preset))
                iternalRequest.AddParameter("preset", request.Preset);
            XGVcrQueryImageResultResponse response = InvokeHttpClient<XGVcrQueryImageResultResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 图片审核查询
        /// <para>用户提供发起图片异步审核的信息，查询审核结果，结果保存时间10分钟。</para>
        /// </summary>
        /// <param name="request">XGVcrQueryImageResultRequest</param>
        /// <returns> 异步任务XGVcrQueryImageResultResponse </returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrQueryImageResultResponse> QueryImageResultAsync(XGVcrQueryImageResultRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.Source, nameof(request.Source));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.VcrVersion.ToString(), IMAGE);
            iternalRequest.AddParameter("source", request.Source);
            if (!string.IsNullOrEmpty(request.Preset) && !string.IsNullOrWhiteSpace(request.Preset))
                iternalRequest.AddParameter("preset", request.Preset);
            XGVcrQueryImageResultResponse response = await InvokeHttpClientAsync<XGVcrQueryImageResultResponse>(iternalRequest);
            return response;
        }

        #endregion

        #region 文本审核

        /// <summary>
        /// 提交文本审核
        /// <para>用户提交 txt 格式的文本，创建一次审核。</para>
        /// <para>文本审核为同步接口，即直接在HTTP response body中返回文本审核结果。</para>
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCR/s/Ejwvyazu0#%E6%8F%90%E4%BA%A4%E6%96%87%E6%9C%AC%E5%AE%A1%E6%A0%B8 </para>
        /// </summary>
        /// <param name="text">审核文本</param>
        /// <param name="preset">模板</param>
        /// <returns>XGVcrPutTextResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrPutTextResponse PutText(string text, string preset = null)
        {
            AssertStringNotNullOrEmpty(text);
            XGVcrPutTextRequest request = new XGVcrPutTextRequest()
            {
                Text = text,
                Preset = preset
            };
            return PutText(request);
        }

        /// <summary>
        /// 提交文本审核
        /// <para>用户提交 txt 格式的文本，创建一次审核。</para>
        /// <para>文本审核为同步接口异步调用，即直接在HTTP response body中返回文本审核结果。</para>
        /// </summary>
        /// <param name="text">审核文本</param>
        /// <param name="preset">模板</param>
        /// <returns> 异步任务XGVcrPutTextResponse </returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrPutTextResponse> PutTextAsync(string text, string preset = null)
        {
            AssertStringNotNullOrEmpty(text);
            XGVcrPutTextRequest request = new XGVcrPutTextRequest()
            {
                Text = text,
                Preset = preset
            };
            return await PutTextAsync(request);
        }

        /// <summary>
        /// 提交文本审核
        /// <para>用户提交 txt 格式的文本，创建一次审核。</para>
        /// <para>文本审核为同步接口，即直接在HTTP response body中返回文本审核结果。</para>
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCR/s/Ejwvyazu0#%E6%8F%90%E4%BA%A4%E6%96%87%E6%9C%AC%E5%AE%A1%E6%A0%B8 </para>
        /// </summary>
        /// <param name="request">XGVcrPutTextRequest</param>
        /// <returns>XGVcrPutTextResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrPutTextResponse PutText(XGVcrPutTextRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.Text);
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.PUT, request.VcrVersion.ToString(), TEXT);
            XGVcrPutTextResponse response = InvokeHttpClient<XGVcrPutTextResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 提交文本审核
        /// <para>用户提交 txt 格式的文本，创建一次审核。</para>
        /// <para>文本审核为同步接口异步调用，即直接在HTTP response body中返回文本审核结果。</para>
        /// </summary>
        /// <param name="request">XGVcrPutTextRequest</param>
        /// <returns> 异步任务XGVcrPutTextResponse </returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrPutTextResponse> PutTextAsync(XGVcrPutTextRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.Text);
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.PUT, request.VcrVersion.ToString(), TEXT);
            XGVcrPutTextResponse response = await InvokeHttpClientAsync<XGVcrPutTextResponse>(iternalRequest);
            return response;
        }

        #endregion

        #region 直播审核

        /// <summary>
        /// 提交直播审核
        /// <para>用户提供视频路径，创建一次视频审核。</para>
        /// <para>支持RTMP/HTTP拉流</para>
        /// <para>正在审核中的直播（以直播流地址区分）无法重复发起审核</para>
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCR/s/Jk986d4a5#%E6%8F%90%E4%BA%A4%E7%9B%B4%E6%92%AD%E5%AE%A1%E6%A0%B8 </para>
        /// </summary>
        /// <param name="source">直播流地址，支持RTMP/HTTP拉流</param>
        /// <param name="notification">通知名称</param>
        /// <param name="preset">审核模板名称</param>
        /// <param name="description">视频描述，默认为空字符串，不超过256字符</param>
        /// <param name="notifyLevel">通知等级</param>
        /// <param name="thumbnailInterval">抽帧间隔，>=1s,默认为1s</param>
        /// <param name="audioInterval">抽音频间隔，>=10s,默认为30s</param>
        /// <returns>XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrResponse PutStream(string source, string notification, string preset = null, string description = null, XGVcrNotifyLevel? notifyLevel = null,float? thumbnailInterval = null, int? audioInterval = null)
        {
            AssertStringNotNullOrEmpty(source, nameof(source));
            AssertStringNotNullOrEmpty(notification);
            XGVcrPutStreamRequest request = new XGVcrPutStreamRequest()
            {
                Source = source,
                Notification = notification,
                Preset = preset,
                Description = description,
                NotifyLevel=notifyLevel,
                ThumbnailInterval=thumbnailInterval,
                AudioInterval=audioInterval
            };
            return PutStream(request);
        }

        /// <summary>
        /// 提交直播审核
        /// <para>用户提供视频路径，创建一次视频审核。</para>
        /// <para>支持RTMP/HTTP拉流</para>
        /// <para>正在审核中的直播（以直播流地址区分）无法重复发起审核</para>
        /// </summary>
        /// <param name="source">直播流地址，支持RTMP/HTTP拉流</param>
        /// <param name="notification">通知名称</param>
        /// <param name="preset">审核模板名称</param>
        /// <param name="description">视频描述，默认为空字符串，不超过256字符</param>
        /// <param name="notifyLevel">通知等级</param>
        /// <param name="thumbnailInterval">抽帧间隔，>=1s,默认为1s</param>
        /// <param name="audioInterval">抽音频间隔，>=10s,默认为30s</param>
        /// <returns> 异步任务XGVcrResponse </returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrResponse> PutStreamAsync(string source, string notification, string preset = null, string description = null, XGVcrNotifyLevel? notifyLevel = null, float? thumbnailInterval = null, int? audioInterval = null)
        {
            AssertStringNotNullOrEmpty(source, nameof(source));
            AssertStringNotNullOrEmpty(notification);
            XGVcrPutStreamRequest request = new XGVcrPutStreamRequest()
            {
                Source = source,
                Notification = notification,
                Preset = preset,
                Description = description,
                NotifyLevel = notifyLevel,
                ThumbnailInterval = thumbnailInterval,
                AudioInterval = audioInterval
            };
            return await PutStreamAsync(request);
        }

        /// <summary>
        /// 提交直播审核
        /// <para>用户提供视频路径，创建一次视频审核。</para>
        /// <para>支持RTMP/HTTP拉流</para>
        /// <para>正在审核中的直播（以直播流地址区分）无法重复发起审核</para>
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCR/s/Jk986d4a5#%E6%8F%90%E4%BA%A4%E7%9B%B4%E6%92%AD%E5%AE%A1%E6%A0%B8 </para>
        /// </summary>
        /// <param name="request">XGVcrPutStreamRequest</param>
        /// <returns>XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrResponse PutStream(XGVcrPutStreamRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.Source, nameof(request.Source));
            AssertStringNotNullOrEmpty(request.Notification);
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.PUT, request.VcrVersion.ToString(), STREAM);
            XGVcrResponse response = InvokeHttpClient<XGVcrResponse>(iternalRequest);
            return response;
        }

        // <summary>
        /// 提交直播审核
        /// <para>用户提供视频路径，创建一次视频审核。</para>
        /// <para>支持RTMP/HTTP拉流</para>
        /// <para>正在审核中的直播（以直播流地址区分）无法重复发起审核</para>
        /// </summary>
        /// <param name="request">XGVcrPutStreamRequest</param>
        /// <returns> 异步任务XGVcrResponse </returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrResponse> PutStreamAsync(XGVcrPutStreamRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.Source, nameof(request.Source));
            AssertStringNotNullOrEmpty(request.Notification);
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.PUT, request.VcrVersion.ToString(), STREAM);
            XGVcrResponse response = await InvokeHttpClientAsync<XGVcrResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询直播流审核状态
        /// <para>查询某条直播流的审核状态</para>
        /// <para> 参考文档：https://cloud.baidu.com/doc/VCR/s/Jk986d4a5#%E6%9F%A5%E8%AF%A2%E7%9B%B4%E6%92%AD%E6%B5%81%E5%AE%A1%E6%A0%B8%E7%8A%B6%E6%80%81 </para>
        /// </summary>
        /// <param name="source">直播流地址</param>
        /// <returns>XGVcrQueryStreamStatusResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrQueryStreamStatusResponse QueryStreamStatus(string source)
        {
            AssertStringNotNullOrEmpty(source, nameof(source));
            XGVcrQueryStreamStatusRequest request = new XGVcrQueryStreamStatusRequest()
            {
                Source = source
            };
            return QueryStreamStatus(request);
        }

        /// <summary>
        /// 查询直播流审核状态
        /// <para>查询某条直播流的审核状态</para>
        /// </summary>
        /// <param name="source">直播流地址</param>
        /// <returns> 异步任务XGVcrQueryStreamStatusResponse </returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrQueryStreamStatusResponse> QueryStreamStatusAsync(string source)
        {
            AssertStringNotNullOrEmpty(source, nameof(source));
            XGVcrQueryStreamStatusRequest request = new XGVcrQueryStreamStatusRequest()
            {
                Source = source
            };
            return await QueryStreamStatusAsync(request);
        }

        /// <summary>
        /// 查询直播流审核状态
        /// <para>查询某条直播流的审核状态</para>
        /// <para> 参考文档：https://cloud.baidu.com/doc/VCR/s/Jk986d4a5#%E6%9F%A5%E8%AF%A2%E7%9B%B4%E6%92%AD%E6%B5%81%E5%AE%A1%E6%A0%B8%E7%8A%B6%E6%80%81 </para>
        /// </summary>
        /// <param name="request">XGVcrQueryStreamStatusRequest</param>
        /// <returns>XGVcrQueryStreamStatusResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrQueryStreamStatusResponse QueryStreamStatus(XGVcrQueryStreamStatusRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.Source, nameof(request.Source));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.VcrVersion.ToString(), STREAM);
            iternalRequest.AddParameter("source", request.Source);
            XGVcrQueryStreamStatusResponse response = InvokeHttpClient<XGVcrQueryStreamStatusResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询直播流审核状态
        /// <para>查询某条直播流的审核状态</para>
        /// </summary>
        /// <param name="request">XGVcrQueryStreamStatusRequest</param>
        /// <returns> 异步任务XGVcrQueryStreamStatusResponse </returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrQueryStreamStatusResponse> QueryStreamStatusAsync(XGVcrQueryStreamStatusRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.Source, nameof(request.Source));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.VcrVersion.ToString(), STREAM);
            iternalRequest.AddParameter("source", request.Source);
            XGVcrQueryStreamStatusResponse response = await InvokeHttpClientAsync<XGVcrQueryStreamStatusResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 直播流审核列表页
        /// <para>可以根据状态查询直播流的列表页</para>
        /// <para> 参考文档：https://cloud.baidu.com/doc/VCR/s/Jk986d4a5#%E7%9B%B4%E6%92%AD%E6%B5%81%E5%AE%A1%E6%A0%B8%E5%88%97%E8%A1%A8%E9%A1%B5 </para>
        /// </summary>
        /// <param name="maxKeys">本次请求返回的任务列表的最大元素个数，合法取值范围为[1-100]，默认值为10</param>
        /// <param name="marker">本次请求的marker，标记查询的起始位置，是上次marker机制查询返回的nextMarker，首次查询不提供本字段</param>
        /// <param name="status">直播流状态</param>
        /// <returns>XGVcrListStreamStatusResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrListStreamStatusResponse ListStreamStatus(int? maxKeys=null, string marker=null, XGVcrStreamStatus? status=null)
        {
            XGVcrListStreamStatusRequest request = new XGVcrListStreamStatusRequest()
            {
                MaxKeys = maxKeys,
                Marker = marker,
                Status = status
            };
            return ListStreamStatus(request);
        }

        /// <summary>
        /// 直播流审核列表页
        /// <para>可以根据状态查询直播流的列表页</para>
        /// </summary>
        /// <param name="maxKeys">本次请求返回的任务列表的最大元素个数，合法取值范围为[1-100]，默认值为10</param>
        /// <param name="marker">本次请求的marker，标记查询的起始位置，是上次marker机制查询返回的nextMarker，首次查询不提供本字段</param>
        /// <param name="status">直播流状态</param>
        /// <returns> 异步任务XGVcrListStreamStatusResponse </returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrListStreamStatusResponse> ListStreamStatusAsync(int? maxKeys = null, string marker = null, XGVcrStreamStatus? status = null)
        {
            XGVcrListStreamStatusRequest request = new XGVcrListStreamStatusRequest()
            {
                MaxKeys = maxKeys,
                Marker = marker,
                Status = status
            };
            return await ListStreamStatusAsync(request);
        }

        /// <summary>
        /// 直播流审核列表页
        /// <para>可以根据状态查询直播流的列表页</para>
        /// <para> 参考文档：https://cloud.baidu.com/doc/VCR/s/Jk986d4a5#%E7%9B%B4%E6%92%AD%E6%B5%81%E5%AE%A1%E6%A0%B8%E5%88%97%E8%A1%A8%E9%A1%B5 </para>
        /// </summary>
        /// <param name="request">XGVcrListStreamStatusRequest</param>
        /// <returns>XGVcrListStreamStatusResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrListStreamStatusResponse ListStreamStatus(XGVcrListStreamStatusRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.VcrVersion.ToString(), STREAM);
            if(request.MaxKeys!=null)
                iternalRequest.AddParameter("maxKeys", request.MaxKeys.Value.ToString());
            if(string.IsNullOrEmpty(request.Marker) || string.IsNullOrWhiteSpace(request.Marker))
                iternalRequest.AddParameter("marker",request.Marker);
            if (request.Status!=null)
                iternalRequest.AddParameter("status", request.Status.ToString());
            XGVcrListStreamStatusResponse response = InvokeHttpClient<XGVcrListStreamStatusResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 直播流审核列表页
        /// <para>可以根据状态查询直播流的列表页</para>
        /// </summary>
        /// <param name="request">XGVcrListStreamStatusRequest</param>
        /// <returns> 异步任务XGVcrListStreamStatusResponse </returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrListStreamStatusResponse> ListStreamStatusAsync(XGVcrListStreamStatusRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.VcrVersion.ToString(), STREAM);
            if (request.MaxKeys != null)
                iternalRequest.AddParameter("maxKeys", request.MaxKeys.Value.ToString());
            if (string.IsNullOrEmpty(request.Marker) || string.IsNullOrWhiteSpace(request.Marker))
                iternalRequest.AddParameter("marker", request.Marker);
            if (request.Status != null)
                iternalRequest.AddParameter("status", request.Status.ToString());
            XGVcrListStreamStatusResponse response = await InvokeHttpClientAsync<XGVcrListStreamStatusResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 取消直播流审核
        /// <para>取消正在进行的直播审核任务。</para>
        /// </summary>
        /// <param name="source">直播流地址，支持RTMP/HTTP拉流</param>
        /// <param name="notification">通知名称</param>
        /// <returns> 异步任务XGVcrResponse </returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrResponse> CancelStreamAsync(string source, string notification)
        {
            AssertStringNotNullOrEmpty(source, nameof(source));
            AssertStringNotNullOrEmpty(notification);
            XGVcrCancelStreamRequest request = new XGVcrCancelStreamRequest()
            {
                Source = source,
                Notification = notification
            };
            return await CancelStreamAsync(request);
        }

        /// <summary>
        /// 取消直播流审核
        /// <para>取消正在进行的直播审核任务。</para>
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCR/s/Jk986d4a5#%E5%8F%96%E6%B6%88%E7%9B%B4%E6%92%AD%E6%B5%81%E5%AE%A1%E6%A0%B8 </para>
        /// </summary>
        /// <param name="source">直播流地址，支持RTMP/HTTP拉流</param>
        /// <param name="notification">通知名称</param>
        /// <returns>XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrResponse CancelStream(string source, string notification)
        {
            AssertStringNotNullOrEmpty(source, nameof(source));
            AssertStringNotNullOrEmpty(notification);
            XGVcrCancelStreamRequest request = new XGVcrCancelStreamRequest()
            {
                Source=source,
                Notification=notification
            };
            return CancelStream(request);
        }

        /// <summary>
        /// 取消直播流审核
        /// <para>取消正在进行的直播审核任务。</para>
        /// </summary>
        /// <param name="request">XGVcrCancelStreamRequest</param>
        /// <returns> 异步任务XGVcrResponse </returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrResponse> CancelStreamAsync(XGVcrCancelStreamRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.Source, nameof(request.Source));
            AssertStringNotNullOrEmpty(request.Notification);
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.PUT, request.VcrVersion.ToString(), STREAM);
            XGVcrResponse response = await InvokeHttpClientAsync<XGVcrResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 取消直播流审核
        /// <para>取消正在进行的直播审核任务。</para>
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCR/s/Jk986d4a5#%E5%8F%96%E6%B6%88%E7%9B%B4%E6%92%AD%E6%B5%81%E5%AE%A1%E6%A0%B8 </para>
        /// </summary>
        /// <param name="request">XGVcrCancelStreamRequest</param>
        /// <returns>XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrResponse CancelStream(XGVcrCancelStreamRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.Source, nameof(request.Source));
            AssertStringNotNullOrEmpty(request.Notification);
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.PUT, request.VcrVersion.ToString(), STREAM);
            XGVcrResponse response = InvokeHttpClient<XGVcrResponse>(iternalRequest);
            return response;
        }

        #endregion

        #region 公共自定义库接口

        /// <summary>
        /// 创建自定义库
        /// </summary>
        /// <param name="request">XGAbstractVcrCreateCustomLibRequest</param>
        /// <returns>XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrResponse CreateCustomLib(XGAbstractVcrCreateCustomLibRequest abstractRequest)
        {
            AssertNotNullOrEmpty(abstractRequest, nameof(abstractRequest));

            if (abstractRequest is XGVcrCreateCustomFaceLibRequest)
            {
                var request = abstractRequest as XGVcrCreateCustomFaceLibRequest;
                AssertStringNotNullOrEmpty(request.Lib);
            }
            else if( abstractRequest as XGVcrCreateCustomLogoLibRequest != null)
            {
                var request = abstractRequest as XGVcrCreateCustomLogoLibRequest;
                AssertStringNotNullOrEmpty(request.Lib);
            }
            else if(abstractRequest as XGVcrCreateCustomTextLibRequest != null)
            {
                var request = abstractRequest as XGVcrCreateCustomTextLibRequest;
                AssertStringNotNullOrEmpty(request.Name, nameof(request.Name));
            }
            else if(abstractRequest as XGVcrCreateCustomImageLibRequest != null)
            {
                var request = abstractRequest as XGVcrCreateCustomImageLibRequest;
                AssertStringNotNullOrEmpty(request.Name, nameof(request.Name));
            }
            XGBceIternalRequest iternalRequest = CreateRequest(abstractRequest, BceHttpMethod.POST, abstractRequest.VcrVersion.ToString(), abstractRequest.LibType,"lib");
            XGVcrResponse response = InvokeHttpClient<XGVcrResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 创建自定义库
        /// </summary>
        /// <param name="request">XGAbstractVcrCreateCustomLibRequest</param>
        /// <returns>异步任务XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrResponse> CreateCustomLibAsync(XGAbstractVcrCreateCustomLibRequest abstractRequest)
        {
            AssertNotNullOrEmpty(abstractRequest, nameof(abstractRequest));

            if (abstractRequest is XGVcrCreateCustomFaceLibRequest)
            {
                var request = abstractRequest as XGVcrCreateCustomFaceLibRequest;
                AssertStringNotNullOrEmpty(request.Lib);
            }
            else if (abstractRequest as XGVcrCreateCustomLogoLibRequest != null)
            {
                var request = abstractRequest as XGVcrCreateCustomLogoLibRequest;
                AssertStringNotNullOrEmpty(request.Lib);
            }
            else if (abstractRequest as XGVcrCreateCustomTextLibRequest != null)
            {
                var request = abstractRequest as XGVcrCreateCustomTextLibRequest;
                AssertStringNotNullOrEmpty(request.Name, nameof(request.Name));
            }
            else if (abstractRequest as XGVcrCreateCustomImageLibRequest != null)
            {
                var request = abstractRequest as XGVcrCreateCustomImageLibRequest;
                AssertStringNotNullOrEmpty(request.Name, nameof(request.Name));
            }
            XGBceIternalRequest iternalRequest = CreateRequest(abstractRequest, BceHttpMethod.POST, abstractRequest.VcrVersion.ToString(), abstractRequest.LibType, "lib");
            XGVcrResponse response = await InvokeHttpClientAsync<XGVcrResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 删除自定义库
        /// </summary>
        /// <param name="request">XGAbstractVcrCreateCustomLibRequest</param>
        /// <returns>XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrResponse DeleteCustomLib(XGAbstractVcrDeleteCustomLibRequest abstractRequest)
        {
            AssertNotNullOrEmpty(abstractRequest, nameof(abstractRequest));

            if (abstractRequest is XGVcrDeleteCustomFaceLibRequest)
            {
                var request = abstractRequest as XGVcrDeleteCustomFaceLibRequest;
                AssertStringNotNullOrEmpty(request.Lib);
            }
            else if (abstractRequest as XGVcrDeleteCustomTextLibRequest != null)
            {
                var request = abstractRequest as XGVcrDeleteCustomTextLibRequest;
                AssertStringNotNullOrEmpty(request.Name, nameof(request.Name));
            }
            else if (abstractRequest as XGVcrDeleteCustomImageLibRequest != null)
            {
                var request = abstractRequest as XGVcrDeleteCustomImageLibRequest;
                AssertStringNotNullOrEmpty(request.Name, nameof(request.Name));
            }

            XGBceIternalRequest iternalRequest = CreateRequest(abstractRequest, BceHttpMethod.DELETE, abstractRequest.VcrVersion.ToString(), abstractRequest.LibType, "lib",abstractRequest.Libname);
            XGVcrResponse response = InvokeHttpClient<XGVcrResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 删除自定义库
        /// </summary>
        /// <param name="request">XGAbstractVcrCreateCustomLibRequest</param>
        /// <returns>异步任务XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrResponse> DeleteCustomLibAsync(XGAbstractVcrDeleteCustomLibRequest abstractRequest)
        {
            AssertNotNullOrEmpty(abstractRequest, nameof(abstractRequest));

            if (abstractRequest is XGVcrDeleteCustomFaceLibRequest)
            {
                var request = abstractRequest as XGVcrDeleteCustomFaceLibRequest;
                AssertStringNotNullOrEmpty(request.Lib);
            }
            else if (abstractRequest as XGVcrDeleteCustomTextLibRequest != null)
            {
                var request = abstractRequest as XGVcrDeleteCustomTextLibRequest;
                AssertStringNotNullOrEmpty(request.Name, nameof(request.Name));
            }
            else if (abstractRequest as XGVcrDeleteCustomImageLibRequest != null)
            {
                var request = abstractRequest as XGVcrDeleteCustomImageLibRequest;
                AssertStringNotNullOrEmpty(request.Name, nameof(request.Name));
            }

            XGBceIternalRequest iternalRequest = CreateRequest(abstractRequest, BceHttpMethod.DELETE, abstractRequest.VcrVersion.ToString(), abstractRequest.LibType, "lib", abstractRequest.Libname);
            XGVcrResponse response = await InvokeHttpClientAsync<XGVcrResponse>(iternalRequest);
            return response;
        }

        #endregion

        #region 自定义face库接口

        /// <summary>
        /// 创建自定义face库
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCR/s/cjwvyaysw#%E5%88%9B%E5%BB%BA%E8%87%AA%E5%AE%9A%E4%B9%89face%E5%BA%93 </para>
        /// </summary>
        /// <param name="lib">face库名称</param>
        /// <param name="description">描述，最大支持256字符</param>
        /// <returns>XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrResponse CreateCustomFaceLib(string lib,string description=null)
        {
            AssertStringNotNullOrEmpty(lib);
            XGVcrCreateCustomFaceLibRequest request = new XGVcrCreateCustomFaceLibRequest()
            {
                Lib=lib,
                Description=description
            };
            return CreateCustomFaceLib(request);
        }

        /// <summary>
        /// 创建自定义face库
        /// </summary>
        /// <param name="lib">face库名称</param>
        /// <param name="description">描述，最大支持256字符</param>
        /// <returns>XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrResponse> CreateCustomFaceLibAsync(string lib, string description = null)
        {
            AssertStringNotNullOrEmpty(lib);
            XGVcrCreateCustomFaceLibRequest request = new XGVcrCreateCustomFaceLibRequest()
            {
                Lib = lib,
                Description = description
            };
            return await CreateCustomFaceLibAsync(request);
        }

        /// <summary>
        /// 创建自定义face库
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCR/s/cjwvyaysw#%E5%88%9B%E5%BB%BA%E8%87%AA%E5%AE%9A%E4%B9%89face%E5%BA%93 </para>
        /// </summary>
        /// <param name="request">XGVcrCreateCustomFaceLibRequest</param>
        /// <returns>XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrResponse CreateCustomFaceLib(XGVcrCreateCustomFaceLibRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.Lib);
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.POST, request.VcrVersion.ToString(), request.LibType, "lib");
            XGVcrResponse response = InvokeHttpClient<XGVcrResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 创建自定义face库
        /// </summary>
        /// <param name="request">XGVcrCreateCustomFaceLibRequest</param>
        /// <returns>异步任务XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrResponse> CreateCustomFaceLibAsync(XGVcrCreateCustomFaceLibRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.Lib);
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.POST, request.VcrVersion.ToString(), request.LibType, "lib");
            XGVcrResponse response = await InvokeHttpClientAsync<XGVcrResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 删除自定义face库
        /// <para>删除face库会导致绑定该库的审核模版不可用，删除face库前请确认已无模版绑定该库。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/VCR/s/cjwvyaysw#%E5%88%A0%E9%99%A4%E8%87%AA%E5%AE%9A%E4%B9%89face%E5%BA%93 </para>
        /// </summary>
        /// <param name="lib_name">自定义人脸库名称</param>
        /// <returns>XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrResponse DeleteCustomFaceLib(string lib_name)
        {
            AssertStringNotNullOrEmpty(lib_name, nameof(lib_name));

            XGVcrBaseRequest request = new XGVcrBaseRequest();
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.DELETE, request.VcrVersion.ToString(), FACE, "lib",lib_name);
            XGVcrResponse response = InvokeHttpClient<XGVcrResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 删除自定义face库
        /// <para>删除face库会导致绑定该库的审核模版不可用，删除face库前请确认已无模版绑定该库。</para>
        /// </summary>
        /// <param name="lib_name">自定义人脸库名称</param>
        /// <returns>异步任务XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrResponse> DeleteCustomFaceLibAsync(string lib_name)
        {
            AssertStringNotNullOrEmpty(lib_name, nameof(lib_name));

            XGVcrBaseRequest request = new XGVcrBaseRequest();
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.DELETE, request.VcrVersion.ToString(), FACE, "lib", lib_name);
            XGVcrResponse response = await InvokeHttpClientAsync<XGVcrResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 列出所有face库
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCR/s/cjwvyaysw#%E5%88%97%E5%87%BA%E6%89%80%E6%9C%89face%E5%BA%93 </para>
        /// </summary>
        /// <returns>XGVcrListFaceLibResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrListFaceLibResponse ListFaceLibs()
        {
            XGVcrBaseRequest request = new XGVcrBaseRequest();
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.VcrVersion.ToString(), FACE, "lib");
            XGVcrListFaceLibResponse response = InvokeHttpClient<XGVcrListFaceLibResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 列出所有face库
        /// </summary>
        /// <returns>异步任务XGVcrListFaceLibResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrListFaceLibResponse> ListFaceLibsAsync()
        {
            XGVcrBaseRequest request = new XGVcrBaseRequest();
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.VcrVersion.ToString(), FACE, "lib");
            XGVcrListFaceLibResponse response = await InvokeHttpClientAsync<XGVcrListFaceLibResponse>(iternalRequest);
            return response;
        }


        /// <summary>
        /// 添加face库集素材
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCR/s/cjwvyaysw#face%E5%BA%93%E9%9B%86%E7%B4%A0%E6%9D%90%E6%B7%BB%E5%8A%A0 </para>
        /// <para>对于BOS图片，source="bos://$bos-bucket/$bos-object”，例如"bos://testbucket/dir/image.jpg”</para>
        /// <para>对于url图片，source="http://domain.com/dir/image.jpg"，目前支持http/https协议url，用户需要确保该url外网可访问。</para>
        /// </summary>
        /// <param name="libName">库名称</param>
        /// <param name="image">图片URL</param>
        /// <param name="brief">库集名称</param>
        /// <returns>XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrResponse AddFaceLibBriefImage(string libName, string image, string brief)
        {

            AssertStringNotNullOrEmpty(image, nameof(image));
            AssertStringNotNullOrEmpty(brief, nameof(brief));
            AssertStringNotNullOrEmpty(libName, nameof(libName));
            XGVcrAddFaceLibBriefImageRequest request = new XGVcrAddFaceLibBriefImageRequest()
            {
                LibName=libName,
                Image=image,
                Brief=brief
            };
            return AddFaceLibBriefImage(request);
        }

        /// <summary>
        /// 添加face库集素材
        /// <para>对于BOS图片，source="bos://$bos-bucket/$bos-object”，例如"bos://testbucket/dir/image.jpg”</para>
        /// <para>对于url图片，source="http://domain.com/dir/image.jpg"，目前支持http/https协议url，用户需要确保该url外网可访问。</para>
        /// </summary>
        /// <param name="libName">库名称</param>
        /// <param name="image">图片URL</param>
        /// <param name="brief">库集名称</param>
        /// <returns>异步任务XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrResponse> AddFaceLibBriefImageAsync(string libName, string image, string brief)
        {
            AssertStringNotNullOrEmpty(image, nameof(image));
            AssertStringNotNullOrEmpty(brief, nameof(brief));
            AssertStringNotNullOrEmpty(libName, nameof(libName));
            XGVcrAddFaceLibBriefImageRequest request = new XGVcrAddFaceLibBriefImageRequest()
            {
                LibName = libName,
                Image = image,
                Brief = brief
            };
            return await AddFaceLibBriefImageAsync(request);
        }

        /// <summary>
        /// 添加face库集素材
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCR/s/cjwvyaysw#face%E5%BA%93%E9%9B%86%E7%B4%A0%E6%9D%90%E6%B7%BB%E5%8A%A0 </para>
        /// </summary>
        /// <param name="request">XGVcrAddFaceLibBriefImageRequest</param>
        /// <returns>XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrResponse AddFaceLibBriefImage(XGVcrAddFaceLibBriefImageRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request),"request 不能为空");
            }

            AssertStringNotNullOrEmpty(request.Image, nameof(request.Image));
            AssertStringNotNullOrEmpty(request.Brief, nameof(request.Brief));
            AssertStringNotNullOrEmpty(request.LibName, nameof(request.LibName));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.POST, request.VcrVersion.ToString(), request.LibType, "lib",request.LibName);
            XGVcrResponse response = InvokeHttpClient<XGVcrResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 添加face库集素材
        /// </summary>
        /// <param name="request">XGVcrAddFaceLibBriefImageRequest</param>
        /// <returns>异步任务XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrResponse> AddFaceLibBriefImageAsync(XGVcrAddFaceLibBriefImageRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request),"request 不能为空");
            }

            AssertStringNotNullOrEmpty(request.Image, nameof(request.Image));
            AssertStringNotNullOrEmpty(request.Brief, nameof(request.Brief));
            AssertStringNotNullOrEmpty(request.LibName, nameof(request.LibName));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.POST, request.VcrVersion.ToString(), request.LibType, "lib", request.LibName);
            XGVcrResponse response = await InvokeHttpClientAsync<XGVcrResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 删除face库集素材
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCR/s/cjwvyaysw#face%E5%BA%93%E9%9B%86%E7%B4%A0%E6%9D%90%E5%88%A0%E9%99%A4 </para>
        /// </summary>
        /// <param name="libName">库名称</param>
        /// <param name="image">图片URL</param>
        /// <param name="brief">brief</param>
        /// <returns>XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrResponse DeleteFaceLibBriefImage(string libName,string image,string brief)
        {
            AssertStringNotNullOrEmpty(image, nameof(image));
            AssertStringNotNullOrEmpty(brief, nameof(brief));
            AssertStringNotNullOrEmpty(libName, nameof(libName));
            XGVcrDeleteFaceLibBriefImageRequest request = new XGVcrDeleteFaceLibBriefImageRequest()
            {
                LibName = libName,
                Image = image,
                Brief = brief
            };
            return DeleteFaceLibBriefImage(request);
        }

        /// <summary>
        /// 删除face库集素材
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCR/s/cjwvyaysw#face%E5%BA%93%E9%9B%86%E7%B4%A0%E6%9D%90%E5%88%A0%E9%99%A4 </para>
        /// </summary>
        /// <param name="libName">库名称</param>
        /// <param name="image">图片URL</param>
        /// <param name="brief">brief</param>
        /// <returns>异步任务XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrResponse> DeleteFaceLibBriefImageAsync(string libName, string image, string brief)
        {
            AssertStringNotNullOrEmpty(image, nameof(image));
            AssertStringNotNullOrEmpty(brief, nameof(brief));
            AssertStringNotNullOrEmpty(libName, nameof(libName));
            XGVcrDeleteFaceLibBriefImageRequest request = new XGVcrDeleteFaceLibBriefImageRequest()
            {
                LibName = libName,
                Image = image,
                Brief = brief
            };
            return await DeleteFaceLibBriefImageAsync(request);
        }

        /// <summary>
        /// 删除face库集素材
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCR/s/cjwvyaysw#face%E5%BA%93%E9%9B%86%E7%B4%A0%E6%9D%90%E5%88%A0%E9%99%A4 </para>
        /// </summary>
        /// <param name="request">XGVcrDeleteFaceLibBriefImageRequest</param>
        /// <returns>XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrResponse DeleteFaceLibBriefImage(XGVcrDeleteFaceLibBriefImageRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request),"request 不能为空");
            }

            AssertStringNotNullOrEmpty(request.Image, nameof(request.Image));
            AssertStringNotNullOrEmpty(request.Brief, nameof(request.Brief));
            AssertStringNotNullOrEmpty(request.LibName, nameof(request.LibName));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.DELETE, request.VcrVersion.ToString(), request.LibType, "lib", request.LibName);
            iternalRequest.AddParameter("brief", request.Brief);
            iternalRequest.AddParameter("image", request.Image);
            XGVcrResponse response = InvokeHttpClient<XGVcrResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 删除face库集素材
        /// </summary>
        /// <param name="request">XGVcrDeleteFaceLibBriefImageRequest</param>
        /// <returns>异步任务XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrResponse> DeleteFaceLibBriefImageAsync(XGVcrDeleteFaceLibBriefImageRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request),"request 不能为空");
            }

            AssertStringNotNullOrEmpty(request.Image, nameof(request.Image));
            AssertStringNotNullOrEmpty(request.Brief, nameof(request.Brief));
            AssertStringNotNullOrEmpty(request.LibName, nameof(request.LibName));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.DELETE, request.VcrVersion.ToString(), request.LibType, "lib", request.LibName);
            iternalRequest.AddParameter("brief", request.Brief);
            iternalRequest.AddParameter("image", request.Image);
            XGVcrResponse response = await InvokeHttpClientAsync<XGVcrResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 列举face库集素材
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCR/s/Cjwvyax35#logo%E5%BA%93%E9%9B%86%E7%B4%A0%E6%9D%90%E5%88%97%E8%A1%A8 </para>
        /// </summary>
        /// <param name="libName">库名称</param>
        /// <param name="brief">brief</param>
        /// <returns>XGVcrListFaceLibBriefImagesResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrListFaceLibBriefImagesResponse ListFaceLibBriefImage(string libName,string brief)
        {
            AssertStringNotNullOrEmpty(brief, nameof(brief));
            AssertStringNotNullOrEmpty(libName, nameof(libName));
            XGVcrListFaceLibBriefImagesRequest request = new XGVcrListFaceLibBriefImagesRequest()
            {
                LibName=libName,
                Brief=brief
            };
            return ListFaceLibBriefImage(request);
        }

        /// <summary>
        /// 列举face库集素材
        /// </summary>
        /// <param name="libName">库名称</param>
        /// <param name="brief">brief</param>
        /// <returns>异步任务XGVcrListFaceLibBriefImagesResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrListFaceLibBriefImagesResponse> ListFaceLibBriefImageAsync(string libName, string brief)
        {
            AssertStringNotNullOrEmpty(brief, nameof(brief));
            AssertStringNotNullOrEmpty(libName, nameof(libName));
            XGVcrListFaceLibBriefImagesRequest request = new XGVcrListFaceLibBriefImagesRequest()
            {
                LibName = libName,
                Brief = brief
            };
            return await ListFaceLibBriefImageAsync(request);
        }

        /// <summary>
        /// 列举face库集素材
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCR/s/Cjwvyax35#logo%E5%BA%93%E9%9B%86%E7%B4%A0%E6%9D%90%E5%88%97%E8%A1%A8 </para>
        /// </summary>
        /// <param name="request">XGVcrListFaceLibBriefImagesRequest</param>
        /// <returns>XGVcrListFaceLibBriefImagesResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrListFaceLibBriefImagesResponse ListFaceLibBriefImage(XGVcrListFaceLibBriefImagesRequest request)
        {
            AssertNotNullOrEmpty(request,nameof(request));
            AssertStringNotNullOrEmpty(request.Brief, nameof(request.Brief));
            AssertStringNotNullOrEmpty(request.LibName, nameof(request.LibName));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.VcrVersion.ToString(), FACE, "lib", request.LibName);
            iternalRequest.AddParameter("brief", request.Brief);
            XGVcrListFaceLibBriefImagesResponse response = InvokeHttpClient<XGVcrListFaceLibBriefImagesResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 列举face库集素材
        /// </summary>
        /// <param name="request">XGVcrListFaceLibBriefImagesRequest</param>
        /// <returns>XGVcrListFaceLibBriefImagesResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrListFaceLibBriefImagesResponse> ListFaceLibBriefImageAsync(XGVcrListFaceLibBriefImagesRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.Brief, nameof(request.Brief));
            AssertStringNotNullOrEmpty(request.LibName, nameof(request.LibName));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.VcrVersion.ToString(), FACE, "lib", request.LibName);
            iternalRequest.AddParameter("brief", request.Brief);
            XGVcrListFaceLibBriefImagesResponse response = await InvokeHttpClientAsync<XGVcrListFaceLibBriefImagesResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 删除face库集
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCR/s/cjwvyaysw#face%E5%BA%93%E9%9B%86%E5%88%A0%E9%99%A4 </para>
        /// </summary>
        /// <param name="libName">库名称</param>
        /// <param name="brief">库集名称</param>
        /// <param name="request">XGVcrDeleteFaceLibBriefRequest</param>
        /// <returns>XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrResponse DeleteFaceLibBrief(string libName,string brief)
        {
            AssertStringNotNullOrEmpty(brief, nameof(brief));
            AssertStringNotNullOrEmpty(libName, nameof(libName));
            XGVcrDeleteFaceLibBriefRequest request = new XGVcrDeleteFaceLibBriefRequest()
            {
                Brief=brief,
                LibName=libName
            };
            return DeleteFaceLibBrief(request);
        }

        /// <summary>
        /// 删除face库集
        /// </summary>
        /// <param name="libName">库名称</param>
        /// <param name="brief">库集名称</param>
        /// <param name="request">XGVcrDeleteFaceLibBriefRequest</param>
        /// <returns>异步任务XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrResponse> DeleteFaceLibBriefAsync(string libName, string brief)
        {
            AssertStringNotNullOrEmpty(brief, nameof(brief));
            AssertStringNotNullOrEmpty(libName, nameof(libName));
            XGVcrDeleteFaceLibBriefRequest request = new XGVcrDeleteFaceLibBriefRequest()
            {
                Brief = brief,
                LibName = libName
            };
            return await DeleteFaceLibBriefAsync(request);
        }

        /// <summary>
        /// 删除face库集
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCR/s/cjwvyaysw#face%E5%BA%93%E9%9B%86%E5%88%A0%E9%99%A4 </para>
        /// </summary>
        /// <param name="request">XGVcrDeleteFaceLibBriefRequest</param>
        /// <returns>XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrResponse DeleteFaceLibBrief(XGVcrDeleteFaceLibBriefRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.Brief, nameof(request.Brief));
            AssertStringNotNullOrEmpty(request.LibName, nameof(request.LibName));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.DELETE, request.VcrVersion.ToString(), FACE, "lib", request.LibName);
            iternalRequest.AddParameter("brief", request.Brief);
            XGVcrResponse response = InvokeHttpClient<XGVcrResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 删除face库集
        /// </summary>
        /// <param name="request">XGVcrDeleteFaceLibBriefRequest</param>
        /// <returns>XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrResponse> DeleteFaceLibBriefAsync(XGVcrDeleteFaceLibBriefRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.Brief, nameof(request.Brief));
            AssertStringNotNullOrEmpty(request.LibName, nameof(request.LibName));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.DELETE, request.VcrVersion.ToString(), FACE, "lib", request.LibName);
            iternalRequest.AddParameter("brief", request.Brief);
            XGVcrResponse response = await InvokeHttpClientAsync<XGVcrResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 列举face库集名称集合
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCR/s/cjwvyaysw#face%E5%BA%93%E9%9B%86%E5%88%A0%E9%99%A4 </para>
        /// </summary>
        /// <param name="libName">face库名称</param>
        /// <returns>XGVcrListFaceLibBriefsResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrListFaceLibBriefsResponse ListFaceLibBriefs(string libName)
        {
            AssertStringNotNullOrEmpty(libName, nameof(libName));
            XGVcrListFaceLibBriefsRequest request = new XGVcrListFaceLibBriefsRequest()
            {
                LibName=libName
            };
            return ListFaceLibBriefs(request);
        }

        /// <summary>
        /// 列举face库集名称集合
        /// </summary>
        /// <param name="libName">face库名称</param>
        /// <returns>异步任务XGVcrListFaceLibBriefsResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrListFaceLibBriefsResponse> ListFaceLibBriefsAsync(string libName)
        {
            AssertStringNotNullOrEmpty(libName, nameof(libName));
            XGVcrListFaceLibBriefsRequest request = new XGVcrListFaceLibBriefsRequest()
            {
                LibName = libName
            };
            return await ListFaceLibBriefsAsync(request);
        }

        /// <summary>
        /// 列举face库集名称集合
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCR/s/cjwvyaysw#face%E5%BA%93%E9%9B%86%E5%88%A0%E9%99%A4 </para>
        /// </summary>
        /// <param name="request">XGVcrListFaceLibBriefsRequest</param>
        /// <returns>XGVcrListFaceLibBriefsResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrListFaceLibBriefsResponse ListFaceLibBriefs(XGVcrListFaceLibBriefsRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.LibName, nameof(request.LibName));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.VcrVersion.ToString(), FACE, "lib", request.LibName);
            XGVcrListFaceLibBriefsResponse response = InvokeHttpClient<XGVcrListFaceLibBriefsResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 列举face库集名称集合
        /// </summary>
        /// <param name="request">XGVcrListFaceLibBriefsRequest</param>
        /// <returns>异步任务XGVcrListFaceLibBriefsResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrListFaceLibBriefsResponse> ListFaceLibBriefsAsync(XGVcrListFaceLibBriefsRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.LibName, nameof(request.LibName));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.VcrVersion.ToString(), FACE, "lib", request.LibName);
            XGVcrListFaceLibBriefsResponse response = await InvokeHttpClientAsync<XGVcrListFaceLibBriefsResponse>(iternalRequest);
            return response;
        }


        #endregion

        #region 自定义logo库接口

        /// <summary>
        /// 创建自定义logo库
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCR/s/Cjwvyax35#%E5%88%9B%E5%BB%BA%E8%87%AA%E5%AE%9A%E4%B9%89logo%E5%BA%93 </para>
        /// </summary>
        /// <param name="lib">自定义logo库名称</param>
        /// <param name="description">描述，最大支持256字符</param>
        /// <returns>XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrResponse CreateCustomLogoLib(string lib,string description=null)
        {
            AssertStringNotNullOrEmpty(lib);
            XGVcrCreateCustomLogoLibRequest request = new XGVcrCreateCustomLogoLibRequest()
            {
                Lib=lib,
                Description=description
            };
            return CreateCustomLogoLib(request);
        }

        /// <summary>
        /// 创建自定义logo库
        /// </summary>
        /// <param name="lib">自定义logo库名称</param>
        /// <param name="description">描述，最大支持256字符</param>
        /// <returns>XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrResponse> CreateCustomLogoLibAsync(string lib, string description = null)
        {
            AssertStringNotNullOrEmpty(lib);
            XGVcrCreateCustomLogoLibRequest request = new XGVcrCreateCustomLogoLibRequest()
            {
                Lib = lib,
                Description = description
            };
            return await CreateCustomLogoLibAsync(request);
        }

        /// <summary>
        /// 创建自定义logo库
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCR/s/Cjwvyax35#%E5%88%9B%E5%BB%BA%E8%87%AA%E5%AE%9A%E4%B9%89logo%E5%BA%93 </para>
        /// </summary>
        /// <param name="request">XGVcrCreateCustomLogoLibRequest</param>
        /// <returns>XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrResponse CreateCustomLogoLib(XGVcrCreateCustomLogoLibRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.Lib);
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.POST, request.VcrVersion.ToString(), request.LibType, "lib");
            XGVcrResponse response = InvokeHttpClient<XGVcrResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 创建自定义logo库
        /// </summary>
        /// <param name="request">XGVcrCreateCustomLogoLibRequest</param>
        /// <returns>异步任务XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrResponse> CreateCustomLogoLibAsync(XGVcrCreateCustomLogoLibRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.Lib);
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.POST, request.VcrVersion.ToString(), request.LibType, "lib");
            XGVcrResponse response = await InvokeHttpClientAsync<XGVcrResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 列出所有logo库
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCR/s/Cjwvyax35#%E5%88%97%E5%87%BA%E6%89%80%E6%9C%89logo%E5%BA%93 </para>
        /// </summary>
        /// <returns>XGVcrListLogoLibResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrListLogoLibResponse ListLogoLibs()
        {
            XGVcrBaseRequest request = new XGVcrBaseRequest();
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.VcrVersion.ToString(), LOGO, "lib");
            XGVcrListLogoLibResponse response = InvokeHttpClient<XGVcrListLogoLibResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 列出所有logo库
        /// </summary>
        /// <returns>异步任务XGVcrListLogoLibResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrListLogoLibResponse> ListLogoLibsAsync()
        {
            XGVcrBaseRequest request = new XGVcrBaseRequest();
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.VcrVersion.ToString(), LOGO, "lib");
            XGVcrListLogoLibResponse response = await InvokeHttpClientAsync<XGVcrListLogoLibResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 添加logo库集素材
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCR/s/Cjwvyax35#logo%E5%BA%93%E9%9B%86%E7%B4%A0%E6%9D%90%E6%B7%BB%E5%8A%A0 </para>
        /// <para>对于BOS图片，source="bos://$bos-bucket/$bos-object”，例如"bos://testbucket/dir/image.jpg”</para>
        /// <para>对于url图片，source="http://domain.com/dir/image.jpg"，目前支持http/https协议url，用户需要确保该url外网可访问。</para>
        /// </summary>
        /// <param name="libName">库名称</param>
        /// <param name="image">图片URL</param>
        /// <param name="brief">库集名称</param>
        /// <returns>XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrResponse AddLogoLibBriefImage(string libName, string image, string brief)
        {

            AssertStringNotNullOrEmpty(image, nameof(image));
            AssertStringNotNullOrEmpty(brief, nameof(brief));
            AssertStringNotNullOrEmpty(libName, nameof(libName));
            XGVcrAddLogoLibBriefImageRequest request = new XGVcrAddLogoLibBriefImageRequest()
            {
                LibName = libName,
                Image = image,
                Brief = brief
            };
            return AddLogoLibBriefImage(request);
        }

        /// <summary>
        /// 添加face库集素材
        /// <para>对于BOS图片，source="bos://$bos-bucket/$bos-object”，例如"bos://testbucket/dir/image.jpg”</para>
        /// <para>对于url图片，source="http://domain.com/dir/image.jpg"，目前支持http/https协议url，用户需要确保该url外网可访问。</para>
        /// </summary>
        /// <param name="libName">库名称</param>
        /// <param name="image">图片URL</param>
        /// <param name="brief">库集名称</param>
        /// <returns>异步任务XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrResponse> AddLogoLibBriefImageAsync(string libName, string image, string brief)
        {
            AssertStringNotNullOrEmpty(image, nameof(image));
            AssertStringNotNullOrEmpty(brief, nameof(brief));
            AssertStringNotNullOrEmpty(libName, nameof(libName));
            XGVcrAddLogoLibBriefImageRequest request = new XGVcrAddLogoLibBriefImageRequest()
            {
                LibName = libName,
                Image = image,
                Brief = brief
            };
            return await AddLogoLibBriefImageAsync(request);
        }

        /// <summary>
        /// 添加logo库集素材
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCR/s/Cjwvyax35#logo%E5%BA%93%E9%9B%86%E7%B4%A0%E6%9D%90%E6%B7%BB%E5%8A%A0 </para>
        /// </summary>
        /// <param name="request">XGVcrAddLogoLibBriefImageRequest</param>
        /// <returns>XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrResponse AddLogoLibBriefImage(XGVcrAddLogoLibBriefImageRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.Image, nameof(request.Image));
            AssertStringNotNullOrEmpty(request.Brief, nameof(request.Brief));
            AssertStringNotNullOrEmpty(request.LibName, nameof(request.LibName));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.POST, request.VcrVersion.ToString(), request.LibType, "lib", request.LibName);
            XGVcrResponse response = InvokeHttpClient<XGVcrResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 添加logo库集素材
        /// </summary>
        /// <param name="request">XGVcrAddLogoLibBriefImageRequest</param>
        /// <returns>异步任务XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrResponse> AddLogoLibBriefImageAsync(XGVcrAddLogoLibBriefImageRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.Image, nameof(request.Image));
            AssertStringNotNullOrEmpty(request.Brief, nameof(request.Brief));
            AssertStringNotNullOrEmpty(request.LibName, nameof(request.LibName));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.POST, request.VcrVersion.ToString(), request.LibType, "lib", request.LibName);
            XGVcrResponse response = await InvokeHttpClientAsync<XGVcrResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 删除logo库集素材
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCR/s/Cjwvyax35#logo%E5%BA%93%E9%9B%86%E7%B4%A0%E6%9D%90%E5%88%A0%E9%99%A4 </para>
        /// </summary>
        /// <param name="libName">库名称</param>
        /// <param name="image">图片URL</param>
        /// <param name="imageId">图片id</param>
        /// <returns>XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrResponse DeleteLogoLibBriefImage(string libName, string image, string imageId)
        {
            AssertStringNotNullOrEmpty(image, nameof(image));
            AssertStringNotNullOrEmpty(imageId, nameof(imageId));
            AssertStringNotNullOrEmpty(libName, nameof(libName));
            XGVcrDeleteLogoLibBriefImageRequest request = new XGVcrDeleteLogoLibBriefImageRequest()
            {
                LibName=libName,
                Image=image,
                ImageId=imageId
            };
            return DeleteLogoLibBriefImage(request);
        }

        /// <summary>
        /// 删除logo库集素材
        /// </summary>
        /// <param name="libName">库名称</param>
        /// <param name="image">图片URL</param>
        /// <param name="imageId">图片id</param>
        /// <returns>异步任务XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrResponse> DeleteLogoLibBriefImageAsync(string libName, string image, string imageId)
        {
            AssertStringNotNullOrEmpty(image, nameof(image));
            AssertStringNotNullOrEmpty(imageId, nameof(imageId));
            AssertStringNotNullOrEmpty(libName, nameof(libName));
            XGVcrDeleteLogoLibBriefImageRequest request = new XGVcrDeleteLogoLibBriefImageRequest()
            {
                LibName = libName,
                Image = image,
                ImageId = imageId
            };
            return await DeleteLogoLibBriefImageAsync(request);
        }

        /// <summary>
        /// 删除face库集素材
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCR/s/Cjwvyax35#logo%E5%BA%93%E9%9B%86%E7%B4%A0%E6%9D%90%E5%88%A0%E9%99%A4 </para>
        /// </summary>
        /// <param name="request">XGVcrDeleteLogoLibBriefImageRequest</param>
        /// <returns>XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrResponse DeleteLogoLibBriefImage(XGVcrDeleteLogoLibBriefImageRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.Image, nameof(request.Image));
            AssertStringNotNullOrEmpty(request.ImageId, nameof(request.ImageId));
            AssertStringNotNullOrEmpty(request.LibName, nameof(request.LibName));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.DELETE, request.VcrVersion.ToString(), request.LibType, "lib", request.LibName);
            iternalRequest.AddParameter("image", request.Image);
            iternalRequest.AddParameter("imageId", request.ImageId);
            XGVcrResponse response = InvokeHttpClient<XGVcrResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 删除face库集素材
        /// </summary>
        /// <param name="request">XGVcrDeleteLogoLibBriefImageRequest</param>
        /// <returns>异步任务XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrResponse> DeleteLogoLibBriefImageAsync(XGVcrDeleteLogoLibBriefImageRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.Image, nameof(request.Image));
            AssertStringNotNullOrEmpty(request.ImageId, nameof(request.ImageId));
            AssertStringNotNullOrEmpty(request.LibName, nameof(request.LibName));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.DELETE, request.VcrVersion.ToString(), request.LibType, "lib", request.LibName);
            iternalRequest.AddParameter("image", request.Image);
            iternalRequest.AddParameter("imageId", request.ImageId);
            XGVcrResponse response = await InvokeHttpClientAsync<XGVcrResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 列举logo库集素材
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCR/s/Cjwvyax35#logo%E5%BA%93%E9%9B%86%E7%B4%A0%E6%9D%90%E5%88%97%E8%A1%A8 </para>
        /// </summary>
        /// <param name="libName">库名称</param>
        /// <param name="brief">brief</param>
        /// <returns>XGVcrListLogoLibBriefImagesResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrListLogoLibBriefImagesResponse ListLogoLibBriefImage(string libName, string brief)
        {
            AssertStringNotNullOrEmpty(libName, nameof(libName));
            AssertStringNotNullOrEmpty(brief, nameof(brief));
            XGVcrListLogoLibBriefImagesRequest request = new XGVcrListLogoLibBriefImagesRequest()
            {
                LibName = libName,
                Brief = brief
            };
            return ListLogoLibBriefImage(request);
        }

        /// <summary>
        /// 列举logo库集素材
        /// </summary>
        /// <param name="libName">库名称</param>
        /// <param name="brief">brief</param>
        /// <returns>异步任务XGVcrListLogoLibBriefImagesResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrListLogoLibBriefImagesResponse> ListLogoLibBriefImageAsync(string libName, string brief)
        {
            AssertStringNotNullOrEmpty(libName, nameof(libName));
            AssertStringNotNullOrEmpty(brief, nameof(brief));
            XGVcrListLogoLibBriefImagesRequest request = new XGVcrListLogoLibBriefImagesRequest()
            {
                LibName = libName,
                Brief = brief
            };
            return await ListLogoLibBriefImageAsync(request);
        }

        /// <summary>
        /// 列举logo库集素材
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCR/s/Cjwvyax35#logo%E5%BA%93%E9%9B%86%E7%B4%A0%E6%9D%90%E5%88%97%E8%A1%A8 </para>
        /// </summary>
        /// <param name="request">XGVcrListLogoLibBriefImagesRequest</param>
        /// <returns>XGVcrListLogoLibBriefImagesResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrListLogoLibBriefImagesResponse ListLogoLibBriefImage(XGVcrListLogoLibBriefImagesRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.Brief, nameof(request.Brief));
            AssertStringNotNullOrEmpty(request.LibName, nameof(request.LibName));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.VcrVersion.ToString(), FACE, "lib", request.LibName);
            iternalRequest.AddParameter("brief", request.Brief);
            XGVcrListLogoLibBriefImagesResponse response = InvokeHttpClient<XGVcrListLogoLibBriefImagesResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 列举logo库集素材
        /// </summary>
        /// <param name="request">XGVcrListLogoLibBriefImagesRequest</param>
        /// <returns>XGVcrListLogoLibBriefImagesResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrListLogoLibBriefImagesResponse> ListLogoLibBriefImageAsync(XGVcrListLogoLibBriefImagesRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.Brief, nameof(request.Brief));
            AssertStringNotNullOrEmpty(request.LibName, nameof(request.LibName));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.VcrVersion.ToString(), FACE, "lib", request.LibName);
            iternalRequest.AddParameter("brief", request.Brief);
            XGVcrListLogoLibBriefImagesResponse response = await InvokeHttpClientAsync<XGVcrListLogoLibBriefImagesResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 删除logo库集
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCR/s/Cjwvyax35#logo%E5%BA%93%E9%9B%86%E5%88%A0%E9%99%A4 </para>
        /// </summary>
        /// <param name="libName">库名称</param>
        /// <param name="brief">库集名称</param>
        /// <returns>XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrResponse DeleteLogoLibBrief(string libName, string brief)
        {
            AssertStringNotNullOrEmpty(libName, nameof(libName));
            AssertStringNotNullOrEmpty(brief, nameof(brief));
            XGVcrDeleteLogoLibBriefRequest request = new XGVcrDeleteLogoLibBriefRequest()
            {
                Brief = brief,
                LibName = libName
            };
            return DeleteLogoLibBrief(request);
        }

        /// <summary>
        /// 删除logo库集
        /// </summary>
        /// <param name="libName">库名称</param>
        /// <param name="brief">库集名称</param>
        /// <returns>异步任务XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrResponse> DeleteLogoLibBriefAsync(string libName, string brief)
        {
            AssertStringNotNullOrEmpty(libName, nameof(libName));
            AssertStringNotNullOrEmpty(brief, nameof(brief));
            XGVcrDeleteLogoLibBriefRequest request = new XGVcrDeleteLogoLibBriefRequest()
            {
                Brief = brief,
                LibName = libName
            };
            return await DeleteLogoLibBriefAsync(request);
        }

        /// <summary>
        /// 删除logo库集
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCR/s/Cjwvyax35#logo%E5%BA%93%E9%9B%86%E5%88%A0%E9%99%A4 </para>
        /// </summary>
        /// <param name="request">XGVcrDeleteLogoLibBriefRequest</param>
        /// <returns>XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrResponse DeleteLogoLibBrief(XGVcrDeleteLogoLibBriefRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.Brief, nameof(request.Brief));
            AssertStringNotNullOrEmpty(request.LibName, nameof(request.LibName));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.DELETE, request.VcrVersion.ToString(), LOGO, "lib", request.LibName);
            iternalRequest.AddParameter("brief", request.Brief);
            XGVcrResponse response = InvokeHttpClient<XGVcrResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 删除face库集
        /// </summary>
        /// <param name="request">XGVcrDeleteLogoLibBriefRequest</param>
        /// <returns>XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrResponse> DeleteLogoLibBriefAsync(XGVcrDeleteLogoLibBriefRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.Brief, nameof(request.Brief));
            AssertStringNotNullOrEmpty(request.LibName, nameof(request.LibName));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.DELETE, request.VcrVersion.ToString(), LOGO, "lib", request.LibName);
            iternalRequest.AddParameter("brief", request.Brief);
            XGVcrResponse response = await InvokeHttpClientAsync<XGVcrResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 列举logo库集名称集合
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCR/s/Cjwvyax35#logo%E5%BA%93%E9%9B%86%E5%88%97%E8%A1%A8 </para>
        /// </summary>
        /// <param name="libName">face库名称</param>
        /// <returns>XGVcrListLogoLibBriefsResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrListLogoLibBriefsResponse ListLogoLibBriefs(string libName)
        {
            AssertStringNotNullOrEmpty(libName, nameof(libName));
            XGVcrListLogoLibBriefsRequest request = new XGVcrListLogoLibBriefsRequest()
            {
                LibName = libName
            };
            return ListLogoLibBriefs(request);
        }

        /// <summary>
        /// 列举logo库集名称集合
        /// </summary>
        /// <param name="libName">face库名称</param>
        /// <returns>异步任务XGVcrListLogoLibBriefsResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrListLogoLibBriefsResponse> ListLogoLibBriefsAsync(string libName)
        {
            AssertStringNotNullOrEmpty(libName, nameof(libName));
            XGVcrListLogoLibBriefsRequest request = new XGVcrListLogoLibBriefsRequest()
            {
                LibName = libName
            };
            return await ListLogoLibBriefsAsync(request);
        }

        /// <summary>
        /// 列举logo库集名称集合
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCR/s/Cjwvyax35#logo%E5%BA%93%E9%9B%86%E5%88%97%E8%A1%A8 </para>
        /// </summary>
        /// <param name="request">XGVcrListLogoLibBriefsRequest</param>
        /// <returns>XGVcrListLogoLibBriefsResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrListLogoLibBriefsResponse ListLogoLibBriefs(XGVcrListLogoLibBriefsRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.LibName, nameof(request.LibName));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.VcrVersion.ToString(), LOGO, "lib", request.LibName);
            XGVcrListLogoLibBriefsResponse response = InvokeHttpClient<XGVcrListLogoLibBriefsResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 列举logo库集名称集合
        /// </summary>
        /// <param name="request">XGVcrListLogoLibBriefsRequest</param>
        /// <returns>异步任务XGVcrListLogoLibBriefsResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrListLogoLibBriefsResponse> ListLogoLibBriefsAsync(XGVcrListLogoLibBriefsRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.LibName, nameof(request.LibName));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.VcrVersion.ToString(), LOGO, "lib", request.LibName);
            XGVcrListLogoLibBriefsResponse response = await InvokeHttpClientAsync<XGVcrListLogoLibBriefsResponse>(iternalRequest);
            return response;
        }

        #endregion

        #region 自定义文本库接口

        /// <summary>
        /// 创建自定义文本库
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCR/s/7k3fbiyza#%E5%88%9B%E5%BB%BA%E8%87%AA%E5%AE%9A%E4%B9%89%E6%96%87%E6%9C%AC%E5%BA%93 </para>
        /// </summary>
        /// <param name="name">自定义文本库名称，最长40个字符</param>
        /// <param name="description">描述，最大支持256字符</param>
        /// <returns>XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrResponse CreateCustomTextLib(string name, string description=null)
        {
            AssertStringNotNullOrEmpty(name, nameof(name));
            XGVcrCreateCustomTextLibRequest request = new XGVcrCreateCustomTextLibRequest()
            {
                Name = name,
                Description = description
            };
            return CreateCustomTextLib(request);
        }

        /// <summary>
        /// 创建自定义文本库
        /// </summary>
        /// <param name="name">自定义文本库名称，最长40个字符</param>
        /// <param name="description">描述，最大支持256字符</param>
        /// <returns>异步任务XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrResponse> CreateCustomTextLibAsync(string name, string description = null)
        {
            AssertStringNotNullOrEmpty(name, nameof(name));
            XGVcrCreateCustomTextLibRequest request = new XGVcrCreateCustomTextLibRequest()
            {
                Name = name,
                Description = description
            };
            return await CreateCustomTextLibAsync(request);
        }

        /// <summary>
        /// 创建自定义文本库
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCR/s/7k3fbiyza#%E5%88%9B%E5%BB%BA%E8%87%AA%E5%AE%9A%E4%B9%89%E6%96%87%E6%9C%AC%E5%BA%93 </para>
        /// </summary>
        /// <param name="request">XGVcrCreateCustomTextLibRequest</param>
        /// <returns>XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrResponse CreateCustomTextLib(XGVcrCreateCustomTextLibRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.Name, nameof(request.Name));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.POST, request.VcrVersion.ToString(), request.LibType, "lib");
            XGVcrResponse response = InvokeHttpClient<XGVcrResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 创建自定义文本库
        /// </summary>
        /// <param name="request">XGVcrCreateCustomTextLibRequest</param>
        /// <returns>XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrResponse> CreateCustomTextLibAsync(XGVcrCreateCustomTextLibRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.Name, nameof(request.Name));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.POST, request.VcrVersion.ToString(), request.LibType, "lib");
            XGVcrResponse response = await InvokeHttpClientAsync<XGVcrResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 删除自定义文本库
        /// <para>接口文档：https://cloud.baidu.com/doc/VCR/s/7k3fbiyza#%E5%88%A0%E9%99%A4%E8%87%AA%E5%AE%9A%E4%B9%89%E6%96%87%E6%9C%AC%E5%BA%93 </para>
        /// </summary>
        /// <param name="name">自定义文本库名称</param>
        /// <returns>XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrResponse DeleteCustomTextLib(string name)
        {
            AssertStringNotNullOrEmpty(name, nameof(name));

            XGVcrBaseRequest request = new XGVcrBaseRequest();
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.DELETE, request.VcrVersion.ToString(), TEXT, "lib", name);
            XGVcrResponse response = InvokeHttpClient<XGVcrResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 删除自定义文本库
        /// </summary>
        /// <param name="name">自定义文本库名称</param>
        /// <returns>异步任务XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrResponse> DeleteCustomTextLibAsync(string name)
        {
            AssertStringNotNullOrEmpty(name, nameof(name));

            XGVcrBaseRequest request = new XGVcrBaseRequest();
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.DELETE, request.VcrVersion.ToString(), TEXT, "lib", name);
            XGVcrResponse response = await InvokeHttpClientAsync<XGVcrResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 列出所有文本库
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCR/s/7k3fbiyza#%E5%88%97%E5%87%BA%E6%89%80%E6%9C%89%E6%96%87%E6%9C%AC%E5%BA%93 </para>
        /// </summary>
        /// <returns>XGVcrListTextLibResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrListTextLibResponse ListTextLibs()
        {
            XGVcrBaseRequest request = new XGVcrBaseRequest();
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.VcrVersion.ToString(), TEXT, "lib");
            XGVcrListTextLibResponse response = InvokeHttpClient<XGVcrListTextLibResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 列出所有文本库
        /// </summary>
        /// <returns>异步任务XGVcrListTextLibResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrListTextLibResponse> ListTextLibsAsync()
        {
            XGVcrBaseRequest request = new XGVcrBaseRequest();
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.VcrVersion.ToString(), TEXT, "lib");
            XGVcrListTextLibResponse response = await InvokeHttpClientAsync<XGVcrListTextLibResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 添加自定义文本库文本
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCR/s/7k3fbiyza#%E6%B7%BB%E5%8A%A0%E8%87%AA%E5%AE%9A%E4%B9%89%E6%96%87%E6%9C%AC </para>
        /// </summary>
        /// <param name="name">文本库名称</param>
        /// <param name="items">文本集合</param>
        /// <returns>XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrResponse AddTextLibTexts(string name, params string[] items)
        {
            AssertStringNotNullOrEmpty(name, nameof(name));
            AssertStringArrayNotNullOrEmpty(items, nameof(items));
            XGVcrTextLibTextsRequest request = new XGVcrTextLibTextsRequest()
            {
                Name = name,
                Items = new List<string>(items)
            };
            return AddTextLibTexts(request);
        }

        /// <summary>
        /// 添加自定义文本库文本
        /// </summary>
        /// <param name="name">文本库名称</param>
        /// <param name="items">文本集合</param>
        /// <returns>XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrResponse> AddTextLibTextsAsync(string name, params string[] items)
        {
            AssertStringNotNullOrEmpty(name, nameof(name));
            AssertStringArrayNotNullOrEmpty(items, nameof(items));
            XGVcrTextLibTextsRequest request = new XGVcrTextLibTextsRequest()
            {
                Name = name,
                Items = new List<string>(items)
            };
            return await AddTextLibTextsAsync(request);
        }

        /// <summary>
        /// 添加自定义文本库文本
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCR/s/7k3fbiyza#%E6%B7%BB%E5%8A%A0%E8%87%AA%E5%AE%9A%E4%B9%89%E6%96%87%E6%9C%AC </para>
        /// </summary>
        /// <param name="request">XGVcrTextLibTextsRequest</param>
        /// <returns>XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrResponse AddTextLibTexts(XGVcrTextLibTextsRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.Name, nameof(request.Name));
            AssertStringListNotNullOrEmpty(request.Items, nameof(request.Items));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.PUT, request.VcrVersion.ToString(), TEXT, "lib",request.Name);
            iternalRequest.AddParameter("add");
            XGVcrResponse response = InvokeHttpClient<XGVcrResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 添加自定义文本库文本
        /// </summary>
        /// <param name="request">XGVcrTextLibTextsRequest</param>
        /// <returns>XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrResponse> AddTextLibTextsAsync(XGVcrTextLibTextsRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.Name, nameof(request.Name));
            AssertStringListNotNullOrEmpty(request.Items, nameof(request.Items));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.PUT, request.VcrVersion.ToString(), TEXT, "lib", request.Name);
            iternalRequest.AddParameter("add");
            XGVcrResponse response = await InvokeHttpClientAsync<XGVcrResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 删除自定义文本库文本
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCR/s/7k3fbiyza#%E5%88%A0%E9%99%A4%E8%87%AA%E5%AE%9A%E4%B9%89%E6%96%87%E6%9C%AC </para>
        /// </summary>
        /// <param name="name">文本库名称</param>
        /// <param name="items">文本集合</param>
        /// <returns>XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrResponse DeleteTextLibTexts(string name, params string[] items)
        {
            AssertStringNotNullOrEmpty(name, nameof(name));
            AssertStringArrayNotNullOrEmpty(items, nameof(items));
            XGVcrTextLibTextsRequest request = new XGVcrTextLibTextsRequest()
            {
                Name = name,
                Items = new List<string>(items)
            };
            return DeleteTextLibTexts(request);
        }

        /// <summary>
        /// 删除自定义文本库文本
        /// </summary>
        /// <param name="name">文本库名称</param>
        /// <param name="items">文本集合</param>
        /// <returns>XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrResponse> DeleteTextLibTextsAsync(string name, params string[] items)
        {
            AssertStringNotNullOrEmpty(name, nameof(name));
            AssertStringArrayNotNullOrEmpty(items, nameof(items));
            XGVcrTextLibTextsRequest request = new XGVcrTextLibTextsRequest()
            {
                Name = name,
                Items = new List<string>(items)
            };
            return await DeleteTextLibTextsAsync(request);
        }

        /// <summary>
        /// 删除自定义文本库文本
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCR/s/7k3fbiyza#%E5%88%A0%E9%99%A4%E8%87%AA%E5%AE%9A%E4%B9%89%E6%96%87%E6%9C%AC </para>
        /// </summary>
        /// <param name="request">XGVcrTextLibTextsRequest</param>
        /// <returns>XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrResponse DeleteTextLibTexts(XGVcrTextLibTextsRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.Name, nameof(request.Name));
            AssertStringListNotNullOrEmpty(request.Items, nameof(request.Items));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.PUT, request.VcrVersion.ToString(), TEXT, "lib", request.Name);
            iternalRequest.AddParameter("delete");
            XGVcrResponse response = InvokeHttpClient<XGVcrResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 删除自定义文本库文本
        /// </summary>
        /// <param name="request">XGVcrTextLibTextsRequest</param>
        /// <returns>异步任务XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrResponse> DeleteTextLibTextsAsync(XGVcrTextLibTextsRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.Name, nameof(request.Name));
            AssertStringListNotNullOrEmpty(request.Items, nameof(request.Items));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.PUT, request.VcrVersion.ToString(), TEXT, "lib", request.Name);
            iternalRequest.AddParameter("delete");
            XGVcrResponse response = await InvokeHttpClientAsync<XGVcrResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查看文本库文本内容
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCR/s/7k3fbiyza#%E6%9F%A5%E7%9C%8B%E6%96%87%E6%9C%AC%E5%BA%93%E6%96%87%E6%9C%AC%E5%86%85%E5%AE%B9 </para>
        /// <para>  </para>
        /// </summary>
        /// <param name="name">文本库名称</param>
        /// <param name="pageNo">分页页数，默认为1</param>
        /// <param name="pageSize">分页显示条数，默认为20</param>
        /// <returns>XGVcrQueryTextLibTextsResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrQueryTextLibTextsResponse QueryTextLibTexts(string name, int pageNo=1, int pageSize=20)
        {
            AssertStringNotNullOrEmpty(name, nameof(name));
            XGVcrQueryTextLibTextsRequest request = new XGVcrQueryTextLibTextsRequest()
            {
                Name=name,
                PageNo=pageNo,
                PageSize=pageSize
            };
            return QueryTextLibTexts(request);
        }

        /// <summary>
        /// 查看文本库文本内容
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCR/s/7k3fbiyza#%E6%9F%A5%E7%9C%8B%E6%96%87%E6%9C%AC%E5%BA%93%E6%96%87%E6%9C%AC%E5%86%85%E5%AE%B9 </para>
        /// <para>  </para>
        /// </summary>
        /// <param name="name">文本库名称</param>
        /// <param name="pageNo">分页页数，默认为1</param>
        /// <param name="pageSize">分页显示条数，默认为20</param>
        /// <returns>异步任务XGVcrQueryTextLibTextsResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrQueryTextLibTextsResponse> QueryTextLibTextsAsync(string name, int pageNo = 1, int pageSize = 20)
        {
            AssertStringNotNullOrEmpty(name, nameof(name));
            XGVcrQueryTextLibTextsRequest request = new XGVcrQueryTextLibTextsRequest()
            {
                Name = name,
                PageNo = pageNo,
                PageSize = pageSize
            };
            return await QueryTextLibTextsAsync(request);
        }

        /// <summary>
        /// 查看文本库文本内容
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCR/s/7k3fbiyza#%E6%9F%A5%E7%9C%8B%E6%96%87%E6%9C%AC%E5%BA%93%E6%96%87%E6%9C%AC%E5%86%85%E5%AE%B9 </para>
        /// </summary>
        /// <param name="request">XGVcrQueryTextLibTextsRequest</param>
        /// <returns>XGVcrQueryTextLibTextsResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrQueryTextLibTextsResponse QueryTextLibTexts(XGVcrQueryTextLibTextsRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.Name, nameof(request.Name));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.VcrVersion.ToString(), TEXT, "lib", request.Name);
            iternalRequest.AddParameter("pageNo",request.PageNo.ToString());
            iternalRequest.AddParameter("pageSize", request.PageSize.ToString());
            XGVcrQueryTextLibTextsResponse response = InvokeHttpClient<XGVcrQueryTextLibTextsResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查看文本库文本内容
        /// </summary>
        /// <param name="request">XGVcrQueryTextLibTextsRequest</param>
        /// <returns>异步任务XGVcrQueryTextLibTextsResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrQueryTextLibTextsResponse> QueryTextLibTextsAsync(XGVcrQueryTextLibTextsRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.Name, nameof(request.Name));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.VcrVersion.ToString(), TEXT, "lib", request.Name);
            iternalRequest.AddParameter("pageNo", request.PageNo.ToString());
            iternalRequest.AddParameter("pageSize", request.PageSize.ToString());
            XGVcrQueryTextLibTextsResponse response = await InvokeHttpClientAsync<XGVcrQueryTextLibTextsResponse>(iternalRequest);
            return response;
        }

        #endregion

        #region 自定义图片黑库接口

        /// <summary>
        /// 创建自定义图片黑库
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCR/s/pklak5nut#%E5%88%9B%E5%BB%BA%E8%87%AA%E5%AE%9A%E4%B9%89%E5%9B%BE%E7%89%87%E9%BB%91%E5%BA%93 </para>
        /// </summary>
        /// <param name="name">自定义图片黑库名称，最长40个字符</param>
        /// <param name="description">描述，最大支持256字符</param>
        /// <returns>XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrResponse CreateCustomImageLib(string name, string description=null)
        {
            AssertStringNotNullOrEmpty(name, nameof(name));
            XGVcrCreateCustomImageLibRequest request = new XGVcrCreateCustomImageLibRequest()
            {
                Name=name,
                Description=description
            };
            return CreateCustomImageLib(request);
        }

        /// <summary>
        /// 创建自定义图片黑库
        /// </summary>
        /// <param name="name">自定义图片黑库名称，最长40个字符</param>
        /// <param name="description">描述，最大支持256字符</param>
        /// <returns>异步任务XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrResponse> CreateCustomImageLibAsync(string name, string description = null)
        {
            AssertStringNotNullOrEmpty(name, nameof(name));
            XGVcrCreateCustomImageLibRequest request = new XGVcrCreateCustomImageLibRequest()
            {
                Name = name,
                Description = description
            };
            return await CreateCustomImageLibAsync(request);
        }

        /// <summary>
        /// 创建自定义图片黑库
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCR/s/pklak5nut#%E5%88%9B%E5%BB%BA%E8%87%AA%E5%AE%9A%E4%B9%89%E5%9B%BE%E7%89%87%E9%BB%91%E5%BA%93 </para>
        /// </summary>
        /// <param name="request">XGVcrCreateCustomImageLibRequest</param>
        /// <returns>XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrResponse CreateCustomImageLib(XGVcrCreateCustomImageLibRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.Name, nameof(request.Name));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.POST, request.VcrVersion.ToString(), request.LibType, "lib");
            XGVcrResponse response = InvokeHttpClient<XGVcrResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 创建自定义图片黑库
        /// </summary>
        /// <param name="request">XGVcrCreateCustomImageLibRequest</param>
        /// <returns>异步任务XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrResponse> CreateCustomImageLibAsync(XGVcrCreateCustomImageLibRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.Name, nameof(request.Name));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.POST, request.VcrVersion.ToString(), request.LibType, "lib");
            XGVcrResponse response = await InvokeHttpClientAsync<XGVcrResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 删除自定义图片黑库
        /// <para>删除图片黑库会导致绑定该库的审核模版不可用，删除图片黑库前请确认已无模版绑定该库。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/VCR/s/pklak5nut#%E5%88%A0%E9%99%A4%E8%87%AA%E5%AE%9A%E4%B9%89%E5%9B%BE%E7%89%87%E9%BB%91%E5%BA%93 </para>
        /// </summary>
        /// <param name="name">库名称</param>
        /// <returns>XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrResponse DeleteCustomImageLib(string name)
        {
            AssertStringNotNullOrEmpty(name, nameof(name));

            XGVcrBaseRequest request = new XGVcrBaseRequest();
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.DELETE, request.VcrVersion.ToString(), IMAGE, "lib", name);
            XGVcrResponse response = InvokeHttpClient<XGVcrResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 删除自定义图片黑库
        /// <para>删除图片黑库会导致绑定该库的审核模版不可用，删除图片黑库前请确认已无模版绑定该库。</para>
        /// </summary>
        /// <param name="name">库名称</param>
        /// <returns>异步任务XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrResponse> DeleteCustomImageLibAsync(string name)
        {
            AssertStringNotNullOrEmpty(name, nameof(name));

            XGVcrBaseRequest request = new XGVcrBaseRequest();
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.DELETE, request.VcrVersion.ToString(), IMAGE, "lib", name);
            XGVcrResponse response = await InvokeHttpClientAsync<XGVcrResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 列出所有图片黑库
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCR/s/pklak5nut#%E5%88%97%E5%87%BA%E6%89%80%E6%9C%89%E5%9B%BE%E7%89%87%E9%BB%91%E5%BA%93 </para>
        /// </summary>
        /// <returns>XGVcrListImageLibResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrListImageLibResponse ListImageLibs()
        {
            XGVcrBaseRequest request = new XGVcrBaseRequest();
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.VcrVersion.ToString(), IMAGE, "lib");
            XGVcrListImageLibResponse response = InvokeHttpClient<XGVcrListImageLibResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 列出所有图片黑库
        /// </summary>
        /// <returns>异步任务XGVcrListImageLibResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrListImageLibResponse> ListImageLibsAsync()
        {
            XGVcrBaseRequest request = new XGVcrBaseRequest();
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.VcrVersion.ToString(), IMAGE, "lib");
            XGVcrListImageLibResponse response = await InvokeHttpClientAsync<XGVcrListImageLibResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 添加图片到黑库
        /// <para>往指定的自定义黑库中添加图片。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/VCR/s/pklak5nut#%E6%B7%BB%E5%8A%A0%E5%9B%BE%E7%89%87%E5%88%B0%E9%BB%91%E5%BA%93 </para>
        /// </summary>
        /// <param name="name">黑库名称</param>
        /// <param name="items">图片地址集合，最多100张</param>
        /// <returns>XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrResponse AddImageLibImages(string name,params string[] items)
        {
            AssertStringNotNullOrEmpty(name, nameof(name));
            AssertStringArrayNotNullOrEmpty(items, nameof(items));
            XGVcrImageLibImagesRequest request = new XGVcrImageLibImagesRequest()
            {
                Name = name,
                Items = new List<string>(items)
            };
            return AddImageLibImages(request);
        }

        /// <summary>
        /// 添加图片到黑库
        /// <para>往指定的自定义黑库中添加图片。</para>
        /// </summary>
        /// <param name="name">黑库名称</param>
        /// <param name="items">图片地址集合，最多100张</param>
        /// <returns>异步任务XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrResponse> AddImageLibImagesAsync(string name, params string[] items)
        {
            AssertStringNotNullOrEmpty(name, nameof(name));
            AssertStringArrayNotNullOrEmpty(items, nameof(items));
            XGVcrImageLibImagesRequest request = new XGVcrImageLibImagesRequest()
            {
                Name = name,
                Items = new List<string>(items)
            };
            return await AddImageLibImagesAsync(request);
        }

        /// <summary>
        /// 添加图片到黑库
        /// <para>往指定的自定义黑库中添加图片。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/VCR/s/pklak5nut#%E6%B7%BB%E5%8A%A0%E5%9B%BE%E7%89%87%E5%88%B0%E9%BB%91%E5%BA%93 </para>
        /// </summary>
        /// <param name="request">XGVcrImageLibImagesRequest</param>
        /// <returns>XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrResponse AddImageLibImages(XGVcrImageLibImagesRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.Name, nameof(request.Name));
            AssertStringListNotNullOrEmpty(request.Items, nameof(request.Items));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.PUT, request.VcrVersion.ToString(), IMAGE, "lib",request.Name);
            iternalRequest.AddParameter("add");
            XGVcrResponse response = InvokeHttpClient<XGVcrResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 添加图片到黑库
        /// <para>往指定的自定义黑库中添加图片。</para>
        /// </summary>
        /// <param name="request">XGVcrImageLibImagesRequest</param>
        /// <returns>异步任务XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrResponse> AddImageLibImagesAsync(XGVcrImageLibImagesRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.Name, nameof(request.Name));
            AssertStringListNotNullOrEmpty(request.Items, nameof(request.Items));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.PUT, request.VcrVersion.ToString(), IMAGE, "lib", request.Name);
            iternalRequest.AddParameter("add");
            XGVcrResponse response = await InvokeHttpClientAsync<XGVcrResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 从黑库中删除图片
        /// <para>删除指定的自定义黑库中的图片。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/VCR/s/pklak5nut#%E4%BB%8E%E9%BB%91%E5%BA%93%E4%B8%AD%E5%88%A0%E9%99%A4%E5%9B%BE%E7%89%87 </para>
        /// </summary>
        /// <param name="name">黑库名称</param>
        /// <param name="items">图片ID集合，最多100张</param>
        /// <returns>XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrResponse DeleteImageLibImages(string name, params string[] items)
        {
            AssertStringNotNullOrEmpty(name, nameof(name));
            AssertStringArrayNotNullOrEmpty(items, nameof(items));
            XGVcrImageLibImagesRequest request = new XGVcrImageLibImagesRequest()
            {
                Name = name,
                Items = new List<string>(items)
            };
            return DeleteImageLibImages(request);
        }

        /// <summary>
        /// 从黑库中删除图片
        /// <para>删除指定的自定义黑库中的图片。</para>
        /// </summary>
        /// <param name="name">黑库名称</param>
        /// <param name="items">图片ID集合，最多100张</param>
        /// <returns>异步任务XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrResponse> DeleteImageLibImagesAsync(string name, params string[] items)
        {
            AssertStringNotNullOrEmpty(name, nameof(name));
            AssertStringArrayNotNullOrEmpty(items, nameof(items));
            XGVcrImageLibImagesRequest request = new XGVcrImageLibImagesRequest()
            {
                Name = name,
                Items = new List<string>(items)
            };
            return await DeleteImageLibImagesAsync(request);
        }

        /// <summary>
        /// 从黑库中删除图片
        /// <para>删除指定的自定义黑库中的图片。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/VCR/s/pklak5nut#%E4%BB%8E%E9%BB%91%E5%BA%93%E4%B8%AD%E5%88%A0%E9%99%A4%E5%9B%BE%E7%89%87 </para>
        /// </summary>
        /// <param name="request">XGVcrImageLibImagesRequest</param>
        /// <returns>XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrResponse DeleteImageLibImages(XGVcrImageLibImagesRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.Name, nameof(request.Name));
            AssertStringListNotNullOrEmpty(request.Items, nameof(request.Items));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.PUT, request.VcrVersion.ToString(), IMAGE, "lib", request.Name);
            iternalRequest.AddParameter("delete");
            XGVcrResponse response = InvokeHttpClient<XGVcrResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 从黑库中删除图片
        /// <para>删除指定的自定义黑库中的图片。</para>
        /// </summary>
        /// <param name="request">XGVcrImageLibImagesRequest</param>
        /// <returns>异步任务XGVcrResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrResponse> DeleteImageLibImagesAsync(XGVcrImageLibImagesRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.Name, nameof(request.Name));
            AssertStringListNotNullOrEmpty(request.Items, nameof(request.Items));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.PUT, request.VcrVersion.ToString(), IMAGE, "lib", request.Name);
            iternalRequest.AddParameter("delete");
            XGVcrResponse response = await InvokeHttpClientAsync<XGVcrResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查看黑库中的图片
        /// <para>查看自定义黑库中的图片列表</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/VCR/s/pklak5nut#%E6%9F%A5%E7%9C%8B%E9%BB%91%E5%BA%93%E4%B8%AD%E7%9A%84%E5%9B%BE%E7%89%87 </para>
        /// </summary>
        /// <param name="name">黑库名称</param>
        /// <param name="pageNo">分页页数，默认为1</param>
        /// <param name="pageSize">分页显示条数，默认为20</param>
        /// <returns>XGVcrQueryImageLibImagesResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrQueryImageLibImagesResponse QueryImageLibImages(string name,int pageNo=1,int pageSize=20)
        {
            AssertStringNotNullOrEmpty(name, nameof(name));
            XGVcrQueryImageLibImagesRequest request = new XGVcrQueryImageLibImagesRequest()
            {
                Name=name,
                PageNo=pageNo,
                PageSize=pageSize
            };
            return QueryImageLibImages(request);
        }

        /// <summary>
        /// 查看黑库中的图片
        /// <para>查看自定义黑库中的图片列表</para>
        /// </summary>
        /// <param name="name">黑库名称</param>
        /// <param name="pageNo">分页页数，默认为1</param>
        /// <param name="pageSize">分页显示条数，默认为20</param>
        /// <returns>异步任务XGVcrQueryImageLibImagesResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrQueryImageLibImagesResponse> QueryImageLibImagesAsync(string name, int pageNo = 1, int pageSize = 20)
        {
            AssertStringNotNullOrEmpty(name, nameof(name));
            XGVcrQueryImageLibImagesRequest request = new XGVcrQueryImageLibImagesRequest()
            {
                Name = name,
                PageNo = pageNo,
                PageSize = pageSize
            };
            return await QueryImageLibImagesAsync(request);
        }

        /// <summary>
        /// 查看黑库中的图片
        /// <para>查看自定义黑库中的图片列表</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/VCR/s/pklak5nut#%E6%9F%A5%E7%9C%8B%E9%BB%91%E5%BA%93%E4%B8%AD%E7%9A%84%E5%9B%BE%E7%89%87 </para>
        /// </summary>
        /// <param name="request">XGVcrQueryImageLibImagesRequest</param>
        /// <returns>XGVcrQueryImageLibImagesResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcrQueryImageLibImagesResponse QueryImageLibImages(XGVcrQueryImageLibImagesRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.Name, nameof(request.Name));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.VcrVersion.ToString(), IMAGE, "lib", request.Name);
            iternalRequest.AddParameter("pageNo",request.PageNo.ToString());
            iternalRequest.AddParameter("pageSize", request.PageSize.ToString());
            XGVcrQueryImageLibImagesResponse response = InvokeHttpClient<XGVcrQueryImageLibImagesResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查看黑库中的图片
        /// <para>查看自定义黑库中的图片列表</para>
        /// </summary>
        /// <param name="request">XGVcrQueryImageLibImagesRequest</param>
        /// <returns>异步任务XGVcrQueryImageLibImagesResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcrQueryImageLibImagesResponse> QueryImageLibImagesAsync(XGVcrQueryImageLibImagesRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.Name, nameof(request.Name));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.VcrVersion.ToString(), IMAGE, "lib", request.Name);
            iternalRequest.AddParameter("pageNo", request.PageNo.ToString());
            iternalRequest.AddParameter("pageSize", request.PageSize.ToString());
            XGVcrQueryImageLibImagesResponse response = await InvokeHttpClientAsync<XGVcrQueryImageLibImagesResponse>(iternalRequest);
            return response;
        }

        #endregion

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

        private static void AssertStringNotNullOrEmpty(string param, string nameofParam = null, string errorMessage = " 不能为空")
        {

            if (string.IsNullOrEmpty(param) || string.IsNullOrWhiteSpace(param))
            {
                if (string.IsNullOrEmpty(nameofParam) || string.IsNullOrWhiteSpace(nameofParam))
                    nameofParam = nameof(param);
                errorMessage = nameofParam + errorMessage;
                throw new ArgumentNullException(nameofParam, errorMessage);
            }
        }

        private static void AssertDicNotNullOrEmpty(IDictionary param, string nameofParam = null, string errorMessage = " 不能为空")
        {
            if (param == null || param.Count < 1)
            {
                if (string.IsNullOrEmpty(nameofParam) || string.IsNullOrWhiteSpace(nameofParam))
                    nameofParam = nameof(param);
                errorMessage = nameofParam + errorMessage;
                throw new ArgumentNullException(nameof(param), errorMessage);
            }
        }

        private static void AssertStringArrayNotNullOrEmpty(string[] param, string nameofParam = null, string errorMessage = " 不能为空")
        {
            if (!(param != null && param.Length > 0))
            {
                if (string.IsNullOrEmpty(nameofParam) || string.IsNullOrWhiteSpace(nameofParam))
                    nameofParam = nameof(param);
                errorMessage = nameofParam + errorMessage;
                throw new ArgumentNullException(nameof(param), errorMessage);
            }
        }

        private static void AssertStringListNotNullOrEmpty(List<string> param, string nameofParam = null, string errorMessage = " 不能为空")
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

        private static void AssertIntListNotNullOrEmpty(List<int> param, string nameofParam = null, string errorMessage = " 不能为空")
        {
            if (!(param != null && param.Count > 0))
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