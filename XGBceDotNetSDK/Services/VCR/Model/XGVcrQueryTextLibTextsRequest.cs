using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.VCR.Model
{
    /// <summary>
    /// 查看文本库文本内容请求类
    /// </summary>
    public class XGVcrQueryTextLibTextsRequest: XGAbstractVcrRequest
    {
        private string name;
        private int pageNo=1;
        private int pageSize=20;
        public XGVcrQueryTextLibTextsRequest()
        {
        }

        /// <summary>
        /// 自定义文本库名称
        /// </summary>
        [JsonIgnore]
        public string Name { get => name; set => name = value; }
        /// <summary>
        /// 分页页数，默认为1
        /// </summary>
        [JsonIgnore]
        public int PageNo { get => pageNo; set => pageNo = value; }
        /// <summary>
        /// 分页显示条数，默认为20
        /// </summary>
        [JsonIgnore]
        public int PageSize { get => pageSize; set => pageSize = value; }
    }
}
