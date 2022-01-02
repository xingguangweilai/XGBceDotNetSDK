using System;
namespace XGBceDotNetSDK.Services.LSS.Model
{
    /// <summary>
    /// 音视频直播枚举
    /// </summary>
    public class XGLssEnum
    {
        public XGLssEnum()
        {
        }

        /// <summary>
        /// 音视频直播API版本
        /// </summary>
        public enum XGLssVersion
        {
            v5
        }

        /// <summary>
        /// 直播状态
        /// </summary>
        public enum XGLssStreamStatus
        {
            /// <summary>
            /// 已就绪
            /// </summary>
            READY,
            /// <summary>
            /// 直播中
            /// </summary>
            ONGOING,
            /// <summary>
            /// 已暂停
            /// </summary>
            PAUSED
        }

        /// <summary>
        /// 直播流状态
        /// <para>streaming，no_resource为ongoing的子状态，会因为网络等因素导致直播不稳定而切换状态</para>
        /// </summary>
        public enum XGLssStreamingStatus
        {
            /// <summary>
            /// 有输入流
            /// </summary>
            STREAMING,
            /// <summary>
            /// 无输入流
            /// </summary>
            NO_SOURCE,
            /// <summary>
            /// 失败
            /// </summary>
            FAILED
        }
    }
}
