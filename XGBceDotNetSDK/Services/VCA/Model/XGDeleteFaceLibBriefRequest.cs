﻿using System;
using Newtonsoft.Json;
using XGBceDotNetSDK.Sign;

namespace XGBceDotNetSDK.Services.VCA.Model
{
    /// <summary>
    /// 删除face库集请求类
    /// </summary>
    public class XGDeleteFaceLibBriefRequest:XGAbstractVcaRequest
    {
        private string lib;
        private string brief;
        public XGDeleteFaceLibBriefRequest()
        {
        }

        /// <summary>
        /// logo库名
        /// 必需
        /// </summary>
        [JsonIgnore]
        public string Lib { get => lib; set => lib = value; }
        /// <summary>
        /// 图片描述
        /// 必需
        /// </summary>
        [JsonIgnore]
        public string Brief { get => brief; set => brief = value; }
    }
}
