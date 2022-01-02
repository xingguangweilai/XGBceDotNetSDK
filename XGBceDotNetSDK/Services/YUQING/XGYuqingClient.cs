using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using XGBceDotNetSDK.BaseClass;
using XGBceDotNetSDK.Http;
using XGBceDotNetSDK.Http.Handler;
using XGBceDotNetSDK.Services.YUQING.Model;
using XGBceDotNetSDK.Sign;
using XGBceDotNetSDK.Utils;

namespace XGBceDotNetSDK.Services.YUQING
{
    /// <summary>
    /// 百度舆情服务客户端
    /// <para>EndPoint固定为：yuqing.bce.baidu.com </para>
    /// <para>使用本产品前，您必须先注册百度智能云账号（若没有百度智能云账号），并完成企业认证。</para>
    /// <para>接口文档：https://cloud.baidu.com/doc/TRENDS/s/wjwvygqak </para>
    /// </summary>
    public class XGYuqingClient: XGAbstractBceClient
    {
        private static string ENDPOINT_HOST = "https://yuqing.bce.baidu.com";

        private static readonly string TASKS = "tasks";
        private static readonly string SYSTEM = "system";
        private static readonly string SELECTED = "selected";

        private static readonly IXGHttpResponseHandler[] YUQING_HANDLERS = { new XGBceMetadataResponseHandler(), new XGBceErrorResponseHandler(), new XGBceYuqingResponseHandler() };

        public XGYuqingClient() : this(new XGBceClientConfiguration()) { }

        public XGYuqingClient(XGBceClientConfiguration configuration) : base(HandleEndPoint(configuration)) { }

        private static XGBceClientConfiguration HandleEndPoint(XGBceClientConfiguration configuration)
        {
            if (configuration == null)
                configuration = new XGBceClientConfiguration();
            if (configuration.Endpoint == null)
                configuration.Endpoint = ENDPOINT_HOST;
            return configuration;
        }

        #region 实时舆情

        /// <summary>
        /// 添加自定义监测任务
        /// <para>创建自定义监测任务</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/TRENDS/s/Vjwvygqpq#%E6%B7%BB%E5%8A%A0%E8%87%AA%E5%AE%9A%E4%B9%89%E7%9B%91%E6%B5%8B%E4%BB%BB%E5%8A%A1 </para>
        /// </summary>
        /// <param name="request">XGYuqingAddTaskRequest</param>
        /// <returns>XGYuqingAddTaskResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGYuqingAddTaskResponse AddTask(XGYuqingAddTaskRequest request)
        {
            AssertNotNullOrEmpty(request,nameof(request));
            AssertStringListNotNullOrEmpty(request.FilterKeywords,nameof(request.FilterKeywords));
            AssertIntListNotNullOrEmpty(request.GeoIds, nameof(request.GeoIds));
            AssertStringNotNullOrEmpty(request.Name, nameof(request.Name));
            AssertStringListNotNullOrEmpty(request.OptionalKeywords, nameof(request.OptionalKeywords));
            AssertStringListNotNullOrEmpty(request.RequiredKeywords, nameof(request.RequiredKeywords));
            if(request.TaskType==null)
                throw new ArgumentNullException(nameof(request.TaskType), "request.TaskType 不能为空");

            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.POST, request.YuqingVersion.ToString(), TASKS);
            XGYuqingAddTaskResponse response = InvokeHttpClient<XGYuqingAddTaskResponse>(iternalRequest, YUQING_HANDLERS);

            return response;
        }

        /// <summary>
        /// 添加自定义监测任务
        /// <para>创建自定义监测任务</para>
        /// </summary>
        /// <param name="request">XGYuqingAddTaskRequest</param>
        /// <returns>异步任务XGYuqingAddTaskResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGYuqingAddTaskResponse> AddTaskAsync(XGYuqingAddTaskRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringListNotNullOrEmpty(request.FilterKeywords, nameof(request.FilterKeywords));
            AssertIntListNotNullOrEmpty(request.GeoIds, nameof(request.GeoIds));
            AssertStringNotNullOrEmpty(request.Name, nameof(request.Name));
            AssertStringListNotNullOrEmpty(request.OptionalKeywords, nameof(request.OptionalKeywords));
            AssertStringListNotNullOrEmpty(request.RequiredKeywords, nameof(request.RequiredKeywords));
            if (request.TaskType == null)
                throw new ArgumentNullException(nameof(request.TaskType), "request.TaskType 不能为空");

            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.POST, request.YuqingVersion.ToString(), TASKS);
            XGYuqingAddTaskResponse response = await InvokeHttpClientAsync<XGYuqingAddTaskResponse>(iternalRequest, YUQING_HANDLERS);

            return response;
        }

        /// <summary>
        /// 修改自定义监测任务
        /// <para>接口文档：https://cloud.baidu.com/doc/TRENDS/s/Vjwvygqpq#%E4%BF%AE%E6%94%B9%E8%87%AA%E5%AE%9A%E4%B9%89%E7%9B%91%E6%B5%8B%E4%BB%BB%E5%8A%A1 </para>
        /// </summary>
        /// <param name="request">XGYuqingModifyTaskRequest</param>
        /// <returns>XGYuqingModifyTaskResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGYuqingModifyTaskResponse ModifyTask(XGYuqingModifyTaskRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.TaskId, nameof(request.TaskId));
            AssertStringListNotNullOrEmpty(request.FilterKeywords, nameof(request.FilterKeywords));
            AssertIntListNotNullOrEmpty(request.GeoIds, nameof(request.GeoIds));
            AssertStringNotNullOrEmpty(request.Name, nameof(request.Name));
            AssertStringListNotNullOrEmpty(request.OptionalKeywords, nameof(request.OptionalKeywords));
            AssertStringListNotNullOrEmpty(request.RequiredKeywords, nameof(request.RequiredKeywords));
            if (request.TaskType == null)
                throw new ArgumentNullException(nameof(request.TaskType),"TaskType 不能为空");

            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.PUT, request.YuqingVersion.ToString(), TASKS,request.TaskId);
            XGYuqingModifyTaskResponse response = InvokeHttpClient<XGYuqingModifyTaskResponse>(iternalRequest, YUQING_HANDLERS);

            return response;
        }

        /// <summary>
        /// 修改自定义监测任务
        /// </summary>
        /// <param name="request">XGYuqingModifyTaskRequest</param>
        /// <returns>异步任务XGYuqingModifyTaskResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGYuqingModifyTaskResponse> ModifyTaskAsync(XGYuqingModifyTaskRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.TaskId, nameof(request.TaskId));
            AssertStringListNotNullOrEmpty(request.FilterKeywords, nameof(request.FilterKeywords));
            AssertIntListNotNullOrEmpty(request.GeoIds, nameof(request.GeoIds));
            AssertStringNotNullOrEmpty(request.Name, nameof(request.Name));
            AssertStringListNotNullOrEmpty(request.OptionalKeywords, nameof(request.OptionalKeywords));
            AssertStringListNotNullOrEmpty(request.RequiredKeywords, nameof(request.RequiredKeywords));
            if (request.TaskType == null)
                throw new ArgumentNullException(nameof(request.TaskType), "TaskType 不能为空");

            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.PUT, request.YuqingVersion.ToString(), TASKS, request.TaskId);
            XGYuqingModifyTaskResponse response = await InvokeHttpClientAsync<XGYuqingModifyTaskResponse>(iternalRequest, YUQING_HANDLERS);

            return response;
        }

        /// <summary>
        /// 删除自定义监测任务
        /// <para>接口文档：https://cloud.baidu.com/doc/TRENDS/s/Vjwvygqpq#%E6%8E%A5%E5%8F%A3%E5%90%8D%E7%A7%B0%EF%BC%9A%E5%88%A0%E9%99%A4%E8%87%AA%E5%AE%9A%E4%B9%89%E7%9B%91%E6%B5%8B%E4%BB%BB%E5%8A%A1 </para>
        /// </summary>
        /// <param name="taskId">任务ID</param>
        /// <returns>XGYuqingDeleteTaskResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGYuqingDeleteTaskResponse DeleteTask(string taskId)
        {
            AssertStringNotNullOrEmpty(taskId, nameof(taskId));
            XGYuqingDeleteTaskRequest request = new XGYuqingDeleteTaskRequest()
            {
                TaskId = taskId
            };

            return DeleteTask(request);
        }

        /// <summary>
        /// 删除自定义监测任务
        /// </summary>
        /// <param name="taskId">任务ID</param>
        /// <returns>异步任务XGYuqingDeleteTaskResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGYuqingDeleteTaskResponse> DeleteTaskAsync(string taskId)
        {
            AssertStringNotNullOrEmpty(taskId, nameof(taskId));
            XGYuqingDeleteTaskRequest request = new XGYuqingDeleteTaskRequest()
            {
                TaskId = taskId
            };

            return await DeleteTaskAsync(request);
        }

        /// <summary>
        /// 删除自定义监测任务
        /// <para>接口文档：https://cloud.baidu.com/doc/TRENDS/s/Vjwvygqpq#%E6%8E%A5%E5%8F%A3%E5%90%8D%E7%A7%B0%EF%BC%9A%E5%88%A0%E9%99%A4%E8%87%AA%E5%AE%9A%E4%B9%89%E7%9B%91%E6%B5%8B%E4%BB%BB%E5%8A%A1 </para>
        /// </summary>
        /// <param name="request">XGYuqingDeleteTaskRequest</param>
        /// <returns>XGYuqingDeleteTaskResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGYuqingDeleteTaskResponse DeleteTask(XGYuqingDeleteTaskRequest request)
        {
            AssertNotNullOrEmpty(request,nameof(request));
            AssertStringNotNullOrEmpty(request.TaskId, nameof(request.TaskId));

            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.DELETE, request.YuqingVersion.ToString(), TASKS, request.TaskId.Trim());
            XGYuqingDeleteTaskResponse response = InvokeHttpClient<XGYuqingDeleteTaskResponse>(iternalRequest, YUQING_HANDLERS);

            return response;
        }

        /// <summary>
        /// 删除自定义监测任务
        /// </summary>
        /// <param name="request">XGYuqingDeleteTaskRequest</param>
        /// <returns>异步任务XGYuqingDeleteTaskResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGYuqingDeleteTaskResponse> DeleteTaskAsync(XGYuqingDeleteTaskRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.TaskId, nameof(request.TaskId));

            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.DELETE, request.YuqingVersion.ToString(), TASKS, request.TaskId.Trim());
            XGYuqingDeleteTaskResponse response = await InvokeHttpClientAsync<XGYuqingDeleteTaskResponse>(iternalRequest, YUQING_HANDLERS);

            return response;
        }

        /// <summary>
        /// 获取监测任务列表
        /// <para>获取全部任务信息</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/TRENDS/s/Vjwvygqpq#%E6%8E%A5%E5%8F%A3%E5%90%8D%E7%A7%B0%EF%BC%9A%E8%8E%B7%E5%8F%96%E7%9B%91%E6%B5%8B%E4%BB%BB%E5%8A%A1%E5%88%97%E8%A1%A8 </para>
        /// </summary>
        /// <returns>XGYuqingListTasksResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGYuqingListTasksResponse ListTasks()
        {
            XGYuqingBaseRequest request = new XGYuqingBaseRequest();

            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.YuqingVersion.ToString(), TASKS);
            XGYuqingListTasksResponse response = InvokeHttpClient<XGYuqingListTasksResponse>(iternalRequest);

            return response;
        }

        /// <summary>
        /// 获取监测任务列表
        /// <para>获取全部任务信息</para>
        /// </summary>
        /// <returns>异步任务XGYuqingListTasksResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGYuqingListTasksResponse> ListTasksAsync()
        {
            XGYuqingBaseRequest request = new XGYuqingBaseRequest();

            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.YuqingVersion.ToString(), TASKS);
            XGYuqingListTasksResponse response = await InvokeHttpClientAsync<XGYuqingListTasksResponse>(iternalRequest);

            return response;
        }

        /// <summary>
        /// 获取系统监测任务列表
        /// <para>获取所有系统任务列表</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/TRENDS/s/Vjwvygqpq#%E8%8E%B7%E5%8F%96%E7%B3%BB%E7%BB%9F%E7%9B%91%E6%B5%8B%E4%BB%BB%E5%8A%A1%E5%88%97%E8%A1%A8 </para>
        /// </summary>
        /// <returns>XGYuqingListSystemTasksResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGYuqingListSystemTasksResponse ListSystemTasks()
        {
            XGYuqingBaseRequest request = new XGYuqingBaseRequest();

            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.YuqingVersion.ToString(), TASKS,SYSTEM);
            XGYuqingListSystemTasksResponse response = InvokeHttpClient<XGYuqingListSystemTasksResponse>(iternalRequest);

            return response;
        }

        /// <summary>
        /// 获取系统监测任务列表
        /// <para>获取所有系统任务列表</para>
        /// </summary>
        /// <returns>异步任务XGYuqingListSystemTasksResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGYuqingListSystemTasksResponse> ListSystemTasksAsync()
        {
            XGYuqingBaseRequest request = new XGYuqingBaseRequest();

            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.YuqingVersion.ToString(), TASKS,SYSTEM);
            XGYuqingListSystemTasksResponse response = await InvokeHttpClientAsync<XGYuqingListSystemTasksResponse>(iternalRequest);

            return response;
        }

        /// <summary>
        /// 更新系统监测任务列表
        /// <para>接口文档：https://cloud.baidu.com/doc/TRENDS/s/Vjwvygqpq#%E6%9B%B4%E6%96%B0%E7%B3%BB%E7%BB%9F%E7%9B%91%E6%B5%8B%E4%BB%BB%E5%8A%A1%E5%88%97%E8%A1%A8 </para>
        /// </summary>
        /// <param name="ids">系统任务id列表</param>
        /// <returns>XGYuqingUpdateSystemTasksResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGYuqingUpdateSystemTasksResponse UpdateSystemTasks(params int[] ids)
        {
            if (ids == null||ids.Length<1)
            {
                throw new ArgumentNullException(nameof(ids),"ids 不能为空");
            }

            XGYuqingUpdateSystemTasksRequest request = new XGYuqingUpdateSystemTasksRequest()
            {
                Ids = new List<int>(ids)
            };

            return UpdateSystemTasks(request);
        }

        /// <summary>
        /// 更新系统监测任务列表
        /// </summary>
        /// <param name="ids">系统任务id列表</param>
        /// <returns>异步任务XGYuqingUpdateSystemTasksResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGYuqingUpdateSystemTasksResponse> UpdateSystemTasksAsync(params int[] ids)
        {
            if (ids == null || ids.Length < 1)
            {
                throw new ArgumentNullException(nameof(ids),"ids 不能为空");
            }

            XGYuqingUpdateSystemTasksRequest request = new XGYuqingUpdateSystemTasksRequest()
            {
                Ids = new List<int>(ids)
            };

            return await UpdateSystemTasksAsync(request);
        }

        /// <summary>
        /// 更新系统监测任务列表
        /// <para>接口文档：https://cloud.baidu.com/doc/TRENDS/s/Vjwvygqpq#%E6%9B%B4%E6%96%B0%E7%B3%BB%E7%BB%9F%E7%9B%91%E6%B5%8B%E4%BB%BB%E5%8A%A1%E5%88%97%E8%A1%A8 </para>
        /// </summary>
        /// <param name="request">XGYuqingUpdateSystemTasksRequest</param>
        /// <returns>XGYuqingUpdateSystemTasksResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGYuqingUpdateSystemTasksResponse UpdateSystemTasks(XGYuqingUpdateSystemTasksRequest request)
        {
            AssertNotNullOrEmpty(request,nameof(request));
            AssertIntListNotNullOrEmpty(request.Ids, "request.Ids 不能为空");

            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.PUT, request.YuqingVersion.ToString(), TASKS, SYSTEM);
            XGYuqingUpdateSystemTasksResponse response = InvokeHttpClient<XGYuqingUpdateSystemTasksResponse>(iternalRequest, YUQING_HANDLERS);

            return response;
        }

        /// <summary>
        /// 更新系统监测任务列表
        /// </summary>
        /// <param name="request">XGYuqingUpdateSystemTasksRequest</param>
        /// <returns>异步任务XGYuqingUpdateSystemTasksResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGYuqingUpdateSystemTasksResponse> UpdateSystemTasksAsync(XGYuqingUpdateSystemTasksRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertIntListNotNullOrEmpty(request.Ids, "request.Ids 不能为空");

            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.PUT, request.YuqingVersion.ToString(), TASKS, SYSTEM);
            XGYuqingUpdateSystemTasksResponse response = await InvokeHttpClientAsync<XGYuqingUpdateSystemTasksResponse>(iternalRequest, YUQING_HANDLERS);

            return response;
        }

        /// <summary>
        /// 获取用户选中的系统监测任务列表
        /// <para>接口文档：https://cloud.baidu.com/doc/TRENDS/s/Vjwvygqpq#%E8%8E%B7%E5%8F%96%E7%94%A8%E6%88%B7%E9%80%89%E4%B8%AD%E7%9A%84%E7%B3%BB%E7%BB%9F%E7%9B%91%E6%B5%8B%E4%BB%BB%E5%8A%A1%E5%88%97%E8%A1%A8 </para>
        /// </summary>
        /// <returns>XGYuqingListSelectedSystemTasksResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGYuqingListSelectedSystemTasksResponse ListSelectedSystemTasks()
        {
            XGYuqingBaseRequest request = new XGYuqingBaseRequest();

            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.YuqingVersion.ToString(), TASKS, SYSTEM,SELECTED);
            XGYuqingListSelectedSystemTasksResponse response = InvokeHttpClient<XGYuqingListSelectedSystemTasksResponse>(iternalRequest);

            return response;
        }

        /// <summary>
        /// 获取用户选中的系统监测任务列表
        /// </summary>
        /// <returns>异步任务XGYuqingListSelectedSystemTasksResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGYuqingListSelectedSystemTasksResponse> ListSelectedSystemTasksAsync()
        {
            XGYuqingBaseRequest request = new XGYuqingBaseRequest();

            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.YuqingVersion.ToString(), TASKS, SYSTEM,SELECTED);
            XGYuqingListSelectedSystemTasksResponse response = await InvokeHttpClientAsync<XGYuqingListSelectedSystemTasksResponse>(iternalRequest);

            return response;
        }

        /// <summary>
        /// 获取监测任务详情
        /// <para>接口文档：https://cloud.baidu.com/doc/TRENDS/s/Vjwvygqpq#%E8%8E%B7%E5%8F%96%E7%9B%91%E6%B5%8B%E4%BB%BB%E5%8A%A1%E8%AF%A6%E6%83%85 </para>
        /// </summary>
        /// <param name="taskId">任务ID</param>
        /// <returns>XGYuqingQueryTaskDetailResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGYuqingQueryTaskDetailResponse QueryTaskDetail(string taskId)
        {
            AssertStringNotNullOrEmpty(taskId, nameof(taskId));

            XGYuqingQueryTaskDetailRequest request = new XGYuqingQueryTaskDetailRequest()
            {
                TaskId=taskId
            };
            return QueryTaskDetail(request);
        }

        /// <summary>
        /// 获取监测任务详情
        /// </summary>
        /// <param name="taskId">任务ID</param>
        /// <returns>异步任务XGYuqingQueryTaskDetailResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGYuqingQueryTaskDetailResponse> QueryTaskDetailAsync(string taskId)
        {
            AssertStringNotNullOrEmpty(taskId, nameof(taskId));

            XGYuqingQueryTaskDetailRequest request = new XGYuqingQueryTaskDetailRequest()
            {
                TaskId = taskId
            };
            return await QueryTaskDetailAsync(request);
        }

        /// <summary>
        /// 获取监测任务详情
        /// <para>接口文档：https://cloud.baidu.com/doc/TRENDS/s/Vjwvygqpq#%E8%8E%B7%E5%8F%96%E7%9B%91%E6%B5%8B%E4%BB%BB%E5%8A%A1%E8%AF%A6%E6%83%85 </para>
        /// </summary>
        /// <param name="request">XGYuqingQueryTaskDetailRequest</param>
        /// <returns>XGYuqingQueryTaskDetailResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGYuqingQueryTaskDetailResponse QueryTaskDetail(XGYuqingQueryTaskDetailRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.TaskId, "request.TaskId 不能为空");

            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.YuqingVersion.ToString(), TASKS, request.TaskId.Trim());
            XGYuqingQueryTaskDetailResponse response = InvokeHttpClient<XGYuqingQueryTaskDetailResponse>(iternalRequest);

            return response;
        }

        /// <summary>
        /// 获取监测任务详情
        /// </summary>
        /// <param name="request">XGYuqingQueryTaskDetailRequest</param>
        /// <returns>异步任务XGYuqingQueryTaskDetailResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGYuqingQueryTaskDetailResponse> QueryTaskDetailAsync(XGYuqingQueryTaskDetailRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.TaskId, "request.TaskId 不能为空");

            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.YuqingVersion.ToString(), TASKS, request.TaskId.Trim());
            XGYuqingQueryTaskDetailResponse response = await InvokeHttpClientAsync<XGYuqingQueryTaskDetailResponse>(iternalRequest);

            return response;
        }

        #endregion

        #region 舆情分析


        #endregion

        #region 预警推送


        #endregion

        #region 地域风向标


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
            BceSignOption options = BceSignOption.defaultBceSignOption;
            List<string> headersToSign = new List<string>()
            {
                XGBceHeaders.HOST
            };
            options.HeadersToSign = headersToSign;

            if (httpMethod == BceHttpMethod.POST || httpMethod == BceHttpMethod.PUT)
                FillRequestPayload(iternalRequest, bceRequest);

            new XGBceSignerV1().Sign(iternalRequest, iternalRequest.Credentials, options);

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
            iternalRequest.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(mediaType: "application/json");
            iternalRequest.AddMoreHeader(XGBceHeaders.BCE_DATE, HttpUtil.FormatUTCTime(DateTime.Now));
            iternalRequest.AddMoreHeader(XGBceHeaders.ACCEPT, "*/*");
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
