using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.VCR.Model
{
    /// <summary>
    /// 查看黑库中的图片请求类
    /// </summary>
    public class XGVcrQueryImageLibImagesRequest: XGAbstractVcrRequest
    {
        private string name;
        private int pageNo = 1;
        private int pageSize = 20;
        public XGVcrQueryImageLibImagesRequest()
        {
        }

        /// <summary>
        /// 黑库名称
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
