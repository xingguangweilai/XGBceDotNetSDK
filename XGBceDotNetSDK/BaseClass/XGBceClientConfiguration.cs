using System;
using System.Net;
using System.Runtime.InteropServices;
using XGBceDotNetSDK.Sign;
using XGBceDotNetSDK.Utils;
using static System.Net.Mime.MediaTypeNames;

namespace XGBceDotNetSDK.BaseClass
{
    /// <summary>
    /// BCE客户端配置基类
    /// </summary>
    public class XGBceClientConfiguration
    {
        private string userAgent=DEFAULT_USER_AGENT;
        private XGRetryPolicy retryPolicy=XGRetryPolicy.DefaultRetryPolicy;
        private IPAddress localAddress;
        private XGBceProtocol protocol=XGBceProtocol.HTTP;
        private string proxyHost=null;
        private int? proxyPort;
        private string proxyUsername=null;
        private string proxyPassword=null;
        private string proxyDomain=null;
        private bool proxyPreemptiveAuthenticationEnabled;
        private int connectionTimeout=50;
        private int socketBufferSizeInBytes=0;
        private string endpoint=null;
        private XGBceRegion region=XGBceRegion.DefaultRegion;
        private XGBceCredentials credentials=null;
        private bool redirectsEnabled = true;

        private static readonly string DEFAULT_USER_AGENT= @"XGBceDotNet_" + SDKVERSION + "; " + Environment.OSVersion.ToString() + "; " + RuntimeInformation.OSArchitecture.ToString();

        private static readonly string SDKVERSION = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();


        /// <summary>
        /// 用户代理
        /// </summary>
        public string UserAgent { get => userAgent; set {
                if (value == null)
                    userAgent = DEFAULT_USER_AGENT;
                else if (value.EndsWith(DEFAULT_USER_AGENT))
                    userAgent = value;
                else
                    userAgent = value +" , "+ DEFAULT_USER_AGENT;
            } }
        /// <summary>
        /// 重试策略
        /// </summary>
        public XGRetryPolicy RetryPolicy { get => retryPolicy; set => retryPolicy = value??XGRetryPolicy.DefaultRetryPolicy; }
        /// <summary>
        /// 地址
        /// </summary>
        public IPAddress LocalAddress { get => localAddress; set => localAddress = value; }
        /// <summary>
        /// 协议
        /// </summary>
        public XGBceProtocol Protocol { get => protocol; set => protocol = value; }
        /// <summary>
        /// 代理主机
        /// </summary>
        public string ProxyHost { get => proxyHost; set => proxyHost = value; }
        /// <summary>
        /// 代理端口
        /// </summary>
        public int? ProxyPort { get => proxyPort; set => proxyPort = value; }
        /// <summary>
        /// 代理-用户名
        /// </summary>
        public string ProxyUsername { get => proxyUsername; set => proxyUsername = value; }
        /// <summary>
        /// 代理-密码
        /// </summary>
        public string ProxyPassword { get => proxyPassword; set => proxyPassword = value; }
        /// <summary>
        /// 代理-域名
        /// </summary>
        public string ProxyDomain { get => proxyDomain; set => proxyDomain = value; }
        public bool ProxyPreemptiveAuthenticationEnabled { get => proxyPreemptiveAuthenticationEnabled; set => proxyPreemptiveAuthenticationEnabled = value; }
        /// <summary>
        /// 连接超时时长
        /// 秒
        /// </summary>
        public int ConnectionTimeout{ get => connectionTimeout; set => connectionTimeout = value > -1 ? value : 0; }
        public int SocketBufferSizeInBytes { get => socketBufferSizeInBytes; set => socketBufferSizeInBytes = value; }
        /// <summary>
        /// 服务域名
        /// </summary>
        public string Endpoint { get {
                string url = endpoint;
                if (url != null && url.Length > 0 && url.IndexOf("://") < 0)
                    url = this.Protocol.ToString().ToLower() + "://" + url;
                return url;
            } set => endpoint = value??""; }
        /// <summary>
        /// 区域
        /// </summary>
        public XGBceRegion Region { get => region; set => region = value??XGBceRegion.DefaultRegion; }
        /// <summary>
        /// 凭证
        /// </summary>
        public XGBceCredentials Credentials { get => credentials; set => credentials = value; }
        /// <summary>
        /// 启用重定向
        /// </summary>
        public bool RedirectsEnabled { get => redirectsEnabled; set => redirectsEnabled = value; }

        public XGBceClientConfiguration()
        {
        }

        public XGBceClientConfiguration(XGBceClientConfiguration other):this(other,null)
        {
        }

        public XGBceClientConfiguration(XGBceClientConfiguration other, string endpo)
        {
            UserAgent = other.UserAgent;
            RetryPolicy = other.RetryPolicy;
            LocalAddress = other.LocalAddress;
            if(endpo!=null)
                this.Endpoint = endpo;
            Protocol = other.Protocol;
            ProxyHost = other.ProxyHost;
            ProxyPort = other.ProxyPort;
            ProxyUsername = other.ProxyUsername;
            ProxyPassword = other.ProxyPassword;
            ProxyPreemptiveAuthenticationEnabled = other.ProxyPreemptiveAuthenticationEnabled;
            ConnectionTimeout = other.ConnectionTimeout;
            SocketBufferSizeInBytes = other.SocketBufferSizeInBytes;
            Region = other.Region;
            Credentials = other.Credentials;
            RedirectsEnabled = other.RedirectsEnabled;
        }
    }
}
