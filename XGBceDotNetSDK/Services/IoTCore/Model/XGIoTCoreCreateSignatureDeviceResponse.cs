using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.IoTCore.Model
{
    /// <summary>
    /// 创建设备响应类
    /// <para>密钥类型</para>
    /// </summary>
    public class XGIoTCoreCreateSignatureDeviceResponse: XGAbstractIoTCoreCreateDeviceResponse
    {
        private string secretKey;
        public XGIoTCoreCreateSignatureDeviceResponse()
        {
        }

        /// <summary>
        /// 生成的DeviceSecret
        /// </summary>
        [JsonProperty(PropertyName = "secretKey", NullValueHandling = NullValueHandling.Ignore)]
        public string SecretKey { get => secretKey; set => secretKey = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
