using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using XGBceDotNetSDK.BaseClass;

namespace XGBceDotNetSDK.Services.IoTCore.Model
{
    public abstract class XGAbstractIoTCoreCreateDeviceResponse: XGAbstractBceResponse
    {
        private string name;
        private long createTs;
        private XGIoTCoreDeviceAuthType authType;

        public XGAbstractIoTCoreCreateDeviceResponse()
        {
        }

        /// <summary>
        /// 设备在此 IoT Core 内的唯一标识，与deviceName、deviceId同义
        /// </summary>
        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get => name; set => name = value; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [JsonProperty(PropertyName = "createTs", NullValueHandling = NullValueHandling.Ignore)]
        public long CreateTs { get => createTs; set => createTs = value; }
        /// <summary>
        /// 认证的类型
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)), JsonProperty(PropertyName = "authType", NullValueHandling = NullValueHandling.Ignore)]
        public XGIoTCoreDeviceAuthType AuthType { get => authType; set => authType = value; }
        
    }
}
