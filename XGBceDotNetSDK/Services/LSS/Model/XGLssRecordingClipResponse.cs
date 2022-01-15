using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.LSS.Model
{
    /// <summary>
    /// 录制视频裁剪响应类
    /// </summary>
    public class XGLssRecordingClipResponse:XGLssResponse
    {
        private string fileUrl;
        private string clipId;

        public XGLssRecordingClipResponse()
        {
        }

        /// <summary>
        /// m3u8剪裁：完成裁剪的视频的BOS地址
        /// </summary>
        [JsonProperty(PropertyName = "fileUrl", NullValueHandling = NullValueHandling.Ignore)]
        public string FileUrl { get => fileUrl; set => fileUrl = value; }
        /// <summary>
        /// MP4裁剪：用于查询裁剪的MP4结果的id，与最终返回的jobId对应
        /// </summary>
        [JsonProperty(PropertyName = "clipId", NullValueHandling = NullValueHandling.Ignore)]
        public string ClipId { get => clipId; set => clipId = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
