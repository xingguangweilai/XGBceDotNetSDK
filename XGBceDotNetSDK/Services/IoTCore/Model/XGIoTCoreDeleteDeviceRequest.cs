using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.IoTCore.Model
{
    /// <summary>
    /// 删除设备请求类
    /// </summary>
    public class XGIoTCoreDeleteDeviceRequest: XGAbstractIoTCoreRequest
    {
        private string iotCoreId;
        private string deviceName;
        public XGIoTCoreDeleteDeviceRequest()
        {
        }

        /// <summary>
        /// URLPath，IotCore的id
        /// <para> 必需 </para>
        /// </summary>
        [JsonIgnore]
        public string IotCoreId { get => iotCoreId; set => iotCoreId = value; }
        /// <summary>
        /// URLPath，设备在此 IoT Core 内的唯一标识，与设备创建中的name、deviceId同义
        /// <para> 必需 </para>
        /// </summary>
        [JsonIgnore]
        public string DeviceName { get => deviceName; set => deviceName = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
