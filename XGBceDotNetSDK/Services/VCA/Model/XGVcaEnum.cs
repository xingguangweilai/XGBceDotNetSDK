using System;
namespace XGBceDotNetSDK.Services.VCA.Model
{
    /// <summary>
    /// 媒体内容分析MCA 枚举
    /// </summary>
    public class XGVcaEnum
    {
        public XGVcaEnum()
        {
        }
    }

    /// <summary>
    /// 媒体内容分析接口版本
    /// </summary>
    public enum XGVcaVersion
    {
        v1,
        v2
    }

    /// <summary>
    /// 分析状态
    /// <para>状态枚举参考文档： https://cloud.baidu.com/doc/VCA/s/fjwvybmi5#%E8%A7%86%E9%A2%91%E5%88%86%E6%9E%90%E7%8A%B6%E6%80%81%E5%92%8C%E8%BF%9B%E5%BA%A6</para>
    /// </summary>
    public enum XGVcaAnalyzeStatus
    {
        /// <summary>
        /// 预处理
        /// 视频分析排队中
        /// </summary>
        PROVISIONING,
        /// <summary>
        /// 分析中
        /// 视频分析进行中
        /// </summary>
        PROCESSING,
        /// <summary>
        /// 分析结束
        /// 可以查询分析结果
        /// </summary>
        FINISHED,
        /// <summary>
        /// 分析失败
        /// 可以查询失败错误原因
        /// </summary>
        ERROR,
        /// <summary>
        /// 分析取消
        /// 视频排队时可以取消分析
        /// </summary>
        CANCELLED
    }

    /// <summary>
    /// MCA 目前支持的分析场景
    /// <para>场景枚举参考文档：https://cloud.baidu.com/doc/VCA/s/fjwvybmi5#%E5%88%86%E6%9E%90%E5%9C%BA%E6%99%AF</para>
    /// </summary>
    public enum XGVcaAnalyzeType
    {
        /// <summary>
        /// 人脸
        /// </summary>
        figure,
        /// <summary>
        /// 关键字
        /// </summary>
        keyword,
        /// <summary>
        /// 场景
        /// </summary>
        scenario,
        /// <summary>
        /// 实体
        /// </summary>
        entity,
        /// <summary>
        /// 标识
        /// </summary>
        logo,
        /// <summary>
        /// 知识图谱
        /// </summary>
        knowledge_graph
    }

    /// <summary>
    /// 中间任务类型
    /// <para>枚举参考文档：https://cloud.baidu.com/doc/VCA/s/fjwvybmi5#%E4%B8%AD%E9%97%B4%E4%BB%BB%E5%8A%A1%E7%BB%93%E6%9E%9C%E8%AF%B4%E6%98%8E</para>
    /// </summary>
    public enum XGVcaSubTaskType
    {
        /// <summary>
        /// 视频转码
        /// </summary>
        video,
        /// <summary>
        /// 视频封面选取
        /// </summary>
        cover,
        /// <summary>
        /// 视频精彩图集
        /// </summary>
        video_cover,
        /// <summary>
        /// 视频精彩片段
        /// </summary>
        highlight,
        /// <summary>
        /// 以一定策略从视频截取的缩略图集合
        /// </summary>
        thumbnail,
        /// <summary>
        /// 视频缩略图通过OCR技术获取的文字识别结果
        /// </summary>
        character,
        /// <summary>
        /// 文字结构化
        /// </summary>
        ocr_structure,
        /// <summary>
        /// 视频音频
        /// </summary>
        audio,
        /// <summary>
        /// 视频音频通过ASR技术获取的语音识别结果
        /// </summary>
        peech,
        /// <summary>
        /// 视频标题
        /// </summary>
        title,
        /// <summary>
        /// 人脸追踪特征
        /// </summary>
        face_tracking,
        /// <summary>
        /// 人脸属性检测
        /// </summary>
        face_detect,
        /// <summary>
        /// tracking版本的公有人脸识别模型
        /// </summary>
        face_recognition_tracking,
        /// <summary>
        /// 非tracking版本的公有人脸识别模型
        /// </summary>
        face_recognition_thumbnail,
        /// <summary>
        /// tracking版本的私有人脸识别模型
        /// </summary>
        private_face_tracking,
        /// <summary>
        /// 非tracking版本的私有人脸识别模型
        /// </summary>
        private_face_image,
        /// <summary>
        /// 公有logo识别模型
        /// </summary>
        logo,
        /// <summary>
        /// 私有logo识别模型
        /// </summary>
        private_logo,
        /// <summary>
        /// 地标识别
        /// </summary>
        landmark,
        /// <summary>
        /// 人体属性
        /// </summary>
        human_attribute,
        /// <summary>
        /// 对文字识别结果textrank（通用版本）
        /// </summary>
        textrank_character,
        /// <summary>
        /// 对文字识别结果textrank（小视频专用版本）
        /// </summary>
        keyword_merge,
        /// <summary>
        /// 对语音识别结果textrank
        /// </summary>
        textrank_speech,
        /// <summary>
        /// 视频场景分类模型（通用版本）
        /// </summary>
        scenario_classify_v2,
        /// <summary>
        /// 场景分类模型（小视频专用版本）
        /// </summary>
        short_video_classify,
        /// <summary>
        /// 图像分类模型
        /// </summary>
        image_classify,
        /// <summary>
        /// 物体检测模型
        /// </summary>
        object_detect,
        /// <summary>
        /// 知识图谱
        /// </summary>
        knowledge_graph,
        /// <summary>
        /// 诗词识别
        /// </summary>
        knowledge_graph_poem
    }
}
