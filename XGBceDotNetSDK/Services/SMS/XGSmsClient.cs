using System;
using System.Threading.Tasks;
using XGBceDotNetSDK.BaseClass;
using XGBceDotNetSDK.Services.SMS.Model;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.SMS
{
    /// <summary>
    /// 简单消息服务SMS客户端
    ///<para> 接口文档：https://cloud.baidu.com/doc/SMS/s/Rjwvxrxc4 </para> 
    /// </summary>
    public class XGSmsClient : XGSmsClientSupport
    {
        public XGSmsClient() : this(new XGSmsClientConfiguration()) { }

        public XGSmsClient(XGSmsClientConfiguration configuration) : base(configuration) { }

        #region 短信接口

        /// <summary>
        /// 实现短信下发功能，一次支持提交多个手机号。
        /// <para> 注意：下发短信前，需要先申请签名和短信模板，并通过审核。</para>
        /// <para>接口文档：https://cloud.baidu.com/doc/SMS/s/lkijy5wvf </para>
        /// </summary>
        /// <param name="request">XGSendMessageV3Request</param>
        /// <returns>XGSendMessageV3Response</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGSendMessageV3Response SendMessage(XGSendMessageV3Request request)
        {
            #region
            //Task<XGSendMessageV3Response> task = Task.Run(() => SendMessageAsync(request));
            //task.Wait();
            //return task.Result;
            #endregion
            if (request == null)
                throw new NullReferenceException("XGSendMessageV3Request 是必需的");
            AssertStringNotNullOrEmpty(request.Mobile, "Mobile 是必需的");
            AssertStringNotNullOrEmpty(request.SignatureId, "SignatureId 是必需的");
            AssertStringNotNullOrEmpty(request.Template, "Template 是必需的");
            XGBceIternalRequest iternalRequest = CreateGeneralRequest("api/v3/sendsms", request, Utils.BceHttpMethod.POST, Array.Empty<string>());
            if (!string.IsNullOrEmpty(request.ClientToken) && !string.IsNullOrWhiteSpace(request.ClientToken))
                iternalRequest.AddParameter("clientToken", request.ClientToken);
            iternalRequest = FillRequestPayload(iternalRequest, JsonConvert.SerializeObject(request));
            XGSendMessageV3Response response;
            try
            {
                response = InvokeHttpClient<XGSendMessageV3Response>(iternalRequest);
            }
            catch (XGBceServiceException ex)
            {
                response = new XGSendMessageV3Response
                {
                    Code = ex.ErrorCode,
                    Message = ex.ErrorMessage,
                    RequestId = ex.RequestId
                };
            }
            return response;
        }

        /// <summary>
        /// 实现短信下发功能，一次支持提交多个手机号。
        /// <para> 注意：下发短信前，需要先申请签名和短信模板，并通过审核。</para> 
        /// </summary>
        /// <param name="request">XGSendMessageV3Request</param>
        /// <returns>异步任务XGSendMessageV3Response</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGSendMessageV3Response> SendMessageAsync(XGSendMessageV3Request request)
        {
            if (request == null)
                throw new NullReferenceException("XGSendMessageV3Request 是必需的");
            AssertStringNotNullOrEmpty(request.Mobile, "Mobile 是必需的");
            AssertStringNotNullOrEmpty(request.SignatureId, "SignatureId 是必需的");
            AssertStringNotNullOrEmpty(request.Template, "Template 是必需的");
            XGBceIternalRequest iternalRequest = CreateGeneralRequest("api/v3/sendsms", request, Utils.BceHttpMethod.POST, Array.Empty<string>());
            if (!string.IsNullOrEmpty(request.ClientToken) && !string.IsNullOrWhiteSpace(request.ClientToken))
                iternalRequest.AddParameter("clientToken", request.ClientToken);
            iternalRequest = FillRequestPayload(iternalRequest, JsonConvert.SerializeObject(request));
            XGSendMessageV3Response response;
            try
            {
                response = await InvokeHttpClientAsync<XGSendMessageV3Response>(iternalRequest);
            }
            catch (XGBceServiceException ex)
            {
                response = new XGSendMessageV3Response
                {
                    Code = ex.ErrorCode,
                    Message = ex.ErrorMessage,
                    RequestId = ex.RequestId
                };
            }
            return response;
        }

        #endregion


        #region 签名相关接口

        /// <summary>
        /// 申请签名
        /// <para> 接口文档： https://cloud.baidu.com/doc/SMS/s/3kijycp30 </para> 
        /// </summary>
        /// <param name="request">XGCreateSignatureResponse</param>
        /// <returns>XGCreateSignatureRequest</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGCreateSignatureResponse CreateSignature(XGCreateSignatureRequest request)
        {
            if (request == null)
                throw new NullReferenceException("XGCreateSignatureRequest 是必需的");
            AssertStringNotNullOrEmpty(request.Content, "Content 是必需的");
            XGBceIternalRequest iternalRequest = CreateGeneralRequest("/sms/v3/signatureApply", request, Utils.BceHttpMethod.POST, Array.Empty<string>());
            if (!string.IsNullOrEmpty(request.ClientToken) && !string.IsNullOrWhiteSpace(request.ClientToken))
                iternalRequest.AddParameter("clientToken", request.ClientToken);
            iternalRequest = FillRequestPayload(iternalRequest, JsonConvert.SerializeObject(request));
            XGCreateSignatureResponse response = InvokeHttpClient<XGCreateSignatureResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 申请签名
        /// </summary>
        /// <param name="request">XGCreateSignatureResponse</param>
        /// <returns>异步任务XGCreateSignatureResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGCreateSignatureResponse> CreateSignatureAsync(XGCreateSignatureRequest request)
        {
            if (request == null)
                throw new NullReferenceException("XGCreateSignatureRequest 是必需的");
            AssertStringNotNullOrEmpty(request.Content, "Content 是必需的");
            XGBceIternalRequest iternalRequest = CreateGeneralRequest("/sms/v3/signatureApply", request, Utils.BceHttpMethod.POST, Array.Empty<string>());
            if (!string.IsNullOrEmpty(request.ClientToken) && !string.IsNullOrWhiteSpace(request.ClientToken))
                iternalRequest.AddParameter("clientToken", request.ClientToken);
            iternalRequest = FillRequestPayload(iternalRequest, JsonConvert.SerializeObject(request));
            XGCreateSignatureResponse response = await InvokeHttpClientAsync<XGCreateSignatureResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 变更签名
        /// <para> 接口文档：https://cloud.baidu.com/doc/SMS/s/Pkijydlpl </para> 
        /// </summary>
        /// <param name="request">XGModifySignatureRequest</param>
        /// <returns>XGSmsResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGSmsResponse ModifySignature(XGModifySignatureRequest request)
        {
            if (request == null)
                throw new NullReferenceException("XGModifySignatureRequest 是必需的");
            AssertStringNotNullOrEmpty(request.Content, "Content 是必需的");
            AssertStringNotNullOrEmpty(request.SignatureId, "SignatureId 是必需的");
            XGBceIternalRequest iternalRequest = CreateGeneralRequest("/sms/v3/signatureApply", request, Utils.BceHttpMethod.PUT, new string[] { request.SignatureId });
            iternalRequest = FillRequestPayload(iternalRequest, JsonConvert.SerializeObject(request));
            XGSmsResponse response = InvokeHttpClient<XGSmsResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 变更签名
        /// </summary>
        /// <param name="request">XGModifySignatureRequest</param>
        /// <returns>异步任务XGSmsResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGSmsResponse> ModifySignatureAsync(XGModifySignatureRequest request)
        {
            if (request == null)
                throw new NullReferenceException("XGModifySignatureRequest 是必需的");
            AssertStringNotNullOrEmpty(request.Content, "Content 是必需的");
            AssertStringNotNullOrEmpty(request.SignatureId, "SignatureId 是必需的");
            XGBceIternalRequest iternalRequest = CreateGeneralRequest("/sms/v3/signatureApply", request, Utils.BceHttpMethod.PUT, new string[] { request.SignatureId });
            iternalRequest = FillRequestPayload(iternalRequest, JsonConvert.SerializeObject(request));
            XGSmsResponse response = await InvokeHttpClientAsync<XGSmsResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询签名
        /// <para> 接口文档：https://cloud.baidu.com/doc/SMS/s/dkijyelyj </para> 
        /// </summary>
        /// <param name="request">XGQuerySignatureRequest</param>
        /// <returns>XGQuerySignatureResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGQuerySignatureResponse QuerySignature(XGQuerySignatureRequest request)
        {
            if (request == null)
                throw new NullReferenceException("XGQuerySignatureRequest 是必需的");
            AssertStringNotNullOrEmpty(request.SignatureId, "SignatureId 是必需的");
            XGBceIternalRequest iternalRequest = CreateGeneralRequest("/sms/v3/signatureApply", request, Utils.BceHttpMethod.GET, new string[] { request.SignatureId });
            iternalRequest = FillRequestPayload(iternalRequest, "");
            XGQuerySignatureResponse response = InvokeHttpClient<XGQuerySignatureResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询签名
        /// </summary>
        /// <param name="request">XGQuerySignatureRequest</param>
        /// <returns>异步任务XGQuerySignatureResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGQuerySignatureResponse> QuerySignatureAsync(XGQuerySignatureRequest request)
        {
            if (request == null)
                throw new NullReferenceException("XGQuerySignatureRequest 是必需的");
            AssertStringNotNullOrEmpty(request.SignatureId, "SignatureId 是必需的");
            XGBceIternalRequest iternalRequest = CreateGeneralRequest("/sms/v3/signatureApply", request, Utils.BceHttpMethod.GET, new string[] { request.SignatureId });
            iternalRequest = FillRequestPayload(iternalRequest, "");
            XGQuerySignatureResponse response = await InvokeHttpClientAsync<XGQuerySignatureResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查看签名列表
        /// </summary>
        /// <param name="request">XGListSignatureRequest</param>
        /// <returns>异步任务XGListSignatureResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGListSignatureResponse ListSignature(XGListSignatureRequest request)
        {
            if (request == null)
                throw new NullReferenceException("XGListSignatureRequest 是必需的");
            XGBceIternalRequest iternalRequest = CreateGeneralRequest("/sms/v3/signatureApply", new XGSmsRequest(), Utils.BceHttpMethod.GET, Array.Empty<string>());
            if (!string.IsNullOrEmpty(request.Content) && !string.IsNullOrWhiteSpace(request.Content))
                iternalRequest.AddParameter("contentLike", request.Content);
            if (!string.IsNullOrEmpty(request.SignatureId) && !string.IsNullOrWhiteSpace(request.SignatureId))
                iternalRequest.AddParameter("signatureIdLike", request.SignatureId);
            if (request.CountryType != null)
                iternalRequest.AddParameter("countryType", request.CountryType.ToString());
            if (request.Status != null)
                iternalRequest.AddParameter("status", request.Status.ToString());
            if (request.PageNo < 1)
                throw new ArgumentOutOfRangeException("pageNo需要大于等于1");
            iternalRequest.AddParameter("pageNo", request.PageNo.ToString());
            if (request.PageSize < 1)
                throw new ArgumentOutOfRangeException("PageSize需要大于等于1");
            iternalRequest.AddParameter("pageSize", request.PageSize.ToString());
            iternalRequest.AddParameter("isIgnoreDeprecated", "true");
            iternalRequest = FillRequestPayload(iternalRequest, "");
            XGListSignatureResponse response = InvokeHttpClient<XGListSignatureResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查看签名列表
        /// </summary>
        /// <param name="request">XGListSignatureRequest</param>
        /// <returns>异步任务XGListSignatureResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGListSignatureResponse> ListSignatureAsync(XGListSignatureRequest request)
        {
            if (request == null)
                throw new NullReferenceException("XGListSignatureRequest 是必需的");
            XGBceIternalRequest iternalRequest = CreateGeneralRequest("/sms/v3/signatureApply", new XGSmsRequest(), Utils.BceHttpMethod.GET, Array.Empty<string>());
            if (!string.IsNullOrEmpty(request.Content)&&!string.IsNullOrWhiteSpace(request.Content))
                iternalRequest.AddParameter("contentLike", request.Content);
            if (!string.IsNullOrEmpty(request.SignatureId) && !string.IsNullOrWhiteSpace(request.SignatureId))
                iternalRequest.AddParameter("signatureIdLike", request.SignatureId);
            if(request.CountryType!=null)
                iternalRequest.AddParameter("countryType", request.CountryType.ToString());
            if (request.Status!=null)
                iternalRequest.AddParameter("status", request.Status.ToString());
            if (request.PageNo < 1)
                throw new ArgumentOutOfRangeException("pageNo需要大于等于1");
            iternalRequest.AddParameter("pageNo", request.PageNo.ToString());
            if (request.PageSize < 1)
                throw new ArgumentOutOfRangeException("PageSize需要大于等于1");
            iternalRequest.AddParameter("pageSize", request.PageSize.ToString());
            iternalRequest.AddParameter("isIgnoreDeprecated", "true");
            iternalRequest = FillRequestPayload(iternalRequest, "");
            XGListSignatureResponse response= await InvokeHttpClientAsync<XGListSignatureResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 删除签名
        /// <para> 接口文档：https://cloud.baidu.com/doc/SMS/s/ekijyk6ng </para> 
        /// </summary>
        /// <param name="request">XGDeleteSignatureRequest</param>
        /// <returns>XGSmsResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGSmsResponse DeleteSignature(XGDeleteSignatureRequest request)
        {
            if (request == null)
                throw new NullReferenceException("XGDeleteSignatureRequest 是必需的");
            AssertStringNotNullOrEmpty(request.SignatureId, "SignatureId 是必需的");
            XGBceIternalRequest iternalRequest = CreateGeneralRequest("/sms/v3/signatureApply", request, Utils.BceHttpMethod.DELETE, new string[] { request.SignatureId });
            iternalRequest = FillRequestPayload(iternalRequest, "");
            XGSmsResponse response = InvokeHttpClient<XGSmsResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 删除签名
        /// </summary>
        /// <param name="request">XGDeleteSignatureRequest</param>
        /// <returns>异步任务XGSmsResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGSmsResponse> DeleteSignatureAsync(XGDeleteSignatureRequest request)
        {
            if (request == null)
                throw new NullReferenceException("XGDeleteSignatureRequest 是必需的");
            AssertStringNotNullOrEmpty(request.SignatureId, "SignatureId 是必需的");
            XGBceIternalRequest iternalRequest = CreateGeneralRequest("/sms/v3/signatureApply", request, Utils.BceHttpMethod.DELETE, new string[] { request.SignatureId });
            iternalRequest = FillRequestPayload(iternalRequest, "");
            XGSmsResponse response = await InvokeHttpClientAsync<XGSmsResponse>(iternalRequest);
            return response;
        }

        #endregion

        #region 模板相关接口

        /// <summary>
        /// 创建模板
        /// <para> 接口文档：https://cloud.baidu.com/doc/SMS/s/gkik0eje2 </para> 
        /// </summary>
        /// <param name="request">XGCreateTemplateRequest</param>
        /// <returns>异步任务XGCreateTemplateResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGCreateTemplateResponse CreateTemplate(XGCreateTemplateRequest request)
        {
            if (request == null)
                throw new NullReferenceException("request 是必需的");
            AssertStringNotNullOrEmpty(request.Content, "Content 是必需的");
            XGBceIternalRequest iternalRequest = CreateGeneralRequest("/sms/v3/template", request, Utils.BceHttpMethod.POST, Array.Empty<string>());
            if (!string.IsNullOrEmpty(request.ClientToken) && !string.IsNullOrWhiteSpace(request.ClientToken))
                iternalRequest.AddParameter("clientToken", request.ClientToken);
            iternalRequest = FillRequestPayload(iternalRequest, JsonConvert.SerializeObject(request));
            XGCreateTemplateResponse response = InvokeHttpClient<XGCreateTemplateResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 创建模板
        /// </summary>
        /// <param name="request">XGCreateTemplateRequest</param>
        /// <returns>异步任务XGCreateTemplateResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGCreateTemplateResponse> CreateTemplateAsync(XGCreateTemplateRequest request)
        {
            if (request == null)
                throw new NullReferenceException("request 是必需的");
            AssertStringNotNullOrEmpty(request.Content, "Content 是必需的");
            XGBceIternalRequest iternalRequest = CreateGeneralRequest("/sms/v3/template", request, Utils.BceHttpMethod.POST, Array.Empty<string>());
            if (!string.IsNullOrEmpty(request.ClientToken) && !string.IsNullOrWhiteSpace(request.ClientToken))
                iternalRequest.AddParameter("clientToken", request.ClientToken);
            iternalRequest = FillRequestPayload(iternalRequest, JsonConvert.SerializeObject(request));
            XGCreateTemplateResponse response = await InvokeHttpClientAsync<XGCreateTemplateResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 变更模板
        /// <para> 接口文档：https://cloud.baidu.com/doc/SMS/s/7kik0f2j9 </para> 
        /// </summary>
        /// <param name="request">XGModifyTemplateRequest</param>
        /// <returns>XGSmsResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGSmsResponse ModifyTemplate(XGModifyTemplateRequest request)
        {
            if (request == null)
                throw new NullReferenceException("XGModifyTemplateRequest 是必需的");
            AssertStringNotNullOrEmpty(request.Content, "Content 是必需的");
            AssertStringNotNullOrEmpty(request.TemplateId, "TemplateId 是必需的");
            XGBceIternalRequest iternalRequest = CreateGeneralRequest("/sms/v3/template", request, Utils.BceHttpMethod.PUT, new string[] { request.TemplateId });
            iternalRequest = FillRequestPayload(iternalRequest, JsonConvert.SerializeObject(request));
            XGSmsResponse response = InvokeHttpClient<XGSmsResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 变更模板
        /// </summary>
        /// <param name="request">XGModifyTemplateRequest</param>
        /// <returns>异步任务XGSmsResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGSmsResponse> ModifyTemplateAsync(XGModifyTemplateRequest request)
        {
            if (request == null)
                throw new NullReferenceException("XGModifyTemplateRequest 是必需的");
            AssertStringNotNullOrEmpty(request.Content, "Content 是必需的");
            AssertStringNotNullOrEmpty(request.TemplateId, "TemplateId 是必需的");
            XGBceIternalRequest iternalRequest = CreateGeneralRequest("/sms/v3/template", request, Utils.BceHttpMethod.PUT, new string[] { request.TemplateId });
            iternalRequest = FillRequestPayload(iternalRequest, JsonConvert.SerializeObject(request));
            XGSmsResponse response = await InvokeHttpClientAsync<XGSmsResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询模板
        /// <para> 接口文档：https://cloud.baidu.com/doc/SMS/s/xkik0fmx5 </para> 
        /// </summary>
        /// <param name="request">XGQueryTemplateRequest</param>
        /// <returns>XGQueryTemplateResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGQueryTemplateResponse QueryTemplate(XGQueryTemplateRequest request)
        {
            if (request == null)
                throw new NullReferenceException("XGQueryTemplateRequest 是必需的");
            AssertStringNotNullOrEmpty(request.TemplateId, "TemplateId 是必需的");
            XGBceIternalRequest iternalRequest = CreateGeneralRequest("/sms/v3/template", request, Utils.BceHttpMethod.GET, new string[] { request.TemplateId });
            iternalRequest = FillRequestPayload(iternalRequest, "");
            XGQueryTemplateResponse response = InvokeHttpClient<XGQueryTemplateResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询模板
        /// </summary>
        /// <param name="request">XGQueryTemplateRequest</param>
        /// <returns>异步任务XGQueryTemplateResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGQueryTemplateResponse> QueryTemplateAsync(XGQueryTemplateRequest request)
        {
            if (request == null)
                throw new NullReferenceException("XGQueryTemplateRequest 是必需的");
            AssertStringNotNullOrEmpty(request.TemplateId, "TemplateId 是必需的");
            XGBceIternalRequest iternalRequest = CreateGeneralRequest("/sms/v3/template", request, Utils.BceHttpMethod.GET, new string[] { request.TemplateId });
            iternalRequest = FillRequestPayload(iternalRequest, "");
            XGQueryTemplateResponse response = await InvokeHttpClientAsync<XGQueryTemplateResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查看模板列表
        /// </summary>
        /// <param name="request">XGListSignatureRequest</param>
        /// <returns>XGListSignatureResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGListTemplateResponse ListTemplate(XGListTemplateRequest request)
        {
            if (request == null)
                throw new NullReferenceException("XGListTemplateRequest 是必需的");
            XGBceIternalRequest iternalRequest = CreateGeneralRequest("/sms/v3/template", new XGSmsRequest(), Utils.BceHttpMethod.GET, Array.Empty<string>());
            if (!string.IsNullOrEmpty(request.Content) && !string.IsNullOrWhiteSpace(request.Content))
                iternalRequest.AddParameter("contentLike", request.Content);
            if (!string.IsNullOrEmpty(request.TemplateId) && !string.IsNullOrWhiteSpace(request.TemplateId))
                iternalRequest.AddParameter("templateIdLike", request.TemplateId);
            if (request.SmsType != null)
                iternalRequest.AddParameter("smsType", request.SmsType.ToString());
            if (request.CountryType != null)
                iternalRequest.AddParameter("countryType", request.CountryType.ToString());
            if (request.Status != null)
                iternalRequest.AddParameter("status", request.Status.ToString());
            if (request.PageNo < 1)
                throw new ArgumentOutOfRangeException("pageNo需要大于等于1");
            iternalRequest.AddParameter("pageNo", request.PageNo.ToString());
            if (request.PageSize < 1)
                throw new ArgumentOutOfRangeException("PageSize需要大于等于1");
            iternalRequest.AddParameter("pageSize", request.PageSize.ToString());
            iternalRequest.AddParameter("isIgnoreDeprecated", "true");
            iternalRequest = FillRequestPayload(iternalRequest, "");
            XGListTemplateResponse response = InvokeHttpClient<XGListTemplateResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查看模板列表
        /// </summary>
        /// <param name="request">XGListSignatureRequest</param>
        /// <returns>异步任务XGListSignatureResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGListTemplateResponse> ListTemplateAsync(XGListTemplateRequest request)
        {
            if (request == null)
                throw new NullReferenceException("XGListTemplateRequest 是必需的");
            XGBceIternalRequest iternalRequest = CreateGeneralRequest("/sms/v3/template", new XGSmsRequest(), Utils.BceHttpMethod.GET, Array.Empty<string>());
            if (!string.IsNullOrEmpty(request.Content) && !string.IsNullOrWhiteSpace(request.Content))
                iternalRequest.AddParameter("contentLike", request.Content);
            if (!string.IsNullOrEmpty(request.TemplateId) && !string.IsNullOrWhiteSpace(request.TemplateId))
                iternalRequest.AddParameter("templateIdLike", request.TemplateId);
            if(request.SmsType!=null)
                iternalRequest.AddParameter("smsType", request.SmsType.ToString());
            if(request.CountryType != null)
                iternalRequest.AddParameter("countryType", request.CountryType.ToString());
            if (request.Status!=null)
                iternalRequest.AddParameter("status", request.Status.ToString());
            if (request.PageNo < 1)
                throw new ArgumentOutOfRangeException("pageNo需要大于等于1");
            iternalRequest.AddParameter("pageNo", request.PageNo.ToString());
            if (request.PageSize < 1)
                throw new ArgumentOutOfRangeException("PageSize需要大于等于1");
            iternalRequest.AddParameter("pageSize", request.PageSize.ToString());
            iternalRequest.AddParameter("isIgnoreDeprecated", "true");
            iternalRequest = FillRequestPayload(iternalRequest, "");
            XGListTemplateResponse response = await InvokeHttpClientAsync<XGListTemplateResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 删除模板
        /// <para> 接口文档：https://cloud.baidu.com/doc/SMS/s/okik0g61a </para> 
        /// </summary>
        /// <param name="request">XGDeleteTemplateRequest</param>
        /// <returns>XGSmsResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGSmsResponse DeleteTemplate(XGDeleteTemplateRequest request)
        {
            if (request == null)
                throw new NullReferenceException("XGDeleteTemplateRequest 是必需的");
            AssertStringNotNullOrEmpty(request.TemplateId, "TemplateId 是必需的");
            XGBceIternalRequest iternalRequest = CreateGeneralRequest("/sms/v3/template", request, Utils.BceHttpMethod.DELETE, new string[] { request.TemplateId });
            iternalRequest = FillRequestPayload(iternalRequest, "");
            XGSmsResponse response = InvokeHttpClient<XGSmsResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 删除模板
        /// </summary>
        /// <param name="request">XGDeleteTemplateRequest</param>
        /// <returns>异步任务XGSmsResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGSmsResponse> DeleteTemplateAsync(XGDeleteTemplateRequest request)
        {
            if (request == null)
                throw new NullReferenceException("XGDeleteTemplateRequest 是必需的");
            AssertStringNotNullOrEmpty(request.TemplateId, "TemplateId 是必需的");
            XGBceIternalRequest iternalRequest = CreateGeneralRequest("/sms/v3/template", request, Utils.BceHttpMethod.DELETE, new string[] { request.TemplateId });
            iternalRequest = FillRequestPayload(iternalRequest, "");
            XGSmsResponse response = await InvokeHttpClientAsync<XGSmsResponse>(iternalRequest);
            return response;
        }

        #endregion

        #region 配额及频控相关接口

        /// <summary>
        /// 查询配额及频控
        /// <para> 接口文档：https://cloud.baidu.com/doc/SMS/s/nkik0hyon </para> 
        /// </summary>
        /// <returns>XGQueryTemplateResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGSmsQueryQuotaRateResponse QueryQuotaRate()
        {
            XGBceIternalRequest iternalRequest = CreateGeneralRequest("/sms/v3/quota", new XGSmsRequest(), Utils.BceHttpMethod.GET, Array.Empty<string>());
            iternalRequest.AddParameter("userQuery", "");
            iternalRequest = FillRequestPayload(iternalRequest, "");
            XGSmsQueryQuotaRateResponse response = InvokeHttpClient<XGSmsQueryQuotaRateResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 查询配额及频控
        /// </summary>
        /// <returns>异步任务XGQueryTemplateResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGSmsQueryQuotaRateResponse> QueryQuotaRateAsync()
        {
            XGBceIternalRequest iternalRequest = CreateGeneralRequest("/sms/v3/quota", new XGSmsRequest(), Utils.BceHttpMethod.GET, Array.Empty<string>());
            iternalRequest.AddParameter("userQuery", "");
            iternalRequest = FillRequestPayload(iternalRequest, "");
            XGSmsQueryQuotaRateResponse response = await InvokeHttpClientAsync<XGSmsQueryQuotaRateResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 变更配额或频控
        /// <para> 接口文档：https://cloud.baidu.com/doc/SMS/s/Ckik0ij3k </para> 
        /// </summary>
        /// <param name="request">XGSmsModifyQuotaRateRequest</param>
        /// <returns>XGSmsResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGSmsResponse ModifyQuotaRate(XGSmsModifyQuotaRateRequest request)
        {
            if (request == null)
                throw new NullReferenceException("XGSmsModifyQuotaRateRequest 是必需的");
            XGBceIternalRequest iternalRequest = CreateGeneralRequest("/sms/v3/template", request, Utils.BceHttpMethod.PUT, Array.Empty<string>());
            iternalRequest = FillRequestPayload(iternalRequest, JsonConvert.SerializeObject(request));
            XGSmsResponse response = InvokeHttpClient<XGSmsResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 变更配额或频控
        /// </summary>
        /// <param name="request">XGSmsModifyQuotaRateRequest</param>
        /// <returns>异步任务XGSmsResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGSmsResponse> ModifyQuotaRateAsync(XGSmsModifyQuotaRateRequest request)
        {
            if (request == null)
                throw new NullReferenceException("XGSmsModifyQuotaRateRequest 是必需的");
            XGBceIternalRequest iternalRequest = CreateGeneralRequest("/sms/v3/template", request, Utils.BceHttpMethod.PUT, Array.Empty<string>());
            iternalRequest = FillRequestPayload(iternalRequest, JsonConvert.SerializeObject(request));
            XGSmsResponse response = await InvokeHttpClientAsync<XGSmsResponse>(iternalRequest);
            return response;
        }

        #endregion
    }
}
