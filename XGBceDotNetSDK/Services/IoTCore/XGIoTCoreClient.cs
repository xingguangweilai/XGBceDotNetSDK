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
            if (request == null)
            {
                throw new ArgumentNullException("request 不能为空");
            }
            if (string.IsNullOrEmpty(request.IotCoreId) || string.IsNullOrWhiteSpace(request.IotCoreId))
                throw new ArgumentNullException("IotCoreId 不能为空");
            if (string.IsNullOrEmpty(request.Name) || string.IsNullOrWhiteSpace(request.Name))
                throw new ArgumentNullException("Name 不能为空");
            if (string.IsNullOrEmpty(request.TemplateId) || string.IsNullOrWhiteSpace(request.TemplateId))
                throw new ArgumentNullException("TemplateId 不能为空");
            if (string.IsNullOrEmpty(request.Desc) || string.IsNullOrWhiteSpace(request.Desc))
                throw new ArgumentNullException("Desc 不能为空");
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
            if (request == null)
            {
                throw new ArgumentNullException("request 不能为空");
            }
            if (string.IsNullOrEmpty(request.IotCoreId) || string.IsNullOrWhiteSpace(request.IotCoreId))
                throw new ArgumentNullException("IotCoreId 不能为空");
            if (string.IsNullOrEmpty(request.Name) || string.IsNullOrWhiteSpace(request.Name))
                throw new ArgumentNullException("Name 不能为空");
            if (string.IsNullOrEmpty(request.TemplateId) || string.IsNullOrWhiteSpace(request.TemplateId))
                throw new ArgumentNullException("TemplateId 不能为空");
            if (string.IsNullOrEmpty(request.Desc) || string.IsNullOrWhiteSpace(request.Desc))
                throw new ArgumentNullException("Desc 不能为空");
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
            if (string.IsNullOrEmpty(iotCoreId) || string.IsNullOrWhiteSpace(iotCoreId))
                throw new ArgumentNullException("iotCoreId 不能为空");
            if (string.IsNullOrEmpty(deviceName) || string.IsNullOrWhiteSpace(deviceName))
                throw new ArgumentNullException("DeviceName 不能为空");
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
            if (string.IsNullOrEmpty(iotCoreId) || string.IsNullOrWhiteSpace(iotCoreId))
                throw new ArgumentNullException("iotCoreId 不能为空");
            if (string.IsNullOrEmpty(deviceName) || string.IsNullOrWhiteSpace(deviceName))
                throw new ArgumentNullException("DeviceName 不能为空");
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
            if (request == null)
            {
                throw new ArgumentNullException("request 不能为空");
            }
            if (string.IsNullOrEmpty(request.IotCoreId) || string.IsNullOrWhiteSpace(request.IotCoreId))
                throw new ArgumentNullException("IotCoreId 不能为空");
            if (string.IsNullOrEmpty(request.DeviceName) || string.IsNullOrWhiteSpace(request.DeviceName))
                throw new ArgumentNullException("DeviceName 不能为空");
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
            if (request == null)
            {
                throw new ArgumentNullException("request 不能为空");
            }
            if (string.IsNullOrEmpty(request.IotCoreId) || string.IsNullOrWhiteSpace(request.IotCoreId))
                throw new ArgumentNullException("IotCoreId 不能为空");
            if (string.IsNullOrEmpty(request.DeviceName) || string.IsNullOrWhiteSpace(request.DeviceName))
                throw new ArgumentNullException("DeviceName 不能为空");
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
