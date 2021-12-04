using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using XGBceDotNetSDK.BaseClass;
using XGBceDotNetSDK.Http;
using XGBceDotNetSDK.Services.DOC.Model;
using XGBceDotNetSDK.Utils;

namespace XGBceDotNetSDK.Services.DOC
{
    /// <summary>
    /// 文档服务DOC客户端类
    /// <para>接口文档：https://cloud.baidu.com/doc/DOC/s/Cjwvypy6e </para>
    /// </summary>
    public class XGDocClient: XGAbstractBceClient
    {
        private readonly string Document = "document";
        public XGDocClient() : this(new XGBceClientConfiguration()) { }

        public XGDocClient(XGBceClientConfiguration configuration) : base(configuration){}


        /// <summary>
        /// 注册文档
        /// <para>注册文档接口用于生成文档的唯一标识documentId、用于存储源文档文件的BOS Bucket相关信息。注册成功后，对应文档状态为UPLOADING，对应Bucket对用户开放写权限，对于用户的BOS空间不可见。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/DOC/s/Zjwvypwpy#%E6%B3%A8%E5%86%8C%E6%96%87%E6%A1%A3 </para>
        /// </summary>
        /// <param name="title">文档标题，不超过50字符</param>
        /// <param name="format">文档格式</param>
        /// <param name="targetType">转码结果类型</param>
        /// <param name="notification">通知名称</param>
        /// <param name="access">文档权限</param>
        /// <returns>XGDocRegisterDocumentResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGDocRegisterDocumentResponse RegisterDocument(string title, XGDocFileFormat format,XGDocTargetType? targetType=null, string notification=null, XGDocAccess? access=null)
        {
            if (string.IsNullOrEmpty(title) || string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException("title 不能为空");
            XGDocRegisterDocumentRequest request = new XGDocRegisterDocumentRequest()
            {
                Title=title,
                Format=format,
                TargetType=targetType,
                Notification=notification,
                Access=access
            };
            return RegisterDocument(request);
        }

        /// <summary>
        /// 注册文档
        /// <para>注册文档接口用于生成文档的唯一标识documentId、用于存储源文档文件的BOS Bucket相关信息。注册成功后，对应文档状态为UPLOADING，对应Bucket对用户开放写权限，对于用户的BOS空间不可见。</para>
        /// </summary>
        /// <param name="title">文档标题，不超过50字符</param>
        /// <param name="format">文档格式</param>
        /// <param name="targetType">转码结果类型</param>
        /// <param name="notification">通知名称</param>
        /// <param name="access">文档权限</param>
        /// <returns>异步任务XGDocRegisterDocumentResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGDocRegisterDocumentResponse> RegisterDocumentAsync(string title, XGDocFileFormat format, XGDocTargetType? targetType = null, string notification = null, XGDocAccess? access = null)
        {
            if (string.IsNullOrEmpty(title) || string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException("title 不能为空");
            XGDocRegisterDocumentRequest request = new XGDocRegisterDocumentRequest()
            {
                Title = title,
                Format = format,
                TargetType = targetType,
                Notification = notification,
                Access = access
            };
            return await RegisterDocumentAsync(request);
        }

        /// <summary>
        /// 注册文档
        /// <para>注册文档接口用于生成文档的唯一标识documentId、用于存储源文档文件的BOS Bucket相关信息。注册成功后，对应文档状态为UPLOADING，对应Bucket对用户开放写权限，对于用户的BOS空间不可见。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/DOC/s/Zjwvypwpy#%E6%B3%A8%E5%86%8C%E6%96%87%E6%A1%A3 </para>
        /// </summary>
        /// <param name="request"></param>
        /// <returns>XGDocRegisterDocumentResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGDocRegisterDocumentResponse RegisterDocument(XGDocRegisterDocumentRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request 不能为空");
            }
            if (string.IsNullOrEmpty(request.Title) || string.IsNullOrWhiteSpace(request.Title))
                throw new ArgumentNullException("Title 不能为空");
            if(request.Format==null)
                throw new ArgumentNullException("Format 不能为空");
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.POST, request.DocVersion.ToString()+ Document);
            iternalRequest.AddParameter("register");
            XGDocRegisterDocumentResponse response = InvokeHttpClient<XGDocRegisterDocumentResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 注册文档
        /// <para>注册文档接口用于生成文档的唯一标识documentId、用于存储源文档文件的BOS Bucket相关信息。注册成功后，对应文档状态为UPLOADING，对应Bucket对用户开放写权限，对于用户的BOS空间不可见。</para>
        /// </summary>
        /// <param name="request"></param>
        /// <returns>异步任务XGDocRegisterDocumentResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGDocRegisterDocumentResponse> RegisterDocumentAsync(XGDocRegisterDocumentRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request 不能为空");
            }
            if (string.IsNullOrEmpty(request.Title) || string.IsNullOrWhiteSpace(request.Title))
                throw new ArgumentNullException("Title 不能为空");
            if (request.Format == null)
                throw new ArgumentNullException("Format 不能为空");
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.POST, request.DocVersion.ToString() + Document);
            iternalRequest.AddParameter("register");
            XGDocRegisterDocumentResponse response = await InvokeHttpClientAsync<XGDocRegisterDocumentResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 根据BOS Object创建文档
        /// <para>通过BOS Object路径，用从BOS导入的方法创建文档。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/DOC/s/Zjwvypwpy#%E6%A0%B9%E6%8D%AEbos-object%E5%88%9B%E5%BB%BA%E6%96%87%E6%A1%A3 </para>
        /// </summary>
        /// <param name="bucket">BOS Bucket</param>
        /// <param name="bosObject">BOS Object</param>
        /// <param name="title">文档标题，不超过50字符</param>
        /// <param name="format">文档格式<param>
        /// <param name="targetType">转码结果类型</param>
        /// <param name="notification">通知名称</param>
        /// <param name="access">文档权限</param>
        /// <returns>XGDocRegisterBosDocumentResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGDocRegisterBosDocumentResponse RegisterBosDocument(string bucket, string bosObject, string title, XGDocFileFormat? format, XGDocTargetType? targetType = null, string notification = null, XGDocAccess? access = null)
        {
            if (string.IsNullOrEmpty(bucket) || string.IsNullOrWhiteSpace(bucket))
                throw new ArgumentNullException("bucket 不能为空");
            if (string.IsNullOrEmpty(bosObject) || string.IsNullOrWhiteSpace(bosObject))
                throw new ArgumentNullException("bosObject 不能为空");
            if (string.IsNullOrEmpty(title) || string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException("title 不能为空");
            if(format==null)
                throw new ArgumentNullException("format 不能为空");
            XGDocRegisterBosDocumentRequest request = new XGDocRegisterBosDocumentRequest()
            {
                Bucket=bucket,
                BosObject=bosObject,
                Title = title,
                Format = format,
                TargetType = targetType,
                Notification = notification,
                Access = access
            };
            return RegisterBosDocument(request);
        }

        /// <summary>
        /// 根据BOS Object创建文档
        /// <para>通过BOS Object路径，用从BOS导入的方法创建文档。</para>
        /// </summary>
        /// <param name="bucket">BOS Bucket</param>
        /// <param name="bosObject">BOS Object</param>
        /// <param name="title">文档标题，不超过50字符</param>
        /// <param name="format">文档格式<param>
        /// <param name="targetType">转码结果类型</param>
        /// <param name="notification">通知名称</param>
        /// <param name="access">文档权限</param>
        /// <returns>异步任务XGDocRegisterBosDocumentResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGDocRegisterBosDocumentResponse> RegisterBosDocumentAsync(string bucket, string bosObject, string title,
            XGDocFileFormat? format, XGDocTargetType? targetType = null, string notification = null, XGDocAccess? access = null)
        {
            if (string.IsNullOrEmpty(bucket) || string.IsNullOrWhiteSpace(bucket))
                throw new ArgumentNullException("bucket 不能为空");
            if (string.IsNullOrEmpty(bosObject) || string.IsNullOrWhiteSpace(bosObject))
                throw new ArgumentNullException("bosObject 不能为空");
            if (string.IsNullOrEmpty(title) || string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException("title 不能为空");
            if (format == null)
                throw new ArgumentNullException("format 不能为空");
            XGDocRegisterBosDocumentRequest request = new XGDocRegisterBosDocumentRequest()
            {
                Bucket = bucket,
                BosObject = bosObject,
                Title = title,
                Format = format,
                TargetType = targetType,
                Notification = notification,
                Access = access
            };
            return await RegisterBosDocumentAsync(request);
        }

        /// <summary>
        /// 根据BOS Object创建文档
        /// <para>通过BOS Object路径，用从BOS导入的方法创建文档。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/DOC/s/Zjwvypwpy#%E6%A0%B9%E6%8D%AEbos-object%E5%88%9B%E5%BB%BA%E6%96%87%E6%A1%A3 </para>
        /// </summary>
        /// <param name="request"></param>
        /// <returns>XGDocRegisterBosDocumentResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGDocRegisterBosDocumentResponse RegisterBosDocument(XGDocRegisterBosDocumentRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request 不能为空");
            }
            if (string.IsNullOrEmpty(request.Bucket) || string.IsNullOrWhiteSpace(request.Bucket))
                throw new ArgumentNullException("Bucket 不能为空");
            if (string.IsNullOrEmpty(request.BosObject) || string.IsNullOrWhiteSpace(request.BosObject))
                throw new ArgumentNullException("BosObject 不能为空");
            if (string.IsNullOrEmpty(request.Title) || string.IsNullOrWhiteSpace(request.Title))
                throw new ArgumentNullException("Title 不能为空");
            if (request.Format == null)
                throw new ArgumentNullException("Format 不能为空");
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.POST, request.DocVersion.ToString(), Document);
            iternalRequest.AddParameter("source","bos");
            XGDocRegisterBosDocumentResponse response = InvokeHttpClient<XGDocRegisterBosDocumentResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 根据BOS Object创建文档
        /// <para>通过BOS Object路径，用从BOS导入的方法创建文档。</para>
        /// </summary>
        /// <param name="request"></param>
        /// <returns>异步任务XGDocRegisterBosDocumentResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGDocRegisterBosDocumentResponse> RegisterBosDocumentAsync(XGDocRegisterBosDocumentRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request 不能为空");
            }
            if (string.IsNullOrEmpty(request.Bucket) || string.IsNullOrWhiteSpace(request.Bucket))
                throw new ArgumentNullException("Bucket 不能为空");
            if (string.IsNullOrEmpty(request.BosObject) || string.IsNullOrWhiteSpace(request.BosObject))
                throw new ArgumentNullException("BosObject 不能为空");
            if (string.IsNullOrEmpty(request.Title) || string.IsNullOrWhiteSpace(request.Title))
                throw new ArgumentNullException("Title 不能为空");
            if (request.Format == null)
                throw new ArgumentNullException("Format 不能为空");
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.POST, request.DocVersion.ToString() , Document);
            iternalRequest.AddParameter("source", "bos");
            XGDocRegisterBosDocumentResponse response = await InvokeHttpClientAsync<XGDocRegisterBosDocumentResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 发布文档
        /// <para>用于对已完成注册和BOS上传的文档进行发布处理。</para>
        /// <para>仅对状态为UPLOADING的文档有效。处理过程中，文档状态为PROCESSING；处理完成后，状态转为PUBLISHED。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/DOC/s/Zjwvypwpy#%E5%8F%91%E5%B8%83%E6%96%87%E6%A1%A3 </para>
        /// </summary>
        /// <param name="documentId">系统生成的文档的唯一标识</param>
        /// <returns>XGDocResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGDocResponse PublishDocument(string documentId)
        {
            if (string.IsNullOrEmpty(documentId) || string.IsNullOrWhiteSpace(documentId))
                throw new ArgumentNullException("documentId 不能为空");
            XGDocPublishDocumentRequest request = new XGDocPublishDocumentRequest()
            {
                DocumentId=documentId
            };
            return PublishDocument(request);
        }

        /// <summary>
        /// 发布文档
        /// <para>用于对已完成注册和BOS上传的文档进行发布处理。</para>
        /// <para>仅对状态为UPLOADING的文档有效。处理过程中，文档状态为PROCESSING；处理完成后，状态转为PUBLISHED。</para>
        /// </summary>
        /// <param name="documentId">系统生成的文档的唯一标识</param>
        /// <returns>异步任务XGDocResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGDocResponse> PublishDocumentAsync(string documentId)
        {
            if (string.IsNullOrEmpty(documentId) || string.IsNullOrWhiteSpace(documentId))
                throw new ArgumentNullException("documentId 不能为空");
            XGDocPublishDocumentRequest request = new XGDocPublishDocumentRequest()
            {
                DocumentId = documentId
            };
            return await PublishDocumentAsync(request);
        }

        /// <summary>
        /// 发布文档
        /// <para>用于对已完成注册和BOS上传的文档进行发布处理。</para>
        /// <para>仅对状态为UPLOADING的文档有效。处理过程中，文档状态为PROCESSING；处理完成后，状态转为PUBLISHED。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/DOC/s/Zjwvypwpy#%E5%8F%91%E5%B8%83%E6%96%87%E6%A1%A3 </para>
        /// </summary>
        /// <param name="request">XGDocPublishDocumentRequest</param>
        /// <returns>XGDocResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGDocResponse PublishDocument(XGDocPublishDocumentRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request 不能为空");
            }
            if (string.IsNullOrEmpty(request.DocumentId) || string.IsNullOrWhiteSpace(request.DocumentId))
                throw new ArgumentNullException("DocumentId 不能为空");
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.PUT, request.DocVersion.ToString() , Document, request.DocumentId);
            iternalRequest.AddParameter("publish");
            XGDocResponse response = InvokeHttpClient<XGDocResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 发布文档
        /// <para>用于对已完成注册和BOS上传的文档进行发布处理。</para>
        /// <para>仅对状态为UPLOADING的文档有效。处理过程中，文档状态为PROCESSING；处理完成后，状态转为PUBLISHED。</para>
        /// </summary>
        /// <param name="request">XGDocPublishDocumentRequest</param>
        /// <returns>异步任务XGDocResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGDocResponse> PublishDocumentAsync(XGDocPublishDocumentRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request 不能为空");
            }
            if (string.IsNullOrEmpty(request.DocumentId) || string.IsNullOrWhiteSpace(request.DocumentId))
                throw new ArgumentNullException("DocumentId 不能为空");
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.PUT, request.DocVersion.ToString() , Document, request.DocumentId);
            iternalRequest.AddParameter("publish");
            XGDocResponse response = await InvokeHttpClientAsync<XGDocResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 重新发布文档
        /// <para>重新发布文档，仅对状态为FAILED/PUBLISHED的文档有效。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/DOC/s/Zjwvypwpy#%E9%87%8D%E6%96%B0%E5%8F%91%E5%B8%83%E6%96%87%E6%A1%A3 </para>
        /// </summary>
        /// <param name="documentId">系统生成的文档的唯一标识</param>
        /// <param name="title">文档标题，不超过50字符。</param>
        /// <param name="format">文档格式</param>
        /// <param name="targetType">转码结果类型</param>
        /// <param name="notification">通知</param>
        /// <param name="access">文档权限</param>
        /// <returns>XGDocResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGDocResponse RepublishDocument(string documentId, string title=null, XGDocFileFormat? format = null,
            XGDocTargetType? targetType = null, string notification = null, XGDocAccess? access = null)
        {
            if (string.IsNullOrEmpty(documentId) || string.IsNullOrWhiteSpace(documentId))
                throw new ArgumentNullException("documentId 不能为空");
            XGDocRepublishDocumentRequest request = new XGDocRepublishDocumentRequest()
            {
                DocumentId=documentId,
                Title=title,
                Format=format,
                TargetType=targetType,
                Notification=notification,
                Access=access
            };
            return RepublishDocument(request);
        }

        /// <summary>
        /// 重新发布文档
        /// <para>重新发布文档，仅对状态为FAILED/PUBLISHED的文档有效。</para>
        /// </summary>
        /// <param name="documentId">系统生成的文档的唯一标识</param>
        /// <param name="title">文档标题，不超过50字符。</param>
        /// <param name="format">文档格式</param>
        /// <param name="targetType">转码结果类型</param>
        /// <param name="notification">通知</param>
        /// <param name="access">文档权限</param>
        /// <returns>异步任务XGDocResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGDocResponse> RepublishDocumentAsync(string documentId, string title = null, XGDocFileFormat? format = null,
            XGDocTargetType? targetType = null, string notification = null, XGDocAccess? access = null)
        {
            if (string.IsNullOrEmpty(documentId) || string.IsNullOrWhiteSpace(documentId))
                throw new ArgumentNullException("documentId 不能为空");
            XGDocRepublishDocumentRequest request = new XGDocRepublishDocumentRequest()
            {
                DocumentId = documentId,
                Title = title,
                Format = format,
                TargetType = targetType,
                Notification = notification,
                Access = access
            };
            return await RepublishDocumentAsync(request);
        }

        /// <summary>
        /// 重新发布文档
        /// <para>重新发布文档，仅对状态为FAILED/PUBLISHED的文档有效。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/DOC/s/Zjwvypwpy#%E9%87%8D%E6%96%B0%E5%8F%91%E5%B8%83%E6%96%87%E6%A1%A3 </para>
        /// </summary>
        /// <param name="request">XGDocRepublishDocumentRequest</param>
        /// <returns>XGDocResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGDocResponse RepublishDocument(XGDocRepublishDocumentRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request 不能为空");
            }
            if (string.IsNullOrEmpty(request.DocumentId) || string.IsNullOrWhiteSpace(request.DocumentId))
                throw new ArgumentNullException("DocumentId 不能为空");
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.PUT, request.DocVersion.ToString() , Document, request.DocumentId);
            iternalRequest.AddParameter("rerun");
            XGDocResponse response = InvokeHttpClient<XGDocResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 重新发布文档
        /// <para>重新发布文档，仅对状态为FAILED/PUBLISHED的文档有效。</para>
        /// </summary>
        /// <param name="request">XGDocRepublishDocumentRequest</param>
        /// <returns>异步任务XGDocResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGDocResponse> RepublishDocumentAsync(XGDocRepublishDocumentRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request 不能为空");
            }
            if (string.IsNullOrEmpty(request.DocumentId) || string.IsNullOrWhiteSpace(request.DocumentId))
                throw new ArgumentNullException("DocumentId 不能为空");
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.PUT, request.DocVersion.ToString() , Document, request.DocumentId);
            iternalRequest.AddParameter("rerun");
            XGDocResponse response = await InvokeHttpClientAsync<XGDocResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询文档
        /// <para>通过文档的唯一标识 documentId 查询指定文档的详细信息。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/DOC/s/Zjwvypwpy#%E6%9F%A5%E8%AF%A2%E6%96%87%E6%A1%A3 </para>
        /// </summary>
        /// <param name="documentId">系统生成的文档的唯一标识</param>
        /// <param name="https">是否支持https阅读，默认为false</param>
        /// <returns>XGDocQueryDocumentResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGDocQueryDocumentResponse QueryDocument(string documentId, bool? https=null)
        {
            if (string.IsNullOrEmpty(documentId) || string.IsNullOrWhiteSpace(documentId))
                throw new ArgumentNullException("documentId 不能为空");
            XGDocQueryDocumentRequest request = new XGDocQueryDocumentRequest()
            {
                DocumentId=documentId,
                Https=https
            };
            return QueryDocument(request);
        }

        /// <summary>
        /// 查询文档
        /// <para>通过文档的唯一标识 documentId 查询指定文档的详细信息。</para>
        /// </summary>
        /// <param name="documentId">系统生成的文档的唯一标识</param>
        /// <param name="https">是否支持https阅读，默认为false</param>
        /// <returns>异步任务XGDocQueryDocumentResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGDocQueryDocumentResponse> QueryDocumentAsync(string documentId, bool? https = null)
        {
            if (string.IsNullOrEmpty(documentId) || string.IsNullOrWhiteSpace(documentId))
                throw new ArgumentNullException("documentId 不能为空");
            XGDocQueryDocumentRequest request = new XGDocQueryDocumentRequest()
            {
                DocumentId = documentId,
                Https = https
            };
            return await QueryDocumentAsync(request);
        }

        /// <summary>
        /// 查询文档
        /// <para>通过文档的唯一标识 documentId 查询指定文档的详细信息。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/DOC/s/Zjwvypwpy#%E6%9F%A5%E8%AF%A2%E6%96%87%E6%A1%A3 </para>
        /// </summary>
        /// <param name="request">XGDocQueryDocumentRequest</param>
        /// <returns>XGDocQueryDocumentResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGDocQueryDocumentResponse QueryDocument(XGDocQueryDocumentRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request 不能为空");
            }
            if (string.IsNullOrEmpty(request.DocumentId) || string.IsNullOrWhiteSpace(request.DocumentId))
                throw new ArgumentNullException("DocumentId 不能为空");
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.DocVersion.ToString() , Document, request.DocumentId);
            if (request.Https != null)
            {
                iternalRequest.AddParameter("https",request.Https.Value?"true":"false");
            }
            XGDocQueryDocumentResponse response = InvokeHttpClient<XGDocQueryDocumentResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询文档
        /// <para>通过文档的唯一标识 documentId 查询指定文档的详细信息。</para>
        /// </summary>
        /// <param name="request">XGDocQueryDocumentRequest</param>
        /// <returns>异步任务XGDocQueryDocumentResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGDocQueryDocumentResponse> QueryDocumentAsync(XGDocQueryDocumentRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request 不能为空");
            }
            if (string.IsNullOrEmpty(request.DocumentId) || string.IsNullOrWhiteSpace(request.DocumentId))
                throw new ArgumentNullException("DocumentId 不能为空");
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.DocVersion.ToString() , Document, request.DocumentId);
            if (request.Https != null)
            {
                iternalRequest.AddParameter("https", request.Https.Value ? "true" : "false");
            }
            XGDocQueryDocumentResponse response = await InvokeHttpClientAsync<XGDocQueryDocumentResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 列出所有文档
        /// <para>查询所有文档，以列表形式返回，支持用文档状态作为筛选条件进行筛选。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/DOC/s/Zjwvypwpy#%E6%96%87%E6%A1%A3%E5%88%97%E8%A1%A8 </para>
        /// </summary>
        /// <param name="status">文档状态</param>
        /// <param name="marker">本次请求的marker，标记查询的起始位置</param>
        /// <param name="maxSize">本次请求的文档数目，不超过200</param>
        /// <returns>XGDocListDocumentsResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGDocListDocumentsResponse ListDocuments(XGDocStatus? status=null, string marker=null, int? maxSize=null)
        {
            XGDocListDocumentsRequest request = new XGDocListDocumentsRequest()
            {
                Status=status,
                Marker=marker,
                MaxSize=maxSize
            };
            return ListDocuments(request);
        }

        /// <summary>
        /// 列出所有文档
        /// <para>查询所有文档，以列表形式返回，支持用文档状态作为筛选条件进行筛选。</para>
        /// </summary>
        /// <param name="status">文档状态</param>
        /// <param name="marker">本次请求的marker，标记查询的起始位置</param>
        /// <param name="maxSize">本次请求的文档数目，不超过200</param>
        /// <returns>异步任务XGDocListDocumentsResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGDocListDocumentsResponse> ListDocumentsAsync(XGDocStatus? status = null, string marker = null, int? maxSize = null)
        {
            XGDocListDocumentsRequest request = new XGDocListDocumentsRequest()
            {
                Status = status,
                Marker = marker,
                MaxSize = maxSize
            };
            return await ListDocumentsAsync(request);
        }

        /// <summary>
        /// 列出所有文档
        /// <para>查询所有文档，以列表形式返回，支持用文档状态作为筛选条件进行筛选。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/DOC/s/Zjwvypwpy#%E6%96%87%E6%A1%A3%E5%88%97%E8%A1%A8 </para>
        /// </summary>
        /// <param name="request">XGDocListDocumentsRequest</param>
        /// <returns>XGDocListDocumentsResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGDocListDocumentsResponse ListDocuments(XGDocListDocumentsRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request 不能为空");
            }
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.DocVersion.ToString() , Document);
            if (request.Status != null)
            {
                iternalRequest.AddParameter("status", request.Status.ToString());
            }
            if (!string.IsNullOrEmpty(request.Marker) && string.IsNullOrWhiteSpace(request.Marker))
            {
                iternalRequest.AddParameter("marker", request.Marker.Trim());
            }
            if (request.MaxSize != null)
            {
                iternalRequest.AddParameter("maxSize", request.MaxSize.ToString());
            }
            XGDocListDocumentsResponse response = InvokeHttpClient<XGDocListDocumentsResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 列出所有文档
        /// <para>查询所有文档，以列表形式返回，支持用文档状态作为筛选条件进行筛选。</para>
        /// </summary>
        /// <param name="request">XGDocListDocumentsRequest</param>
        /// <returns>异步任务XGDocListDocumentsResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGDocListDocumentsResponse> ListDocumentsAsync(XGDocListDocumentsRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request 不能为空");
            }
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.DocVersion.ToString() , Document);
            if (request.Status != null)
            {
                iternalRequest.AddParameter("status", request.Status.ToString());
            }
            if (!string.IsNullOrEmpty(request.Marker) && string.IsNullOrWhiteSpace(request.Marker))
            {
                iternalRequest.AddParameter("marker", request.Marker.Trim());
            }
            if (request.MaxSize != null)
            {
                iternalRequest.AddParameter("maxSize", request.MaxSize.ToString());
            }
            XGDocListDocumentsResponse response = await InvokeHttpClientAsync<XGDocListDocumentsResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 阅读文档
        /// <para>通过文档的唯一标识 documentId 获取指定文档的阅读信息，以便在PC/Android/iOS设备上阅读。仅对状态为PUBLISHED的文档有效。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/DOC/s/Zjwvypwpy#%E9%98%85%E8%AF%BB%E6%96%87%E6%A1%A3 </para>
        /// </summary>
        /// <param name="documentId">系统生成的文档的唯一标识</param>
        /// <param name="expireInSeconds">阅读Token有效期，仅当阅读私有文档（"access" : "PRIVATE"）时有效</param>
        /// <returns>XGDocReadDocumentResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGDocReadDocumentResponse ReadDocument(string documentId, long? expireInSeconds=null)
        {
            if (string.IsNullOrEmpty(documentId) || string.IsNullOrWhiteSpace(documentId))
            {
                throw new ArgumentNullException("documentId 不能为空");
            }
            XGDocReadDocumentRequest request = new XGDocReadDocumentRequest()
            {
                DocumentId=documentId,
                ExpireInSeconds=expireInSeconds
            };
            return ReadDocument(request);
        }

        /// <summary>
        /// 阅读文档
        /// <para>通过文档的唯一标识 documentId 获取指定文档的阅读信息，以便在PC/Android/iOS设备上阅读。仅对状态为PUBLISHED的文档有效。</para>
        /// </summary>
        /// <param name="documentId">系统生成的文档的唯一标识</param>
        /// <param name="expireInSeconds">阅读Token有效期，仅当阅读私有文档（"access" : "PRIVATE"）时有效</param>
        /// <returns>异步任务XGDocReadDocumentResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGDocReadDocumentResponse> ReadDocumentAsync(string documentId, long? expireInSeconds = null)
        {
            if (string.IsNullOrEmpty(documentId) || string.IsNullOrWhiteSpace(documentId))
            {
                throw new ArgumentNullException("documentId 不能为空");
            }
            XGDocReadDocumentRequest request = new XGDocReadDocumentRequest()
            {
                DocumentId = documentId,
                ExpireInSeconds = expireInSeconds
            };
            return await ReadDocumentAsync(request);
        }

        /// <summary>
        /// 阅读文档
        /// <para>通过文档的唯一标识 documentId 获取指定文档的阅读信息，以便在PC/Android/iOS设备上阅读。仅对状态为PUBLISHED的文档有效。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/DOC/s/Zjwvypwpy#%E9%98%85%E8%AF%BB%E6%96%87%E6%A1%A3 </para>
        /// </summary>
        /// <param name="request">XGDocReadDocumentRequest</param>
        /// <returns>XGDocReadDocumentResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGDocReadDocumentResponse ReadDocument(XGDocReadDocumentRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request 不能为空");
            }
            if (string.IsNullOrEmpty(request.DocumentId) || string.IsNullOrWhiteSpace(request.DocumentId))
            {
                throw new ArgumentNullException("DocumentId 不能为空");
            }
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.DocVersion.ToString() , Document,request.DocumentId.Trim());
            iternalRequest.AddParameter("read");
            if (request.ExpireInSeconds != null)
            {
                iternalRequest.AddParameter("expireInSeconds", request.ExpireInSeconds.ToString());
            }
            XGDocReadDocumentResponse response = InvokeHttpClient<XGDocReadDocumentResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 阅读文档
        /// <para>通过文档的唯一标识 documentId 获取指定文档的阅读信息，以便在PC/Android/iOS设备上阅读。仅对状态为PUBLISHED的文档有效。</para>
        /// </summary>
        /// <param name="request">XGDocReadDocumentRequest</param>
        /// <returns>异步任务XGDocReadDocumentResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGDocReadDocumentResponse> ReadDocumentAsync(XGDocReadDocumentRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request 不能为空");
            }
            if (string.IsNullOrEmpty(request.DocumentId) || string.IsNullOrWhiteSpace(request.DocumentId))
            {
                throw new ArgumentNullException("DocumentId 不能为空");
            }
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.DocVersion.ToString() , Document, request.DocumentId.Trim());
            iternalRequest.AddParameter("read");
            if (request.ExpireInSeconds != null)
            {
                iternalRequest.AddParameter("expireInSeconds", request.ExpireInSeconds.ToString());
            }
            XGDocReadDocumentResponse response = await InvokeHttpClientAsync<XGDocReadDocumentResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 禁用阅读Token
        /// <para>禁用阅读文档接口生成的某个阅读Token</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/DOC/s/Zjwvypwpy#%E7%A6%81%E7%94%A8%E9%98%85%E8%AF%BBtoken </para>
        /// </summary>
        /// <param name="documentId">系统生成的文档的唯一标识</param>
        /// <param name="token">阅读token</param>
        /// <returns>XGDocResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGDocResponse DisableReadToken(string documentId, string token=null)
        {

            if (string.IsNullOrEmpty(documentId) || string.IsNullOrWhiteSpace(documentId))
            {
                throw new ArgumentNullException("documentId 不能为空");
            }
            XGDocDisableReadTokenRequest request = new XGDocDisableReadTokenRequest()
            {
                DocumentId=documentId,
                Token=token,
            };
            return DisableReadToken(request);
        }

        /// <summary>
        /// 禁用阅读Token
        /// <para>禁用阅读文档接口生成的某个阅读Token</para>
        /// </summary>
        /// <param name="documentId">系统生成的文档的唯一标识</param>
        /// <param name="token">阅读token</param>
        /// <returns>异步任务XGDocResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGDocResponse> DisableReadTokenAsync(string documentId, string token = null)
        {

            if (string.IsNullOrEmpty(documentId) || string.IsNullOrWhiteSpace(documentId))
            {
                throw new ArgumentNullException("documentId 不能为空");
            }
            XGDocDisableReadTokenRequest request = new XGDocDisableReadTokenRequest()
            {
                DocumentId = documentId,
                Token = token,
            };
            return await DisableReadTokenAsync(request);
        }

        /// <summary>
        /// 禁用阅读Token
        /// <para>禁用阅读文档接口生成的某个阅读Token</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/DOC/s/Zjwvypwpy#%E7%A6%81%E7%94%A8%E9%98%85%E8%AF%BBtoken </para>
        /// </summary>
        /// <param name="request">XGDocDisableReadTokenRequest</param>
        /// <returns>XGDocResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGDocResponse DisableReadToken(XGDocDisableReadTokenRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request 不能为空");
            }
            if (string.IsNullOrEmpty(request.DocumentId) || string.IsNullOrWhiteSpace(request.DocumentId))
            {
                throw new ArgumentNullException("DocumentId 不能为空");
            }
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.PUT, request.DocVersion.ToString() , Document, request.DocumentId.Trim());
            iternalRequest.AddParameter("disableReadToken");
            if (string.IsNullOrEmpty(request.Token) || string.IsNullOrWhiteSpace(request.Token))
            {
                iternalRequest.AddParameter("token", request.Token.Trim());
            }
            XGDocReadDocumentResponse response = InvokeHttpClient<XGDocReadDocumentResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 禁用阅读Token
        /// <para>禁用阅读文档接口生成的某个阅读Token</para>
        /// </summary>
        /// <param name="request">XGDocDisableReadTokenRequest</param>
        /// <returns>异步任务XGDocResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGDocResponse> DisableReadTokenAsync(XGDocDisableReadTokenRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request 不能为空");
            }
            if (string.IsNullOrEmpty(request.DocumentId) || string.IsNullOrWhiteSpace(request.DocumentId))
            {
                throw new ArgumentNullException("DocumentId 不能为空");
            }
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.PUT, request.DocVersion.ToString() , Document, request.DocumentId.Trim());
            iternalRequest.AddParameter("disableReadToken");
            if (string.IsNullOrEmpty(request.Token) || string.IsNullOrWhiteSpace(request.Token))
            {
                iternalRequest.AddParameter("token", request.Token.Trim());
            }
            XGDocReadDocumentResponse response = await InvokeHttpClientAsync<XGDocReadDocumentResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 下载文档
        /// <para>通过文档的唯一标识 documentId 获取指定文档的下载链接。仅对状态为PUBLISHED/FAILED的文档有效</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/DOC/s/Zjwvypwpy#%E4%B8%8B%E8%BD%BD%E6%96%87%E6%A1%A3 </para>
        /// </summary>
        /// <param name="documentId">系统生成的文档的唯一标识</param>
        /// <param name="expireInSeconds">源文档下载地址有效时长，默认值：-1表示永久有效</param>
        /// <param name="https">是否支持https，默认为false</param>
        /// <returns>XGDocDownloadDocumentResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGDocDownloadDocumentResponse DownloadDocument(string documentId, int? expireInSeconds=null, bool? https=null)
        {
            if (string.IsNullOrEmpty(documentId) || string.IsNullOrWhiteSpace(documentId))
            {
                throw new ArgumentNullException("documentId 不能为空");
            }
            XGDocDownloadDocumentRequest request = new XGDocDownloadDocumentRequest()
            {
                DocumentId=documentId,
                ExpireInSeconds=expireInSeconds,
                Https=https
            };
            return DownloadDocument(request);
        }

        /// <summary>
        /// 下载文档
        /// <para>通过文档的唯一标识 documentId 获取指定文档的下载链接。仅对状态为PUBLISHED/FAILED的文档有效</para>
        /// </summary>
        /// <param name="documentId">系统生成的文档的唯一标识</param>
        /// <param name="expireInSeconds">源文档下载地址有效时长，默认值：-1表示永久有效</param>
        /// <param name="https">是否支持https，默认为false</param>
        /// <returns>异步任务XGDocDownloadDocumentResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGDocDownloadDocumentResponse> DownloadDocumentAsync(string documentId, int? expireInSeconds = null, bool? https = null)
        {
            if (string.IsNullOrEmpty(documentId) || string.IsNullOrWhiteSpace(documentId))
            {
                throw new ArgumentNullException("documentId 不能为空");
            }
            XGDocDownloadDocumentRequest request = new XGDocDownloadDocumentRequest()
            {
                DocumentId = documentId,
                ExpireInSeconds = expireInSeconds,
                Https = https
            };
            return await DownloadDocumentAsync(request);
        }

        /// <summary>
        /// 下载文档
        /// <para>通过文档的唯一标识 documentId 获取指定文档的下载链接。仅对状态为PUBLISHED/FAILED的文档有效</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/DOC/s/Zjwvypwpy#%E4%B8%8B%E8%BD%BD%E6%96%87%E6%A1%A3 </para>
        /// </summary>
        /// <param name="request">XGDocDownloadDocumentRequest</param>
        /// <returns>XGDocDownloadDocumentResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGDocDownloadDocumentResponse DownloadDocument(XGDocDownloadDocumentRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request 不能为空");
            }
            if (string.IsNullOrEmpty(request.DocumentId) || string.IsNullOrWhiteSpace(request.DocumentId))
            {
                throw new ArgumentNullException("DocumentId 不能为空");
            }
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.DocVersion.ToString() , Document, request.DocumentId.Trim());
            iternalRequest.AddParameter("download");
            if (request.ExpireInSeconds !=null)
            {
                iternalRequest.AddParameter("expireInSeconds", request.ExpireInSeconds.ToString());
            }
            if (request.Https != null)
            {
                iternalRequest.AddParameter("https", request.Https.Value?"true":"false");
            }
            XGDocDownloadDocumentResponse response = InvokeHttpClient<XGDocDownloadDocumentResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 下载文档
        /// <para>通过文档的唯一标识 documentId 获取指定文档的下载链接。仅对状态为PUBLISHED/FAILED的文档有效</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/DOC/s/Zjwvypwpy#%E4%B8%8B%E8%BD%BD%E6%96%87%E6%A1%A3 </para>
        /// </summary>
        /// <param name="request">XGDocDownloadDocumentRequest</param>
        /// <returns>异步任务XGDocDownloadDocumentResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGDocDownloadDocumentResponse> DownloadDocumentAsync(XGDocDownloadDocumentRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request 不能为空");
            }
            if (string.IsNullOrEmpty(request.DocumentId) || string.IsNullOrWhiteSpace(request.DocumentId))
            {
                throw new ArgumentNullException("DocumentId 不能为空");
            }
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.DocVersion.ToString() , Document, request.DocumentId.Trim());
            iternalRequest.AddParameter("download");
            if (request.ExpireInSeconds != null)
            {
                iternalRequest.AddParameter("expireInSeconds", request.ExpireInSeconds.ToString());
            }
            if (request.Https != null)
            {
                iternalRequest.AddParameter("https", request.Https.Value ? "true" : "false");
            }
            XGDocDownloadDocumentResponse response = await InvokeHttpClientAsync<XGDocDownloadDocumentResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询文档转码结果图片列表
        /// <para>对于转码结果类型为图片的文档，通过本接口可以在文档转码完成后，获取转码结果图片的URL列表。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/DOC/s/Zjwvypwpy#%E6%9F%A5%E8%AF%A2%E6%96%87%E6%A1%A3%E8%BD%AC%E7%A0%81%E7%BB%93%E6%9E%9C%E5%9B%BE%E7%89%87%E5%88%97%E8%A1%A8 </para>
        /// </summary>
        /// <param name="documentId">系统生成的文档的唯一标识</param>
        /// <returns>XGDocListDocumentImagesResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGDocListDocumentImagesResponse ListDocumentImages(string documentId)
        {
            if (string.IsNullOrEmpty(documentId) || string.IsNullOrWhiteSpace(documentId))
            {
                throw new ArgumentNullException("documentId 不能为空");
            }
            XGDocListDocumentImagesRequest request = new XGDocListDocumentImagesRequest()
            {
                DocumentId=documentId
            };
            return ListDocumentImages(request);
        }

        /// <summary>
        /// 查询文档转码结果图片列表
        /// <para>对于转码结果类型为图片的文档，通过本接口可以在文档转码完成后，获取转码结果图片的URL列表。</para>
        /// </summary>
        /// <param name="documentId">系统生成的文档的唯一标识</param>
        /// <returns>异步任务XGDocListDocumentImagesResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGDocListDocumentImagesResponse> ListDocumentImagesAsync(string documentId)
        {
            if (string.IsNullOrEmpty(documentId) || string.IsNullOrWhiteSpace(documentId))
            {
                throw new ArgumentNullException("documentId 不能为空");
            }
            XGDocListDocumentImagesRequest request = new XGDocListDocumentImagesRequest()
            {
                DocumentId = documentId
            };
            return await ListDocumentImagesAsync(request);
        }

        /// <summary>
        /// 查询文档转码结果图片列表
        /// <para>对于转码结果类型为图片的文档，通过本接口可以在文档转码完成后，获取转码结果图片的URL列表。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/DOC/s/Zjwvypwpy#%E6%9F%A5%E8%AF%A2%E6%96%87%E6%A1%A3%E8%BD%AC%E7%A0%81%E7%BB%93%E6%9E%9C%E5%9B%BE%E7%89%87%E5%88%97%E8%A1%A8 </para>
        /// </summary>
        /// <param name="request">XGDocListDocumentImagesRequest</param>
        /// <returns>XGDocListDocumentImagesResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGDocListDocumentImagesResponse ListDocumentImages(XGDocListDocumentImagesRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request 不能为空");
            }
            if (string.IsNullOrEmpty(request.DocumentId) || string.IsNullOrWhiteSpace(request.DocumentId))
            {
                throw new ArgumentNullException("DocumentId 不能为空");
            }
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.DocVersion.ToString() , Document, request.DocumentId.Trim());
            iternalRequest.AddParameter("getImages");
            XGDocListDocumentImagesResponse response = InvokeHttpClient<XGDocListDocumentImagesResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询文档转码结果图片列表
        /// <para>对于转码结果类型为图片的文档，通过本接口可以在文档转码完成后，获取转码结果图片的URL列表。</para>
        /// </summary>
        /// <param name="request">XGDocListDocumentImagesRequest</param>
        /// <returns>异步任务XGDocListDocumentImagesResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGDocListDocumentImagesResponse> ListDocumentImagesAsync(XGDocListDocumentImagesRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request 不能为空");
            }
            if (string.IsNullOrEmpty(request.DocumentId) || string.IsNullOrWhiteSpace(request.DocumentId))
            {
                throw new ArgumentNullException("DocumentId 不能为空");
            }
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.GET, request.DocVersion.ToString() , Document, request.DocumentId.Trim());
            iternalRequest.AddParameter("getImages");
            XGDocListDocumentImagesResponse response = await InvokeHttpClientAsync<XGDocListDocumentImagesResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 删除文档
        /// <para>仅对状态status不是PROCESSING时的文档有效，清除文档占用的存储空间。</para>
        /// <para>文档一经删除，无法通过查询文档/文档列表等接口获取，并且无法阅读、下载，请谨慎操作。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/DOC/s/Zjwvypwpy#%E5%88%A0%E9%99%A4%E6%96%87%E6%A1%A3 </para>
        /// </summary>
        /// <param name="documentId">系统生成的文档的唯一标识</param>
        /// <returns>XGDocResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGDocResponse DeleteDocument(string documentId)
        {
            if (string.IsNullOrEmpty(documentId) || string.IsNullOrWhiteSpace(documentId))
            {
                throw new ArgumentNullException("documentId 不能为空");
            }
            XGDocDeleteDocumentRequest request = new XGDocDeleteDocumentRequest()
            {
                DocumentId=documentId
            };
            return DeleteDocument(request);
        }

        /// <summary>
        /// 删除文档
        /// <para>仅对状态status不是PROCESSING时的文档有效，清除文档占用的存储空间。</para>
        /// <para>文档一经删除，无法通过查询文档/文档列表等接口获取，并且无法阅读、下载，请谨慎操作。</para>
        /// </summary>
        /// <param name="documentId">系统生成的文档的唯一标识</param>
        /// <returns>异步任务XGDocResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGDocResponse> DeleteDocumentAsync(string documentId)
        {
            if (string.IsNullOrEmpty(documentId) || string.IsNullOrWhiteSpace(documentId))
            {
                throw new ArgumentNullException("documentId 不能为空");
            }
            XGDocDeleteDocumentRequest request = new XGDocDeleteDocumentRequest()
            {
                DocumentId = documentId
            };
            return await DeleteDocumentAsync(request);
        }

        /// <summary>
        /// 删除文档
        /// <para>仅对状态status不是PROCESSING时的文档有效，清除文档占用的存储空间。</para>
        /// <para>文档一经删除，无法通过查询文档/文档列表等接口获取，并且无法阅读、下载，请谨慎操作。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/DOC/s/Zjwvypwpy#%E5%88%A0%E9%99%A4%E6%96%87%E6%A1%A3 </para>
        /// </summary>
        /// <param name="request">XGDocDeleteDocumentRequest</param>
        /// <returns>XGDocResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGDocResponse DeleteDocument(XGDocDeleteDocumentRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request 不能为空");
            }
            if (string.IsNullOrEmpty(request.DocumentId) || string.IsNullOrWhiteSpace(request.DocumentId))
            {
                throw new ArgumentNullException("DocumentId 不能为空");
            }
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.DELETE, request.DocVersion.ToString() , Document, request.DocumentId.Trim());
            XGDocResponse response = InvokeHttpClient<XGDocResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 删除文档
        /// <para>仅对状态status不是PROCESSING时的文档有效，清除文档占用的存储空间。</para>
        /// <para>文档一经删除，无法通过查询文档/文档列表等接口获取，并且无法阅读、下载，请谨慎操作。</para>
        /// </summary>
        /// <param name="request">XGDocDeleteDocumentRequest</param>
        /// <returns>异步任务XGDocResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGDocResponse> DeleteDocumentAsync(XGDocDeleteDocumentRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request 不能为空");
            }
            if (string.IsNullOrEmpty(request.DocumentId) || string.IsNullOrWhiteSpace(request.DocumentId))
            {
                throw new ArgumentNullException("DocumentId 不能为空");
            }
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.DELETE, request.DocVersion.ToString() , Document, request.DocumentId.Trim());
            XGDocResponse response = await InvokeHttpClientAsync<XGDocResponse>(iternalRequest);
            return response;
        }


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
    }
}
