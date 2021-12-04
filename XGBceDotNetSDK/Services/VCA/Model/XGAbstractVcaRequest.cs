using System;
using XGBceDotNetSDK.BaseClass;

namespace XGBceDotNetSDK.Services.VCA.Model
{
    /// <summary>
    /// 媒体内容分析VCA抽象请求类
    /// 提到的库指的是lib，库集指的是brief，库集素材指的是image。库里包含库集，库集里包含库集素材集合。
    /// </summary>
    public abstract class XGAbstractVcaRequest: XGAbstractBceRequest
    {
        private XGVcaVersion vcaVersion = XGVcaVersion.v2;  //默认v2
        public XGAbstractVcaRequest()
        {
        }

        /// <summary>
        /// VCA接口版本
        /// </summary>
        public XGVcaVersion VcaVersion { get => vcaVersion; set => vcaVersion = value; }
    }
}
