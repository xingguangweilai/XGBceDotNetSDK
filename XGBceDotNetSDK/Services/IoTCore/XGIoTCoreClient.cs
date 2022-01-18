using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using XGBceDotNetSDK.BaseClass;
using XGBceDotNetSDK.Http;
using XGBceDotNetSDK.Services.IoTCore.Model;
using XGBceDotNetSDK.Utils;

namespace XGBceDotNetSDK.Services.IoTCore
{
    public class XGIoTCoreClient: XGAbstractBceClient
    {
        private static string ENDPOINT_HOST= "iot.baidubce.com";
        public XGIoTCoreClient() : this(new XGBceClientConfiguration()) { }

        public XGIoTCoreClient(XGBceClientConfiguration configuration):base(HandleEndPoint(configuration))
        {
        }

        private static XGBceClientConfiguration HandleEndPoint(XGBceClientConfiguration configuration)
        {
            if (configuration == null)
                configuration = new XGBceClientConfiguration();
            if (configuration.Endpoint == null)
                configuration.Endpoint = ENDPOINT_HOST;
            return configuration;
        }

        /// <summary>
        /// 创建设备
        /// <para> 接口文档：https://cloud.baidu.com/doc/IoTCore/s/6kaw7eova#%E5%88%9B%E5%BB%BA%E8%AE%BE%E5%A4%87 </para>
        /// </summary>
        /// <param name="request">XGIoTCoreCreateDeviceRequest</param>
        /// <returns>XGAbstractIoTCoreCreateDeviceResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGAbstractIoTCoreCreateDeviceResponse CreateDevice(XGIoTCoreCreateDeviceRequest request)
        {
            AssertNotNullOrEmpty(request,nameof(request));
            AssertStringNotNullOrEmpty(request.IotCoreId,nameof(request.IotCoreId));
            AssertStringNotNullOrEmpty(request.Name,nameof(request.Name));
            AssertStringNotNullOrEmpty(request.TemplateId,nameof(request.TemplateId));
            AssertStringNotNullOrEmpty(request.Desc,nameof(request.Desc));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.POST, "v1/iotcore", request.IotCoreId, "device/new");
            XGAbstractIoTCoreCreateDeviceResponse response;
            if (request.AuthType == XGIoTCoreDeviceAuthType.SIGNATURE)
            {
               response= InvokeHttpClient<XGIoTCoreCreateSignatureDeviceResponse>(iternalRequest);
            }
            else
            {
                response = InvokeHttpClient<XGIoTCoreCreateCertDeviceResponse>(iternalRequest);
            }
            return response;
        }

        /// <summary>
        /// 创建设备
        /// </summary>
        /// <param name="request">XGIoTCoreCreateDeviceRequest</param>
        /// <returns>异步任务XGAbstractIoTCoreCreateDeviceResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGAbstractIoTCoreCreateDeviceResponse> CreateDeviceAsync(XGIoTCoreCreateDeviceRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.IotCoreId, nameof(request.IotCoreId));
            AssertStringNotNullOrEmpty(request.Name, nameof(request.Name));
            AssertStringNotNullOrEmpty(request.TemplateId, nameof(request.TemplateId));
            AssertStringNotNullOrEmpty(request.Desc, nameof(request.Desc));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.POST, "v1/iotcore", request.IotCoreId, "device/new");
            XGAbstractIoTCoreCreateDeviceResponse response;
            if (request.AuthType == XGIoTCoreDeviceAuthType.SIGNATURE)
            {
                response = await InvokeHttpClientAsync<XGIoTCoreCreateSignatureDeviceResponse>(iternalRequest);
            }
            else
            {
                response = await InvokeHttpClientAsync<XGIoTCoreCreateCertDeviceResponse>(iternalRequest);
            }
            return response;
        }

        /// <summary>
        /// 删除设备
        /// <para>删除单个设备</para>
        /// <para> 接口文档：https://cloud.baidu.com/doc/IoTCore/s/6kaw7eova#%E5%88%A0%E9%99%A4%E8%AE%BE%E5%A4%87 </para>
        /// </summary>
        /// <param name="iotCoreId">URLPath，IotCore的id</param>
        /// <param name="deviceName">URLPath，设备在此 IoT Core 内的唯一标识，与设备创建中的name、deviceId同义</param>
        /// <returns>XGIoTCoreResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGIoTCoreResponse DeleteDevice(string iotCoreId,string deviceName)
        {
            AssertStringNotNullOrEmpty(iotCoreId, nameof(iotCoreId));
            AssertStringNotNullOrEmpty(deviceName, nameof(deviceName));
            XGIoTCoreDeleteDeviceRequest request = new XGIoTCoreDeleteDeviceRequest()
            {
                IotCoreId=iotCoreId,
                DeviceName=deviceName
            };
            return DeleteDevice(request);
        }

        /// <summary>
        /// 删除设备
        /// <para>删除单个设备</para>
        /// </summary>
        /// <param name="iotCoreId">URLPath，IotCore的id</param>
        /// <param name="deviceName">URLPath，设备在此 IoT Core 内的唯一标识，与设备创建中的name、deviceId同义</param>
        /// <returns>异步任务XGIoTCoreResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGIoTCoreResponse> DeleteDeviceAsync(string iotCoreId, string deviceName)
        {
            AssertStringNotNullOrEmpty(iotCoreId, nameof(iotCoreId));
            AssertStringNotNullOrEmpty(deviceName, nameof(deviceName));
            XGIoTCoreDeleteDeviceRequest request = new XGIoTCoreDeleteDeviceRequest()
            {
                IotCoreId = iotCoreId,
                DeviceName = deviceName
            };
            return await DeleteDeviceAsync(request);
        }

        /// <summary>
        /// 删除设备
        /// <para>删除单个设备</para>
        /// <para> 接口文档：https://cloud.baidu.com/doc/IoTCore/s/6kaw7eova#%E5%88%A0%E9%99%A4%E8%AE%BE%E5%A4%87 </para>
        /// </summary>
        /// <param name="request">XGIoTCoreDeleteDeviceRequest</param>
        /// <returns>XGIoTCoreResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public XGIoTCoreResponse DeleteDevice(XGIoTCoreDeleteDeviceRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.IotCoreId, nameof(request.IotCoreId));
            AssertStringNotNullOrEmpty(request.DeviceName, nameof(request.DeviceName));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.DELETE, "v1/iotcore", request.IotCoreId, "device",request.DeviceName);
            XGIoTCoreResponse response = InvokeHttpClient<XGIoTCoreResponse>(iternalRequest);
            return response;
        }

        /// <summary>
        /// 删除设备
        /// <para>删除单个设备</para>
        /// </summary>
        /// <param name="request">XGIoTCoreDeleteDeviceRequest</param>
        /// <returns>异步任务XGIoTCoreResponse</returns>
        /// <exception cref="XGBceClientException">XGBce客户端异常</exception>
        public async Task<XGIoTCoreResponse> DeleteDeviceAsync(XGIoTCoreDeleteDeviceRequest request)
        {
            AssertNotNullOrEmpty(request, nameof(request));
            AssertStringNotNullOrEmpty(request.IotCoreId, nameof(request.IotCoreId));
            AssertStringNotNullOrEmpty(request.DeviceName, nameof(request.DeviceName));
            XGBceIternalRequest iternalRequest = CreateRequest(request, BceHttpMethod.DELETE, "v1/iotcore", request.IotCoreId, "device", request.DeviceName);
            XGIoTCoreResponse response = await InvokeHttpClientAsync<XGIoTCoreResponse>(iternalRequest);
            return response;
        }

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

        #endregion
    }
}
