using System;
namespace XGBceDotNetSDK.Utils
{
    /// <summary>
    /// 请求协议
    /// </summary>
    public class XGBceProtocol
    {
        /// <summary>
        /// 协议，默认为0：HTTP
        /// </summary>
        private int protocol=0;
        /// <summary>
        /// HTTP协议
        /// </summary>
        public static XGBceProtocol HTTP = new XGBceProtocol(0);
        /// <summary>
        /// HTTPS协议
        /// </summary>
        public static XGBceProtocol HTTPS = new XGBceProtocol(1);
        /// <summary>
        /// 端口号
        /// </summary>
        public string Port { get {
                if (protocol == 0)
                    return "80";
                return "443";
            } }

        public XGBceProtocol()
        {
        }

        public XGBceProtocol(int port)
        {
            protocol = port;
        }

        public override string ToString()
        {
            return protocol == 0 ? @"HTTP" : @"HTTPS";
        }
    }
}
