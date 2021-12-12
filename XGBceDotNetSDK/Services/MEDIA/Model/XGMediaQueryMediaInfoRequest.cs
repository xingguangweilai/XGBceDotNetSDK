using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.MEDIA.Model
{
    /// <summary>
    /// 查询指定媒体信息请求类
    /// </summary>
    public class XGMediaQueryMediaInfoRequest:XGAbstractMediaRequest
    {
        private string bucket;
        private string key;

        public XGMediaQueryMediaInfoRequest()
        {
        }

        /// <summary>
        /// 音视频文件所在的BOS的Bucket
        /// <para>必需</para>
        /// </summary>
        [JsonIgnore]
        public string Bucket { get => bucket; set => bucket = value; }
        /// <summary>
        /// 音视频文件的BOS的Key
        /// </summary>
        [JsonIgnore]
        public string Key { get => key; set => key = value; }
    }
}
