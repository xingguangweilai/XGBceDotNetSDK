using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.VCA.Model
{
    /// <summary>
    /// 标签对应时间段
    /// </summary>
    public class XGTimeInSeconds
    {
        private int start;
        private int end;

        public XGTimeInSeconds() { }

        /// <summary>
        /// 起始时间
        /// </summary>
        [JsonProperty(PropertyName = "start", NullValueHandling = NullValueHandling.Ignore)]
        public int Start { get => start; set => start = value; }
        /// <summary>
        /// 结束时间
        /// </summary>
        [JsonProperty(PropertyName = "end", NullValueHandling = NullValueHandling.Ignore)]
        public int End { get => end; set => end = value; }
    }

    /// <summary>
    /// 标签属性
    /// </summary>
    public class XGSubTags
    {
        private string name;
        private List<string> attribute;

        public XGSubTags() { }

        /// <summary>
        /// 属性名，对于标签来源source=knowledge_graph_poem而言name的全量枚举是：作者/年代/类型，
        /// 对于标签来源source=knowledge_graph而言name的全量枚举是：别名/类型/所属系列/国家/地区/语言/年代/上映时间/出品方/看点/主演/全体演员
        /// </summary>
        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
        public string Start { get => name; set => name = value; }
        /// <summary>
        /// 属性值列表
        /// </summary>
        [JsonProperty(PropertyName = "attribute", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Attribute { get => attribute; set => attribute = value; }
    }

    /// <summary>
    /// 分析结果项
    /// </summary>
    public class XGResultItem
    {
        private string attribute;
        private double confidence;
        private string source;
        private List<XGTimeInSeconds> time;
        private string faceUrl;
        private string image;
        private string version;
        private XGSubTags subTags;

        public XGResultItem()
        {
        }

        /// <summary>
        /// 分析结果标签
        /// </summary>
        [JsonProperty(PropertyName = "attribute", NullValueHandling = NullValueHandling.Ignore)]
        public string Attribute { get => attribute; set => attribute = value; }
        /// <summary>
        /// 分析结果项的置信度，0~100的浮点数
        /// </summary>
        [JsonProperty(PropertyName = "confidence", NullValueHandling = NullValueHandling.Ignore)]
        public double Confidence { get => confidence; set => confidence = value; }
        /// <summary>
        /// 标签来源
        /// </summary>
        [JsonProperty(PropertyName = "source", NullValueHandling = NullValueHandling.Ignore)]
        public string Source { get => source; set => source = value; }
        /// <summary>
        /// 通知名称
        /// </summary>
        [JsonProperty(PropertyName = "notification", NullValueHandling = NullValueHandling.Ignore)]
        public List<XGTimeInSeconds> Time { get => time; set => time = value; }
        /// <summary>
        /// 中间任务版本
        /// </summary>
        [JsonProperty(PropertyName = "version", NullValueHandling = NullValueHandling.Ignore)]
        public string Version { get => version; set => version = value; }
        /// <summary>
        /// 对于人脸标签（即分析场景type=figure），当模版中开启人脸追踪时，可能会提供人脸图片地址
        /// </summary>
        [JsonProperty(PropertyName = "faceUrl", NullValueHandling = NullValueHandling.Ignore)]
        public string FaceUrl { get => faceUrl; set => faceUrl = value; }
        /// <summary>
        /// 对于人脸标签（即分析场景type=figure），当模版中开启人脸追踪时，可能会提供人脸所在抽帧地址
        /// </summary>
        [JsonProperty(PropertyName = "image", NullValueHandling = NullValueHandling.Ignore)]
        public string Image { get => image; set => image = value; }
        /// <summary>
        /// 对于知识图谱标签（即分析场景type=knowledge_graph），可能会提供标签属性列表
        /// </summary>
        [JsonProperty(PropertyName = "subTags", NullValueHandling = NullValueHandling.Ignore)]
        public XGSubTags SubTags { get => subTags; set => subTags = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
