using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using static XGBceDotNetSDK.Services.LSS.Model.XGLssEnum;

namespace XGBceDotNetSDK.Services.LSS.Model
{
    /// <summary>
    /// 录制视频裁剪请求类
    /// </summary>
    public class XGLssRecordingClipRequest:XGAbstractLssRequest
    {
        private string playDomain;
        private string app;
        private string stream;
        private string filename;
        private XGLssClipFormat? format;
        private long? startTime;
        private long? endTime;
        private string sourceFile;
        private string pipeline;
        private string preset;
        private string clipId;

        public XGLssRecordingClipRequest()
        {
        }

        /// <summary>
        /// 播放域名名称
        /// <para>必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "playDomain", NullValueHandling = NullValueHandling.Ignore)]
        public string PlayDomain { get => playDomain; set => playDomain = value; }
        /// <summary>
        /// app名称
        /// <para>必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "app", NullValueHandling = NullValueHandling.Ignore)]
        public string App { get => app; set => app = value; }
        /// <summary>
        /// stream名称
        /// <para>必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "stream", NullValueHandling = NullValueHandling.Ignore)]
        public string Stream { get => stream; set => stream = value; }
        /// <summary>
        /// 指定裁剪后的文件名称
        /// <para>格式为clip_<stream名称>_<startTime>_<endTime>，startTime与endTime如果未指定也用对应的默认值</para>
        /// <para>可选</para>
        /// </summary>
        [JsonProperty(PropertyName = "filename", NullValueHandling = NullValueHandling.Ignore)]
        public string Filename { get => filename; set => filename = value; }
        /// <summary>
        /// 裁剪后视频的格式
        /// <para>可选</para>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)), JsonProperty(PropertyName = "format", NullValueHandling = NullValueHandling.Ignore)]
        public XGLssClipFormat? Format { get => format; set => format = value; }
        /// <summary>
        /// 指定录制视频开始时间（unix时间戳，单位秒）
        /// <para>可选</para>
        /// </summary>
        [JsonProperty(PropertyName = "startTime", NullValueHandling = NullValueHandling.Ignore)]
        public long? StartTime { get => startTime; set => startTime = value; }
        /// <summary>
        /// 指定录制视频结束时间（unix时间戳，单位秒）
        /// <para>可选</para>
        /// </summary>
        [JsonProperty(PropertyName = "endTime", NullValueHandling = NullValueHandling.Ignore)]
        public long? EndTime { get => endTime; set => endTime = value; }
        /// <summary>
        /// 是指定要裁剪的m3u8文件名，需要包括bucket下目录的路径
        /// <para>必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "sourceFile", NullValueHandling = NullValueHandling.Ignore)]
        public string SourceFile { get => sourceFile; set => sourceFile = value; }
        /// <summary>
        /// 指定MCT中的转码队列
        /// <para>format=mp4时必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "pipeline", NullValueHandling = NullValueHandling.Ignore)]
        public string Pipeline { get => pipeline; set => pipeline = value; }
        /// <summary>
        /// 指定MCT中的mp4转码模板
        /// <para>format=mp4时必选</para>
        /// </summary>
        [JsonProperty(PropertyName = "preset", NullValueHandling = NullValueHandling.Ignore)]
        public string Preset { get => preset; set => preset = value; }
        /// <summary>
        /// 查询裁剪MP4结果的id
        /// <para>可选</para>
        /// </summary>
        [JsonProperty(PropertyName = "clipId", NullValueHandling = NullValueHandling.Ignore)]
        public string ClipId { get => clipId; set => clipId = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
