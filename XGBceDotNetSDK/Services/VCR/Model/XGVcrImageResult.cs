using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.VCR.Model
{
    /// <summary>
    /// 图片审核结果
    /// </summary>
    public class XGVcrImageResult
    {
        private string type;
        private List<XGVcrImageResultItem> items;

        public XGVcrImageResult()
        {
        }

        // <summary>
        /// 审核类型
        /// <para> 审核结果中的type表示”审核类型”。</para>
        /// <para> 每类审核场景下包含着多种审核类型，不同审核类型支持的审核物料也不一样。随着智能内容审核服务的迭代升级，会不断扩展审核场景和审核类型。 </para>
        /// </summary>
        [JsonProperty(PropertyName = "type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get => type; set => type = value; }
        /// <summary>
        /// 审核结果项数组
        /// <para> 在审核结果中，每个审核类型都对应一个items，表示该子审核的结果。数组中的元素称为审核结果项 </para>
        /// </summary>
        [JsonProperty(PropertyName = "items", NullValueHandling = NullValueHandling.Ignore)]
        public List<XGVcrImageResultItem> Items { get => items; set => items = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
