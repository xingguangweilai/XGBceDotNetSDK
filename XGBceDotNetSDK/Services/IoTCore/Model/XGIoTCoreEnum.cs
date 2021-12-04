using System;
namespace XGBceDotNetSDK.Services.IoTCore.Model
{
    /// <summary>
    /// IoTCore 枚举类
    /// </summary>
    public class XGIoTCoreEnum
    {
        public XGIoTCoreEnum()
        {
        }
    }

    /// <summary>
    /// 设备认证类型
    /// </summary>
    public enum XGIoTCoreDeviceAuthType
    {
        /// <summary>
        /// 密钥
        /// </summary>
        SIGNATURE,
        /// <summary>
        /// 证书
        /// </summary>
        CERT
    }
}
