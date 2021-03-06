using System;
using System.Threading.Tasks;
using XGBceDotNetSDK.BaseClass;
using XGBceDotNetSDK.Http.Handler;
using XGBceDotNetSDK.Sign;
using XGBceDotNetSDK.Utils;

namespace XGBceDotNetSDK.BaseClass
{
    public abstract class XGAbstractBceClient
    {
        /// <summary>
        /// 默认域名
        /// </summary>
        protected static string DEFAULT_SERVICE_DOMAIN = "baidubce.com";
        /// <summary>
        /// URL前缀
        /// </summary>
        protected static string URL_PREFIX = "v1";
        /// <summary>
        /// 默认编码
        /// </summary>
        protected static string DEFAULT_ENCODING = "UTF-8";
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

        public XGAbstractBceClient(XGBceClientConfiguration configuration)
        {
            serviceId = ComputeServiceId();
            config = configuration;
            endpoint = ComputeEndpoint();
            if (config.Endpoint == null)
                config.Endpoint = endpoint.AbsoluteUri;
            client = new XGBceHttpClient(configuration, new XGBceSignerV1());
        }

        protected async Task<T> InvokeHttpClientAsync<T>(XGBceIternalRequest request, IXGHttpResponseHandler[] httpResponseHandlers=null) where T : XGAbstractBceResponse, new()
        {
            if (request.Content != null)
            {
                if (request.Content.Headers.ContentType==null)
                {
                    request.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(mediaType: "application/json")
                    {
                        CharSet = "utf-8"
                    };
                }
            }
            return await client.SendAsyny<T>(request, httpResponseHandlers);
        }

        protected T InvokeHttpClient<T>(XGBceIternalRequest request, IXGHttpResponseHandler[] httpResponseHandlers = null) where T:XGAbstractBceResponse,new ()
        {
            if (request.Content != null)
            {
                if (request.Content.Headers.ContentType == null)
                {
                    request.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(mediaType: "application/json")
                    {
                        CharSet = "utf-8"
                    };
                }
            }
            return client.Send<T>(request, httpResponseHandlers);
        }

        public string ComputeServiceId()
        {
            string nameSpace = GetType().Namespace.ToLower();
            if (!nameSpace.StartsWith("XGBceDotNetSDK.Services.".ToLower()))
                throw new Exception("请将类放入：XGBceDotNetSDK.Services.产品下");
            string [] ns = nameSpace.Split('.');
            nameSpace = ns[ns.Length-1];
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
                        endpoint_ = string.Format("{0}://{1}.{2}.{3}",config.Protocol.ToString().ToLower(),serviceId,config.Region.ToString(),"baidubce.com");
                    else
                        endpoint_ = string.Format("{0}://{1}.{2}", config.Protocol.ToString().ToLower(), serviceId, "baidubce.com");
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
