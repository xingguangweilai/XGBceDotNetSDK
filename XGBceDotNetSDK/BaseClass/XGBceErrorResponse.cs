using System;
namespace XGBceDotNetSDK.BaseClass
{
    public class XGBceErrorResponse
    {
        private string requestId;
        private string code;
        private string message;
        public XGBceErrorResponse()
        {
        }

        /// <summary>
        /// RequestId
        /// </summary>
        public string RequestId { get => requestId; set => requestId = value; }
        /// <summary>
        /// 错误码
        /// </summary>
        public string Code { get => code; set => code = value; }
        /// <summary>
        /// 错误描述
        /// </summary>
        public string Message { get => message; set => message = value; }
    }
}
