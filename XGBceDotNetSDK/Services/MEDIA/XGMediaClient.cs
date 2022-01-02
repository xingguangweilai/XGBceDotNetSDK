using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using XGBceDotNetSDK.BaseClass;
using XGBceDotNetSDK.Http;
using XGBceDotNetSDK.Services.MEDIA.Model;
using XGBceDotNetSDK.Utils;

namespace XGBceDotNetSDK.Services.MEDIA
{
    /// <summary>
    /// 音视频处理MCP
    /// <para>为了保证 MCP API能够被授权访问 BOS，CDN 等服务，用户需要在管理控制台至少创建一次任务队列。</para>
    /// <para>接口文档：https://cloud.baidu.com/doc/MCT/s/Sjwvz5hq5 </para>
    /// </summary>
    public class XGMediaClient: XGAbstractBceClient
    {
        private static readonly string MEDIA = "media";
        private static readonly string PIPELINE = "pipeline";
        private static readonly string JOB = "job";
        private static readonly string TRANSCODING = "transcoding";
        private static readonly string PRESET = "preset";
        private static readonly string MEDIAINFO="mediainfo";
        private static readonly string WATERMARK="watermark";
        private static readonly string NOTIFICATION = "notification";
        private static readonly string THUMBNAIL = "thumbnail";

        public XGMediaClient() : this(new XGBceClientConfiguration()) { }

        public XGMediaClient(XGBceClientConfiguration configuration) : base(configuration) { }

        #region 队列接口

        /// <summary>
        /// 创建队列
        /// <para>用户向服务请求创建任务队列。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/MCT/s/djwvz5f9i#%E5%88%9B%E5%BB%BA%E9%98%9F%E5%88%97 </para>
        /// </summary>
        /// <param name="pipelineName">队列名称</param>
        /// <param name="sourceBucket">输入Bucket</param>
        /// <param name="targetBucket">输出Bucket</param>
        /// <param name="description">队列描述</param>
        /// <returns>XGMediaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGMediaResponse CreatePipeline(string pipelineName, string sourceBucket, string targetBucket, string description=null)
        {
            AssertStringNotNullOrEmpty(pipelineName,nameof(pipelineName));
            AssertStringNotNullOrEmpty(sourceBucket,nameof(sourceBucket));
            AssertStringNotNullOrEmpty(targetBucket,nameof(targetBucket));
            XGMediaCreatePipelineRequest request = new XGMediaCreatePipelineRequest()
            {
                PipelineName=pipelineName,
                Description=description,
                SourceBucket=sourceBucket,
                TargetBucket=targetBucket
            };
            return CreatePipeline(request);
        }

        /// <summary>
        /// 创建队列
        /// <para>用户向服务请求创建任务队列。</para>
        /// </summary>
        /// <param name="pipelineName">队列名称</param>
        /// <param name="sourceBucket">输入Bucket</param>
        /// <param name="targetBucket">输出Bucket</param>
        /// <param name="description">队列描述</param>
        /// <returns>异步任务XGMediaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGMediaResponse> CreatePipelineAsync(string pipelineName, string sourceBucket, string targetBucket, string description = null)
        {
            AssertStringNotNullOrEmpty(pipelineName, nameof(pipelineName));
            AssertStringNotNullOrEmpty(sourceBucket, nameof(sourceBucket));
            AssertStringNotNullOrEmpty(targetBucket, nameof(targetBucket));
            XGMediaCreatePipelineRequest request = new XGMediaCreatePipelineRequest()
            {
                PipelineName = pipelineName,
                Description = description,
                SourceBucket = sourceBucket,
                TargetBucket = targetBucket
            };
            return await CreatePipelineAsync(request);
        }

        /// <summary>
        /// 创建队列
        /// <para>用户向服务请求创建任务队列。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/MCT/s/djwvz5f9i#%E5%88%9B%E5%BB%BA%E9%98%9F%E5%88%97 </para>
        /// </summary>
        /// <param name="request">XGMediaCreatePipelineRequest</param>
        /// <returns>XGMediaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGMediaResponse CreatePipeline(XGMediaCreatePipelineRequest request)
        {
            AssertNotNullOrEmpty(request,nameof(request));
            AssertStringNotNullOrEmpty(request.PipelineName, nameof(request.PipelineName));
            AssertStringNotNullOrEmpty(request.SourceBucket, nameof(request.SourceBucket));
            AssertStringNotNullOrEmpty(request.TargetBucket, nameof(request.TargetBucket));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.POST, request.MediaVersion.ToString() , PIPELINE);
            XGMediaResponse response = InvokeHttpClient<XGMediaResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 创建队列
        /// <para>用户向服务请求创建任务队列。</para>
        /// </summary>
        /// <param name="request">XGMediaCreatePipelineRequest</param>
        /// <returns>异步任务XGMediaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGMediaResponse> CreatePipelineAsync(XGMediaCreatePipelineRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.PipelineName, nameof(request.PipelineName));
            AssertStringNotNullOrEmpty(request.SourceBucket, nameof(request.SourceBucket));
            AssertStringNotNullOrEmpty(request.TargetBucket, nameof(request.TargetBucket));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.POST, request.MediaVersion.ToString(), PIPELINE);
            XGMediaResponse response = await InvokeHttpClientAsync<XGMediaResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询指定队列
        /// <para>用户通过指定name来查询该指定队列的信息。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/MCT/s/djwvz5f9i#%E6%9F%A5%E8%AF%A2%E6%8C%87%E5%AE%9A%E9%98%9F%E5%88%97 </para>
        /// </summary>
        /// <param name="pipelineName">指定队列名称</param>
        /// <returns>XGMediaQueryPipelineResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGMediaQueryPipelineResponse QueryPipeline(string pipelineName)
        {
            AssertStringNotNullOrEmpty(pipelineName, nameof(pipelineName));
            XGMediaQueryPipelineRequest request = new XGMediaQueryPipelineRequest()
            {
                PipelineName=pipelineName
            };
            return QueryPipeline(request);
        }

        /// <summary>
        /// 查询指定队列
        /// <para>用户通过指定name来查询该指定队列的信息。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/MCT/s/djwvz5f9i#%E6%9F%A5%E8%AF%A2%E6%8C%87%E5%AE%9A%E9%98%9F%E5%88%97 </para>
        /// </summary>
        /// <param name="pipelineName">指定队列名称</param>
        /// <returns>异步任务XGMediaQueryPipelineResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGMediaQueryPipelineResponse> QueryPipelineAsync(string pipelineName)
        {
            AssertStringNotNullOrEmpty(pipelineName, nameof(pipelineName));
            XGMediaQueryPipelineRequest request = new XGMediaQueryPipelineRequest()
            {
                PipelineName = pipelineName
            };
            return await QueryPipelineAsync(request);
        }

        /// <summary>
        /// 查询指定队列
        /// <para>用户通过指定name来查询该指定队列的信息。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/MCT/s/djwvz5f9i#%E6%9F%A5%E8%AF%A2%E6%8C%87%E5%AE%9A%E9%98%9F%E5%88%97 </para>
        /// </summary>
        /// <param name="request">XGMediaQueryPipelineRequest</param>
        /// <returns>XGMediaQueryPipelineResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGMediaQueryPipelineResponse QueryPipeline(XGMediaQueryPipelineRequest request)
        {
            AssertNotNullOrEmpty(request,nameof(request));
            AssertStringNotNullOrEmpty(request.PipelineName, nameof(request.PipelineName));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.MediaVersion.ToString(), PIPELINE,request.PipelineName.Trim());
            XGMediaQueryPipelineResponse response = InvokeHttpClient<XGMediaQueryPipelineResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询指定队列
        /// <para>用户通过指定name来查询该指定队列的信息。</para>
        /// </summary>
        /// <param name="request">XGMediaQueryPipelineRequest</param>
        /// <returns>异步任务XGMediaQueryPipelineResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGMediaQueryPipelineResponse> QueryPipelineAsync(XGMediaQueryPipelineRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.PipelineName, nameof(request.PipelineName));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.MediaVersion.ToString(), PIPELINE, request.PipelineName.Trim());
            XGMediaQueryPipelineResponse response = await InvokeHttpClientAsync<XGMediaQueryPipelineResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 列举用户所有队列
        /// <para>帮助用户查询所拥有的所有队列的详细信息。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/MCT/s/djwvz5f9i#%E6%9F%A5%E8%AF%A2%E7%94%A8%E6%88%B7%E6%89%80%E6%9C%89%E9%98%9F%E5%88%97 </para>
        /// </summary>
        /// <returns>XGMediaListPipelinesResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGMediaListPipelinesResponse ListPipelines()
        {
            XGMediaBaseRequest request = new XGMediaBaseRequest();
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.MediaVersion.ToString(), PIPELINE);
            XGMediaListPipelinesResponse response = InvokeHttpClient<XGMediaListPipelinesResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 列举用户所有队列
        /// <para>帮助用户查询所拥有的所有队列的详细信息。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/MCT/s/djwvz5f9i#%E6%9F%A5%E8%AF%A2%E7%94%A8%E6%88%B7%E6%89%80%E6%9C%89%E9%98%9F%E5%88%97 </para>
        /// </summary>
        /// <returns>异步任务XGMediaListPipelinesResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGMediaListPipelinesResponse> ListPipelinesAsync()
        {
            XGMediaBaseRequest request = new XGMediaBaseRequest();
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.MediaVersion.ToString(), PIPELINE);
            XGMediaListPipelinesResponse response = await InvokeHttpClientAsync<XGMediaListPipelinesResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 删除指定队列
        /// <para>用户向服务请求删除指定pipelineName的任务队列。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/MCT/s/djwvz5f9i#%E5%88%A0%E9%99%A4%E6%8C%87%E5%AE%9A%E9%98%9F%E5%88%97 </para>
        /// </summary>
        /// <param name="pipelineName">队列名称</param>
        /// <returns>XGMediaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGMediaResponse DeletePipeline(string pipelineName)
        {
            AssertStringNotNullOrEmpty(pipelineName,nameof(pipelineName));
            XGMediaDeletePipelineRequest request = new XGMediaDeletePipelineRequest()
            {
                PipelineName=pipelineName
            };
            return DeletePipeline(request);
        }

        /// <summary>
        /// 删除指定队列
        /// <para>用户向服务请求删除指定pipelineName的任务队列。</para>
        /// </summary>
        /// <param name="pipelineName">队列名称</param>
        /// <returns>异步任务XGMediaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGMediaResponse> DeletePipelineAsync(string pipelineName)
        {
            AssertStringNotNullOrEmpty(pipelineName, nameof(pipelineName));
            XGMediaDeletePipelineRequest request = new XGMediaDeletePipelineRequest()
            {
                PipelineName = pipelineName
            };
            return await DeletePipelineAsync(request);
        }

        /// <summary>
        /// 删除指定队列
        /// <para>用户向服务请求删除指定pipelineName的任务队列。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/MCT/s/djwvz5f9i#%E5%88%A0%E9%99%A4%E6%8C%87%E5%AE%9A%E9%98%9F%E5%88%97 </para>
        /// </summary>
        /// <param name="request">XGMediaDeletePipelineRequest</param>
        /// <returns>XGMediaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGMediaResponse DeletePipeline(XGMediaDeletePipelineRequest request)
        {
            AssertNotNullOrEmpty(request,nameof(request));
            AssertStringNotNullOrEmpty(request.PipelineName, nameof(request.PipelineName));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.DELETE, request.MediaVersion.ToString(), PIPELINE, request.PipelineName.Trim());
            XGMediaQueryPipelineResponse response = InvokeHttpClient<XGMediaQueryPipelineResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 删除指定队列
        /// <para>用户向服务请求删除指定pipelineName的任务队列。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/MCT/s/djwvz5f9i#%E5%88%A0%E9%99%A4%E6%8C%87%E5%AE%9A%E9%98%9F%E5%88%97 </para>
        /// </summary>
        /// <param name="request">XGMediaDeletePipelineRequest</param>
        /// <returns>异步任务XGMediaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGMediaResponse> DeletePipelineAsync(XGMediaDeletePipelineRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.PipelineName, nameof(request.PipelineName));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.DELETE, request.MediaVersion.ToString(), PIPELINE, request.PipelineName.Trim());
            XGMediaQueryPipelineResponse response = await InvokeHttpClientAsync<XGMediaQueryPipelineResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 更新指定队列
        /// <para>用户向服务请求更新任务队列。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/MCT/s/djwvz5f9i#%E6%9B%B4%E6%96%B0%E6%8C%87%E5%AE%9A%E9%98%9F%E5%88%97 </para>
        /// </summary>
        /// <param name="pipelineName">队列名称</param>
        /// <param name="sourceBucket">输入Bucket</param>
        /// <param name="targetBucket">输出Bucket</param>
        /// <param name="description">队列描述</param>
        /// <returns>XGMediaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGMediaResponse UpdatePipeline(string pipelineName, string sourceBucket, string targetBucket, string description = null)
        {
            AssertStringNotNullOrEmpty(pipelineName, nameof(pipelineName));
            AssertStringNotNullOrEmpty(sourceBucket, nameof(sourceBucket));
            AssertStringNotNullOrEmpty(targetBucket, nameof(targetBucket));
            XGMediaUpdatePipelineRequest request = new XGMediaUpdatePipelineRequest()
            {
                PipelineName = pipelineName,
                Description = description,
                SourceBucket = sourceBucket,
                TargetBucket = targetBucket
            };
            return UpdatePipeline(request);
        }

        /// <summary>
        /// 更新指定队列
        /// <para>用户向服务请求更新任务队列。</para>
        /// </summary>
        /// <param name="pipelineName">队列名称</param>
        /// <param name="sourceBucket">输入Bucket</param>
        /// <param name="targetBucket">输出Bucket</param>
        /// <param name="description">队列描述</param>
        /// <returns>异步任务XGMediaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGMediaResponse> UpdatePipelineAsync(string pipelineName, string sourceBucket, string targetBucket, string description = null)
        {
            AssertStringNotNullOrEmpty(pipelineName, nameof(pipelineName));
            AssertStringNotNullOrEmpty(sourceBucket, nameof(sourceBucket));
            AssertStringNotNullOrEmpty(targetBucket, nameof(targetBucket));
            XGMediaUpdatePipelineRequest request = new XGMediaUpdatePipelineRequest()
            {
                PipelineName = pipelineName,
                Description = description,
                SourceBucket = sourceBucket,
                TargetBucket = targetBucket
            };
            return await UpdatePipelineAsync(request);
        }

        /// <summary>
        /// 更新指定队列
        /// <para>用户向服务请求更新任务队列。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/MCT/s/djwvz5f9i#%E6%9B%B4%E6%96%B0%E6%8C%87%E5%AE%9A%E9%98%9F%E5%88%97 </para>
        /// </summary>
        /// <param name="request">XGMediaUpdatePipelineRequest</param>
        /// <returns>XGMediaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGMediaResponse UpdatePipeline(XGMediaUpdatePipelineRequest request)
        {
            AssertNotNullOrEmpty(request,nameof(request));
            AssertStringNotNullOrEmpty(request.PipelineName, nameof(request.PipelineName));
            AssertStringNotNullOrEmpty(request.SourceBucket, nameof(request.SourceBucket));
            AssertStringNotNullOrEmpty(request.TargetBucket, nameof(request.TargetBucket));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.PUT, request.MediaVersion.ToString(), PIPELINE,request.PipelineName.Trim());
            XGMediaResponse response = InvokeHttpClient<XGMediaResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 更新指定队列
        /// <para>用户向服务请求更新任务队列。</para>
        /// </summary>
        /// <param name="request">XGMediaUpdatePipelineRequest</param>
        /// <returns>异步任务XGMediaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGMediaResponse> UpdatePipelineAsync(XGMediaUpdatePipelineRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.PipelineName, nameof(request.PipelineName));
            AssertStringNotNullOrEmpty(request.SourceBucket, nameof(request.SourceBucket));
            AssertStringNotNullOrEmpty(request.TargetBucket, nameof(request.TargetBucket));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.PUT, request.MediaVersion.ToString(), PIPELINE,request.PipelineName.Trim());
            XGMediaResponse response = await InvokeHttpClientAsync<XGMediaResponse>(iternalRequest);
            return response;
        }

        #endregion

        #region 视频转码任务接口

        /// <summary>
        /// 创建视频转码任务
        /// <para>通过该接口创建转码任务，支持多视频合并。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/MCT/s/4jwvz5ifb#%E5%88%9B%E5%BB%BA%E8%A7%86%E9%A2%91%E8%BD%AC%E7%A0%81%E4%BB%BB%E5%8A%A1 </para>
        /// </summary>
        /// <param name="request">XGMediaCreateTranscodingJobRequest</param>
        /// <returns>XGMediaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGMediaResponse CreateTranscodingJob(XGMediaCreateTranscodingJobRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.PipelineName, nameof(request.PipelineName));
            AssertNotNullOrEmpty(request.Source, nameof(request.Source));
            AssertStringNotNullOrEmpty(request.Source.SourceKey,nameof(request.Source.SourceKey));
            AssertNotNullOrEmpty(request.Target,nameof(request.Target));
            AssertStringNotNullOrEmpty(request.Target.TargetBucket, nameof(request.Target.TargetBucket));
            AssertStringNotNullOrEmpty(request.Target.PresetName, nameof(request.Target.PresetName));
            if (request.Target.DelogoArea != null)
            {
                if (request.Target.DelogoArea.HasNullProperty())
                    throw new ArgumentNullException(nameof(request.Target.DelogoArea), "request.Target.DelogoArea的属性不能为空");
            }
            else
                if (request.Target.DelogoAreas != null && request.Target.DelogoAreas.Count > 0)
                request.Target.DelogoAreas.ForEach((x) => { if (x.HasNullProperty()) throw new ArgumentNullException(nameof(request.Target.DelogoAreas), "request.Target.DelogoAreas的属性不能为空"); });
            if(request.Target.Crop!=null)
                if (request.Target.Crop.HasNullProperty())
                    throw new ArgumentNullException(nameof(request.Target.Crop), "request.Target.Crop的属性不能为空");
            if (request.Target.Inserts != null && request.Target.Inserts.Count > 0)
                request.Target.Inserts.ForEach((x)=> { if(x.Type==null) throw new ArgumentNullException(nameof(request.Target.Inserts), "request.Target.Inserts属性type 不能为空"); });

            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.POST, request.MediaVersion.ToString(), JOB,TRANSCODING);
            XGMediaResponse response = InvokeHttpClient<XGMediaResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 创建视频转码任务
        /// <para>通过该接口创建转码任务，支持多视频合并。</para>
        /// </summary>
        /// <param name="request">XGMediaCreateTranscodingJobRequest</param>
        /// <returns>异步任务XGMediaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGMediaResponse> CreateTranscodingJobAsync(XGMediaCreateTranscodingJobRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.PipelineName, nameof(request.PipelineName));
            AssertNotNullOrEmpty(request.Source, nameof(request.Source));
            AssertStringNotNullOrEmpty(request.Source.SourceKey, nameof(request.Source.SourceKey));
            AssertNotNullOrEmpty(request.Target, nameof(request.Target));
            AssertStringNotNullOrEmpty(request.Target.TargetBucket, nameof(request.Target.TargetBucket));
            AssertStringNotNullOrEmpty(request.Target.PresetName, nameof(request.Target.PresetName));
            if (request.Target.DelogoArea != null)
            {
                if (request.Target.DelogoArea.HasNullProperty())
                    throw new ArgumentNullException(nameof(request.Target.DelogoArea), "request.Target.DelogoArea的属性不能为空");
            }
            else
                if (request.Target.DelogoAreas != null && request.Target.DelogoAreas.Count > 0)
                request.Target.DelogoAreas.ForEach((x) => { if (x.HasNullProperty()) throw new ArgumentNullException(nameof(request.Target.DelogoAreas), "request.Target.DelogoAreas的属性不能为空"); });
            if (request.Target.Crop != null)
                if (request.Target.Crop.HasNullProperty())
                    throw new ArgumentNullException(nameof(request.Target.Crop), "request.Target.Crop的属性不能为空");
            if (request.Target.Inserts != null && request.Target.Inserts.Count > 0)
                request.Target.Inserts.ForEach((x) => { if (x.Type == null) throw new ArgumentNullException(nameof(request.Target.Inserts), "request.Target.Inserts属性type 不能为空"); });

            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.POST, request.MediaVersion.ToString(), JOB, TRANSCODING);
            XGMediaResponse response = await InvokeHttpClientAsync<XGMediaResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询指定队列的视频转码任务信息
        /// <para>查询指定队列下满足一定条件的所有转码任务。</para>
        /// <para> 接口文档：https://cloud.baidu.com/doc/MCT/s/4jwvz5ifb#%E6%9F%A5%E8%AF%A2%E6%8C%87%E5%AE%9A%E9%98%9F%E5%88%97%E7%9A%84%E8%A7%86%E9%A2%91%E8%BD%AC%E7%A0%81%E4%BB%BB%E5%8A%A1%E4%BF%A1%E6%81%AF </para>
        /// </summary>
        /// <param name="pipelineName">任务所属的队列名</param>
        /// <param name="jobStatus">所选任务的状态</param>
        /// <param name="begin">任务创建时间的上限。所选任务开始时间要大于等于begin</param>
        /// <param name="end">任务创建时间的下限，所选任务开始时间要小于等于end</param>
        /// <param name="marker">本次请求的marker，标记查询的起始位置，此处为jobId</param>
        /// <param name="maxSize">本次请求返回的任务列表的最大元素个数</param>
        /// <returns>XGMediaQueryPipelineTranscodingJobResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGMediaQueryPipelineTranscodingJobResponse QueryPipelineTranscodingJob(string pipelineName, XGMediaJobStatus? jobStatus = null,
            DateTime? begin = null, DateTime? end = null, string marker = null, int? maxSize = null)
        {
            AssertStringNotNullOrEmpty(pipelineName,nameof(pipelineName));

            XGMediaQueryPipelineTranscodingJobRequest request = new XGMediaQueryPipelineTranscodingJobRequest()
            {
                PipelineName = pipelineName,
                JobStatus = jobStatus,
                Begin = begin,
                End = end,
                Marker = marker,
                MaxSize = maxSize
            };
            return QueryPipelineTranscodingJob(request);
        }

        /// <summary>
        /// 查询指定队列的视频转码任务信息
        /// <para>查询指定队列下满足一定条件的所有转码任务。</para>
        /// </summary>
        /// <param name="pipelineName">任务所属的队列名</param>
        /// <param name="jobStatus">所选任务的状态</param>
        /// <param name="begin">任务创建时间的上限。所选任务开始时间要大于等于begin</param>
        /// <param name="end">任务创建时间的下限，所选任务开始时间要小于等于end</param>
        /// <param name="marker">本次请求的marker，标记查询的起始位置，此处为jobId</param>
        /// <param name="maxSize">本次请求返回的任务列表的最大元素个数</param>
        /// <returns>异步任务XGMediaQueryPipelineTranscodingJobResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGMediaQueryPipelineTranscodingJobResponse> QueryPipelineTranscodingJobAsync(string pipelineName, XGMediaJobStatus? jobStatus = null,
            DateTime? begin = null, DateTime? end = null, string marker = null, int? maxSize = null)
        {
            AssertStringNotNullOrEmpty(pipelineName, nameof(pipelineName));

            XGMediaQueryPipelineTranscodingJobRequest request = new XGMediaQueryPipelineTranscodingJobRequest()
            {
                PipelineName = pipelineName,
                JobStatus = jobStatus,
                Begin = begin,
                End = end,
                Marker = marker,
                MaxSize = maxSize
            };
            return await QueryPipelineTranscodingJobAsync(request);
        }

        /// <summary>
        /// 查询指定队列的视频转码任务信息
        /// <para>查询指定队列下满足一定条件的所有转码任务。</para>
        /// <para> 接口文档：https://cloud.baidu.com/doc/MCT/s/4jwvz5ifb#%E6%9F%A5%E8%AF%A2%E6%8C%87%E5%AE%9A%E9%98%9F%E5%88%97%E7%9A%84%E8%A7%86%E9%A2%91%E8%BD%AC%E7%A0%81%E4%BB%BB%E5%8A%A1%E4%BF%A1%E6%81%AF </para>
        /// </summary>
        /// <param name="request">XGMediaQueryPipelineTranscodingJobRequest</param>
        /// <returns>XGMediaQueryPipelineTranscodingJobResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGMediaQueryPipelineTranscodingJobResponse QueryPipelineTranscodingJob(XGMediaQueryPipelineTranscodingJobRequest request)
        {
            AssertNotNullOrEmpty(request,nameof(request));
            AssertStringNotNullOrEmpty(request.PipelineName, nameof(request.PipelineName));

            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.MediaVersion.ToString(), JOB, TRANSCODING);
            iternalRequest.AddParameter("pipelineName", request.PipelineName);
            if (request.JobStatus != null)
                iternalRequest.AddParameter("jobStatus", request.JobStatus.ToString());
            if (request.Begin!=null)
                iternalRequest.AddParameter("begin", HttpUtil.FormatUTCTime(request.Begin.Value));
            if (request.End != null)
                iternalRequest.AddParameter("end", HttpUtil.FormatUTCTime(request.End.Value));
            if (!string.IsNullOrEmpty(request.Marker) && !string.IsNullOrWhiteSpace(request.Marker))
                iternalRequest.AddParameter("end", request.Marker.Trim());
            if(request.MaxSize!=null)
                iternalRequest.AddParameter("maxSize", request.MaxSize.ToString());

            XGMediaQueryPipelineTranscodingJobResponse response = InvokeHttpClient<XGMediaQueryPipelineTranscodingJobResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询指定队列的视频转码任务信息
        /// <para>查询指定队列下满足一定条件的所有转码任务。</para>
        /// </summary>
        /// <param name="request">XGMediaQueryPipelineTranscodingJobRequest</param>
        /// <returns>异步任务XGMediaQueryPipelineTranscodingJobResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGMediaQueryPipelineTranscodingJobResponse> QueryPipelineTranscodingJobAsync(XGMediaQueryPipelineTranscodingJobRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.PipelineName, nameof(request.PipelineName));

            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.MediaVersion.ToString(), JOB, TRANSCODING);
            iternalRequest.AddParameter("pipelineName", request.PipelineName);
            if (request.JobStatus != null)
                iternalRequest.AddParameter("jobStatus", request.JobStatus.ToString());
            if (request.Begin != null)
                iternalRequest.AddParameter("begin", HttpUtil.FormatUTCTime(request.Begin.Value));
            if (request.End != null)
                iternalRequest.AddParameter("end", HttpUtil.FormatUTCTime(request.End.Value));
            if (!string.IsNullOrEmpty(request.Marker) && !string.IsNullOrWhiteSpace(request.Marker))
                iternalRequest.AddParameter("end", request.Marker.Trim());
            if (request.MaxSize != null)
                iternalRequest.AddParameter("maxSize", request.MaxSize.ToString());

            XGMediaQueryPipelineTranscodingJobResponse response = await InvokeHttpClientAsync<XGMediaQueryPipelineTranscodingJobResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询指定视频转码任务
        /// <para>通过指定jobId查询该任务的信息。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/MCT/s/4jwvz5ifb#%E6%9F%A5%E8%AF%A2%E6%8C%87%E5%AE%9A%E8%A7%86%E9%A2%91%E8%BD%AC%E7%A0%81%E4%BB%BB%E5%8A%A1 </para>
        /// </summary>
        /// <param name="jobId">任务ID</param>
        /// <returns>XGMediaQueryTranscodingJobResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGMediaQueryTranscodingJobResponse QueryTranscodingJob(string jobId)
        {
            AssertStringNotNullOrEmpty(jobId,nameof(jobId));

            XGMediaQueryTranscodingJobRequest request = new XGMediaQueryTranscodingJobRequest()
            {
                JobId=jobId
            };
            return QueryTranscodingJob(request);
        }

        /// <summary>
        /// 查询指定视频转码任务
        /// <para>通过指定jobId查询该任务的信息。</para>
        /// </summary>
        /// <param name="jobId">任务ID</param>
        /// <returns>异步任务XGMediaQueryTranscodingJobResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGMediaQueryTranscodingJobResponse> QueryTranscodingJobAsync(string jobId)
        {
            AssertStringNotNullOrEmpty(jobId, nameof(jobId));

            XGMediaQueryTranscodingJobRequest request = new XGMediaQueryTranscodingJobRequest()
            {
                JobId = jobId
            };
            return await QueryTranscodingJobAsync(request);
        }

        /// <summary>
        /// 查询指定视频转码任务
        /// <para>通过指定jobId查询该任务的信息。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/MCT/s/4jwvz5ifb#%E6%9F%A5%E8%AF%A2%E6%8C%87%E5%AE%9A%E8%A7%86%E9%A2%91%E8%BD%AC%E7%A0%81%E4%BB%BB%E5%8A%A1 </para>
        /// </summary>
        /// <param name="request">XGMediaQueryTranscodingJobRequest</param>
        /// <returns>XGMediaQueryTranscodingJobResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGMediaQueryTranscodingJobResponse QueryTranscodingJob(XGMediaQueryTranscodingJobRequest request)
        {
            AssertNotNullOrEmpty(request,nameof(request));
            AssertStringNotNullOrEmpty(request.JobId, nameof(request.JobId));

            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.MediaVersion.ToString(), JOB, TRANSCODING,request.JobId.Trim());

            XGMediaQueryTranscodingJobResponse response = InvokeHttpClient<XGMediaQueryTranscodingJobResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询指定视频转码任务
        /// <para>通过指定jobId查询该任务的信息。</para>
        /// </summary>
        /// <param name="request">XGMediaQueryTranscodingJobRequest</param>
        /// <returns>异步任务XGMediaQueryTranscodingJobResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGMediaQueryTranscodingJobResponse> QueryTranscodingJobAsync(XGMediaQueryTranscodingJobRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.JobId, nameof(request.JobId));

            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.MediaVersion.ToString(), JOB, TRANSCODING, request.JobId.Trim());

            XGMediaQueryTranscodingJobResponse response = await InvokeHttpClientAsync<XGMediaQueryTranscodingJobResponse>(iternalRequest);
            return response;
        }

        #endregion

        #region 模板接口

        /// <summary>
        /// 创建模板
        /// <para>当系统预设的Preset无法满足需求时，用户可以通过此接口创建自定义的Preset</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/MCT/s/Sjwvz5hey#%E5%88%9B%E5%BB%BA%E6%A8%A1%E6%9D%BF </para>
        /// </summary>
        /// <param name="request">XGMediaCreatePresetRequest</param>
        /// <returns>XGMediaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGMediaResponse CreatePreset(XGMediaCreatePresetRequest request)
        {
            AssertNotNullOrEmpty(request,nameof(request));
            AssertStringNotNullOrEmpty(request.PresetName,nameof(request.PresetName));
            AssertStringNotNullOrEmpty(request.Container, nameof(request.Container));
            if (request.Video!=null)
            {
                if (request.Video.BitRateInBps==null)
                    throw new ArgumentNullException(nameof(request.Video.BitRateInBps),"request.Video.BitRateInBps 不能为空");
            }
            if(request.Encryption!=null)
            {
                if (request.Encryption.Strategy == null)
                    throw new ArgumentNullException(nameof(request.Encryption.Strategy), "request.Encryption.Strategy 不能为空");
                AssertStringNotNullOrEmpty(request.Encryption.AesKey,nameof(request.Encryption.AesKey));
            }
            bool hasWatermarkId = false;
            if (string.IsNullOrEmpty(request.WatermarkId) || string.IsNullOrWhiteSpace(request.WatermarkId))
            {
                if(request.Transmux!=null&&request.Transmux.Value)
                    throw new ArgumentException("当transmux=true时不允许添加WatermarkId");
            }
            if (request.Watermarks != null)
            {
                if(hasWatermarkId)
                    throw new ArgumentException("不可同时指定watermarkId和watermarks");
                if (request.Transmux != null && request.Transmux.Value)
                    throw new ArgumentException("当transmux=true时不允许添加Watermarks");
                if(!request.Watermarks.IsValid())
                    throw new ArgumentNullException(nameof(request.Watermarks),"request.Watermarks的Image 不能为空");
            }
            if(request.TransCfg!=null&&request.TransCfg.TransMode==null)
                throw new ArgumentNullException(nameof(request.TransCfg.TransMode),"request.TransCfg.TransMode 不能为空");

            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.POST, request.MediaVersion.ToString(),PRESET);
            XGMediaResponse response = InvokeHttpClient<XGMediaResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 创建模板
        /// <para>当系统预设的Preset无法满足需求时，用户可以通过此接口创建自定义的Preset</para>
        /// </summary>
        /// <param name="request">XGMediaCreatePresetRequest</param>
        /// <returns>异步任务XGMediaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGMediaResponse> CreatePresetAsync(XGMediaCreatePresetRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.PresetName, nameof(request.PresetName));
            AssertStringNotNullOrEmpty(request.Container, nameof(request.Container));
            if (request.Video != null)
            {
                if (request.Video.BitRateInBps == null)
                    throw new ArgumentNullException(nameof(request.Video.BitRateInBps), "request.Video.BitRateInBps 不能为空");
            }
            if (request.Encryption != null)
            {
                if (request.Encryption.Strategy == null)
                    throw new ArgumentNullException(nameof(request.Encryption.Strategy), "request.Encryption.Strategy 不能为空");
                AssertStringNotNullOrEmpty(request.Encryption.AesKey, nameof(request.Encryption.AesKey));
            }
            bool hasWatermarkId = false;
            if (string.IsNullOrEmpty(request.WatermarkId) || string.IsNullOrWhiteSpace(request.WatermarkId))
            {
                if (request.Transmux != null && request.Transmux.Value)
                    throw new ArgumentException("当transmux=true时不允许添加WatermarkId");
            }
            if (request.Watermarks != null)
            {
                if (hasWatermarkId)
                    throw new ArgumentException("不可同时指定watermarkId和watermarks");
                if (request.Transmux != null && request.Transmux.Value)
                    throw new ArgumentException("当transmux=true时不允许添加Watermarks");
                if (!request.Watermarks.IsValid())
                    throw new ArgumentNullException(nameof(request.Watermarks), "request.Watermarks的Image 不能为空");
            }
            if (request.TransCfg != null && request.TransCfg.TransMode == null)
                throw new ArgumentNullException(nameof(request.TransCfg.TransMode), "request.TransCfg.TransMode 不能为空");

            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.POST, request.MediaVersion.ToString(), PRESET);
            XGMediaResponse response = await InvokeHttpClientAsync<XGMediaResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询指定模板
        /// <para>通过模板名称查询指定的模板信息</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/MCT/s/Sjwvz5hey#%E6%9F%A5%E8%AF%A2%E6%8C%87%E5%AE%9A%E6%A8%A1%E6%9D%BF </para>
        /// </summary>
        /// <param name="presetId">模板名称</param>
        /// <returns>XGMediaQueryPresetResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGMediaQueryPresetResponse QueryPreset(string presetId)
        {
            AssertStringNotNullOrEmpty(presetId,nameof(presetId));

            XGMediaQueryPresetRequest request = new XGMediaQueryPresetRequest()
            {
                PresetId=presetId
            };
            return QueryPreset(request);
        }

        /// <summary>
        /// 查询指定模板
        /// <para>通过模板名称查询指定的模板信息</para>
        /// </summary>
        /// <param name="presetId">模板名称</param>
        /// <returns>异步任务XGMediaQueryPresetResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGMediaQueryPresetResponse> QueryPresetAsync(string presetId)
        {
            AssertStringNotNullOrEmpty(presetId, nameof(presetId));

            XGMediaQueryPresetRequest request = new XGMediaQueryPresetRequest()
            {
                PresetId = presetId
            };
            return await QueryPresetAsync(request);
        }

        /// <summary>
        /// 查询指定模板
        /// <para>通过模板名称查询指定的模板信息</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/MCT/s/Sjwvz5hey#%E6%9F%A5%E8%AF%A2%E6%8C%87%E5%AE%9A%E6%A8%A1%E6%9D%BF </para>
        /// </summary>
        /// <param name="request">XGMediaQueryPresetRequest</param>
        /// <returns>XGMediaQueryPresetResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGMediaQueryPresetResponse QueryPreset(XGMediaQueryPresetRequest request)
        {
            AssertNotNullOrEmpty(request);
            AssertStringNotNullOrEmpty(request.PresetId, nameof(request.PresetId));

            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.MediaVersion.ToString(), PRESET,request.PresetId.Trim());
            XGMediaQueryPresetResponse response = InvokeHttpClient<XGMediaQueryPresetResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询指定模板
        /// <para>通过模板名称查询指定的模板信息</para>
        /// </summary>
        /// <param name="request">XGMediaQueryPresetRequest</param>
        /// <returns>异步任务XGMediaQueryPresetResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGMediaQueryPresetResponse> QueryPresetAsync(XGMediaQueryPresetRequest request)
        {
            AssertNotNullOrEmpty(request);
            AssertStringNotNullOrEmpty(request.PresetId, nameof(request.PresetId));

            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.MediaVersion.ToString(), PRESET, request.PresetId.Trim());
            XGMediaQueryPresetResponse response = await InvokeHttpClientAsync<XGMediaQueryPresetResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询当前用户模板及所有系统模板
        /// <para>用户查询其名下及系统提供的所有的模板，具体有哪些系统模板可以参考系统内置模板</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/MCT/s/Sjwvz5hey#%E6%9F%A5%E8%AF%A2%E5%BD%93%E5%89%8D%E7%94%A8%E6%88%B7%E6%A8%A1%E6%9D%BF%E5%8F%8A%E6%89%80%E6%9C%89%E7%B3%BB%E7%BB%9F%E6%A8%A1%E6%9D%BF </para>
        /// </summary>
        /// <returns>XGMediaListPresetsResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGMediaListPresetsResponse ListPreset()
        {
            XGMediaBaseRequest request = new XGMediaBaseRequest();

            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.MediaVersion.ToString(), PRESET);
            XGMediaListPresetsResponse response = InvokeHttpClient<XGMediaListPresetsResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询当前用户模板及所有系统模板
        /// <para>用户查询其名下及系统提供的所有的模板，具体有哪些系统模板可以参考系统内置模板</para>
        /// </summary>
        /// <returns>异步任务XGMediaListPresetsResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGMediaListPresetsResponse> ListPresetAsync()
        {
            XGMediaBaseRequest request = new XGMediaBaseRequest();

            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.MediaVersion.ToString(), PRESET);
            XGMediaListPresetsResponse response = await InvokeHttpClientAsync<XGMediaListPresetsResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 删除指定模板
        /// <para>用于删除用户指定的用户模板</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/MCT/s/Sjwvz5hey#%E5%88%A0%E9%99%A4%E6%8C%87%E5%AE%9A%E6%A8%A1%E6%9D%BF </para>
        /// </summary>
        /// <param name="presetName">模板名称</param>
        /// <returns>XGMediaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGMediaResponse DeletePreset(string presetName)
        {
            AssertStringNotNullOrEmpty(presetName,nameof(presetName));

            XGMediaDeletePresetRequest request = new XGMediaDeletePresetRequest()
            {
                PresetName=presetName
            };
            return DeletePreset(request);
        }

        /// <summary>
        /// 删除指定模板
        /// <para>用于删除用户指定的用户模板</para>
        /// </summary>
        /// <param name="presetName">模板名称</param>
        /// <returns>异步任务XGMediaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGMediaResponse> DeletePresetAsync(string presetName)
        {
            AssertStringNotNullOrEmpty(presetName, nameof(presetName));

            XGMediaDeletePresetRequest request = new XGMediaDeletePresetRequest()
            {
                PresetName = presetName
            };
            return await DeletePresetAsync(request);
        }

        /// <summary>
        /// 删除指定模板
        /// <para>用于删除用户指定的用户模板</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/MCT/s/Sjwvz5hey#%E5%88%A0%E9%99%A4%E6%8C%87%E5%AE%9A%E6%A8%A1%E6%9D%BF </para>
        /// </summary>
        /// <param name="request">XGMediaDeletePresetRequest</param>
        /// <returns>XGMediaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGMediaResponse DeletePreset(XGMediaDeletePresetRequest request)
        {
            AssertNotNullOrEmpty(request,nameof(request));
            AssertStringNotNullOrEmpty(request.PresetName, nameof(request.PresetName));

            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.DELETE, request.MediaVersion.ToString(), PRESET, request.PresetName.Trim());
            XGMediaResponse response = InvokeHttpClient<XGMediaResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 删除指定模板
        /// <para>用于删除用户指定的用户模板</para>
        /// </summary>
        /// <param name="request">XGMediaDeletePresetRequest</param>
        /// <returns>异步任务XGMediaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGMediaResponse> DeletePresetAsync(XGMediaDeletePresetRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.PresetName, nameof(request.PresetName));

            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.DELETE, request.MediaVersion.ToString(), PRESET, request.PresetName.Trim());
            XGMediaResponse response = await InvokeHttpClientAsync<XGMediaResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 更新指定模板
        /// <para>用户可以通过此接口更新指定Preset</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/MCT/s/Sjwvz5hey#%E6%9B%B4%E6%96%B0%E6%8C%87%E5%AE%9A%E6%A8%A1%E6%9D%BF </para>
        /// </summary>
        /// <param name="request">XGMediaCreatePresetRequest</param>
        /// <returns>XGMediaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGMediaResponse UpdatePreset(XGMediaUpdatePresetRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.PresetName, nameof(request.PresetName));
            AssertStringNotNullOrEmpty(request.Container, nameof(request.Container));
            if (request.Video != null)
            {
                if (request.Video.BitRateInBps == null)
                    throw new ArgumentNullException(nameof(request.Video.BitRateInBps),"request.Video.BitRateInBps 不能为空");
            }
            if (request.Encryption != null)
            {
                if (request.Encryption.Strategy == null)
                    throw new ArgumentNullException(nameof(request.Encryption.Strategy), "request.Encryption.Strategy 不能为空");
                AssertStringNotNullOrEmpty(request.Encryption.AesKey, nameof(request.Encryption.AesKey));
            }
            bool hasWatermarkId = false;
            if (string.IsNullOrEmpty(request.WatermarkId) || string.IsNullOrWhiteSpace(request.WatermarkId))
            {
                if (request.Transmux != null && request.Transmux.Value)
                    throw new ArgumentException("当transmux=true时不允许添加WatermarkId");
            }
            if (request.Watermarks != null)
            {
                if (hasWatermarkId)
                    throw new ArgumentException("不可同时指定watermarkId和watermarks");
                if (request.Transmux != null && request.Transmux.Value)
                    throw new ArgumentException("当transmux=true时不允许添加Watermarks");
                if (!request.Watermarks.IsValid())
                    throw new ArgumentNullException(nameof(request.Watermarks), "request.Watermarks的Image 不能为空");
            }
            if (request.TransCfg != null && request.TransCfg.TransMode == null)
                throw new ArgumentNullException(nameof(request.TransCfg.TransMode),"request.TransCfg.TransMode 不能为空");

            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.PUT, request.MediaVersion.ToString(), PRESET,request.PresetName);
            XGMediaResponse response = InvokeHttpClient<XGMediaResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 更新指定模板
        /// <para>用户可以通过此接口更新指定Preset</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/MCT/s/Sjwvz5hey#%E6%9B%B4%E6%96%B0%E6%8C%87%E5%AE%9A%E6%A8%A1%E6%9D%BF </para>
        /// </summary>
        /// <param name="request">XGMediaCreatePresetRequest</param>
        /// <returns>异步任务XGMediaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGMediaResponse> UpdatePresetAsync(XGMediaUpdatePresetRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.PresetName, nameof(request.PresetName));
            AssertStringNotNullOrEmpty(request.Container, nameof(request.Container));
            if (request.Video != null)
            {
                if (request.Video.BitRateInBps == null)
                    throw new ArgumentNullException(nameof(request.Video.BitRateInBps), "request.Video.BitRateInBps 不能为空");
            }
            if (request.Encryption != null)
            {
                if (request.Encryption.Strategy == null)
                    throw new ArgumentNullException(nameof(request.Encryption.Strategy), "request.Encryption.Strategy 不能为空");
                AssertStringNotNullOrEmpty(request.Encryption.AesKey, nameof(request.Encryption.AesKey));
            }
            bool hasWatermarkId = false;
            if (string.IsNullOrEmpty(request.WatermarkId) || string.IsNullOrWhiteSpace(request.WatermarkId))
            {
                if (request.Transmux != null && request.Transmux.Value)
                    throw new ArgumentException("当transmux=true时不允许添加WatermarkId");
            }
            if (request.Watermarks != null)
            {
                if (hasWatermarkId)
                    throw new ArgumentException("不可同时指定watermarkId和watermarks");
                if (request.Transmux != null && request.Transmux.Value)
                    throw new ArgumentException("当transmux=true时不允许添加Watermarks");
                if (!request.Watermarks.IsValid())
                    throw new ArgumentNullException(nameof(request.Watermarks), "request.Watermarks的Image 不能为空");
            }
            if (request.TransCfg != null && request.TransCfg.TransMode == null)
                throw new ArgumentNullException(nameof(request.TransCfg.TransMode), "request.TransCfg.TransMode 不能为空");

            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.PUT, request.MediaVersion.ToString(), PRESET, request.PresetName);
            XGMediaResponse response = await InvokeHttpClientAsync<XGMediaResponse>(iternalRequest);
            return response;
        }

        #endregion

        #region 媒体信息接口

        /// <summary>
        /// 查询指定媒体信息
        /// <para>用户通过Bucket+BOS Key的URL Encoded的结果获取指定音视频文件的媒体信息</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/MCT/s/Sjwvz5g0p#%E6%9F%A5%E8%AF%A2%E6%8C%87%E5%AE%9A%E5%AA%92%E4%BD%93%E4%BF%A1%E6%81%AF </para>
        /// </summary>
        /// <param name="bucket">音视频文件所在的BOS的Bucket</param>
        /// <param name="key">音视频文件的BOS的Key</param>
        /// <returns>XGMediaQueryMediaInfoResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGMediaQueryMediaInfoResponse QueryMediaInfo(string bucket, string key)
        {
            AssertStringNotNullOrEmpty(bucket,nameof(bucket));
            AssertStringNotNullOrEmpty(key,nameof(key));

            XGMediaQueryMediaInfoRequest request = new XGMediaQueryMediaInfoRequest()
            {
                Bucket=bucket,
                Key=key
            };
            return QueryMediaInfo(request);
        }

        /// <summary>
        /// 查询指定媒体信息
        /// <para>用户通过Bucket+BOS Key的URL Encoded的结果获取指定音视频文件的媒体信息</para>
        /// </summary>
        /// <param name="bucket">音视频文件所在的BOS的Bucket</param>
        /// <param name="key">音视频文件的BOS的Key</param>
        /// <returns>异步任务XGMediaQueryMediaInfoResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGMediaQueryMediaInfoResponse> QueryMediaInfoAsync(string bucket, string key)
        {
            AssertStringNotNullOrEmpty(bucket, nameof(bucket));
            AssertStringNotNullOrEmpty(key, nameof(key));

            XGMediaQueryMediaInfoRequest request = new XGMediaQueryMediaInfoRequest()
            {
                Bucket = bucket,
                Key = key
            };
            return await QueryMediaInfoAsync(request);
        }

        /// <summary>
        /// 查询指定媒体信息
        /// <para>用户通过Bucket+BOS Key的URL Encoded的结果获取指定音视频文件的媒体信息</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/MCT/s/Sjwvz5g0p#%E6%9F%A5%E8%AF%A2%E6%8C%87%E5%AE%9A%E5%AA%92%E4%BD%93%E4%BF%A1%E6%81%AF </para>
        /// </summary>
        /// <param name="request">XGMediaQueryMediaInfoRequest</param>
        /// <returns>XGMediaQueryMediaInfoResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGMediaQueryMediaInfoResponse QueryMediaInfo(XGMediaQueryMediaInfoRequest request)
        {
            AssertNotNullOrEmpty(request,nameof(request));
            AssertStringNotNullOrEmpty(request.Bucket, nameof(request.Bucket));
            AssertStringNotNullOrEmpty(request.Key, nameof(request.Key));

            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.MediaVersion.ToString(), MEDIAINFO);
            iternalRequest.AddParameter("bucket",request.Bucket);
            iternalRequest.AddParameter("key",HttpUtil.UriEncode(request.Key.Trim(),true));
            XGMediaQueryMediaInfoResponse response = InvokeHttpClient<XGMediaQueryMediaInfoResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询指定媒体信息
        /// <para>用户通过Bucket+BOS Key的URL Encoded的结果获取指定音视频文件的媒体信息</para>
        /// </summary>
        /// <param name="request">XGMediaQueryMediaInfoRequest</param>
        /// <returns>异步任务XGMediaQueryMediaInfoResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGMediaQueryMediaInfoResponse> QueryMediaInfoAsync(XGMediaQueryMediaInfoRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.Bucket, nameof(request.Bucket));
            AssertStringNotNullOrEmpty(request.Key, nameof(request.Key));

            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.MediaVersion.ToString(), MEDIAINFO);
            iternalRequest.AddParameter("bucket", request.Bucket);
            iternalRequest.AddParameter("key", HttpUtil.UriEncode(request.Key.Trim(), true));
            XGMediaQueryMediaInfoResponse response = await InvokeHttpClientAsync<XGMediaQueryMediaInfoResponse>(iternalRequest);
            return response;
        }

        #endregion

        #region 水印接口

        /// <summary>
        /// 创建水印
        /// <para>接口文档：https://cloud.baidu.com/doc/MCT/s/Sjwvz5isl#%E5%88%9B%E5%BB%BA%E6%B0%B4%E5%8D%B0 </para>
        /// </summary>
        /// <param name="bucket">BOS存储上水印文件Bucket</param>
        /// <param name="key">BOS存储上水印文件Key</param>
        /// <returns>XGMediaCreateWatermarkResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGMediaCreateWatermarkResponse CreateWatermark(string bucket, string key)
        {
            AssertStringNotNullOrEmpty(bucket, nameof(bucket));
            AssertStringNotNullOrEmpty(key, nameof(key));

            XGMediaCreateWatermarkRequest request = new XGMediaCreateWatermarkRequest()
            {
                Bucket=bucket,
                Key=key
            };
            return CreateWatermark(request);
        }

        /// <summary>
        /// 创建水印
        /// </summary>
        /// <param name="bucket">BOS存储上水印文件Bucket</param>
        /// <param name="key">BOS存储上水印文件Key</param>
        /// <returns>异步任务XGMediaCreateWatermarkResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGMediaCreateWatermarkResponse> CreateWatermarkAsync(string bucket, string key)
        {
            AssertStringNotNullOrEmpty(bucket, nameof(bucket));
            AssertStringNotNullOrEmpty(key, nameof(key));

            XGMediaCreateWatermarkRequest request = new XGMediaCreateWatermarkRequest()
            {
                Bucket = bucket,
                Key = key
            };
            return await CreateWatermarkAsync(request);
        }

        /// <summary>
        /// 创建水印
        /// <para>接口文档：https://cloud.baidu.com/doc/MCT/s/Sjwvz5isl#%E5%88%9B%E5%BB%BA%E6%B0%B4%E5%8D%B0 </para>
        /// </summary>
        /// <param name="request">XGMediaCreateWatermarkRequest</param>
        /// <returns>XGMediaCreateWatermarkResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGMediaCreateWatermarkResponse CreateWatermark(XGMediaCreateWatermarkRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.Bucket, nameof(request.Bucket));
            AssertStringNotNullOrEmpty(request.Key, nameof(request.Key));

            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.POST, request.MediaVersion.ToString(), WATERMARK);
            XGMediaCreateWatermarkResponse response = InvokeHttpClient<XGMediaCreateWatermarkResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 创建水印
        /// </summary>
        /// <param name="request">XGMediaCreateWatermarkRequest</param>
        /// <returns>异步任务XGMediaCreateWatermarkResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGMediaCreateWatermarkResponse> CreateWatermarkAsync(XGMediaCreateWatermarkRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.Bucket, nameof(request.Bucket));
            AssertStringNotNullOrEmpty(request.Key, nameof(request.Key));

            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.POST, request.MediaVersion.ToString(), WATERMARK);
            XGMediaCreateWatermarkResponse response = await InvokeHttpClientAsync<XGMediaCreateWatermarkResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询指定水印
        /// <para>接口文档：https://cloud.baidu.com/doc/MCT/s/Sjwvz5isl#%E6%9F%A5%E8%AF%A2%E6%8C%87%E5%AE%9A%E6%B0%B4%E5%8D%B0 </para>
        /// </summary>
        /// <param name="watermarkId">水印的唯一标识</param>
        //// <returns>XGMediaQueryWatermarkResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGMediaQueryWatermarkResponse QueryWatermark(string watermarkId)
        {
            AssertStringNotNullOrEmpty(watermarkId,nameof(watermarkId));

            XGMediaQueryWatermarkRequest request = new XGMediaQueryWatermarkRequest()
            {
                WatermarkId=watermarkId
            };
            return QueryWatermark(request);
        }

        /// <summary>
        /// 查询指定水印
        /// </summary>
        /// <param name="watermarkId">水印的唯一标识</param>
        //// <returns>异步任务XGMediaQueryWatermarkResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGMediaQueryWatermarkResponse> QueryWatermarkAsync(string watermarkId)
        {
            AssertStringNotNullOrEmpty(watermarkId, nameof(watermarkId));

            XGMediaQueryWatermarkRequest request = new XGMediaQueryWatermarkRequest()
            {
                WatermarkId = watermarkId
            };
            return await QueryWatermarkAsync(request);
        }

        /// <summary>
        /// 查询指定水印
        /// <para>接口文档：https://cloud.baidu.com/doc/MCT/s/Sjwvz5isl#%E6%9F%A5%E8%AF%A2%E6%8C%87%E5%AE%9A%E6%B0%B4%E5%8D%B0 </para>
        /// </summary>
        /// <param name="request">XGMediaQueryWatermarkRequest</param>
        /// <returns>XGMediaQueryWatermarkResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGMediaQueryWatermarkResponse QueryWatermark(XGMediaQueryWatermarkRequest request)
        {
            AssertNotNullOrEmpty(request,nameof(request));
            AssertStringNotNullOrEmpty(request.WatermarkId, nameof(request.WatermarkId));

            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.MediaVersion.ToString(), WATERMARK,request.WatermarkId.Trim());
            XGMediaQueryWatermarkResponse response = InvokeHttpClient<XGMediaQueryWatermarkResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询指定水印
        /// </summary>
        /// <param name="request">XGMediaQueryWatermarkRequest</param>
        /// <returns>异步任务XGMediaQueryWatermarkResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGMediaQueryWatermarkResponse> QueryWatermarkAsync(XGMediaQueryWatermarkRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.WatermarkId, nameof(request.WatermarkId));

            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.MediaVersion.ToString(), WATERMARK, request.WatermarkId.Trim());
            XGMediaQueryWatermarkResponse response = await InvokeHttpClientAsync<XGMediaQueryWatermarkResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 列举当前用户水印
        /// <para>接口文档：https://cloud.baidu.com/doc/MCT/s/Sjwvz5isl#%E6%9F%A5%E8%AF%A2%E5%BD%93%E5%89%8D%E7%94%A8%E6%88%B7%E6%B0%B4%E5%8D%B0 </para>
        /// </summary>
        /// <returns>XGMediaListWatermarksResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGMediaListWatermarksResponse ListWatermarks()
        {
            XGMediaBaseRequest request = new XGMediaBaseRequest();

            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.MediaVersion.ToString(), WATERMARK);
            XGMediaListWatermarksResponse response = InvokeHttpClient<XGMediaListWatermarksResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 列举当前用户水印
        /// </summary>
        /// <returns>异步任务XGMediaListWatermarksResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGMediaListWatermarksResponse> ListWatermarksAsync()
        {
            XGMediaBaseRequest request = new XGMediaBaseRequest();

            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.MediaVersion.ToString(), WATERMARK);
            XGMediaListWatermarksResponse response = await InvokeHttpClientAsync<XGMediaListWatermarksResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 删除水印
        /// <para>接口文档：https://cloud.baidu.com/doc/MCT/s/Sjwvz5isl#%E5%88%A0%E9%99%A4%E6%B0%B4%E5%8D%B0 </para>
        /// </summary>
        /// <param name="watermarkId">水印的唯一标识</param>
        //// <returns>XGMediaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGMediaResponse DeleteWatermark(string watermarkId)
        {
            AssertStringNotNullOrEmpty(watermarkId, nameof(watermarkId));

            XGMediaDeleteWatermarkRequest request = new XGMediaDeleteWatermarkRequest()
            {
                WatermarkId = watermarkId
            };
            return DeleteWatermark(request);
        }

        /// <summary>
        /// 删除水印
        /// </summary>
        /// <param name="watermarkId">水印的唯一标识</param>
        //// <returns>异步任务XGMediaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGMediaResponse> DeleteWatermarkAsync(string watermarkId)
        {
            AssertStringNotNullOrEmpty(watermarkId, nameof(watermarkId));

            XGMediaDeleteWatermarkRequest request = new XGMediaDeleteWatermarkRequest()
            {
                WatermarkId = watermarkId
            };
            return await DeleteWatermarkAsync(request);
        }

        /// <summary>
        /// 删除水印
        /// <para>接口文档：https://cloud.baidu.com/doc/MCT/s/Sjwvz5isl#%E5%88%A0%E9%99%A4%E6%B0%B4%E5%8D%B0 </para>
        /// </summary>
        /// <param name="request">XGMediaDeleteWatermarkRequest</param>
        /// <returns>XGMediaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGMediaResponse DeleteWatermark(XGMediaDeleteWatermarkRequest request)
        {
            AssertNotNullOrEmpty(request,nameof(request));
            AssertStringNotNullOrEmpty(request.WatermarkId, nameof(request.WatermarkId));

            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.DELETE, request.MediaVersion.ToString(), WATERMARK, request.WatermarkId.Trim());
            XGMediaQueryWatermarkResponse response = InvokeHttpClient<XGMediaQueryWatermarkResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 删除水印
        /// </summary>
        /// <param name="request">XGMediaDeleteWatermarkRequest</param>
        /// <returns>异步任务XGMediaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGMediaResponse> DeleteWatermarkAsync(XGMediaDeleteWatermarkRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.WatermarkId, nameof(request.WatermarkId));

            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.DELETE, request.MediaVersion.ToString(), WATERMARK, request.WatermarkId.Trim());
            XGMediaQueryWatermarkResponse response = await InvokeHttpClientAsync<XGMediaQueryWatermarkResponse>(iternalRequest);
            return response;
        }

        #endregion

        #region 缩略图模板接口

        /// <summary>
        /// 创建缩略图模板
        /// <para>接口文档：https://cloud.baidu.com/doc/MCT/s/tkb8t1775#%E5%88%9B%E5%BB%BA%E7%BC%A9%E7%95%A5%E5%9B%BE%E6%A8%A1%E6%9D%BF </para>
        /// </summary>
        /// <param name="presetName">缩略图模板名称</param>
        /// <param name="description">缩略图模板描述</param>
        /// <returns>XGMediaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGMediaResponse CreateThumbnailPreset(string presetName, string description=null)
        {
            AssertStringNotNullOrEmpty(presetName, nameof(presetName));

            XGMediaCreateThumbnailPresetRequest request = new XGMediaCreateThumbnailPresetRequest()
            {
                PresetName=presetName,
                Description=description
            };
            return CreateThumbnailPreset(request);
        }

        /// <summary>
        /// 创建缩略图模板
        /// </summary>
        /// <param name="presetName">缩略图模板名称</param>
        /// <param name="description">缩略图模板描述</param>
        /// <returns>异步任务XGMediaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGMediaResponse> CreateThumbnailPresetAsync(string presetName, string description = null)
        {
            AssertStringNotNullOrEmpty(presetName, nameof(presetName));

            XGMediaCreateThumbnailPresetRequest request = new XGMediaCreateThumbnailPresetRequest()
            {
                PresetName = presetName,
                Description = description
            };
            return await CreateThumbnailPresetAsync(request);
        }

        /// <summary>
        /// 创建缩略图模板
        /// <para>接口文档：https://cloud.baidu.com/doc/MCT/s/tkb8t1775#%E5%88%9B%E5%BB%BA%E7%BC%A9%E7%95%A5%E5%9B%BE%E6%A8%A1%E6%9D%BF </para>
        /// </summary>
        /// <param name="request">XGMediaCreateThumbnailPresetRequest</param>
        /// <returns>XGMediaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGMediaResponse CreateThumbnailPreset(XGMediaCreateThumbnailPresetRequest request)
        {
            AssertNotNullOrEmpty(request,nameof(request));
            AssertStringNotNullOrEmpty(request.PresetName, nameof(request.PresetName));

            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.POST, request.MediaVersion.ToString(), PRESET,THUMBNAIL);
            XGMediaResponse response = InvokeHttpClient<XGMediaResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 创建缩略图模板
        /// </summary>
        /// <param name="request">XGMediaCreateThumbnailPresetRequest</param>
        /// <returns>异步任务XGMediaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGMediaResponse> CreateThumbnailPresetAsync(XGMediaCreateThumbnailPresetRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.PresetName, nameof(request.PresetName));

            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.POST, request.MediaVersion.ToString(), PRESET, THUMBNAIL);
            XGMediaResponse response = await InvokeHttpClientAsync<XGMediaResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询指定模板
        /// <para>接口文档：https://cloud.baidu.com/doc/MCT/s/tkb8t1775#%E6%9F%A5%E8%AF%A2%E6%8C%87%E5%AE%9A%E6%A8%A1%E6%9D%BF </para>
        /// </summary>
        /// <param name="presetName">缩略图模板名称</param>
        /// <returns>XGMediaQueryThumbnailPresetResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGMediaQueryThumbnailPresetResponse QueryThumbnailPreset(string presetName)
        {
            AssertStringNotNullOrEmpty(presetName, nameof(presetName));

            XGMediaQueryThumbnailPresetRequest request = new XGMediaQueryThumbnailPresetRequest()
            {
                PresetName=presetName
            };
            return QueryThumbnailPreset(request);
        }

        /// <summary>
        /// 查询指定模板
        /// </summary>
        /// <param name="presetName">缩略图模板名称</param>
        /// <returns>异步任务XGMediaQueryThumbnailPresetResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGMediaQueryThumbnailPresetResponse> QueryThumbnailPresetAsync(string presetName)
        {
            AssertStringNotNullOrEmpty(presetName, nameof(presetName));

            XGMediaQueryThumbnailPresetRequest request = new XGMediaQueryThumbnailPresetRequest()
            {
                PresetName = presetName
            };
            return await QueryThumbnailPresetAsync(request);
        }

        /// <summary>
        /// 查询指定模板
        /// <para>接口文档：https://cloud.baidu.com/doc/MCT/s/tkb8t1775#%E6%9F%A5%E8%AF%A2%E6%8C%87%E5%AE%9A%E6%A8%A1%E6%9D%BF </para>
        /// </summary>
        /// <param name="request">XGMediaQueryThumbnailPresetRequest</param>
        /// <returns>XGMediaQueryThumbnailPresetResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGMediaQueryThumbnailPresetResponse QueryThumbnailPreset(XGMediaQueryThumbnailPresetRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.PresetName, nameof(request.PresetName));

            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.MediaVersion.ToString(), PRESET, THUMBNAIL,request.PresetName.Trim());
            XGMediaQueryThumbnailPresetResponse response = InvokeHttpClient<XGMediaQueryThumbnailPresetResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询指定模板
        /// </summary>
        /// <param name="request">XGMediaQueryThumbnailPresetRequest</param>
        /// <returns>异步任务XGMediaQueryThumbnailPresetResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGMediaQueryThumbnailPresetResponse> QueryThumbnailPresetAsync(XGMediaQueryThumbnailPresetRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.PresetName, nameof(request.PresetName));

            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.MediaVersion.ToString(), PRESET, THUMBNAIL, request.PresetName.Trim());
            XGMediaQueryThumbnailPresetResponse response = await InvokeHttpClientAsync<XGMediaQueryThumbnailPresetResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 删除指定缩略图模板
        /// <para>接口文档：https://cloud.baidu.com/doc/MCT/s/tkb8t1775#%E5%88%A0%E9%99%A4%E6%8C%87%E5%AE%9A%E7%BC%A9%E7%95%A5%E5%9B%BE%E6%A8%A1%E6%9D%BF </para>
        /// </summary>
        /// <param name="presetName">缩略图模板名称</param>
        /// <returns>XGMediaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGMediaResponse DeleteThumbnailPreset(string presetName)
        {
            AssertStringNotNullOrEmpty(presetName, nameof(presetName));

            XGMediaDeleteThumbnailPresetRequest request = new XGMediaDeleteThumbnailPresetRequest()
            {
                PresetName=presetName
            };
            return DeleteThumbnailPreset(request);
        }

        /// <summary>
        /// 删除指定缩略图模板
        /// </summary>
        /// <param name="presetName">缩略图模板名称</param>
        /// <returns>异步任务XGMediaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGMediaResponse> DeleteThumbnailPresetAsync(string presetName)
        {
            AssertStringNotNullOrEmpty(presetName, nameof(presetName));

            XGMediaDeleteThumbnailPresetRequest request = new XGMediaDeleteThumbnailPresetRequest()
            {
                PresetName = presetName
            };
            return await DeleteThumbnailPresetAsync(request);
        }

        /// <summary>
        /// 删除指定缩略图模板
        /// <para>接口文档：https://cloud.baidu.com/doc/MCT/s/tkb8t1775#%E5%88%A0%E9%99%A4%E6%8C%87%E5%AE%9A%E7%BC%A9%E7%95%A5%E5%9B%BE%E6%A8%A1%E6%9D%BF </para>
        /// </summary>
        /// <param name="request">XGMediaDeleteThumbnailPresetRequest</param>
        /// <returns>XGMediaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGMediaResponse DeleteThumbnailPreset(XGMediaDeleteThumbnailPresetRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.PresetName, nameof(request.PresetName));

            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.DELETE, request.MediaVersion.ToString(), PRESET, THUMBNAIL, request.PresetName.Trim());
            XGMediaResponse response = InvokeHttpClient<XGMediaResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 删除指定缩略图模板
        /// </summary>
        /// <param name="request">XGMediaDeleteThumbnailPresetRequest</param>
        /// <returns>异步任务XGMediaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGMediaResponse> DeleteThumbnailPresetAsync(XGMediaDeleteThumbnailPresetRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.PresetName, nameof(request.PresetName));

            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.DELETE, request.MediaVersion.ToString(), PRESET, THUMBNAIL, request.PresetName.Trim());
            XGMediaResponse response = await InvokeHttpClientAsync<XGMediaResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 更新缩略图模板
        /// <para>接口文档：https://cloud.baidu.com/doc/MCT/s/tkb8t1775#%E6%9B%B4%E6%96%B0%E6%8C%87%E5%AE%9A%E6%A8%A1%E6%9D%BF </para>
        /// </summary>
        /// <param name="presetName">缩略图模板名称</param>
        /// <param name="description">缩略图模板描述</param>
        /// <returns>XGMediaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGMediaResponse UpdateThumbnailPreset(string presetName, string description=null)
        {
            AssertStringNotNullOrEmpty(presetName, nameof(presetName));

            XGMediaUpdateThumbnailPresetRequest request = new XGMediaUpdateThumbnailPresetRequest()
            {
                PresetName=presetName,
                Description=description
            };
            return UpdateThumbnailPreset(request);
        }

        /// <summary>
        /// 更新缩略图模板
        /// </summary>
        /// <param name="presetName">缩略图模板名称</param>
        /// <param name="description">缩略图模板描述</param>
        /// <returns>异步任务XGMediaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGMediaResponse> UpdateThumbnailPresetAsync(string presetName, string description = null)
        {
            AssertStringNotNullOrEmpty(presetName, nameof(presetName));

            XGMediaUpdateThumbnailPresetRequest request = new XGMediaUpdateThumbnailPresetRequest()
            {
                PresetName = presetName,
                Description = description
            };
            return await UpdateThumbnailPresetAsync(request);
        }

        /// <summary>
        /// 更新缩略图模板
        /// <para>接口文档：https://cloud.baidu.com/doc/MCT/s/tkb8t1775#%E6%9B%B4%E6%96%B0%E6%8C%87%E5%AE%9A%E6%A8%A1%E6%9D%BF </para>
        /// </summary>
        /// <param name="request">XGMediaUpdateThumbnailPresetRequest</param>
        /// <returns>XGMediaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGMediaResponse UpdateThumbnailPreset(XGMediaUpdateThumbnailPresetRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.PresetName, nameof(request.PresetName));

            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.PUT, request.MediaVersion.ToString(), PRESET, THUMBNAIL,request.PresetName.Trim());
            XGMediaResponse response = InvokeHttpClient<XGMediaResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 更新缩略图模板
        /// </summary>
        /// <param name="request">XGMediaUpdateThumbnailPresetRequest</param>
        /// <returns>异步任务XGMediaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGMediaResponse> UpdateThumbnailPresetAsync(XGMediaUpdateThumbnailPresetRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.PresetName, nameof(request.PresetName));

            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.PUT, request.MediaVersion.ToString(), PRESET, THUMBNAIL, request.PresetName.Trim());
            XGMediaResponse response = await InvokeHttpClientAsync<XGMediaResponse>(iternalRequest);
            return response;
        }

        #endregion

        #region 缩略图任务接口

        /// <summary>
        /// 创建缩略图任务
        /// <para>接口文档：https://cloud.baidu.com/doc/MCT/s/Ojwvz5fo4#%E5%88%9B%E5%BB%BA%E7%BC%A9%E7%95%A5%E5%9B%BE%E4%BB%BB%E5%8A%A1 </para>
        /// </summary>
        /// <param name="request">XGMediaCreateThumbnailJobRequest</param>
        /// <returns>XGMediaCreateThumbnailJobResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGMediaCreateThumbnailJobResponse CreateThumbnailJob(XGMediaCreateThumbnailJobRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.PipelineName, nameof(request.PipelineName));
            if (request.Source == null)
            {
                throw new ArgumentNullException(nameof(request.Source), "request.Source 不能为空");
            }
            else
            {
                AssertStringNotNullOrEmpty(request.Source.Key,nameof(request.Source.Key));
            }
            if (request.DelogoArea != null)
            {
                if(request.DelogoArea.HasNullProperty())
                    throw new ArgumentNullException(nameof(request.DelogoArea),"request.DelogoArea的属性 不能为空");
                if(request.DelogoAreas!=null&&request.DelogoAreas.Count>0)
                    throw new ArgumentException("DelogoArea和DelogoAreas不能同时指定");
            }
            if (request.DelogoAreas != null && request.DelogoAreas.Count > 0)
                request.DelogoAreas.ForEach((x)=> { if(x.HasNullProperty()) throw new ArgumentNullException(nameof(request.DelogoAreas),"request.DelogoAreas的属性 不能为空"); });

            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.POST, request.MediaVersion.ToString(), JOB, THUMBNAIL);
            XGMediaCreateThumbnailJobResponse response = InvokeHttpClient<XGMediaCreateThumbnailJobResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 创建缩略图任务
        /// </summary>
        /// <param name="request">XGMediaCreateThumbnailJobRequest</param>
        /// <returns>异步任务XGMediaCreateThumbnailJobResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGMediaCreateThumbnailJobResponse> CreateThumbnailJobAsync(XGMediaCreateThumbnailJobRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.PipelineName, nameof(request.PipelineName));
            if (request.Source == null)
            {
                throw new ArgumentNullException(nameof(request.Source), "request.Source 不能为空");
            }
            else
            {
                AssertStringNotNullOrEmpty(request.Source.Key, nameof(request.Source.Key));
            }
            if (request.DelogoArea != null)
            {
                if (request.DelogoArea.HasNullProperty())
                    throw new ArgumentNullException(nameof(request.DelogoArea), "request.DelogoArea的属性 不能为空");
                if (request.DelogoAreas != null && request.DelogoAreas.Count > 0)
                    throw new ArgumentException("DelogoArea和DelogoAreas不能同时指定");
            }
            if (request.DelogoAreas != null && request.DelogoAreas.Count > 0)
                request.DelogoAreas.ForEach((x) => { if (x.HasNullProperty()) throw new ArgumentNullException(nameof(request.DelogoAreas), "request.DelogoAreas的属性 不能为空"); });

            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.POST, request.MediaVersion.ToString(), JOB, THUMBNAIL);
            XGMediaCreateThumbnailJobResponse response = await InvokeHttpClientAsync<XGMediaCreateThumbnailJobResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询指定缩略图任务
        /// <para>接口文档：https://cloud.baidu.com/doc/MCT/s/Ojwvz5fo4#%E6%9F%A5%E8%AF%A2%E6%8C%87%E5%AE%9A%E7%BC%A9%E7%95%A5%E5%9B%BE%E4%BB%BB%E5%8A%A1 </para>
        /// </summary>
        /// <param name="jobId">任务ID</param>
        /// <returns>XGMediaQueryThumbnailJobResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGMediaQueryThumbnailJobResponse QueryThumbnailJob(string jobId)
        {
            AssertStringNotNullOrEmpty(jobId,nameof(jobId));

            XGMediaQueryThumbnailJobRequest request = new XGMediaQueryThumbnailJobRequest()
            {
                JobId=jobId
            };
            return QueryThumbnailJob(request);
        }

        /// <summary>
        /// 查询指定缩略图任务
        /// </summary>
        /// <param name="jobId">任务ID</param>
        /// <returns>异步任务XGMediaQueryThumbnailJobResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGMediaQueryThumbnailJobResponse> QueryThumbnailJobAsync(string jobId)
        {
            AssertStringNotNullOrEmpty(jobId, nameof(jobId));

            XGMediaQueryThumbnailJobRequest request = new XGMediaQueryThumbnailJobRequest()
            {
                JobId = jobId
            };
            return await QueryThumbnailJobAsync(request);
        }

        /// <summary>
        /// 查询指定缩略图任务
        /// <para>接口文档：https://cloud.baidu.com/doc/MCT/s/Ojwvz5fo4#%E6%9F%A5%E8%AF%A2%E6%8C%87%E5%AE%9A%E7%BC%A9%E7%95%A5%E5%9B%BE%E4%BB%BB%E5%8A%A1 </para>
        /// </summary>
        /// <param name="request">XGMediaQueryThumbnailJobRequest</param>
        /// <returns>XGMediaQueryThumbnailJobResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGMediaQueryThumbnailJobResponse QueryThumbnailJob(XGMediaQueryThumbnailJobRequest request)
        {
            AssertNotNullOrEmpty(request,nameof(request));
            AssertStringNotNullOrEmpty(request.JobId, nameof(request.JobId));

            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.MediaVersion.ToString(), JOB, THUMBNAIL,request.JobId.Trim());
            XGMediaQueryThumbnailJobResponse response = InvokeHttpClient<XGMediaQueryThumbnailJobResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询指定缩略图任务
        /// </summary>
        /// <param name="request">XGMediaQueryThumbnailJobRequest</param>
        /// <returns>异步任务XGMediaQueryThumbnailJobResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGMediaQueryThumbnailJobResponse> QueryThumbnailJobAsync(XGMediaQueryThumbnailJobRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.JobId, nameof(request.JobId));

            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.MediaVersion.ToString(), JOB, THUMBNAIL, request.JobId.Trim());
            XGMediaQueryThumbnailJobResponse response = await InvokeHttpClientAsync<XGMediaQueryThumbnailJobResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询指定队列的缩略图任务信息
        /// <para>接口文档：https://cloud.baidu.com/doc/MCT/s/Ojwvz5fo4#%E6%9F%A5%E8%AF%A2%E6%8C%87%E5%AE%9A%E9%98%9F%E5%88%97%E7%9A%84%E7%BC%A9%E7%95%A5%E5%9B%BE%E4%BB%BB%E5%8A%A1%E4%BF%A1%E6%81%AF </para>
        /// </summary>
        /// <param name="pipelineName">任务所属的队列名</param>
        /// <param name="jobStatus">所选任务的状态</param>
        /// <param name="begin">任务创建时间的上限。所选任务开始时间要大于等于begin</param>
        /// <param name="end">任务创建时间的下限，所选任务开始时间要小于等于end</param>
        /// <param name="marker">本次请求的marker，标记查询的起始位置，此处为jobId</param>
        /// <param name="maxSize">本次请求返回的任务列表的最大元素个数</param>
        /// <returns>XGMediaQueryPipelineThumbnailJobResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGMediaQueryPipelineThumbnailJobResponse QueryPipelineThumbnailJob(string pipelineName, XGMediaJobStatus? jobStatus=null,
            DateTime? begin=null, DateTime? end=null, string marker=null, int? maxSize=null)
        {
            AssertStringNotNullOrEmpty(pipelineName,nameof(pipelineName));

            XGMediaQueryPipelineThumbnailJobRequest request = new XGMediaQueryPipelineThumbnailJobRequest()
            {
                PipelineName=pipelineName,
                JobStatus=jobStatus,
                Begin=begin,
                End=end,
                Marker=marker,
                MaxSize=maxSize
            };
            return QueryPipelineThumbnailJob(request);
        }

        /// <summary>
        /// 查询指定队列的缩略图任务信息
        /// </summary>
        /// <param name="pipelineName">任务所属的队列名</param>
        /// <param name="jobStatus">所选任务的状态</param>
        /// <param name="begin">任务创建时间的上限。所选任务开始时间要大于等于begin</param>
        /// <param name="end">任务创建时间的下限，所选任务开始时间要小于等于end</param>
        /// <param name="marker">本次请求的marker，标记查询的起始位置，此处为jobId</param>
        /// <param name="maxSize">本次请求返回的任务列表的最大元素个数</param>
        /// <returns>异步任务XGMediaQueryPipelineThumbnailJobResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGMediaQueryPipelineThumbnailJobResponse> QueryPipelineThumbnailJobAsync(string pipelineName, XGMediaJobStatus? jobStatus = null,
            DateTime? begin = null, DateTime? end = null, string marker = null, int? maxSize = null)
        {
            AssertStringNotNullOrEmpty(pipelineName, nameof(pipelineName));

            XGMediaQueryPipelineThumbnailJobRequest request = new XGMediaQueryPipelineThumbnailJobRequest()
            {
                PipelineName = pipelineName,
                JobStatus = jobStatus,
                Begin = begin,
                End = end,
                Marker = marker,
                MaxSize = maxSize
            };
            return await QueryPipelineThumbnailJobAsync(request);
        }

        /// <summary>
        /// 查询指定队列的缩略图任务信息
        /// <para>接口文档：https://cloud.baidu.com/doc/MCT/s/Ojwvz5fo4#%E6%9F%A5%E8%AF%A2%E6%8C%87%E5%AE%9A%E9%98%9F%E5%88%97%E7%9A%84%E7%BC%A9%E7%95%A5%E5%9B%BE%E4%BB%BB%E5%8A%A1%E4%BF%A1%E6%81%AF </para>
        /// </summary>
        /// <param name="request">XGMediaQueryPipelineThumbnailJobRequest</param>
        /// <returns>XGMediaQueryPipelineThumbnailJobResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGMediaQueryPipelineThumbnailJobResponse QueryPipelineThumbnailJob(XGMediaQueryPipelineThumbnailJobRequest request)
        {
            AssertNotNullOrEmpty(request,nameof(request));
            AssertStringNotNullOrEmpty(request.PipelineName, nameof(request.PipelineName));

            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.MediaVersion.ToString(), JOB, THUMBNAIL);
            iternalRequest.AddParameter("pipelineName", request.PipelineName);
            if (request.JobStatus != null)
                iternalRequest.AddParameter("jobStatus",request.JobStatus.Value.ToString());
            if (request.Begin!=null)
                iternalRequest.AddParameter("begin",request.Begin.Value.ToString("yyyy-MM-dd'T'HH:mm:ss'Z'"));
            if (request.End != null)
                iternalRequest.AddParameter("end", request.End.Value.ToString("yyyy-MM-dd'T'HH:mm:ss'Z'"));
            if (string.IsNullOrEmpty(request.Marker) || string.IsNullOrWhiteSpace(request.Marker))
                iternalRequest.AddParameter("marker",request.Marker.Trim());
            if (request.MaxSize != null)
                iternalRequest.AddParameter("maxSize",request.MaxSize.Value.ToString());
            XGMediaQueryPipelineThumbnailJobResponse response = InvokeHttpClient<XGMediaQueryPipelineThumbnailJobResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询指定队列的缩略图任务信息
        /// </summary>
        /// <param name="request">XGMediaQueryPipelineThumbnailJobRequest</param>
        /// <returns>异步任务XGMediaQueryPipelineThumbnailJobResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGMediaQueryPipelineThumbnailJobResponse> QueryPipelineThumbnailJobAsync(XGMediaQueryPipelineThumbnailJobRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.PipelineName, nameof(request.PipelineName));

            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.MediaVersion.ToString(), JOB, THUMBNAIL);
            iternalRequest.AddParameter("pipelineName", request.PipelineName);
            if (request.JobStatus != null)
                iternalRequest.AddParameter("jobStatus", request.JobStatus.Value.ToString());
            if (request.Begin != null)
                iternalRequest.AddParameter("begin", request.Begin.Value.ToString("yyyy-MM-dd'T'HH:mm:ss'Z'"));
            if (request.End != null)
                iternalRequest.AddParameter("end", request.End.Value.ToString("yyyy-MM-dd'T'HH:mm:ss'Z'"));
            if (string.IsNullOrEmpty(request.Marker) || string.IsNullOrWhiteSpace(request.Marker))
                iternalRequest.AddParameter("marker", request.Marker.Trim());
            if (request.MaxSize != null)
                iternalRequest.AddParameter("maxSize", request.MaxSize.Value.ToString());
            XGMediaQueryPipelineThumbnailJobResponse response = await InvokeHttpClientAsync<XGMediaQueryPipelineThumbnailJobResponse>(iternalRequest);
            return response;
        }

        #endregion

        #region 视频质量检测模板接口

        #endregion

        #region 视频质量检测任务接口

        #endregion

        #region 通知接口

        /// <summary>
        /// 创建通知
        /// <para>接口文档：https://cloud.baidu.com/doc/MCT/s/7jwvz5gew#%E5%88%9B%E5%BB%BA%E9%80%9A%E7%9F%A5 </para>
        /// </summary>
        /// <param name="name">通知名称</param>
        /// <param name="endpoint">通知消息接收地址</param>
        /// <param name="type">通知消息类型</param>
        /// <param name="token">通知消息鉴权</param>
        /// <returns>XGMediaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGMediaResponse CreateNotification(string name, string endpoint, XGMediaNotificationType? type=null, string token=null)
        {
            AssertStringNotNullOrEmpty(name,nameof(name));
            AssertStringNotNullOrEmpty(endpoint,nameof(endpoint));

            XGMediaCreateNotificationRequest request = new XGMediaCreateNotificationRequest()
            {
                Name=name,
                Endpoint=endpoint
            };
            return CreateNotification(request);
        }

        /// <summary>
        /// 创建通知
        /// </summary>
        /// <param name="name">通知名称</param>
        /// <param name="endpoint">通知消息接收地址</param>
        /// <param name="type">通知消息类型</param>
        /// <param name="token">通知消息鉴权</param>
        /// <returns>异步任务XGMediaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGMediaResponse> CreateNotificationAsync(string name, string endpoint, XGMediaNotificationType? type = null, string token = null)
        {
            AssertStringNotNullOrEmpty(name, nameof(name));
            AssertStringNotNullOrEmpty(endpoint, nameof(endpoint));

            XGMediaCreateNotificationRequest request = new XGMediaCreateNotificationRequest()
            {
                Name = name,
                Endpoint = endpoint
            };
            return await CreateNotificationAsync(request);
        }

        /// <summary>
        /// 创建通知
        /// <para>接口文档：https://cloud.baidu.com/doc/MCT/s/7jwvz5gew#%E5%88%9B%E5%BB%BA%E9%80%9A%E7%9F%A5 </para>
        /// </summary>
        /// <param name="request">XGMediaCreateNotificationRequest</param>
        /// <returns>XGMediaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGMediaResponse CreateNotification(XGMediaCreateNotificationRequest request)
        {
            AssertNotNullOrEmpty(request,nameof(request));
            AssertStringNotNullOrEmpty(request.Name, nameof(request.Name));
            AssertStringNotNullOrEmpty(request.Endpoint, nameof(request.Endpoint));

            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.POST, request.MediaVersion.ToString(), NOTIFICATION);
            XGMediaResponse response = InvokeHttpClient<XGMediaResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 创建通知
        /// </summary>
        /// <param name="request">XGMediaCreateNotificationRequest</param>
        /// <returns>异步任务XGMediaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGMediaResponse> CreateNotificationAsync(XGMediaCreateNotificationRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.Name, nameof(request.Name));
            AssertStringNotNullOrEmpty(request.Endpoint, nameof(request.Endpoint));

            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.POST, request.MediaVersion.ToString(), NOTIFICATION);
            XGMediaResponse response = await InvokeHttpClientAsync<XGMediaResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询通知
        /// <para>接口文档：https://cloud.baidu.com/doc/MCT/s/7jwvz5gew#%E6%9F%A5%E8%AF%A2%E9%80%9A%E7%9F%A5 </para>
        /// </summary>
        /// <param name="name">通知名称</param>
        /// <returns>XGMediaQueryNotificationResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGMediaQueryNotificationResponse QueryNotification(string name)
        {
            AssertStringNotNullOrEmpty(name,nameof(name));

            XGMediaQueryNotificationRequest request = new XGMediaQueryNotificationRequest()
            {
                Name=name
            };
            return QueryNotification(request);
        }

        /// <summary>
        /// 查询通知
        /// </summary>
        /// <param name="name">通知名称</param>
        /// <returns>异步任务XGMediaQueryNotificationResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGMediaQueryNotificationResponse> QueryNotificationAsync(string name)
        {
            AssertStringNotNullOrEmpty(name, nameof(name));

            XGMediaQueryNotificationRequest request = new XGMediaQueryNotificationRequest()
            {
                Name = name
            };
            return await QueryNotificationAsync(request);
        }

        /// <summary>
        /// 查询通知
        /// <para>接口文档：https://cloud.baidu.com/doc/MCT/s/7jwvz5gew#%E6%9F%A5%E8%AF%A2%E9%80%9A%E7%9F%A5 </para>
        /// </summary>
        /// <param name="request">XGMediaQueryNotificationRequest</param>
        /// <returns>XGMediaQueryNotificationResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGMediaQueryNotificationResponse QueryNotification(XGMediaQueryNotificationRequest request)
        {
            AssertNotNullOrEmpty(request,nameof(request));
            AssertStringNotNullOrEmpty(request.Name, nameof(request.Name));

            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.MediaVersion.ToString(), NOTIFICATION,request.Name.Trim());
            XGMediaQueryNotificationResponse response = InvokeHttpClient<XGMediaQueryNotificationResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询通知
        /// <para>接口文档：https://cloud.baidu.com/doc/MCT/s/7jwvz5gew#%E6%9F%A5%E8%AF%A2%E9%80%9A%E7%9F%A5 </para>
        /// </summary>
        /// <param name="request">XGMediaQueryNotificationRequest</param>
        /// <returns>异步任务XGMediaQueryNotificationResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGMediaQueryNotificationResponse> QueryNotificationAsync(XGMediaQueryNotificationRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.Name, nameof(request.Name));

            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.MediaVersion.ToString(), NOTIFICATION,request.Name.Trim());
            XGMediaQueryNotificationResponse response = await InvokeHttpClientAsync<XGMediaQueryNotificationResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 删除通知
        /// <para>接口文档：https://cloud.baidu.com/doc/MCT/s/7jwvz5gew#%E5%88%A0%E9%99%A4%E9%80%9A%E7%9F%A5 </para>
        /// </summary>
        /// <param name="name">通知名称</param>
        /// <returns>XGMediaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGMediaResponse DeleteNotification(string name)
        {
            AssertStringNotNullOrEmpty(name, nameof(name));

            XGMediaDeleteNotificationRequest request = new XGMediaDeleteNotificationRequest()
            {
                Name=name
            };
            return DeleteNotification(request);
        }

        /// <summary>
        /// 删除通知
        /// </summary>
        /// <param name="name">通知名称</param>
        /// <returns>异步任务XGMediaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGMediaResponse> DeleteNotificationAsync(string name)
        {
            AssertStringNotNullOrEmpty(name, nameof(name));

            XGMediaDeleteNotificationRequest request = new XGMediaDeleteNotificationRequest()
            {
                Name = name
            };
            return await DeleteNotificationAsync(request);
        }

        /// <summary>
        /// 删除通知
        /// <para>接口文档：https://cloud.baidu.com/doc/MCT/s/7jwvz5gew#%E5%88%A0%E9%99%A4%E9%80%9A%E7%9F%A5 </para>
        /// </summary>
        /// <param name="request">XGMediaDeleteNotificationRequest</param>
        /// <returns>XGMediaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGMediaResponse DeleteNotification(XGMediaDeleteNotificationRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.Name, nameof(request.Name));

            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.DELETE, request.MediaVersion.ToString(), NOTIFICATION, request.Name.Trim());
            XGMediaResponse response = InvokeHttpClient<XGMediaResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 删除通知
        /// </summary>
        /// <param name="request">XGMediaDeleteNotificationRequest</param>
        /// <returns>异步任务XGMediaResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGMediaResponse> DeleteNotificationAsync(XGMediaDeleteNotificationRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.Name, nameof(request.Name));

            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.DELETE, request.MediaVersion.ToString(), NOTIFICATION, request.Name.Trim());
            XGMediaResponse response = await InvokeHttpClientAsync<XGMediaResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 列举通知
        /// <para>接口文档：https://cloud.baidu.com/doc/MCT/s/7jwvz5gew#%E9%80%9A%E7%9F%A5%E5%88%97%E8%A1%A8 </para>
        /// </summary>
        /// <returns>XGMediaListNotificationsResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGMediaListNotificationsResponse ListNotifications()
        {
            XGMediaBaseRequest request = new XGMediaBaseRequest();

            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.MediaVersion.ToString(), NOTIFICATION);
            XGMediaListNotificationsResponse response = InvokeHttpClient<XGMediaListNotificationsResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 列举通知
        /// </summary>
        /// <returns>异步任务XGMediaListNotificationsResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGMediaListNotificationsResponse> ListNotificationsAsync()
        {
            XGMediaBaseRequest request = new XGMediaBaseRequest();

            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.MediaVersion.ToString(), NOTIFICATION);
            XGMediaListNotificationsResponse response = await InvokeHttpClientAsync<XGMediaListNotificationsResponse>(iternalRequest);
            return response;
        }

        #endregion

        #region 通用请求方法
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
