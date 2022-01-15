using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.LSS.Model
{
    /// <summary>
    /// 录制到VOD的配置信息
    /// </summary>
    public class XGLssRecordingVod
    {
        private bool? enabled;

        /// <summary>
        /// 是否录制到VOD
        /// </summary>
        [JsonProperty(PropertyName = "enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Enabled { get => enabled; set => enabled = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }

    /// <summary>
    /// 录制到BOS的配置信息
    /// </summary>
    public class XGLssRecordingBos
    {
        private string bucket;
        private string region;
        private string type;

        /// <summary>
        /// 录制文件存储的bos bucket名称
        /// </summary>
        [JsonProperty(PropertyName = "bucket", NullValueHandling = NullValueHandling.Ignore)]
        public string Bucket { get => bucket; set => bucket = value; }
        /// <summary>
        /// 录制文件存储的bos bucket区域
        /// </summary>
        [JsonProperty(PropertyName = "region", NullValueHandling = NullValueHandling.Ignore)]
        public string Region { get => region; set => region = value; }
        /// <summary>
        /// 录制文件存储的bos 文件类型
        /// </summary>
        [JsonProperty(PropertyName = "type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get => type; set => type = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }

    /// <summary>
    /// 查询录制模板响应类
    /// </summary>
    public class XGLssQueryRecordingResponse:XGLssResponse
    {
        private string name;
        private string description;
        private string format;
        private string pattern;
        private int? periodInMinute;
        private bool? inUse;
        private bool? alwaysMerge;
        private string avMode;
        private DateTime? createTime;
        private long? lastUpdateTime;
        private XGLssRecordingBos bos;
        private XGLssRecordingVod vod;

        public XGLssQueryRecordingResponse()
        {
        }

        /// <summary>
        /// 录制模板名称
        /// </summary>
        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get => name; set => name = value; }
        /// <summary>
        /// 录制模板描述
        /// </summary>
        [JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get => description; set => description = value; }
        /// <summary>
        /// 录制文件格式
        /// </summary>
        [JsonProperty(PropertyName = "format", NullValueHandling = NullValueHandling.Ignore)]
        public string Format { get => format; set => format = value; }
        /// <summary>
        /// 录制文件名模式
        /// </summary>
        [JsonProperty(PropertyName = "pattern", NullValueHandling = NullValueHandling.Ignore)]
        public string Pattern { get => pattern; set => pattern = value; }
        /// <summary>
        /// 单个录制文件时长
        /// <para>1-360分钟</para>
        /// </summary>
        [JsonProperty(PropertyName = "periodInMinute", NullValueHandling = NullValueHandling.Ignore)]
        public int? PeriodInMinute { get => periodInMinute; set => periodInMinute = value; }
        /// <summary>
        /// 录制模板是否在用
        /// </summary>
        [JsonProperty(PropertyName = "inUse", NullValueHandling = NullValueHandling.Ignore)]
        public bool? InUse { get => inUse; set => inUse = value; }
        /// <summary>
        /// 录制m3u8时一直合并
        /// </summary>
        [JsonProperty(PropertyName = "alwaysMerge", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AlwaysMerge { get => alwaysMerge; set => alwaysMerge = value; }
        /// <summary>
        /// avMode
        /// </summary>
        [JsonProperty(PropertyName = "avMode", NullValueHandling = NullValueHandling.Ignore)]
        public string AvMode { get => avMode; set => avMode = value; }
        /// <summary>
        /// 录制模板创建时间
        /// </summary>
        [JsonProperty(PropertyName = "createTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? CreateTime { get => createTime; set => createTime = value; }
        /// <summary>
        /// 录制模板最后更新时间
        /// </summary>
        [JsonProperty(PropertyName = "lastUpdateTime", NullValueHandling = NullValueHandling.Ignore)]
        public long? LastUpdateTime { get => lastUpdateTime; set => lastUpdateTime = value; }
        /// <summary>
        /// 录制到BOS的配置信息
        /// <para>与“录制到VOD”互斥</para>
        /// </summary>
        [JsonProperty(PropertyName = "bos", NullValueHandling = NullValueHandling.Ignore)]
        public XGLssRecordingBos Bos { get => bos; set => bos = value; }
        /// <summary>
        /// 录制到VOD的配置信息
        /// <para>与“录制到BOS”互斥</para>
        /// </summary>
        [JsonProperty(PropertyName = "vod", NullValueHandling = NullValueHandling.Ignore)]
        public XGLssRecordingVod Vod { get => vod; set => vod = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
