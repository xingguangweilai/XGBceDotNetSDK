using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using XGBceDotNetSDK.BaseClass;
using XGBceDotNetSDK.Http;
using XGBceDotNetSDK.Http.Handler;
using XGBceDotNetSDK.Services.VCA.Model;
using XGBceDotNetSDK.Utils;

namespace XGBceDotNetSDK.Services.VCA
{
    /// <summary>
    /// 媒体内容分析 MCA客户端类
    /// <para>Endpoint为：vca.bj.baidubce.com</para>
    /// <para>接口文档：https://cloud.baidu.com/doc/VCA/s/Tjwvybmvd</para>
    /// </summary>
    public class XGVcaClient: XGAbstractBceClient
    {
        private static readonly string MEDIA = "media";       //视频分析
        private static readonly string IMAGE = "image";       //图片分析
        private static readonly string STREAM = "stream";    //直播分析
        private static readonly string FACE = "face";       //face库
        private static readonly string LOGO = "logo";    //logo库

        public XGVcaClient() : this(new XGBceClientConfiguration()) { }

        public XGVcaClient(XGBceClientConfiguration configuration) : base(configuration) { }

        #region 视频分析

        /// <summary>
        /// 提交视频分析
        /// <para>接口文档：https://cloud.baidu.com/doc/VCA/s/fjwvybmi5#%E6%8F%90%E4%BA%A4%E8%A7%86%E9%A2%91%E5%88%86%E6%9E%90 </para>
        /// </summary>
        /// <param name="source">视频路径，不超过1024字符</param>
        /// <param name="title">视频标题，默认不设置，不超过256字符</param>
        /// <returns>XGAnalyzeResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGAnalyzeResponse Analyze(string source, string title=null)
        {
            if (string.IsNullOrEmpty(source))
            {
                throw new ArgumentNullException("source 不能为空");
            }
            XGAnalyzeRequest analyzeRequest = new XGAnalyzeRequest() { Source = source, Title=title };
            return Analyze(analyzeRequest);
        }

        //// <summary>
        /// 提交视频分析
        /// </summary>
        /// <param name="source">视频路径，不超过1024字符</param>
        /// <param name="title">视频标题，默认不设置，不超过256字符</param>
        /// <returns>异步任务 XGAnalyzeResponse </returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGAnalyzeResponse> AnalyzeAsync(string source, string title=null)
        {
            XGAnalyzeRequest analyzeRequest = new XGAnalyzeRequest() { Source = source, Title = title };
            return await AnalyzeAsync(analyzeRequest);
        }

        /// <summary>
        /// 提交视频分析
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCA/s/fjwvybmi5#%E6%8F%90%E4%BA%A4%E8%A7%86%E9%A2%91%E5%88%86%E6%9E%90 </para>
        /// </summary>
        /// <param name="request">XGAnalyzeRequest</param>
        /// <returns>XGAnalyzeResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGAnalyzeResponse Analyze(XGAnalyzeRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request 不能为空");
            }
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.PUT, request.VcaVersion.ToString(), MEDIA);
            XGAnalyzeResponse response = InvokeHttpClient<XGAnalyzeResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 提交视频分析
        /// </summary>
        /// <param name="request">XGAnalyzeRequest</param>
        /// <returns>异步任务 XGAnalyzeResponse </returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGAnalyzeResponse> AnalyzeAsync(XGAnalyzeRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request 不能为空");
            }
            XGBceIternalRequest iternalRequest = CreateRequest(request,BceHttpMethod.PUT, request.VcaVersion.ToString(),MEDIA);
            XGAnalyzeResponse response= await InvokeHttpClientAsync<XGAnalyzeResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询视频分析结果
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCA/s/fjwvybmi5#%E6%9F%A5%E8%AF%A2%E8%A7%86%E9%A2%91%E5%88%86%E6%9E%90%E7%BB%93%E6%9E%9C </para>
        /// </summary>
        /// <param name="source">视频路径，需要对source进行urlEncode，必需</param>
        /// <returns>XGQueryResultResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGQueryResultResponse QueryResult(string source)
        {
            if (source == null)
                throw new ArgumentNullException("source 不能为空");
            XGQueryResultRequest request = new XGQueryResultRequest() { Source=source};
            return QueryResult(request);
        }

        /// <summary>
        /// 查询视频分析结果
        /// </summary>
        /// <param name="source">视频路径，需要对source进行urlEncode，必需</param>
        /// <returns>异步任务 XGQueryResultResponse </returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGQueryResultResponse> QueryResultAsync(string source)
        {
            if (source == null)
                throw new ArgumentNullException("source 不能为空");
            XGQueryResultRequest analyzeRequest = new XGQueryResultRequest() { Source = source};
            return await QueryResultAsync(analyzeRequest);
        }

        /// <summary>
        /// 查询视频分析结果
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCA/s/fjwvybmi5#%E6%9F%A5%E8%AF%A2%E8%A7%86%E9%A2%91%E5%88%86%E6%9E%90%E7%BB%93%E6%9E%9C </para>
        /// </summary>
        /// <param name="request">XGQueryResultRequest</param>
        /// <returns>XGQueryResultResponse </returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGQueryResultResponse QueryResult(XGQueryResultRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("XGQueryResultRequest 不能为空");
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.VcaVersion.ToString(), MEDIA);
            iternalRequest.AddParameter("source", request.Source);
            XGQueryResultResponse response = InvokeHttpClient<XGQueryResultResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询视频分析结果
        /// </summary>
        /// <param name="request">XGQueryResultRequest</param>
        /// <returns>异步任务 XGQueryResultResponse </returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGQueryResultResponse> QueryResultAsync(XGQueryResultRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("XGQueryResultRequest 不能为空");
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.VcaVersion.ToString(),MEDIA);
            iternalRequest.AddParameter("source",request.Source);
            XGQueryResultResponse response = await InvokeHttpClientAsync<XGQueryResultResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询视频分析中间任务结果
        ///  <para> 接口文档：https://cloud.baidu.com/doc/VCA/s/fjwvybmi5#%E6%9F%A5%E8%AF%A2%E8%A7%86%E9%A2%91%E5%88%86%E6%9E%90%E4%B8%AD%E9%97%B4%E4%BB%BB%E5%8A%A1%E7%BB%93%E6%9E%9C </para>
        /// </summary>
        /// <param name="source">视频路径，需要对source进行urlEncode</param>
        /// <param name="type">中间任务类型</param>
        /// <returns>XGQuerySubTaskResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGQuerySubTaskResponse QuerySubTaskResult(string source, XGVcaSubTaskType type)
        {
            if (string.IsNullOrEmpty(source) || string.IsNullOrWhiteSpace(source))
                throw new ArgumentNullException("source 不能为空");
            if (string.IsNullOrEmpty(type.ToString()) || string.IsNullOrWhiteSpace(type.ToString()))
                throw new ArgumentNullException("type 不能为空");
            XGQuerySubTaskRequest request = new XGQuerySubTaskRequest()
            {
                Source = source,
                SubTaskType = type
            };
            return QuerySubTaskResult(request);
        }

        /// <summary>
        /// 查询视频分析中间任务结果
        /// </summary>
        /// <param name="source">视频路径，需要对source进行urlEncode</param>
        /// <param name="type">中间任务类型</param>
        /// <returns>异步任务 XGQuerySubTaskResponse </returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGQuerySubTaskResponse> QuerySubTaskResultAsync(string source, XGVcaSubTaskType type)
        {
            if (string.IsNullOrEmpty(source) || string.IsNullOrWhiteSpace(source))
                throw new ArgumentNullException("source 不能为空");
            if (string.IsNullOrEmpty(type.ToString()) || string.IsNullOrWhiteSpace(type.ToString()))
                throw new ArgumentNullException("type 不能为空");
            XGQuerySubTaskRequest request = new XGQuerySubTaskRequest() {
                Source=source,
                SubTaskType=type
            };
            return await QuerySubTaskResultAsync(request);
        }

        /// <summary>
        /// 查询视频分析中间任务结果
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCA/s/fjwvybmi5#%E6%9F%A5%E8%AF%A2%E8%A7%86%E9%A2%91%E5%88%86%E6%9E%90%E4%B8%AD%E9%97%B4%E4%BB%BB%E5%8A%A1%E7%BB%93%E6%9E%9C </para>
        /// </summary>
        /// <param name="request">XGQuerySubTaskRequest</param>
        /// <returns>XGQuerySubTaskResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGQuerySubTaskResponse QuerySubTaskResult(XGQuerySubTaskRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("XGQuerySubTaskRequest 不能为空");
            if (string.IsNullOrEmpty(request.SubTaskType.ToString()) || string.IsNullOrWhiteSpace(request.SubTaskType.ToString()))
                throw new ArgumentNullException("SubTastypekType 不能为空");
            if (string.IsNullOrEmpty(request.Source) || string.IsNullOrWhiteSpace(request.Source))
                throw new ArgumentNullException("Source 不能为空");
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.VcaVersion.ToString(), MEDIA, request.SubTaskType.ToString());
            iternalRequest.AddParameter("source", request.Source);
            if (!string.IsNullOrEmpty(request.Version))
                iternalRequest.AddParameter("version", request.Version);
            XGQuerySubTaskResponse response = InvokeHttpClient<XGQuerySubTaskResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询视频分析中间任务结果
        /// </summary>
        /// <param name="request">XGQuerySubTaskRequest</param>
        /// <returns>异步任务 XGQuerySubTaskResponse </returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGQuerySubTaskResponse> QuerySubTaskResultAsync(XGQuerySubTaskRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("XGQuerySubTaskRequest 不能为空");
            if(string.IsNullOrEmpty(request.SubTaskType.ToString())||string.IsNullOrWhiteSpace(request.SubTaskType.ToString()))
                throw new ArgumentNullException("SubTastypekType 不能为空");
            if (string.IsNullOrEmpty(request.Source)||string.IsNullOrWhiteSpace(request.Source))
                throw new ArgumentNullException("Source 不能为空");
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.VcaVersion.ToString(),MEDIA,request.SubTaskType.ToString());
            iternalRequest.AddParameter("source", request.Source);
            if(!string.IsNullOrEmpty(request.Version))
                iternalRequest.AddParameter("version", request.Version);
            XGQuerySubTaskResponse response = await InvokeHttpClientAsync<XGQuerySubTaskResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 取消视频分析
        /// <para> 只有状态处于预处理的视频可以进行取消 </para>
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCA/s/fjwvybmi5#%E5%8F%96%E6%B6%88%E8%A7%86%E9%A2%91%E5%88%86%E6%9E%90 </para>
        /// </summary>
        /// <param name="source">视频路径，需要对source进行urlEncode</param>
        /// <returns>XGVcaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcaResponse CancelAnalyze(string source)
        {
            if(string.IsNullOrEmpty(source) || string.IsNullOrWhiteSpace(source))
                throw new ArgumentNullException("source 不能为空");
            XGCancelAnalyzeRequest request = new XGCancelAnalyzeRequest() {
                Source = source
            };
            return CancelAnalyze(request);
        }

        /// <summary>
        /// 取消视频分析
        /// <para> 只有状态处于预处理的视频可以进行取消 </para>
        /// </summary>
        /// <param name="source">视频路径，需要对source进行urlEncode</param>
        /// <returns>异步任务 XGVcaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcaResponse> CancelAnalyzeAsync(string source)
        {
            if (string.IsNullOrEmpty(source) || string.IsNullOrWhiteSpace(source))
                throw new ArgumentNullException("source 不能为空");
            XGCancelAnalyzeRequest request = new XGCancelAnalyzeRequest()
            {
                Source = source
            };
            return await CancelAnalyzeAsync(request);
        }

        /// <summary>
        /// 取消视频分析
        /// <para> 只有状态处于预处理的视频可以进行取消 </para>
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCA/s/fjwvybmi5#%E5%8F%96%E6%B6%88%E8%A7%86%E9%A2%91%E5%88%86%E6%9E%90 </para>
        /// </summary>
        /// <param name="request">XGCancelAnalyzeRequest</param>
        /// <returns>XGVcaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcaResponse CancelAnalyze(XGCancelAnalyzeRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("XGCancelAnalyzeRequest 不能为空");
            if (string.IsNullOrEmpty(request.Source) || string.IsNullOrWhiteSpace(request.Source))
                throw new ArgumentNullException("SubTastypekType 不能为空");
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.PUT, request.VcaVersion.ToString(), MEDIA);
            iternalRequest.AddParameter("source", request.Source);
            iternalRequest.AddParameter("cancel", "");
            XGVcaResponse response = InvokeHttpClient<XGVcaResponse>(iternalRequest);
            return response;
        }


        /// <summary>
        /// 取消视频分析
        /// <para> 只有状态处于预处理的视频可以进行取消 </para>
        /// </summary>
        /// <param name="request">XGCancelAnalyzeRequest</param>
        /// <returns>异步任务 XGVcaResponse </returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcaResponse> CancelAnalyzeAsync(XGCancelAnalyzeRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("XGCancelAnalyzeRequest 不能为空");
            if (string.IsNullOrEmpty(request.Source) || string.IsNullOrWhiteSpace(request.Source))
                throw new ArgumentNullException("SubTastypekType 不能为空");
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.PUT, request.VcaVersion.ToString(),MEDIA);
            iternalRequest.AddParameter("source", request.Source);
            iternalRequest.AddParameter("cancel","");
            XGVcaResponse response = await InvokeHttpClientAsync<XGVcaResponse>(iternalRequest);
            return response;
        }

        #endregion

        #region 直播分析

        /// <summary>
        /// 提交直播分析
        /// <para> 用户提供直播流地址，创建一次直播分析 </para>
        /// <para> 支持RTMP/HTTP拉流； </para>
        /// <para> 正在分析中的直播（以直播流地址区分）无法再次进行分析； </para>
        /// <para> 已经分析过的直播（以直播流地址区分，FINISHED/ERROR）可以重新进行分析。 </para>
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCA/s/Kkhd0qlu5#%E6%8F%90%E4%BA%A4%E7%9B%B4%E6%92%AD%E5%88%86%E6%9E%90 </para>
        /// </summary>
        /// <param name="source">直播地址</param>
        /// <param name="notification">通知名称，需要先在mca控制台进行配置</param>
        /// <returns>XGStreamAnalyzeResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGStreamAnalyzeResponse StreamAnalyze(string source, string notification)
        {
            if (string.IsNullOrEmpty(source) || string.IsNullOrWhiteSpace(source))
                throw new ArgumentNullException("source 不能为空");
            if (string.IsNullOrEmpty(notification) || string.IsNullOrWhiteSpace(notification))
                throw new ArgumentNullException("notification 不能为空");
            XGStreamAnalyzeRequest request = new XGStreamAnalyzeRequest()
            {
                Source = source,
                Notification = notification
            };
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.PUT, request.VcaVersion.ToString(), STREAM);
            XGStreamAnalyzeResponse response = InvokeHttpClient<XGStreamAnalyzeResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 提交直播分析
        /// </summary>
        /// <param name="source">直播地址</param>
        /// <param name="notification">通知名称，需要先在mca控制台进行配置</param>
        /// <returns>异步任务 XGStreamAnalyzeResponse </returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGStreamAnalyzeResponse> StreamAnalyzeAsync(string source, string notification)
        {
            if (string.IsNullOrEmpty(source) || string.IsNullOrWhiteSpace(source))
                throw new ArgumentNullException("source 不能为空");
            if (string.IsNullOrEmpty(notification) || string.IsNullOrWhiteSpace(notification))
                throw new ArgumentNullException("notification 不能为空");
            XGStreamAnalyzeRequest request = new XGStreamAnalyzeRequest() {
                Source=source,
                Notification=notification
            };
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.PUT, request.VcaVersion.ToString(),STREAM);
            XGStreamAnalyzeResponse response = await InvokeHttpClientAsync<XGStreamAnalyzeResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 提交直播分析
        /// <para> 用户提供直播流地址，创建一次直播分析 </para>
        /// <para> 支持RTMP/HTTP拉流； </para>
        /// <para> 正在分析中的直播（以直播流地址区分）无法再次进行分析； </para>
        /// <para> 已经分析过的直播（以直播流地址区分，FINISHED/ERROR）可以重新进行分析。 </para>
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCA/s/Kkhd0qlu5#%E6%8F%90%E4%BA%A4%E7%9B%B4%E6%92%AD%E5%88%86%E6%9E%90 </para>
        /// </summary>
        /// <param name="request">XGStreamAnalyzeRequest</param>
        /// <returns>XGStreamAnalyzeResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGStreamAnalyzeResponse StreamAnalyze(XGStreamAnalyzeRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("XGCancelAnalyzeRequest 不能为空");
            if (string.IsNullOrEmpty(request.Source) || string.IsNullOrWhiteSpace(request.Source))
                throw new ArgumentNullException("source 不能为空");
            if (string.IsNullOrEmpty(request.Notification) || string.IsNullOrWhiteSpace(request.Notification))
                throw new ArgumentNullException("notification 不能为空");
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.PUT, request.VcaVersion.ToString(), STREAM);
            XGStreamAnalyzeResponse response = InvokeHttpClient<XGStreamAnalyzeResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 提交直播分析
        /// </summary>
        /// <param name="request">XGStreamAnalyzeRequest</param>
        /// <returns>异步任务 XGStreamAnalyzeResponse </returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGStreamAnalyzeResponse> StreamAnalyzeAsync(XGStreamAnalyzeRequest request)
        {
            if(request==null)
                throw new ArgumentNullException("XGCancelAnalyzeRequest 不能为空");
            if (string.IsNullOrEmpty(request.Source) || string.IsNullOrWhiteSpace(request.Source))
                throw new ArgumentNullException("source 不能为空");
            if (string.IsNullOrEmpty(request.Notification) || string.IsNullOrWhiteSpace(request.Notification))
                throw new ArgumentNullException("notification 不能为空");
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.PUT, request.VcaVersion.ToString(),STREAM);
            XGStreamAnalyzeResponse response = await InvokeHttpClientAsync<XGStreamAnalyzeResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询直播分析基本信息
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCA/s/Kkhd0qlu5#%E6%9F%A5%E8%AF%A2%E7%9B%B4%E6%92%AD%E5%88%86%E6%9E%90%E5%9F%BA%E6%9C%AC%E4%BF%A1%E6%81%AF </para>
        /// </summary>
        /// <param name="source">直播路径，必需</param>
        /// <returns>XGQueryStreamAnalyzeBasicResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGQueryStreamAnalyzeBasicResponse QueryStreamAnalyzeBasic(string source)
        {
            if (string.IsNullOrEmpty(source) || string.IsNullOrWhiteSpace(source))
                throw new ArgumentNullException("source 不能为空");
            XGQueryStreamAnalyzeBasicRequest request = new XGQueryStreamAnalyzeBasicRequest()
            {
                Source = source
            };
            return QueryStreamAnalyzeBasic(request);
        }

        /// <summary>
        /// 查询直播分析基本信息
        /// </summary>
        /// <param name="source">直播路径，必需</param>
        /// <returns>异步任务 XGQueryStreamAnalyzeBasicResponse </returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGQueryStreamAnalyzeBasicResponse> QueryStreamAnalyzeBasicAsync(string source)
        {
            if (string.IsNullOrEmpty(source) || string.IsNullOrWhiteSpace(source))
                throw new ArgumentNullException("source 不能为空");
            XGQueryStreamAnalyzeBasicRequest request = new XGQueryStreamAnalyzeBasicRequest() {
                Source=source
            };
            return await QueryStreamAnalyzeBasicAsync(request);
        }

        /// <summary>
        /// 查询直播分析基本信息
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCA/s/Kkhd0qlu5#%E6%9F%A5%E8%AF%A2%E7%9B%B4%E6%92%AD%E5%88%86%E6%9E%90%E5%9F%BA%E6%9C%AC%E4%BF%A1%E6%81%AF </para>
        /// </summary>
        /// <param name="request">XGQueryStreamAnalyzeBasicRequest</param>
        /// <returns>XGQueryStreamAnalyzeBasicResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGQueryStreamAnalyzeBasicResponse QueryStreamAnalyzeBasic(XGQueryStreamAnalyzeBasicRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("XGCancelAnalyzeRequest 不能为空");
            if (string.IsNullOrEmpty(request.Source) || string.IsNullOrWhiteSpace(request.Source))
                throw new ArgumentNullException("source 不能为空");
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.VcaVersion.ToString(), STREAM);
            iternalRequest.AddParameter("source", request.Source);
            XGQueryStreamAnalyzeBasicResponse response = InvokeHttpClient<XGQueryStreamAnalyzeBasicResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询直播分析基本信息
        /// </summary>
        /// <param name="request">XGStreamAnalyzeRequest</param>
        /// <returns>异步任务 XGQueryStreamAnalyzeBasicResponse </returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGQueryStreamAnalyzeBasicResponse> QueryStreamAnalyzeBasicAsync(XGQueryStreamAnalyzeBasicRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("XGCancelAnalyzeRequest 不能为空");
            if (string.IsNullOrEmpty(request.Source) || string.IsNullOrWhiteSpace(request.Source))
                throw new ArgumentNullException("source 不能为空");
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.VcaVersion.ToString(),STREAM);
            iternalRequest.AddParameter("source",request.Source);
            XGQueryStreamAnalyzeBasicResponse response = await InvokeHttpClientAsync<XGQueryStreamAnalyzeBasicResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 结束直播分析任务
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCA/s/Kkhd0qlu5#%E7%BB%93%E6%9D%9F%E7%9B%B4%E6%92%AD%E5%88%86%E6%9E%90%E4%BB%BB%E5%8A%A1 </para>
        /// </summary>
        /// <param name="source">直播路径，必需</param>
        /// <returns>XGVcaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcaResponse StopStreamAnalyzeTask(string source)
        {
            if (string.IsNullOrEmpty(source) || string.IsNullOrWhiteSpace(source))
                throw new ArgumentNullException("source 不能为空");
            XGStopStreamAnalyzeRequest request = new XGStopStreamAnalyzeRequest() {
                Source=source
            };
            return StopStreamAnalyzeTask(request);
        }

        /// <summary>
        /// 结束直播分析任务
        /// </summary>
        /// <param name="source">直播路径，必需</param>
        /// <returns>异步任务 XGVcaResponse </returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcaResponse> StopStreamAnalyzeTaskAsync(string source)
        {
            if (string.IsNullOrEmpty(source) || string.IsNullOrWhiteSpace(source))
                throw new ArgumentNullException("source 不能为空");
            XGStopStreamAnalyzeRequest request = new XGStopStreamAnalyzeRequest()
            {
                Source = source
            };
            return await StopStreamAnalyzeTaskAsync(request);
        }

        /// <summary>
        /// 结束直播分析任务
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCA/s/Kkhd0qlu5#%E7%BB%93%E6%9D%9F%E7%9B%B4%E6%92%AD%E5%88%86%E6%9E%90%E4%BB%BB%E5%8A%A1 </para>
        /// </summary>
        /// <param name="request">XGStopStreamAnalyzeRequest</param>
        /// <returns>XGVcaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcaResponse StopStreamAnalyzeTask(XGStopStreamAnalyzeRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("XGStopStreamAnalyzeRequest 不能为空");
            if (string.IsNullOrEmpty(request.Source) || string.IsNullOrWhiteSpace(request.Source))
                throw new ArgumentNullException("Source 不能为空");
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.PUT, request.VcaVersion.ToString(), STREAM);
            iternalRequest.AddParameter("source", request.Source);
            iternalRequest.AddParameter("stop", "");
            XGVcaResponse response = InvokeHttpClient<XGVcaResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 结束直播分析任务
        /// </summary>
        /// <param name="request">XGStopStreamAnalyzeRequest</param>
        /// <returns>异步任务 XGVcaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcaResponse> StopStreamAnalyzeTaskAsync(XGStopStreamAnalyzeRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("XGStopStreamAnalyzeRequest 不能为空");
            if (string.IsNullOrEmpty(request.Source) || string.IsNullOrWhiteSpace(request.Source))
                throw new ArgumentNullException("Source 不能为空");
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.PUT, request.VcaVersion.ToString(),STREAM);
            iternalRequest.AddParameter("source", request.Source);
            iternalRequest.AddParameter("stop", "");
            XGVcaResponse response = await InvokeHttpClientAsync<XGVcaResponse>(iternalRequest);
            return response;
        }

        #endregion

        #region 图片分析

        /// <summary>
        /// 提交图片分析（同步）
        /// <para> 用户提供图片URL或BOS路径，进行图片分析。</para>
        /// <para> 该接口为同步接口，即直接在HTTP response body中返回图片分析结果。</para>
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCA/s/ukmbxecsp#%E6%8F%90%E4%BA%A4%E5%9B%BE%E7%89%87%E5%88%86%E6%9E%90%EF%BC%88%E5%90%8C%E6%AD%A5%EF%BC%89 </para>
        /// </summary>
        /// <param name="source">图片url，必需</param>
        /// <returns>XGImageAnalyzeResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGImageAnalyzeResponse ImageAnalyze(string source)
        {
            if (string.IsNullOrEmpty(source) || string.IsNullOrWhiteSpace(source))
                throw new ArgumentNullException("source 不能为空");
            XGImageAnalyzeRequest request = new XGImageAnalyzeRequest()
            {
                Source = source
            };
            return ImageAnalyze(request);
        }

        /// <summary>
        /// 提交图片分析
        /// </summary>
        /// <param name="source"></param>
        /// <returns>异步任务 XGImageAnalyzeResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGImageAnalyzeResponse> ImageAnalyzeAsync(string source)
        {
            if (string.IsNullOrEmpty(source) || string.IsNullOrWhiteSpace(source))
                throw new ArgumentNullException("source 不能为空");
            XGImageAnalyzeRequest request = new XGImageAnalyzeRequest() {
                Source=source
            };
            return await ImageAnalyzeAsync(request);
        }

        /// <summary>
        /// 提交图片分析（同步）
        /// <para> 用户提供图片URL或BOS路径，进行图片分析。</para>
        /// <para> 该接口为同步接口，即直接在HTTP response body中返回图片分析结果。</para>
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCA/s/ukmbxecsp#%E6%8F%90%E4%BA%A4%E5%9B%BE%E7%89%87%E5%88%86%E6%9E%90%EF%BC%88%E5%90%8C%E6%AD%A5%EF%BC%89 </para>
        /// </summary>
        /// <param name="request">XGImageAnalyzeRequest</param>
        /// <returns>XGImageAnalyzeResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGImageAnalyzeResponse ImageAnalyze(XGImageAnalyzeRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("XGImageAnalyzeRequest 不能为空");
            if (string.IsNullOrEmpty(request.Source) || string.IsNullOrWhiteSpace(request.Source))
                throw new ArgumentNullException("Source 不能为空");
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.PUT, request.VcaVersion.ToString(), IMAGE);
            iternalRequest.AddParameter("sync", "");
            XGImageAnalyzeResponse response = InvokeHttpClient<XGImageAnalyzeResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 提交图片分析
        /// </summary>
        /// <param name="request">XGStreamAnalyzeRequest</param>
        /// <returns>异步任务 XGQueryStreamAnalyzeBasicResponse </returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGImageAnalyzeResponse> ImageAnalyzeAsync(XGImageAnalyzeRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("XGImageAnalyzeRequest 不能为空");
            if (string.IsNullOrEmpty(request.Source) || string.IsNullOrWhiteSpace(request.Source))
                throw new ArgumentNullException("Source 不能为空");
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.PUT, request.VcaVersion.ToString(),IMAGE);
            iternalRequest.AddParameter("sync", "");
            XGImageAnalyzeResponse response = await InvokeHttpClientAsync<XGImageAnalyzeResponse>(iternalRequest);
            return response;
        }

        #endregion

        #region 自定义face库接口

        /// <summary>
        /// 创建自定义face库
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCA/s/2khkk49hb#%E5%88%9B%E5%BB%BA%E8%87%AA%E5%AE%9A%E4%B9%89face%E5%BA%93 </para>
        /// </summary>
        /// <param name="lib">face库名</param>
        /// <param name="description">图片描述</param>
        /// <returns>XGVcaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcaResponse CreateCustomFaceLib(string lib, string description=null)
        {
            if (string.IsNullOrEmpty(lib) || string.IsNullOrWhiteSpace(lib))
                throw new ArgumentNullException("lib 不能为空");
            XGCreateCustomFaceLibRequest request = new XGCreateCustomFaceLibRequest()
            {
                Lib=lib,
                Description=description
            };
            return CreateCustomFaceLib(request);
        }

        /// <summary>
        /// 创建自定义face库
        /// </summary>
        /// <param name="lib">face库名</param>
        /// <param name="description">图片描述</param>
        /// <returns>异步任务XGVcaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcaResponse> CreateCustomFaceLibAsync(string lib, string description = null)
        {
            if (string.IsNullOrEmpty(lib) || string.IsNullOrWhiteSpace(lib))
                throw new ArgumentNullException("lib 不能为空");
            XGCreateCustomFaceLibRequest request = new XGCreateCustomFaceLibRequest()
            {
                Lib = lib,
                Description = description
            };
            return await CreateCustomFaceLibAsync(request);
        }

        /// <summary>
        /// 创建自定义face库
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCA/s/2khkk49hb#%E5%88%9B%E5%BB%BA%E8%87%AA%E5%AE%9A%E4%B9%89face%E5%BA%93 </para>
        /// </summary>
        /// <param name="request">XGCreateCustomFaceLibRequest</param>
        /// <returns>XGVcaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcaResponse CreateCustomFaceLib(XGCreateCustomFaceLibRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request 不能为空");
            if (string.IsNullOrEmpty(request.Lib) || string.IsNullOrWhiteSpace(request.Lib))
                throw new ArgumentNullException("Lib 不能为空");
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.POST, request.VcaVersion.ToString(), FACE, "lib");
            XGVcaResponse response = InvokeHttpClient<XGVcaResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 创建自定义face库
        /// </summary>
        /// <param name="request">XGCreateCustomFaceLibRequest</param>
        /// <returns>异步任务 XGVcaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcaResponse> CreateCustomFaceLibAsync(XGCreateCustomFaceLibRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request 不能为空");
            if (string.IsNullOrEmpty(request.Lib) || string.IsNullOrWhiteSpace(request.Lib))
                throw new ArgumentNullException("Lib 不能为空");
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.POST, request.VcaVersion.ToString(),FACE,"lib");
            XGVcaResponse response = await InvokeHttpClientAsync<XGVcaResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 列出所有face库
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCA/s/2khkk49hb#%E5%88%97%E5%87%BA%E6%89%80%E6%9C%89face%E5%BA%93 </para>
        /// </summary>
        /// <param name="vcaVersion">vca接口版本</param>
        /// <returns>XGListFaceLibResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGListFaceLibResponse ListFaceLibs(XGVcaVersion vcaVersion=XGVcaVersion.v1)
        {
            XGBceIternalRequest iternalRequest = CreateRequest(new XGVcaBaseRequest(), BceHttpMethod.GET, vcaVersion.ToString(), FACE, "lib");
            XGListFaceLibResponse response = InvokeHttpClient<XGListFaceLibResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 列出所有face库
        /// </summary>
        /// <param name="vcaVersion">vca接口版本</param>
        /// <returns>异步任务 XGListFaceLibResponse </returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGListFaceLibResponse> ListFaceLibsAsync(XGVcaVersion vcaVersion=XGVcaVersion.v1)
        {
            XGBceIternalRequest iternalRequest = CreateRequest(new XGVcaBaseRequest(), BceHttpMethod.GET, vcaVersion.ToString(),FACE,"lib");
            XGListFaceLibResponse response = await InvokeHttpClientAsync<XGListFaceLibResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 删除自定义face库
        /// <para> 接口文档： https://cloud.baidu.com/doc/VCA/s/2khkk49hb#%E5%88%A0%E9%99%A4%E8%87%AA%E5%AE%9A%E4%B9%89face%E5%BA%93 </para>
        /// </summary>
        /// <param name="vcaVersion">版本</param>
        /// <param name="lib">face库名</param>
        /// <returns>XGVcaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcaResponse DeleteCustomFaceLib(XGVcaVersion vcaVersion, string lib)
        {
            if (string.IsNullOrEmpty(lib) || string.IsNullOrWhiteSpace(lib))
                throw new ArgumentNullException("lib 不能为空");
            XGDeleteCustomFaceLibRequest request = new XGDeleteCustomFaceLibRequest()
            {
                Lib=lib,
                VcaVersion=vcaVersion
            };
            return DeleteCustomFaceLib(request);
        }

        /// <summary>
        /// 删除自定义face库
        /// <para> 接口文档： https://cloud.baidu.com/doc/VCA/s/2khkk49hb#%E5%88%A0%E9%99%A4%E8%87%AA%E5%AE%9A%E4%B9%89face%E5%BA%93 </para>
        /// </summary>
        /// <param name="vcaVersion">版本</param>
        /// <param name="lib">face库名</param>
        /// <returns>异步任务XGVcaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcaResponse> DeleteCustomFaceLibAsync(XGVcaVersion vcaVersion, string lib)
        {
            if (string.IsNullOrEmpty(lib) || string.IsNullOrWhiteSpace(lib))
                throw new ArgumentNullException("lib 不能为空");
            XGDeleteCustomFaceLibRequest request = new XGDeleteCustomFaceLibRequest()
            {
                Lib = lib,
                VcaVersion = vcaVersion
            };
            return await DeleteCustomFaceLibAsync(request);
        }

        /// <summary>
        /// 删除自定义face库
        /// <para> 接口文档： https://cloud.baidu.com/doc/VCA/s/2khkk49hb#%E5%88%A0%E9%99%A4%E8%87%AA%E5%AE%9A%E4%B9%89face%E5%BA%93 </para>
        /// </summary>
        /// <param name="request">XGDeleteCustomFaceLibRequest</param>
        /// <returns>XGVcaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcaResponse DeleteCustomFaceLib(XGDeleteCustomFaceLibRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request 不能为空");
            if (string.IsNullOrEmpty(request.Lib) || string.IsNullOrWhiteSpace(request.Lib))
                throw new ArgumentNullException("Lib 不能为空");
            if (string.IsNullOrEmpty(request.Version) || string.IsNullOrWhiteSpace(request.Version))
                throw new ArgumentNullException("Version 不能为空");
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.DELETE, request.VcaVersion.ToString(), FACE, "lib", request.Lib);
            XGVcaResponse response;
            response = InvokeHttpClient<XGVcaResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 删除自定义face库
        /// </summary>
        /// <param name="request">XGDeleteCustomFaceLibRequest</param>
        /// <returns>异步任务 XGVcaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcaResponse> DeleteCustomFaceLibAsync(XGDeleteCustomFaceLibRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request 不能为空");
            if (string.IsNullOrEmpty(request.Lib) || string.IsNullOrWhiteSpace(request.Lib))
                throw new ArgumentNullException("Lib 不能为空");
            if (string.IsNullOrEmpty(request.Version) || string.IsNullOrWhiteSpace(request.Version))
                throw new ArgumentNullException("Version 不能为空");
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.DELETE, request.VcaVersion.ToString(),FACE, "lib",request.Lib);
            XGVcaResponse response;
            response = await InvokeHttpClientAsync<XGVcaResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 添加face库集素材
        /// <para> 接口文档： https://cloud.baidu.com/doc/VCA/s/2khkk49hb#face%E5%BA%93%E9%9B%86%E7%B4%A0%E6%9D%90%E6%B7%BB%E5%8A%A0 </para>
        /// </summary>
        /// <param name="lib">face库名</param>
        /// <param name="image">图片url</param>
        /// <param name="brief">图片描述</param>
        /// <returns>XGVcaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcaResponse AddFaceLibBriefSource(string lib, string image, string brief)
        {
            if (string.IsNullOrEmpty(lib) || string.IsNullOrWhiteSpace(lib))
                throw new ArgumentNullException("lib 不能为空");
            if (string.IsNullOrEmpty(brief) || string.IsNullOrWhiteSpace(brief))
                throw new ArgumentNullException("brief 不能为空");
            if (string.IsNullOrEmpty(image) || string.IsNullOrWhiteSpace(image))
                throw new ArgumentNullException("image 不能为空");
            XGAddFaceLibBriefSourceRequest request = new XGAddFaceLibBriefSourceRequest()
            {
                Lib=lib,
                Brief=brief,
                Image=image
            };
            return AddFaceLibBriefSource(request);
        }

        /// <summary>
        /// 添加face库集素材
        /// </summary>
        /// <param name="lib">face库名</param>
        /// <param name="image">图片url</param>
        /// <param name="brief">图片描述</param>
        /// <returns>异步任务XGVcaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcaResponse> AddFaceLibBriefSourceAsync(string lib, string image, string brief)
        {
            if (string.IsNullOrEmpty(lib) || string.IsNullOrWhiteSpace(lib))
                throw new ArgumentNullException("lib 不能为空");
            if (string.IsNullOrEmpty(brief) || string.IsNullOrWhiteSpace(brief))
                throw new ArgumentNullException("brief 不能为空");
            if (string.IsNullOrEmpty(image) || string.IsNullOrWhiteSpace(image))
                throw new ArgumentNullException("image 不能为空");
            XGAddFaceLibBriefSourceRequest request = new XGAddFaceLibBriefSourceRequest()
            {
                Lib = lib,
                Brief = brief,
                Image = image
            };
            return await AddFaceLibBriefSourceAsync(request);
        }

        /// <summary>
        /// 添加face库集素材
        /// <para> 接口文档： https://cloud.baidu.com/doc/VCA/s/2khkk49hb#face%E5%BA%93%E9%9B%86%E7%B4%A0%E6%9D%90%E6%B7%BB%E5%8A%A0 </para>
        /// </summary>
        /// <param name="request">XGAddFaceLibBriefSourceRequest</param>
        /// <returns>XGVcaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcaResponse AddFaceLibBriefSource(XGAddFaceLibBriefSourceRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request 不能为空");
            if (string.IsNullOrEmpty(request.Lib) || string.IsNullOrWhiteSpace(request.Lib))
                throw new ArgumentNullException("Lib 不能为空");
            if (string.IsNullOrEmpty(request.Image) || string.IsNullOrWhiteSpace(request.Image))
                throw new ArgumentNullException("Image 不能为空");
            if (string.IsNullOrEmpty(request.Brief) || string.IsNullOrWhiteSpace(request.Brief))
                throw new ArgumentNullException("Brief 不能为空");
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.POST, request.VcaVersion.ToString(), FACE, "lib", request.Lib);
            XGVcaResponse response = InvokeHttpClient<XGVcaResponse>(iternalRequest);
            return response;
        }


        /// <summary>
        /// 添加face库集素材
        /// </summary>
        /// <param name="request">XGAddFaceLibBriefSourceRequest</param>
        /// <returns>异步任务 XGVcaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcaResponse> AddFaceLibBriefSourceAsync(XGAddFaceLibBriefSourceRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request 不能为空");
            if (string.IsNullOrEmpty(request.Lib) || string.IsNullOrWhiteSpace(request.Lib))
                throw new ArgumentNullException("Lib 不能为空");
            if (string.IsNullOrEmpty(request.Image) || string.IsNullOrWhiteSpace(request.Image))
                throw new ArgumentNullException("Image 不能为空");
            if(string.IsNullOrEmpty(request.Brief) || string.IsNullOrWhiteSpace(request.Brief))
                throw new ArgumentNullException("Brief 不能为空");
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.POST, request.VcaVersion.ToString(),FACE, "lib", request.Lib);
            XGVcaResponse response = await InvokeHttpClientAsync<XGVcaResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 删除face库集素材
        /// <para> 接口文档： https://cloud.baidu.com/doc/VCA/s/2khkk49hb#face%E5%BA%93%E9%9B%86%E7%B4%A0%E6%9D%90%E5%88%A0%E9%99%A4 </para>
        /// </summary>
        /// <param name="lib">face库名</param>
        /// <param name="brief">图片描述</param>
        /// <param name="image">图片url</param>
        /// <returns>XGVcaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcaResponse DeleteFaceLibBriefSource(string lib, string brief, string image)
        {
            if (string.IsNullOrEmpty(lib) || string.IsNullOrWhiteSpace(lib))
                throw new ArgumentNullException("lib 不能为空");
            if (string.IsNullOrEmpty(brief) || string.IsNullOrWhiteSpace(brief))
                throw new ArgumentNullException("brief 不能为空");
            if (string.IsNullOrEmpty(image) || string.IsNullOrWhiteSpace(image))
                throw new ArgumentNullException("image 不能为空");
            XGDeleteFaceLibBriefSourceRequest request = new XGDeleteFaceLibBriefSourceRequest()
            {
                Lib=lib,
                Brief=brief,
                Image=image
            };
            return DeleteFaceLibBriefSource(request);
        }

        /// <summary>
        /// 删除face库集素材
        /// </summary>
        /// <param name="lib">face库名</param>
        /// <param name="brief">图片描述</param>
        /// <param name="image">图片url</param>
        /// <returns>异步任务XGVcaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcaResponse> DeleteFaceLibBriefSourceAsync(string lib, string brief, string image)
        {
            if (string.IsNullOrEmpty(lib) || string.IsNullOrWhiteSpace(lib))
                throw new ArgumentNullException("lib 不能为空");
            if (string.IsNullOrEmpty(brief) || string.IsNullOrWhiteSpace(brief))
                throw new ArgumentNullException("brief 不能为空");
            if (string.IsNullOrEmpty(image) || string.IsNullOrWhiteSpace(image))
                throw new ArgumentNullException("image 不能为空");
            XGDeleteFaceLibBriefSourceRequest request = new XGDeleteFaceLibBriefSourceRequest()
            {
                Lib = lib,
                Brief = brief,
                Image = image
            };
            return await DeleteFaceLibBriefSourceAsync(request);
        }

        /// <summary>
        /// 删除face库集素材
        /// <para> 接口文档： https://cloud.baidu.com/doc/VCA/s/2khkk49hb#face%E5%BA%93%E9%9B%86%E7%B4%A0%E6%9D%90%E5%88%A0%E9%99%A4 </para>
        /// </summary>
        /// <param name="request">XGDeleteFaceLibBriefSourceRequest</param>
        /// <returns>XGVcaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcaResponse DeleteFaceLibBriefSource(XGDeleteFaceLibBriefSourceRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request 不能为空");
            if (string.IsNullOrEmpty(request.Lib) || string.IsNullOrWhiteSpace(request.Lib))
                throw new ArgumentNullException("Lib 不能为空");
            if (string.IsNullOrEmpty(request.Image) || string.IsNullOrWhiteSpace(request.Image))
                throw new ArgumentNullException("Image 不能为空");
            if (string.IsNullOrEmpty(request.Brief) || string.IsNullOrWhiteSpace(request.Brief))
                throw new ArgumentNullException("Brief 不能为空");
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.DELETE, request.VcaVersion.ToString(), FACE, "lib", request.Lib);
            iternalRequest.AddParameter("brief", request.Brief);
            iternalRequest.AddParameter("image", request.Image);
            XGVcaResponse response = InvokeHttpClient<XGVcaResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 删除face库集素材
        /// </summary>
        /// <param name="request">XGDeleteFaceLibBriefSourceRequest</param>
        /// <returns>异步任务 XGVcaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcaResponse> DeleteFaceLibBriefSourceAsync(XGDeleteFaceLibBriefSourceRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request 不能为空");
            if (string.IsNullOrEmpty(request.Lib) || string.IsNullOrWhiteSpace(request.Lib))
                throw new ArgumentNullException("Lib 不能为空");
            if (string.IsNullOrEmpty(request.Image) || string.IsNullOrWhiteSpace(request.Image))
                throw new ArgumentNullException("Image 不能为空");
            if (string.IsNullOrEmpty(request.Brief) || string.IsNullOrWhiteSpace(request.Brief))
                throw new ArgumentNullException("Brief 不能为空");
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.DELETE, request.VcaVersion.ToString(), FACE, "lib", request.Lib);
            iternalRequest.AddParameter("brief",request.Brief);
            iternalRequest.AddParameter("image",request.Image);
            XGVcaResponse response = await InvokeHttpClientAsync<XGVcaResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// face库集素材列表
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCA/s/2khkk49hb#face%E5%BA%93%E9%9B%86%E7%B4%A0%E6%9D%90%E5%88%97%E8%A1%A8 </para>
        /// </summary>
        /// <param name="lib">face库名</param>
        /// <param name="brief">图片描述</param>
        /// <returns>XGListFaceLibBriefSourceResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGListFaceLibBriefSourceResponse ListFaceLibBriefSources(string lib, string brief)
        {
            if (string.IsNullOrEmpty(lib) || string.IsNullOrWhiteSpace(lib))
                throw new ArgumentNullException("lib 不能为空");
            if (string.IsNullOrEmpty(brief) || string.IsNullOrWhiteSpace(brief))
                throw new ArgumentNullException("brief 不能为空");
            XGListFaceLibBriefSourceRequest request = new XGListFaceLibBriefSourceRequest()
            {
                Lib=lib,
                Brief=brief
            };
            return ListFaceLibBriefSources(request);
        }

        /// <summary>
        /// face库集素材列表
        /// </summary>
        /// <param name="lib">face库名</param>
        /// <param name="brief">图片描述</param>
        /// <returns>异步任务XGListFaceLibBriefSourceResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGListFaceLibBriefSourceResponse> ListFaceLibBriefSourcesAsync(string lib, string brief)
        {
            if (string.IsNullOrEmpty(lib) || string.IsNullOrWhiteSpace(lib))
                throw new ArgumentNullException("lib 不能为空");
            if (string.IsNullOrEmpty(brief) || string.IsNullOrWhiteSpace(brief))
                throw new ArgumentNullException("brief 不能为空");
            XGListFaceLibBriefSourceRequest request = new XGListFaceLibBriefSourceRequest()
            {
                Lib = lib,
                Brief = brief
            };
            return await ListFaceLibBriefSourcesAsync(request);
        }

        /// <summary>
        /// face库集素材列表
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCA/s/2khkk49hb#face%E5%BA%93%E9%9B%86%E7%B4%A0%E6%9D%90%E5%88%97%E8%A1%A8 </para>
        /// </summary>
        /// <param name="request">XGListFaceLibBriefSourceRequest</param>
        /// <returns>XGListFaceLibBriefSourceResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGListFaceLibBriefSourceResponse ListFaceLibBriefSources(XGListFaceLibBriefSourceRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request 不能为空");
            if (string.IsNullOrEmpty(request.Lib) || string.IsNullOrWhiteSpace(request.Lib))
                throw new ArgumentNullException("Lib 不能为空");
            if (string.IsNullOrEmpty(request.Brief) || string.IsNullOrWhiteSpace(request.Brief))
                throw new ArgumentNullException("Brief 不能为空");
            XGBceIternalRequest iternalRequest = CreateRequest(new XGVcaBaseRequest(), BceHttpMethod.GET, request.VcaVersion.ToString(), FACE, "lib", request.Lib);
            iternalRequest.AddParameter("brief", request.Brief);
            XGListFaceLibBriefSourceResponse response = InvokeHttpClient<XGListFaceLibBriefSourceResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// face库集素材列表
        /// </summary>
        /// <param name="request">XGListFaceLibBriefSourceRequest</param>
        /// <returns>异步任务 XGListFaceLibBriefSourceResponse </returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGListFaceLibBriefSourceResponse> ListFaceLibBriefSourcesAsync(XGListFaceLibBriefSourceRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request 不能为空");
            if (string.IsNullOrEmpty(request.Lib) || string.IsNullOrWhiteSpace(request.Lib))
                throw new ArgumentNullException("Lib 不能为空");
            if (string.IsNullOrEmpty(request.Brief) || string.IsNullOrWhiteSpace(request.Brief))
                throw new ArgumentNullException("Brief 不能为空");
            XGBceIternalRequest iternalRequest = CreateRequest(new XGVcaBaseRequest(), BceHttpMethod.GET, request.VcaVersion.ToString(), FACE, "lib",request.Lib);
            iternalRequest.AddParameter("brief",request.Brief);
            XGListFaceLibBriefSourceResponse response = await InvokeHttpClientAsync<XGListFaceLibBriefSourceResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// face库集删除
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCA/s/2khkk49hb#face%E5%BA%93%E9%9B%86%E5%88%A0%E9%99%A4 </para>
        /// </summary>
        /// <param name="lib">face库名</param>
        /// <param name="brief">图片描述</param>
        /// <returns>XGVcaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcaResponse DeleteFaceLibBrief(string lib, string brief)
        {
            if (string.IsNullOrEmpty(lib) || string.IsNullOrWhiteSpace(lib))
                throw new ArgumentNullException("lib 不能为空");
            if (string.IsNullOrEmpty(brief) || string.IsNullOrWhiteSpace(brief))
                throw new ArgumentNullException("brief 不能为空");
            XGDeleteFaceLibBriefRequest request = new XGDeleteFaceLibBriefRequest()
            {
                Lib=lib,
                Brief=brief
            };
            return DeleteFaceLibBrief(request);
        }

        /// <summary>
        /// face库集删除
        /// </summary>
        /// <param name="lib">face库名</param>
        /// <param name="brief">图片描述</param>
        /// <returns>异步任务XGVcaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcaResponse> DeleteFaceLibBriefAsync(string lib, string brief)
        {
            if (string.IsNullOrEmpty(lib) || string.IsNullOrWhiteSpace(lib))
                throw new ArgumentNullException("lib 不能为空");
            if (string.IsNullOrEmpty(brief) || string.IsNullOrWhiteSpace(brief))
                throw new ArgumentNullException("brief 不能为空");
            XGDeleteFaceLibBriefRequest request = new XGDeleteFaceLibBriefRequest()
            {
                Lib = lib,
                Brief = brief
            };
            return await DeleteFaceLibBriefAsync(request);
        }

        /// <summary>
        /// face库集删除
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCA/s/2khkk49hb#face%E5%BA%93%E9%9B%86%E5%88%A0%E9%99%A4 </para>
        /// </summary>
        /// <param name="request">XGDeleteFaceLibBriefRequest</param>
        /// <returns>XGVcaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcaResponse DeleteFaceLibBrief(XGDeleteFaceLibBriefRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request 不能为空");
            if (string.IsNullOrEmpty(request.Lib) || string.IsNullOrWhiteSpace(request.Lib))
                throw new ArgumentNullException("Lib 不能为空");
            if (string.IsNullOrEmpty(request.Brief) || string.IsNullOrWhiteSpace(request.Brief))
                throw new ArgumentNullException("Brief 不能为空");
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.DELETE, request.VcaVersion.ToString(), FACE, "lib", request.Lib);
            iternalRequest.AddParameter("brief", request.Brief);
            XGVcaResponse response = InvokeHttpClient<XGVcaResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// face库集删除
        /// </summary>
        /// <param name="request">XGDeleteFaceLibBriefRequest</param>
        /// <returns>异步任务 XGVcaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcaResponse> DeleteFaceLibBriefAsync(XGDeleteFaceLibBriefRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request 不能为空");
            if (string.IsNullOrEmpty(request.Lib) || string.IsNullOrWhiteSpace(request.Lib))
                throw new ArgumentNullException("Lib 不能为空");
            if (string.IsNullOrEmpty(request.Brief) || string.IsNullOrWhiteSpace(request.Brief))
                throw new ArgumentNullException("Brief 不能为空");
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.DELETE, request.VcaVersion.ToString(), FACE, "lib", request.Lib);
            iternalRequest.AddParameter("brief", request.Brief);
            XGVcaResponse response = await InvokeHttpClientAsync<XGVcaResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// face库集列表
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCA/s/2khkk49hb#face%E5%BA%93%E9%9B%86%E5%88%97%E8%A1%A8 </para>
        /// </summary>
        /// <param name="lib">face库名</param>
        /// <returns>XGListFaceLibBriefResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGListFaceLibBriefResponse ListFaceLibBrief(string lib)
        {
            if (string.IsNullOrEmpty(lib) || string.IsNullOrWhiteSpace(lib))
                throw new ArgumentNullException("lib 不能为空");
            XGListFaceLibBriefRequest request = new XGListFaceLibBriefRequest()
            {
                Lib=lib
            };
            return ListFaceLibBrief(request);
        }

        /// <summary>
        /// face库集列表
        /// </summary>
        /// <param name="lib">face库名</param>
        /// <returns>异步任务XGListFaceLibBriefResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGListFaceLibBriefResponse> ListFaceLibBriefAsync(string lib)
        {
            if (string.IsNullOrEmpty(lib) || string.IsNullOrWhiteSpace(lib))
                throw new ArgumentNullException("lib 不能为空");
            XGListFaceLibBriefRequest request = new XGListFaceLibBriefRequest()
            {
                Lib = lib
            };
            return await ListFaceLibBriefAsync(request);
        }

        /// <summary>
        /// face库集列表
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCA/s/2khkk49hb#face%E5%BA%93%E9%9B%86%E5%88%97%E8%A1%A8 </para>
        /// </summary>
        /// <param name="request">XGListFaceLibBriefRequest</param>
        /// <returns>XGListFaceLibBriefResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGListFaceLibBriefResponse ListFaceLibBrief(XGListFaceLibBriefRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request 不能为空");
            if (string.IsNullOrEmpty(request.Lib) || string.IsNullOrWhiteSpace(request.Lib))
                throw new ArgumentNullException("Lib 不能为空");
            XGBceIternalRequest iternalRequest = CreateRequest(new XGVcaBaseRequest(), BceHttpMethod.GET, request.VcaVersion.ToString(), FACE, "lib", request.Lib);
            XGListFaceLibBriefResponse response = InvokeHttpClient<XGListFaceLibBriefResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// face库集列表
        /// </summary>
        /// <param name="request">XGListFaceLibBriefRequest</param>
        /// <returns>异步任务 XGListFaceLibBriefResponse </returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGListFaceLibBriefResponse> ListFaceLibBriefAsync(XGListFaceLibBriefRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request 不能为空");
            if (string.IsNullOrEmpty(request.Lib) || string.IsNullOrWhiteSpace(request.Lib))
                throw new ArgumentNullException("Lib 不能为空");
            XGBceIternalRequest iternalRequest = CreateRequest(new XGVcaBaseRequest(), BceHttpMethod.GET, request.VcaVersion.ToString(), FACE, "lib", request.Lib);
            XGListFaceLibBriefResponse response = await InvokeHttpClientAsync<XGListFaceLibBriefResponse>(iternalRequest);
            return response;
        }

        #endregion

        #region 自定义logo库

        /// <summary>
        /// 创建自定义logo库
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCA/s/zki9mepfq#%E5%88%9B%E5%BB%BA%E8%87%AA%E5%AE%9A%E4%B9%89logo%E5%BA%93 </para>
        /// </summary>
        /// <param name="lib">logo库名</param>
        /// <param name="description">图片描述</param>
        /// <returns>XGVcaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcaResponse CreateCustomLogoLib(string lib, string description=null)
        {
            if (string.IsNullOrEmpty(lib) || string.IsNullOrWhiteSpace(lib))
                throw new ArgumentNullException("lib 不能为空");
            XGCreateCustomLogoLibRequest request = new XGCreateCustomLogoLibRequest()
            {
                Lib=lib,
                Description=description
            };
            return CreateCustomLogoLib(request);
        }

        /// <summary>
        /// 创建自定义logo库
        /// </summary>
        /// <param name="lib">logo库名</param>
        /// <param name="description">图片描述</param>
        /// <returns>异步任务XGVcaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcaResponse> CreateCustomLogoLibAsync(string lib, string description = null)
        {
            if (string.IsNullOrEmpty(lib) || string.IsNullOrWhiteSpace(lib))
                throw new ArgumentNullException("lib 不能为空");
            XGCreateCustomLogoLibRequest request = new XGCreateCustomLogoLibRequest()
            {
                Lib = lib,
                Description = description
            };
            return await CreateCustomLogoLibAsync(request);
        }

        /// <summary>
        /// 创建自定义logo库
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCA/s/zki9mepfq#%E5%88%9B%E5%BB%BA%E8%87%AA%E5%AE%9A%E4%B9%89logo%E5%BA%93 </para>
        /// </summary>
        /// <param name="request">XGCreateCustomLogoLibRequest</param>
        /// <returns>XGVcaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcaResponse CreateCustomLogoLib(XGCreateCustomLogoLibRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request 不能为空");
            if (string.IsNullOrEmpty(request.Lib) || string.IsNullOrWhiteSpace(request.Lib))
                throw new ArgumentNullException("Lib 不能为空");
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.POST, request.VcaVersion.ToString(), LOGO, "lib");
            XGVcaResponse response = InvokeHttpClient<XGVcaResponse>(iternalRequest); 
            return response;
        }

        /// <summary>
        /// 创建自定义logo库
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCA/s/zki9mepfq#%E5%88%9B%E5%BB%BA%E8%87%AA%E5%AE%9A%E4%B9%89logo%E5%BA%93 </para>
        /// </summary>
        /// <param name="request">XGCreateCustomLogoLibRequest</param>
        /// <returns>异步任务 XGVcaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcaResponse> CreateCustomLogoLibAsync(XGCreateCustomLogoLibRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request 不能为空");
            if (string.IsNullOrEmpty(request.Lib) || string.IsNullOrWhiteSpace(request.Lib))
                throw new ArgumentNullException("Lib 不能为空");
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.POST, request.VcaVersion.ToString(), LOGO, "lib");
            XGVcaResponse response = await InvokeHttpClientAsync<XGVcaResponse>(iternalRequest);
            return response;
        }

        // <summary>
        /// 列出所有logo库
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCA/s/zki9mepfq#%E5%88%97%E5%87%BA%E6%89%80%E6%9C%89logo%E5%BA%93 </para>
        /// </summary>
        /// <param name="vcaVersion">vca接口版本</param>
        /// <returns>XGListLogoLibResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGListLogoLibResponse ListLogoLibs(XGVcaVersion vcaVersion)
        {
            XGBceIternalRequest iternalRequest = CreateRequest(new XGVcaBaseRequest(), BceHttpMethod.GET, vcaVersion.ToString(), LOGO, "lib");
            XGListLogoLibResponse response = InvokeHttpClient<XGListLogoLibResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 列出所有logo库
        /// </summary>
        /// <param name="vcaVersion">vca接口版本</param>
        /// <returns>异步任务 XGListLogoLibResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGListLogoLibResponse> ListLogoLibsAsync(XGVcaVersion vcaVersion=XGVcaVersion.v2)
        {
            XGBceIternalRequest iternalRequest = CreateRequest(new XGVcaBaseRequest(), BceHttpMethod.GET, vcaVersion.ToString(),LOGO, "lib");
            XGListLogoLibResponse response = await InvokeHttpClientAsync<XGListLogoLibResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 添加logo库集素材
        /// <para> 往指定的logo库集添加图片 </para>
        /// <para> 接口文档： https://cloud.baidu.com/doc/VCA/s/zki9mepfq#logo%E5%BA%93%E9%9B%86%E7%B4%A0%E6%9D%90%E6%B7%BB%E5%8A%A0 </para>
        /// </summary>
        /// <param name="lib">logo库名</param>
        /// <param name="image">图片url</param>
        /// <param name="brief">图片描述</param>
        /// <returns>XGVcaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcaResponse AddLogoLibBriefSource(string lib, string image, string brief=null)
        {
            if (string.IsNullOrEmpty(lib) || string.IsNullOrWhiteSpace(lib))
                throw new ArgumentNullException("lib 不能为空");
            if (string.IsNullOrEmpty(image) || string.IsNullOrWhiteSpace(image))
                throw new ArgumentNullException("image 不能为空");
            XGAddLogoLibBriefSourceRequest request = new XGAddLogoLibBriefSourceRequest()
            {
                Lib=lib,
                Image=image,
                Brief=brief
            };
            return AddLogoLibBriefSource(request);
        }

        /// <summary>
        /// 添加logo库集素材
        /// <para> 往指定的logo库集添加图片 </para>
        /// </summary>
        /// <param name="lib">logo库名</param>
        /// <param name="image">图片url</param>
        /// <param name="brief">图片描述</param>
        /// <returns>异步任务XGVcaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcaResponse> AddLogoLibBriefSourceAsync(string lib, string image, string brief = null)
        {
            if (string.IsNullOrEmpty(lib) || string.IsNullOrWhiteSpace(lib))
                throw new ArgumentNullException("lib 不能为空");
            if (string.IsNullOrEmpty(image) || string.IsNullOrWhiteSpace(image))
                throw new ArgumentNullException("image 不能为空");
            XGAddLogoLibBriefSourceRequest request = new XGAddLogoLibBriefSourceRequest()
            {
                Lib = lib,
                Image = image,
                Brief = brief
            };
            return await AddLogoLibBriefSourceAsync(request);
        }

        /// <summary>
        /// 添加logo库集素材
        /// <para> 往指定的logo库集添加图片 </para>
        /// <para> 接口文档： https://cloud.baidu.com/doc/VCA/s/zki9mepfq#logo%E5%BA%93%E9%9B%86%E7%B4%A0%E6%9D%90%E6%B7%BB%E5%8A%A0 </para>
        /// </summary>
        /// <param name="request">XGAddLogoLibBriefSourceRequest</param>
        /// <returns>XGVcaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcaResponse AddLogoLibBriefSource(XGAddLogoLibBriefSourceRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request 不能为空");
            if (string.IsNullOrEmpty(request.Lib) || string.IsNullOrWhiteSpace(request.Lib))
                throw new ArgumentNullException("Lib 不能为空");
            if (string.IsNullOrEmpty(request.Image) || string.IsNullOrWhiteSpace(request.Image))
                throw new ArgumentNullException("Image 不能为空");
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.POST, request.VcaVersion.ToString(), LOGO, "lib", request.Lib);
            XGVcaResponse response = InvokeHttpClient<XGVcaResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 添加logo库集素材
        /// <para> 往指定的logo库集添加图片 </para>
        /// </summary>
        /// <param name="request">XGAddLogoLibBriefSourceRequest</param>
        /// <returns>异步任务 XGVcaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcaResponse> AddLogoLibBriefSourceAsync(XGAddLogoLibBriefSourceRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request 不能为空");
            if (string.IsNullOrEmpty(request.Lib) || string.IsNullOrWhiteSpace(request.Lib))
                throw new ArgumentNullException("Lib 不能为空");
            if (string.IsNullOrEmpty(request.Image) || string.IsNullOrWhiteSpace(request.Image))
                throw new ArgumentNullException("Image 不能为空");
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.POST, request.VcaVersion.ToString(), LOGO, "lib", request.Lib);
            XGVcaResponse response = await InvokeHttpClientAsync<XGVcaResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 删除logo库集素材
        /// <para>删除指定的库集素材</para>
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCA/s/zki9mepfq#logo%E5%BA%93%E9%9B%86%E7%B4%A0%E6%9D%90%E5%88%A0%E9%99%A4 </para>
        /// </summary>
        /// <param name="lib">logo库名</param>
        /// <param name="image">图片url</param>
        /// <returns>XGVcaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcaResponse DeleteLogoLibBriefSource(string lib, string image)
        {
            if (string.IsNullOrEmpty(lib) || string.IsNullOrWhiteSpace(lib))
                throw new ArgumentNullException("lib 不能为空");
            if (string.IsNullOrEmpty(image) || string.IsNullOrWhiteSpace(image))
                throw new ArgumentNullException("image 不能为空");
            XGDeleteLogoLibBriefSourceRequest request = new XGDeleteLogoLibBriefSourceRequest()
            {
                Lib=lib,
                Image=image
            };
            return DeleteLogoLibBriefSource(request);
        }

        /// <summary>
        /// 删除logo库集素材
        /// <para>删除指定的库集素材</para>
        /// </summary>
        /// <param name="lib">logo库名</param>
        /// <param name="image">图片url</param>
        /// <returns>异步任务XGVcaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcaResponse> DeleteLogoLibBriefSourceAsync(string lib, string image)
        {
            if (string.IsNullOrEmpty(lib) || string.IsNullOrWhiteSpace(lib))
                throw new ArgumentNullException("lib 不能为空");
            if (string.IsNullOrEmpty(image) || string.IsNullOrWhiteSpace(image))
                throw new ArgumentNullException("image 不能为空");
            XGDeleteLogoLibBriefSourceRequest request = new XGDeleteLogoLibBriefSourceRequest()
            {
                Lib = lib,
                Image = image
            };
            return await DeleteLogoLibBriefSourceAsync(request);
        }

        /// <summary>
        /// 删除logo库集素材
        /// <para>删除指定的库集素材</para>
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCA/s/zki9mepfq#logo%E5%BA%93%E9%9B%86%E7%B4%A0%E6%9D%90%E5%88%A0%E9%99%A4 </para>
        /// </summary>
        /// <param name="request">XGDeleteLogoLibBriefSourceRequest</param>
        /// <returns>XGVcaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcaResponse DeleteLogoLibBriefSource(XGDeleteLogoLibBriefSourceRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request 不能为空");
            if (string.IsNullOrEmpty(request.Lib) || string.IsNullOrWhiteSpace(request.Lib))
                throw new ArgumentNullException("Lib 不能为空");
            if (string.IsNullOrEmpty(request.Image) || string.IsNullOrWhiteSpace(request.Image))
                throw new ArgumentNullException("Image 不能为空");
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.DELETE, request.VcaVersion.ToString(), LOGO, "lib", request.Lib);
            iternalRequest.AddParameter("image", request.Image);
            XGVcaResponse response = InvokeHttpClient<XGVcaResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 删除logo库集素材
        /// <para>删除指定的库集素材</para>
        /// </summary>
        /// <param name="request">XGDeleteLogoLibBriefSourceRequest</param>
        /// <returns>异步任务 XGVcaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcaResponse> DeleteLogoLibBriefSourceAsync(XGDeleteLogoLibBriefSourceRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request 不能为空");
            if (string.IsNullOrEmpty(request.Lib) || string.IsNullOrWhiteSpace(request.Lib))
                throw new ArgumentNullException("Lib 不能为空");
            if (string.IsNullOrEmpty(request.Image) || string.IsNullOrWhiteSpace(request.Image))
                throw new ArgumentNullException("Image 不能为空");
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.DELETE, request.VcaVersion.ToString(), LOGO, "lib", request.Lib);
            iternalRequest.AddParameter("image", request.Image);
            XGVcaResponse response = await InvokeHttpClientAsync<XGVcaResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// logo库集素材列表
        /// <para> 根据logo库集名称查询库集素材集合 </para>
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCA/s/zki9mepfq#logo%E5%BA%93%E9%9B%86%E7%B4%A0%E6%9D%90%E5%88%97%E8%A1%A8 </para>
        /// </summary>
        /// <param name="lib">logo库名</param>
        /// <param name="brief">图片描述</param>
        /// <returns>XGListLogoLibBriefSourceResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGListLogoLibBriefSourceResponse ListLogoLibBriefSources(string lib, string brief)
        {
            if (string.IsNullOrEmpty(lib) || string.IsNullOrWhiteSpace(lib))
                throw new ArgumentNullException("lib 不能为空");
            if (string.IsNullOrEmpty(brief) || string.IsNullOrWhiteSpace(brief))
                throw new ArgumentNullException("brief 不能为空");
            XGListLogoLibBriefSourceRequest request = new XGListLogoLibBriefSourceRequest()
            {
                Lib=lib,
                Brief=brief
            };
            return ListLogoLibBriefSources(request);
        }

        /// <summary>
        /// logo库集素材列表
        /// <para> 根据logo库集名称查询库集素材集合 </para>
        /// </summary>
        /// <param name="lib">logo库名</param>
        /// <param name="brief">图片描述</param>
        /// <returns>异步任务XGListLogoLibBriefSourceResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGListLogoLibBriefSourceResponse> ListLogoLibBriefSourcesAsync(string lib, string brief)
        {
            if (string.IsNullOrEmpty(lib) || string.IsNullOrWhiteSpace(lib))
                throw new ArgumentNullException("lib 不能为空");
            if (string.IsNullOrEmpty(brief) || string.IsNullOrWhiteSpace(brief))
                throw new ArgumentNullException("brief 不能为空");
            XGListLogoLibBriefSourceRequest request = new XGListLogoLibBriefSourceRequest()
            {
                Lib = lib,
                Brief = brief
            };
            return await ListLogoLibBriefSourcesAsync(request);
        }

        /// <summary>
        /// logo库集素材列表
        /// <para> 根据logo库集名称查询库集素材集合 </para>
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCA/s/zki9mepfq#logo%E5%BA%93%E9%9B%86%E7%B4%A0%E6%9D%90%E5%88%97%E8%A1%A8 </para>
        /// </summary>
        /// <param name="request">XGListLogoLibBriefSourceRequest</param>
        /// <returns>XGListLogoLibBriefSourceResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGListLogoLibBriefSourceResponse ListLogoLibBriefSources(XGListLogoLibBriefSourceRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request 不能为空");
            if (string.IsNullOrEmpty(request.Lib) || string.IsNullOrWhiteSpace(request.Lib))
                throw new ArgumentNullException("Lib 不能为空");
            if (string.IsNullOrEmpty(request.Brief) || string.IsNullOrWhiteSpace(request.Brief))
                throw new ArgumentNullException("Brief 不能为空");
            XGBceIternalRequest iternalRequest = CreateRequest(new XGVcaBaseRequest(), BceHttpMethod.GET, request.VcaVersion.ToString(), LOGO, "lib");
            iternalRequest.AddParameter("brief", request.Brief);
            XGListLogoLibBriefSourceResponse response = InvokeHttpClient<XGListLogoLibBriefSourceResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// logo库集素材列表
        /// </summary>
        /// <param name="request">XGListLogoLibBriefSourceRequest</param>
        /// <returns>异步任务 XGListLogoLibBriefSourceResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGListLogoLibBriefSourceResponse> ListLogoLibBriefSourcesAsync(XGListLogoLibBriefSourceRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request 不能为空");
            if (string.IsNullOrEmpty(request.Lib) || string.IsNullOrWhiteSpace(request.Lib))
                throw new ArgumentNullException("Lib 不能为空");
            if (string.IsNullOrEmpty(request.Brief) || string.IsNullOrWhiteSpace(request.Brief))
                throw new ArgumentNullException("Brief 不能为空");
            XGBceIternalRequest iternalRequest = CreateRequest(new XGVcaBaseRequest(), BceHttpMethod.GET, request.VcaVersion.ToString(), LOGO, "lib");
            iternalRequest.AddParameter("brief",request.Brief);
            XGListLogoLibBriefSourceResponse response = await InvokeHttpClientAsync<XGListLogoLibBriefSourceResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 删除logo库集
        /// <para>根据指定的logo库集名称删除库集</para>
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCA/s/zki9mepfq#logo%E5%BA%93%E9%9B%86%E5%88%A0%E9%99%A4 </para>
        /// </summary>
        /// <param name="lib">logo库名</param>
        /// <param name="brief">图片描述</param>
        /// <returns>XGVcaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcaResponse DeleteLogoLibBrief(string lib,string brief)
        {
            if (string.IsNullOrEmpty(lib) || string.IsNullOrWhiteSpace(lib))
                throw new ArgumentNullException("lib 不能为空");
            if (string.IsNullOrEmpty(brief) || string.IsNullOrWhiteSpace(brief))
                throw new ArgumentNullException("brief 不能为空");
            XGDeleteLogoLibBriefRequest request = new XGDeleteLogoLibBriefRequest()
            {
                Lib=lib,
                Brief=brief
            };
            return DeleteLogoLibBrief(request);
        }

        /// <summary>
        /// 删除logo库集
        /// <para>根据指定的logo库集名称删除库集</para>
        /// </summary>
        /// <param name="lib">logo库名</param>
        /// <param name="brief">图片描述</param>
        /// <returns>异步任务XGVcaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcaResponse> DeleteLogoLibBriefAsync(string lib, string brief)
        {
            if (string.IsNullOrEmpty(lib) || string.IsNullOrWhiteSpace(lib))
                throw new ArgumentNullException("lib 不能为空");
            if (string.IsNullOrEmpty(brief) || string.IsNullOrWhiteSpace(brief))
                throw new ArgumentNullException("brief 不能为空");
            XGDeleteLogoLibBriefRequest request = new XGDeleteLogoLibBriefRequest()
            {
                Lib = lib,
                Brief = brief
            };
            return await DeleteLogoLibBriefAsync(request);
        }

        /// <summary>
        /// 删除logo库集
        /// <para>根据指定的logo库集名称删除库集</para>
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCA/s/zki9mepfq#logo%E5%BA%93%E9%9B%86%E5%88%A0%E9%99%A4 </para>
        /// </summary>
        /// <param name="request">XGDeleteLogoLibBriefRequest</param>
        /// <returns>XGVcaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGVcaResponse DeleteLogoLibBrief(XGDeleteLogoLibBriefRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request 不能为空");
            if (string.IsNullOrEmpty(request.Lib) || string.IsNullOrWhiteSpace(request.Lib))
                throw new ArgumentNullException("Lib 不能为空");
            if (string.IsNullOrEmpty(request.Brief) || string.IsNullOrWhiteSpace(request.Brief))
                throw new ArgumentNullException("Brief 不能为空");
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.DELETE, request.VcaVersion.ToString(), LOGO, "lib", request.Lib);
            iternalRequest.AddParameter("brief", request.Brief);
            XGVcaResponse response = InvokeHttpClient<XGVcaResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 删除logo库集
        /// <para>根据指定的logo库集名称删除库集</para>
        /// </summary>
        /// <param name="request">XGDeleteLogoLibBriefRequest</param>
        /// <returns>异步任务 XGVcaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGVcaResponse> DeleteLogoLibBriefAsync(XGDeleteLogoLibBriefRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request 不能为空");
            if (string.IsNullOrEmpty(request.Lib) || string.IsNullOrWhiteSpace(request.Lib))
                throw new ArgumentNullException("Lib 不能为空");
            if (string.IsNullOrEmpty(request.Brief) || string.IsNullOrWhiteSpace(request.Brief))
                throw new ArgumentNullException("Brief 不能为空");
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.DELETE, request.VcaVersion.ToString(), LOGO, "lib", request.Lib);
            iternalRequest.AddParameter("brief", request.Brief);
            XGVcaResponse response = await InvokeHttpClientAsync<XGVcaResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// logo库集列表
        /// <para> 查询logo库集名称集合 </para>
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCA/s/zki9mepfq#logo%E5%BA%93%E9%9B%86%E5%88%97%E8%A1%A8 </para>
        /// </summary>
        /// <param name="lib">logo库名</param>
        /// <returns>XGListLogoLibBriefSourceResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGListLogoLibBriefSourceResponse ListLogoLibBrief(string lib)
        {
            if (string.IsNullOrEmpty(lib) || string.IsNullOrWhiteSpace(lib))
                throw new ArgumentNullException("lib 不能为空");
            XGListLogoLibBriefRequest request = new XGListLogoLibBriefRequest()
            {
                Lib=lib
            };
            return ListLogoLibBrief(request);
        }

        /// <summary>
        /// logo库集列表
        /// <para> 查询logo库集名称集合 </para>
        /// </summary>
        /// <param name="lib">logo库名</param>
        /// <returns>异步任务XGListLogoLibBriefSourceResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGListLogoLibBriefSourceResponse> ListLogoLibBriefAsync(string lib)
        {
            if (string.IsNullOrEmpty(lib) || string.IsNullOrWhiteSpace(lib))
                throw new ArgumentNullException("lib 不能为空");
            XGListLogoLibBriefRequest request = new XGListLogoLibBriefRequest()
            {
                Lib = lib
            };
            return await ListLogoLibBriefAsync(request);
        }

        /// <summary>
        /// logo库集列表
        /// <para> 查询logo库集名称集合 </para>
        /// <para> 接口文档：https://cloud.baidu.com/doc/VCA/s/zki9mepfq#logo%E5%BA%93%E9%9B%86%E5%88%97%E8%A1%A8 </para>
        /// </summary>
        /// <param name="request">XGListLogoLibBriefRequest</param>
        /// <returns>XGListLogoLibBriefSourceResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGListLogoLibBriefSourceResponse ListLogoLibBrief(XGListLogoLibBriefRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request 不能为空");
            if (string.IsNullOrEmpty(request.Lib) || string.IsNullOrWhiteSpace(request.Lib))
                throw new ArgumentNullException("Lib 不能为空");
            XGBceIternalRequest iternalRequest = CreateRequest(new XGVcaBaseRequest(), BceHttpMethod.GET, request.VcaVersion.ToString(), LOGO, "lib");
            XGListLogoLibBriefSourceResponse response = InvokeHttpClient<XGListLogoLibBriefSourceResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// logo库集列表
        /// </summary>
        /// <param name="request">XGListLogoLibBriefRequest</param>
        /// <returns>异步任务 XGListLogoLibBriefSourceResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGListLogoLibBriefSourceResponse> ListLogoLibBriefAsync(XGListLogoLibBriefRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request 不能为空");
            if (string.IsNullOrEmpty(request.Lib) || string.IsNullOrWhiteSpace(request.Lib))
                throw new ArgumentNullException("Lib 不能为空");
            XGBceIternalRequest iternalRequest = CreateRequest(new XGVcaBaseRequest(), BceHttpMethod.GET, request.VcaVersion.ToString(), LOGO, "lib");
            XGListLogoLibBriefSourceResponse response = await InvokeHttpClientAsync<XGListLogoLibBriefSourceResponse>(iternalRequest);
            return response;
        }

        #endregion

        protected XGBceIternalRequest CreateRequest( XGAbstractBceRequest bceRequest, BceHttpMethod httpMethod, params string[] pathVariables)
        {
            List<string> pathComponents = new List<string>() { };
            if (pathVariables != null)
                pathComponents.AddRange(pathVariables);

            XGBceIternalRequest iternalRequest = new XGBceIternalRequest(httpMethod, HttpUtil.AppendUri(Endpoint, pathComponents.ToArray()))
            {
                Credentials = bceRequest.Credentials
            };
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

    }
}
