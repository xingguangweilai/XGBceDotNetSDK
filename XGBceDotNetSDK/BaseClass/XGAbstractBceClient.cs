using System;
using XGBceDotNetSDK.BaseClass;
using XGBceDotNetSDK.Http.Handler;
using XGBceDotNetSDK.Sign;

namespace XGBceDotNetSDK.BaseClass
{
    public abstract class XGAbstractBceClient
    {
        /// <summary>
        /// 默认域名
        /// </summary>
        public static string DEFAULT_SERVICE_DOMAIN = "baidubce.com";
        /// <summary>
        /// URL前缀
        /// </summary>
        public static string URL_PREFIX = "v1";
        /// <summary>
        /// 默认编码
        /// </summary>
        public static string DEFAULT_ENCODING = "UTF-8";
        /// <summary>
        /// 默认Content-Type
        /// </summary>
        public static string DEFAULT_CONTENT_TYPE = "application/json; charset=utf-8";
        private string serviceId;
        private Uri endpoint;
        private XGBceHttpClient client;
        protected XGBceClientConfiguration config;
        private IXGHttpResponseHandler[] responseHandlers;

        public string ServiceId { get => serviceId; }
        public Uri Endpoint { get => endpoint; }
        public XGBceHttpClient Client { get => client; set => client = value; }
        public bool IsRegionSupported { get => true; }

        public XGAbstractBceClient(XGBceClientConfiguration configuration, IXGHttpResponseHandler[] handlers, bool isHttpAsyncPutEnable)
        {
            serviceId = ComputeServiceId();
            config = configuration;
            endpoint = ComputeEndpoint();
            client = new XGBceHttpClient(configuration, new XGBceSignerV1(), isHttpAsyncPutEnable);
            responseHandlers = handlers;
        }

        public XGAbstractBceClient(XGBceClientConfiguration configuration, IXGHttpResponseHandler[] handlers) :this(configuration, handlers, false) { }

        public string ComputeServiceId()
        {
            string nameSpace = GetType().Namespace.ToLower();
            if (!nameSpace.StartsWith("XGBceDotNetSDK.Services.".ToLower()))
                throw new Exception("请将类放入：XGBceDotNetSDK.Services.产品下");
            string [] ns = nameSpace.Split('.');
            nameSpace = ns[ns.Length - 1];
            return nameSpace;
        }

        private Uri ComputeEndpoint()
        {
            string endpoint_ = config.Endpoint;
            try
            {
                if (endpoint_ == null)
                {
                    if (IsRegionSupported)
                        endpoint_ = string.Format("%s://%s.%s.%s",config.Protocol.ToString(),serviceId,config.Region,"baidubce.com");
                    else
                        endpoint_ = string.Format("%s://%s.%s", config.Protocol.ToString(), serviceId, "baidubce.com");
                }
                return new Uri(endpoint_);
            }
            catch(UriFormatException ex)
            {
                throw new Exception("无效的endpoint："+ex.Message);
            }

        }
    }
}
