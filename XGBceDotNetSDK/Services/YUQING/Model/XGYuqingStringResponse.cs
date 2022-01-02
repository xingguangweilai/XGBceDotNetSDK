using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.YUQING.Model
{
    /// <summary>
    /// 适配舆情服务的奇葩应答包
    /// </summary>
    public class XGYuqingStringResponse: XGYuqingResponse
    {
        private string result;

        public XGYuqingStringResponse()
        {
        }

        /// <summary>
        /// 响应结果
        /// </summary>
        public string Result { get => result; set => result = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
