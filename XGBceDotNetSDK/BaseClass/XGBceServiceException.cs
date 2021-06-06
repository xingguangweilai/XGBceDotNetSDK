using System;
namespace XGBceDotNetSDK.BaseClass
{
    public enum XGBceErrorType
    {
        /// <summary>
        /// 客户端错误
        /// </summary>
        Client,
        /// <summary>
        /// 服务端错误
        /// </summary>
        Service,
        /// <summary>
        /// 未知错误
        /// </summary>
        Unknown
    }
    public class XGBceServiceException:XGBceClientException
    {
        private static long serialVersionUID = 123060000010086L;
        private string requestId;
        private string errorCode;
        private XGBceErrorType errorType=XGBceErrorType.Unknown;
        private string errorMessage;
        private int statusCode;
        public XGBceServiceException(string errormsg):base(errormsg)
        {
            ErrorMessage = errormsg;
        }

        public XGBceServiceException(string errormsg,Exception ex):base(errormsg,ex)
        {
            ErrorMessage = errormsg;
        }

        public string RequestId { get => requestId; set => requestId = value; }
        public string ErrorCode { get => errorCode; set => errorCode = value; }
        public XGBceErrorType ErrorType { get => errorType; set => errorType = value; }
        public string ErrorMessage { get => errorMessage; set => errorMessage = value; }
        public int StatusCode { get => statusCode; set => statusCode = value; }
        public override string Message { get => ErrorMessage + " (Status Code: " + StatusCode + "; Error Code: " + ErrorCode + "; Request ID: " + RequestId + ")"; }
    }
}
