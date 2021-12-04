using System;
namespace XGBceDotNetSDK.Services.SMS.Model
{
    /// <summary>
    /// 删除签名请求类
    /// </summary>
    public class XGDeleteSignatureRequest:XGSmsRequest
    {
        private string signatureId;
        public XGDeleteSignatureRequest()
        {
        }

        /// <summary>
        /// 签名ID，唯一标识一个签名
        /// <para>必需</para>
        /// </summary>
        public string SignatureId { get => signatureId; set => signatureId = value; }
    }
}
