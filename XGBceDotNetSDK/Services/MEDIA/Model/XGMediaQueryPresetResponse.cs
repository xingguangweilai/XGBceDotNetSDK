using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace XGBceDotNetSDK.Services.MEDIA.Model
{
    /// <summary>
    /// 查询指定模板响应类
    /// </summary>
    public class XGMediaQueryPresetResponse:XGMediaResponse
    {
        private string presetName;
        private string description;
        private string container;
        private bool? transmux;
        private XGMediaClip clip;
        private XGMediaAudioOutInfo audio;
        private XGMediaVideoOutInfo video;
        private XGMediaHLSEncryption encryption;
        private string watermarkId;
        private XGMediaWatermark watermarks;
        private XGMediaTransCfg transCfg;
        private XGMediaPresetState? state;
        private XGMediaPresetType? presetType;
        private DateTime? createdTime;

        public XGMediaQueryPresetResponse()
        {
        }

        /// <summary>
        /// 模板名称
        /// </summary>
        [JsonProperty(PropertyName = "presetName", NullValueHandling = NullValueHandling.Ignore)]
        public string PresetName { get => presetName; set => presetName = value; }
        /// <summary>
        /// 转码模板描述
        /// </summary>
        [JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get => description; set => description = value; }
        /// <summary>
        /// 音视频文件的容器
        /// </summary>
        [JsonProperty(PropertyName = "container", NullValueHandling = NullValueHandling.Ignore)]
        public string Container { get => container; set => container = value; }
        /// <summary>
        /// 是否仅执行容器格式转换
        /// </summary>
        [JsonProperty(PropertyName = "transmux", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Transmux { get => transmux; set => transmux = value; }
        /// <summary>
        /// 是否截取音视频片段
        /// </summary>
        [JsonProperty(PropertyName = "clip", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaClip Clip { get => clip; set => clip = value; }
        /// <summary>
        /// 音频输出信息的集合
        /// <para>不设置audio相关参数则转码输出不包含音频流，如果保留音频流则必须设置此对象</para>
        /// </summary>
        [JsonProperty(PropertyName = "audio", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaAudioOutInfo Audio { get => audio; set => audio = value; }
        /// <summary>
        /// 视频输出信息的集合
        /// </summary>
        [JsonProperty(PropertyName = "video", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaVideoOutInfo Video { get => video; set => video = value; }
        /// <summary>
        /// HLS加解密信息的集合
        /// </summary>
        [JsonProperty(PropertyName = "encryption", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaHLSEncryption Encryption { get => encryption; set => encryption = value; }
        /// <summary>
        /// 水印id
        /// </summary>
        [JsonProperty(PropertyName = "watermarkId", NullValueHandling = NullValueHandling.Ignore)]
        public string WatermarkId { get => watermarkId; set => watermarkId = value; }
        /// <summary>
        /// 多水印设置
        /// </summary>
        [JsonProperty(PropertyName = "watermarks", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaWatermark Watermarks { get => watermarks; set => watermarks = value; }
        /// <summary>
        /// 转码额外配置
        /// </summary>
        [JsonProperty(PropertyName = "transCfg", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaTransCfg TransCfg { get => transCfg; set => transCfg = value; }
        /// <summary>
        /// 模板状态
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)),JsonProperty(PropertyName = "state", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaPresetState? State { get => state; set => state = value; }
        /// <summary>
        /// 模板创建的UTC格式的时间
        /// </summary>
        [JsonProperty(PropertyName = "createdTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? CreatedTime { get => createdTime; set => createdTime = value; }
        /// <summary>
        /// 模板类型
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter)),JsonProperty(PropertyName = "presetType", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaPresetType? PresetType { get => presetType; set => presetType = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
