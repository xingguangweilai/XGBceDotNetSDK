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

        protected static void AssertStringNotNullOrEmpty(string parameterValue, String errorMessage)
        {
            if (string.IsNullOrEmpty(parameterValue)||string.IsNullOrWhiteSpace(parameterValue))
            {
                throw new ArgumentException(errorMessage);
            }
        }

        protected static void AssertDicNotNullOrEmpty(IDictionary parameterValue, String errorMessage)
        {
            if (parameterValue == null || parameterValue.Count<1)
            {
                throw new ArgumentException(errorMessage);
            }
        }

        protected static void AssertStringArrayNotNullOrEmpty(string[] parameterValue, String errorMessage)
        {
            if (parameterValue == null)
            {
                throw new ArgumentException(errorMessage);
            }
            else if (parameterValue.Length<1)
            {
                throw new ArgumentException(errorMessage);
            }
        }

        protected static void AssertListNotNullOrEmpty(List<Type> parameterValue, String errorMessage)
        {
            if (parameterValue == null)
            {
                throw new ArgumentException(errorMessage);
            }
            else if (parameterValue.Count<1)
            {
                throw new ArgumentException(errorMessage);
            }
        }
    }
}
