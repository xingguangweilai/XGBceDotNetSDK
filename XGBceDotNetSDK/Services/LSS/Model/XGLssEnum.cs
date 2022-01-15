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

        /// <summary>
        /// 垂直对齐方式
        /// </summary>
        public enum XGLssVerticalAlignment
        {
            top,
            center,
            bottom
        }

        /// <summary>
        /// 水平对齐方式
        /// </summary>
        public enum XGLssHorizontalAlignment
        {
            left,
            center,
            right
        }

        /// <summary>
        /// 伸缩策略
        /// </summary>
        public enum XGLssSizingPolicy
        {
            /// <summary>
            /// 保持原始视频宽高比
            /// </summary>
            keep,
            /// <summary>
            /// 保持原始视频宽高比并加黑边
            /// </summary>
            shrinkToFit,
            /// <summary>
            /// 拉伸原始视频
            /// </summary>
            stretch,
            /// <summary>
            /// 原始视频宽高比并加高斯模糊
            /// </summary>
            shrinkToFitBlur
        }

        /// <summary>
        /// 时区
        /// </summary>
        public enum XGLssTimezone
        {
            /// <summary>
            /// 中国标准时间
            /// </summary>
            CST,
            /// <summary>
            /// 协调世界时
            /// </summary>
            UTC
        }

        /// <summary>
        /// 文字字体
        /// </summary>
        public enum XGLssFontFamily
        {
            Arial
        }

        /// <summary>
        /// 统计时间间隔
        /// </summary>
        public enum XGLssStatisticsTimeInterval
        {
            /// <summary>
            /// 每天
            /// </summary>
            LONG_TERM,
            /// <summary>
            /// 每小时
            /// </summary>
            MID_TERM,
            /// <summary>
            /// 每5分钟
            /// </summary>
            SHORT_TERM
        }

        /// <summary>
        /// 统计排序关键字
        /// </summary>
        public enum XGLssStatisticsOrderBy
        {
            /// <summary>
            /// 域名
            /// </summary>
            domain,
            /// <summary>
            /// 下行流量
            /// </summary>
            downstream,
            /// <summary>
            /// 直播总时长
            /// </summary>
            duration,
            /// <summary>
            /// 峰值带宽
            /// </summary>
            peak_bandwidth,
            /// <summary>
            /// 峰值播放人数
            /// </summary>
            peak_play_count,
            /// <summary>
            /// 累计播放请求数
            /// </summary>
            play_count
        }

        /// <summary>
        /// 裁剪后视频的格式
        /// </summary>
        public enum XGLssClipFormat
        {
            m3u8,
            mp4
        }
    }
}
