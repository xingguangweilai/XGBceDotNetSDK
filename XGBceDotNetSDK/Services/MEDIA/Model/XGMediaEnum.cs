using System;
namespace XGBceDotNetSDK.Services.MEDIA.Model
{
    /// <summary>
    /// 音视频处理MCP枚举模型
    /// </summary>
    public class XGMediaEnum
    {
        public XGMediaEnum()
        {
        }
    }

    /// <summary>
    /// 音视频处理MCP接口版本
    /// </summary>
    public enum XGMediaVersion
    {
        v1,
        v2,
        v3
    }

    /// <summary>
    /// 队列类型
    /// </summary>
    public enum XGMediaPipelineType
    {
        /// <summary>
        /// 默认
        /// </summary>
        normal,
        /// <summary>
        /// 极速转码
        /// </summary>
        acceleration
    }

    /// <summary>
    /// 队列状态
    /// </summary>
    public enum XGMediaPipilineState
    {
        ACTIVE,
        INACTIVE
    }

    /// <summary>
    /// insert类型
    /// </summary>
    public enum XGMediaInsertType
    {
        /// <summary>
        /// 视频
        /// </summary>
        video,
        /// <summary>
        /// 图片
        /// </summary>
        image,
        /// <summary>
        /// 音频
        /// </summary>
        audio,
        /// <summary>
        /// 字幕
        /// </summary>
        subtitle,
        /// <summary>
        /// 文本
        /// </summary>
        text
    }

    /// <summary>
    /// 垂直对齐方式
    /// </summary>
    public enum XGMediaVerticalAlignment
    {
        /// <summary>
        /// 顶部对齐
        /// </summary>
        top,
        /// <summary>
        /// 中心对齐
        /// </summary>
        center,
        /// <summary>
        /// 底部对齐
        /// </summary>
        bottom
    }

    /// <summary>
    /// 水平对齐方式
    /// </summary>
    public enum XGMediaHorizontalAlignment
    {
        /// <summary>
        /// 左对齐
        /// </summary>
        left,
        /// <summary>
        /// 中心对齐
        /// </summary>
        center,
        /// <summary>
        /// 右对齐
        /// </summary>
        right
    }

    /// <summary>
    /// 自动去水印模式
    /// </summary>
    public enum XGMediaDelogoMode
    {
        Normal,
        Inpainting
    }

    /// <summary>
    /// 任务的状态
    /// </summary>
    public enum XGMediaJobStatus
    {
        SUCCESS,
        FAILED,
        PENDING,
        RUNNING
    }

    /// <summary>
    /// 视频编码类型
    /// </summary>
    public enum XGMediaVideoCodec
    {
        h264,
        /// <summary>
        /// 只支持 main profile
        /// </summary>
        h265,
        h265_bd265
    }

    /// <summary>
    /// 视频编码档次
    /// </summary>
    public enum XGMediaVideoCodecProfile
    {
        baseline,
        main,
        high
    }

    /// <summary>
    /// 尺寸伸缩策略
    /// </summary>
    public enum XGMediaVideoSizingPolicy
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
    /// HLS视频加密策略
    /// </summary>
    public enum XGMediaHLSEncryptionStrategy
    {
        /// <summary>
        /// 固定密钥加密
        /// <para>使用用户指定的密钥对视频进行加密，此时需要aesKey</para>
        /// </summary>
        Fixed,
        /// <summary>
        /// 开放密钥
        /// <para>系统自动生成加密密钥，密钥公开，不设访问控制</para>
        /// </summary>
        Open,
        Token,
        /// <summary>
        /// 绑定播放器
        /// <para>系统自动生成加密密钥，密钥设有访问控制，安全性比较高，推荐使用</para>
        /// </summary>
        PlayerBinding,
    }

    /// <summary>
    /// 转码模式
    /// </summary>
    public enum XGMediaTransMode
    {
        normal,
        twopass,
        super_resolution,
        cae_external,
        cae_external_sr,
        caev3
    }

    /// <summary>
    /// 模板状态
    /// </summary>
    public enum XGMediaPresetState
    {
        ACTIVE,
        INACTIVE
    }

    /// <summary>
    /// 模板类型
    /// </summary>
    public enum XGMediaPresetType
    {
        /// <summary>
        /// 系统预置模板
        /// </summary>
        SYSTEM,
        /// <summary>
        /// 用户自定义模板
        /// </summary>
        CUSTOM
    }

    /// <summary>
    /// 通知类型
    /// </summary>
    public enum XGMediaNotificationType
    {
        /// <summary>
        /// 普通通知回调
        /// </summary>
        NONE,
        /// <summary>
        /// 鉴权模式
        /// <para>会在header中增加Notification-Auth-Expire、Notification-Auth-User和Notification-Auth-Token用于验证</para>
        /// </summary>
        SIGN
    }

    /// <summary>
    /// 缩略图格式
    /// </summary>
    public enum XGMediaThumbnailFormat
    {
        jpg,
        png,
        mp4,
        gif,
        webp
    }

    /// <summary>
    /// gif的质量
    /// </summary>
    public enum XGMediaGifQuality
    {
        high,
        medium
    }

    /// <summary>
    /// 生成缩略图的模式
    /// </summary>
    public enum XGMediaThumbnailMode
    {
        /// <summary>
        /// 系统自动截取熵值较高的一帧作为缩略图
        /// </summary>
        auto,
        /// <summary>
        /// 根据指定的起止时间和间隔时间截取缩略图
        /// </summary>
        manual,
        /// <summary>
        /// 根据指定的起止时间和张数截取缩略图
        /// </summary>
        split,
        /// <summary>
        /// 根据场景切换自动截取画面(不支持输出视频格式)
        /// </summary>
        shot,
        /// <summary>
        /// 使用百度IDL（Institute of Deep Learning）智能缩略图算法截取缩略图（仅支持输出jpg、png格式）
        /// </summary>
        idl,
        /// <summary>
        /// 自动生成一个0.5s的精彩片段（目前仅适用于竖屏小视频，只支持输出视频格式，默认为正播反播合并效果
        /// </summary>
        highlight
    }

}
