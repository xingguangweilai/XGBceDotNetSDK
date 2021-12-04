using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.SMS.Model
{
    /// <summary>
    /// 查询签名请求类
    /// </summary>
    public class XGQuerySignatureRequest: XGSmsRequest
    {
        private string signatureId;
        public XGQuerySignatureRequest()
        {
        }

        /// <summary>
        /// 签名ID，唯一标识一个签名
        /// <para>必需</para>
        /// </summary>
        public string SignatureId { get => signatureId; set => signatureId = value; }
    }
}
