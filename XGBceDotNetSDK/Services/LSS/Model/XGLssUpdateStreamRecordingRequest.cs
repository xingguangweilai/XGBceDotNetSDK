using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.LSS.Model
{
    /// <summary>
    /// 更新Stream录制模版请求类
    /// </summary>
    public class XGLssUpdateStreamRecordingRequest : XGLssStreamRequest
    {
        private string recording;
        public XGLssUpdateStreamRecordingRequest()
        {
        }

        /// <summary>
        /// 更新录制模板
        /// <para>必需</para>
        /// </summary>
        [JsonIgnore]
        public string Recording { get => recording; set => recording = value; }
    }
}
