using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using XGBceDotNetSDK.BaseClass;
using XGBceDotNetSDK.Http;
using XGBceDotNetSDK.Http.Handler;
using XGBceDotNetSDK.Sign;
using XGBceDotNetSDK.Utils;

namespace XGBceDotNetSDK.Services.SMS
{
    /// <summary>
    /// 简单消息服务SMS客户端支持
    /// </summary>
    public class XGSmsClientSupport: XGAbstractBceClient
    {
        public XGSmsClientSupport(XGBceClientConfiguration configuration) : base(configuration) { }

        protected XGBceIternalRequest CreateGeneralRequest(string pathPrefix, XGAbstractBceRequest bceRequest,BceHttpMethod httpMethod,params string[] pathVariables)
        {
            List<string> pathComponents = new List<string>();
            AssertStringNotNullOrEmpty(pathPrefix, "pathPrefix不能为空");
            if (pathPrefix.EndsWith("/"))
                pathPrefix = pathPrefix.Remove(pathPrefix.Length-1); 
            pathComponents.Add(pathPrefix);
            if (pathVariables != null)
                pathComponents.AddRange(pathVariables);

            XGBceIternalRequest request = new XGBceIternalRequest(httpMethod, HttpUtil.AppendUri(Endpoint, pathComponents.ToArray()))
            {
                Credentials = bceRequest.Credentials
            };
            BceSignOption options = BceSignOption.defaultBceSignOption;
            List<string> headersToSign = new List<string>()
            {
                XGBceHeaders.HOST,
                XGBceHeaders.BCE_DATE,
            };
            options.HeadersToSign = headersToSign;
            string bce_date = XGDateUtils.FormatISO8601Date(DateTime.UtcNow);
            request.AddMoreHeader(XGBceHeaders.BCE_DATE, bce_date);
            request.AddMoreHeader(XGBceHeaders.USER_AGENT, config.UserAgent);
            new XGBceSignerV1().Sign(request, request.Credentials, options);
            return request;
        }

        protected XGBceIternalRequest CreateRequest(string resourceKey,XGAbstractBceRequest bceRequest,BceHttpMethod httpMethod,params string[] pathVariables)
        {
            List<string> pathComponents = new List<string>()
            {
                "v1"
            };
            AssertStringNotNullOrEmpty(resourceKey, "resourceKey不能为空");
            pathComponents.Add(resourceKey);
            if (pathVariables != null)
                pathComponents.AddRange(pathVariables);

            XGBceIternalRequest request = new XGBceIternalRequest(httpMethod, HttpUtil.AppendUri(Endpoint, pathComponents.ToArray()))
            {
                Credentials = bceRequest.Credentials
            };
            request.AddMoreHeader(XGBceHeaders.USER_AGENT, config.UserAgent);
            BceSignOption options = BceSignOption.defaultBceSignOption;
            List<string> headersToSign = new List<string>()
            {
                XGBceHeaders.HOST,
                XGBceHeaders.BCE_DATE,
            };
            options.HeadersToSign = headersToSign;
            new XGBceSignerV1().Sign(request, request.Credentials, options);
            return request;
        }

        protected XGBceIternalRequest FillRequestPayload(XGBceIternalRequest iternalRequest,string strJson)
        {
            byte[] requestJson;
            try
            {
                requestJson = System.Text.Encoding.UTF8.GetBytes(strJson);
            }catch(Exception ex)
            {
                throw new XGBceClientException("不支持编码", ex);
            }

            iternalRequest.Content = new StringContent(strJson);
            iternalRequest.Content.Headers.ContentType= new System.Net.Http.Headers.MediaTypeHeaderValue(mediaType: "application/json") { CharSet = "utf-8" };
            iternalRequest.AddMoreHeader(XGBceHeaders.BCE_DATE, HttpUtil.FormatUTCTime(DateTime.Now));
            return iternalRequest;
        }

        #region

        protected static void AssertNotNullOrEmpty(object param, string nameofParam = null, string errorMessage = " 不能为空")
        {
            if (param == null)
            {
                if (string.IsNullOrEmpty(nameofParam) || string.IsNullOrWhiteSpace(nameofParam))
                    nameofParam = nameof(param);
                errorMessage = nameofParam + errorMessage;
                throw new ArgumentNullException(nameofParam, errorMessage);
            }
        }

        protected static void AssertStringNotNullOrEmpty(string param, string nameofParam = null, string errorMessage = " 不能为空")
        {

            if (string.IsNullOrEmpty(param) || string.IsNullOrWhiteSpace(param))
            {
                if (string.IsNullOrEmpty(nameofParam) || string.IsNullOrWhiteSpace(nameofParam))
                    nameofParam = nameof(param);
                errorMessage = nameofParam + errorMessage;
                throw new ArgumentNullException(nameofParam, errorMessage);
            }
        }

        protected static void AssertDicNotNullOrEmpty(IDictionary param, string nameofParam = null, string errorMessage = " 不能为空")
        {
            if (param == null || param.Count < 1)
            {
                if (string.IsNullOrEmpty(nameofParam) || string.IsNullOrWhiteSpace(nameofParam))
                    nameofParam = nameof(param);
                errorMessage = nameofParam + errorMessage;
                throw new ArgumentNullException(nameof(param), errorMessage);
            }
        }

        protected static void AssertStringArrayNotNullOrEmpty(string[] param, string nameofParam = null, string errorMessage = " 不能为空")
        {
            if (!(param != null && param.Length > 0))
            {
                if (string.IsNullOrEmpty(nameofParam) || string.IsNullOrWhiteSpace(nameofParam))
                    nameofParam = nameof(param);
                errorMessage = nameofParam + errorMessage;
                throw new ArgumentNullException(nameof(param), errorMessage);
            }
        }

        protected static void AssertStringListNotNullOrEmpty(List<string> param, string nameofParam = null, string errorMessage = " 不能为空")
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

        protected static void AssertIntListNotNullOrEmpty(List<int> param, string nameofParam = null, string errorMessage = " 不能为空")
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
