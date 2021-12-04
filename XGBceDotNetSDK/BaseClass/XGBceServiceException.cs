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

    /// <summary>
    /// BCE service
    /// </summary>
    public class XGBceServiceException:XGBceClientException
    {
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

        /// <summary>
        /// 导致该错误的requestId
        /// </summary>
        public string RequestId { get => requestId; set => requestId = value; }
        /// <summary>
        /// 表示具体错误类型
        /// </summary>
        public string ErrorCode { get => errorCode; set => errorCode = value; }
        public XGBceErrorType ErrorType { get => errorType; set => errorType = value; }
        /// <summary>
        /// 有关该错误的详细说明
        /// </summary>
        public string ErrorMessage { get => errorMessage; set => errorMessage = value; }
        /// <summary>
        /// 状态码
        /// </summary>
        public int StatusCode { get => statusCode; set => statusCode = value; }
        public override string Message { get => ErrorMessage + " (Status Code: " + StatusCode + "; Error Code: " + ErrorCode + "; Request ID: " + RequestId + ")"; }
    }
}
