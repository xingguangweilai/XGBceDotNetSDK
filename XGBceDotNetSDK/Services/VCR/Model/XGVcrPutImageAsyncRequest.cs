using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.VCR.Model
{
    /// <summary>
    /// 提交图片审核（异步）请求类
    /// <para>用户提供图片URL或BOS路径，进行图片审核,支持GIF图片审核（GIF图片帧数不能超过100张）。</para>
    /// </summary>
    public class XGVcrPutImageAsyncRequest:XGVcrPutImageRequest
    {
        private string notification;
        public XGVcrPutImageAsyncRequest()
        {
        }

        /// <summary>
        /// 通知名称
        /// <para>非必需</para>
        /// <para>如果为空则审核结果不进行回调通知</para>
        /// </summary>
        [JsonProperty(PropertyName = "notification", NullValueHandling = NullValueHandling.Ignore)]
        public string Notification { get => notification; set => notification = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
