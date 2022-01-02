using System;
namespace XGBceDotNetSDK.Services.YUQING.Model
{
    /// <summary>
    /// 舆情服务枚举类
    /// </summary>
    public class XGYuqingEnum
    {
        public XGYuqingEnum()
        {
        }
    }

    /// <summary>
    /// 舆情服务API版本
    /// </summary>
    public enum XGYuqingVersion
    {
        v1
    }

    /// <summary>
    /// 舆情媒体分类
    /// </summary>
    public enum XGYuqingMediaType
    {
        /// <summary>
        /// APP新闻
        /// </summary>
        APP_MEDIA,
        /// <summary>
        /// 论坛
        /// </summary>
        BBS_MEDIA,
        /// <summary>
        /// 网页新闻
        /// </summary>
        NEWS_MEDIA,
        /// <summary>
        /// 百家号
        /// </summary>
        FEED_MEDIA,
        /// <summary>
        /// 微博
        /// </summary>
        WEIBO_MEDIA,
        /// <summary>
        /// 博客
        /// </summary>
        BOKE_MEDIA,
        /// <summary>
        /// 其他
        /// </summary>
        OTHER_MEDIA,
        /// <summary>
        /// 视频
        /// </summary>
        VIDEO_MEDIA
    }

    /// <summary>
    /// 舆情服务监测方案分类
    /// </summary>
    public enum XGYuqingTaskType
    {
        /// <summary>
        /// 机构/企业
        /// </summary>
        COMPANY,
        /// <summary>
        /// 人物/角色
        /// </summary>
        HUMAN,
        /// <summary>
        /// 品牌/产品
        /// </summary>
        PRODUCT,
        /// <summary>
        /// 事件/专题
        /// </summary>
        EVENT,
        /// <summary>
        /// 其他
        /// </summary>
        OTHERS
    }

    /// <summary>
    /// 舆情服务情感属性分类
    /// </summary>
    public enum XGYuqingSentimentType
    {
        /// <summary>
        /// 证明
        /// </summary>
        POSITIVE,
        /// <summary>
        /// 中立
        /// </summary>
        NEUTRAL,
        /// <summary>
        /// 负面
        /// </summary>
        NEGATIVE
    }

    /// <summary>
    /// 舆情服务排序分类
    /// </summary>
    public enum XGYuqingOrderType
    {
        /// <summary>
        /// 按时间从旧到新排序
        /// </summary>
        ASC,
        /// <summary>
        /// 按时间从新到旧排序
        /// </summary>
        DESC,
        /// <summary>
        /// 按相关性从低到高排序
        /// </summary>
        RELEVANTASC,
        /// <summary>
        /// 按相关性从高到低排序
        /// </summary>
        RELEVANTDESC
    }

    /// <summary>
    /// 按任务关键词/表达式命中内容的字段
    /// </summary>
    public enum XGYuqingHitTypes
    {
        /// <summary>
        /// 标题和内容
        /// </summary>
        ALL,
        /// <summary>
        /// 标题
        /// </summary>
        TIELE
    }
}
