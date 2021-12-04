using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.VCR.Model
{
    /// <summary>
    /// 提交图片审核（同步）请求类
    /// </summary>
    public class XGVcrPutImageRequest: XGAbstractVcrRequest
    {
        private string source;
        private string preset;
        public XGVcrPutImageRequest()
        {
        }

        /// <summary>
        /// 图片路径，支持bos或url两种格式
        /// <para>必需</para>
        /// <para>对于BOS图片，source="bos://{bos-bucket}/{bos-object}”，例如"bos://testbucket/dir/image.jpg”，用户需要确保bos路径可访问。</para>
        /// <para>对于url图片，source="http://domain.com/dir/image.jpg"，目前仅支持http协议url，用户需要确保该url外网可访问。</para>
        /// </summary>
        [JsonProperty(PropertyName = "source", NullValueHandling = NullValueHandling.Ignore)]
        public string Source { get => source; set => source = value; }
        /// <summary>
        /// 模板
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "preset", NullValueHandling = NullValueHandling.Ignore)]
        public string Preset { get => preset; set => preset = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
