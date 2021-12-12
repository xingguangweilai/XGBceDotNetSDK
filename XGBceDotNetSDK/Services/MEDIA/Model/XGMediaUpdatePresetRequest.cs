using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.MEDIA.Model
{
    /// <summary>
    /// 更新指定模板请求类
    /// </summary>
    public class XGMediaUpdatePresetRequest:XGAbstractMediaRequest
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

        public XGMediaUpdatePresetRequest()
        {
        }

        /// <summary>
        /// 模板名称
        /// <para>必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "presetName", NullValueHandling = NullValueHandling.Ignore)]
        public string PresetName { get => presetName; set => presetName = value; }
        /// <summary>
        /// 转码模板描述
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get => description; set => description = value; }
        /// <summary>
        /// 音视频文件的容器
        /// <para>取值范围：mp4, flv, hls, mp3, m4a, a-hls, pcm, dash, ts</para>
        /// <para>必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "container", NullValueHandling = NullValueHandling.Ignore)]
        public string Container { get => container; set => container = value; }
        /// <summary>
        /// 是否仅执行容器格式转换
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "transmux", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Transmux { get => transmux; set => transmux = value; }
        /// <summary>
        /// 是否截取音视频片段
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "clip", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaClip Clip { get => clip; set => clip = value; }
        /// <summary>
        /// 音频输出信息的集合
        /// <para>不设置audio相关参数则转码输出不包含音频流，如果保留音频流则必须设置此对象</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "audio", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaAudioOutInfo Audio { get => audio; set => audio = value; }
        /// <summary>
        /// 视频输出信息的集合
        /// <para>不设置vedio相关参数则转码输出不包含视频流，如果保留视频流则必须设置此对象</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "video", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaVideoOutInfo Video { get => video; set => video = value; }
        /// <summary>
        /// HLS加解密信息的集合
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "encryption", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaHLSEncryption Encryption { get => encryption; set => encryption = value; }
        /// <summary>
        /// 水印id
        /// <para>当transmux=true时不允许添加水印</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "watermarkId", NullValueHandling = NullValueHandling.Ignore)]
        public string WatermarkId { get => watermarkId; set => watermarkId = value; }
        /// <summary>
        /// 多水印设置
        /// <para>不可同时指定watermarkId和watermarks</para>
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "watermarks", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaWatermark Watermarks { get => watermarks; set => watermarks = value; }
        /// <summary>
        /// 转码额外配置
        /// <para>非必需</para>
        /// </summary>
        [JsonProperty(PropertyName = "transCfg", NullValueHandling = NullValueHandling.Ignore)]
        public XGMediaTransCfg TransCfg { get => transCfg; set => transCfg = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
