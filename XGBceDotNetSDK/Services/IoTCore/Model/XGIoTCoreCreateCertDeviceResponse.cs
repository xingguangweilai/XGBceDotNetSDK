using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.IoTCore.Model
{
    /// <summary>
    /// 创建设备响应类
    /// <para>证书类型</para>
    /// </summary>
    public class XGIoTCoreCreateCertDeviceResponse: XGAbstractIoTCoreCreateDeviceResponse
    {
        private string privateKey;
        private string clientCert;

        public XGIoTCoreCreateCertDeviceResponse()
        {
        }

        /// <summary>
        /// 私钥
        /// </summary>
        [JsonProperty(PropertyName = "privateKey", NullValueHandling = NullValueHandling.Ignore)]
        public string PrivateKey { get => privateKey; set => privateKey = value; }
        /// <summary>
        /// 证书内容
        /// </summary>
        [JsonProperty(PropertyName = "clientCert", NullValueHandling = NullValueHandling.Ignore)]
        public string ClientCert { get => clientCert; set => clientCert = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
