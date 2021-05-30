using System;
namespace XGBceDotNetSDK.BaseClass
{
    /// <summary>
    /// 抽象类
    /// </summary>
    public abstract class XGAbstractBceClient
    {
        /// <summary>
        /// 默认域名
        /// </summary>
        string DEFAULT_SERVICE_DOMAIN = "baidubce.com";
        string URL_PREFIX = "v1";
        /// <summary>
        /// 默认编码
        /// </summary>
        string DEFAULT_ENCODING = "UTF-8";
        /// <summary>
        /// 默认content-type
        /// </summary>
        string DEFAULT_CONTENT_TYPE = "application/json; charset=utf-8";
        String serviceId;
        private Uri endpoint;
        private XGBceHttpClient client;
        protected XGBceClientBaseConfiguration config;
        private HttpResponseHandler[] responseHandlers;
        public XGAbstractBceClient()
        {
        }
    }
}
