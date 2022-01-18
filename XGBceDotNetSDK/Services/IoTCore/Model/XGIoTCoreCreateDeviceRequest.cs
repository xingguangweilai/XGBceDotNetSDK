using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace XGBceDotNetSDK.Services.IoTCore.Model
{
    /// <summary>
    /// 创建设备请求类
    /// </summary>
    public class XGIoTCoreCreateDeviceRequest: XGAbstractIoTCoreRequest
    {
        private string iotCoreId;
        private string name;
        private string templateId;
        private XGIoTCoreDeviceAuthType authType;
        private string desc;

        public XGIoTCoreCreateDeviceRequest()
        {
        }

        /// <summary>
        /// URLPath，IoT Core的 id，可在 IoT Core 列表页获取
        /// <para> 必需 </para>
        /// </summary>
        [JsonIgnore]
        public string IotCoreId { get => iotCoreId; set => iotCoreId = value; }
        /// <summary>
        /// 设备在此 IoT Core 内的唯一标识，与deviceName、deviceId 同义
        /// <para> 必需 </para>
        /// </summary>
        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get => name; set => name = value; }
        /// <summary>
        /// 设备模板的Id，可在控制台查看
        /// <para> 必需 </para>
        /// </summary>
        [JsonProperty(PropertyName = "templateId", NullValueHandling = NullValueHandling.Ignore)]
        public string TemplateId { get => templateId; set => templateId = value; }
        /// <summary>
        /// 认证类型
        /// <para> 必需 </para>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)), JsonProperty("authType")]
        public XGIoTCoreDeviceAuthType AuthType { get => authType; set => authType = value; }
        /// <summary>
        /// device 的描述信息0-128任意字符
        /// <para> 必需 </para>
        /// </summary>
        [JsonProperty(PropertyName = "desc", NullValueHandling = NullValueHandling.Ignore)]
        public string Desc { get => desc; set => desc = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
