using System;
namespace XGBceDotNetSDK.Services.VCR.Model
{/// <summary>
 /// 媒体内容审核VCR 枚举
 /// </summary>
    public class XGVcrEnum
    {
        public XGVcrEnum()
        {
        }
    }

    /// <summary>
    /// 媒体内容审核VCR 接口版本
    /// </summary>
    public enum XGVcrVersion
    {
        v1,
        v2,
        v3
    }

    /// <summary>
    /// 审核状态和进度
    /// <para> 每一次提交审核后，VCR会根据其使用的审核模板在内部根据不同审核类型进行多项”子审核”。 </para>
    /// <para> 若任一子审核失败，本次审核就会失败。 </para>
    /// <para> 当每项子审核完成时，VCR 都会更新本次审核的审核进度。 </para>
    /// </summary>
    public enum XGVcrStatus
    {
        /// <summary>
        /// 排队中
        /// <para> 审核排队中 </para>
        /// </summary>
        PROVISIONING,
        /// <summary>
        /// 审核中
        /// <para> 审核进行中 </para>
        /// </summary>
        PROCESSING,
        /// <summary>
        /// 审核完成
        /// <para> 可以查询审核结果 </para>
        /// </summary>
        FINISHED,
        /// <summary>
        /// 审核失败
        /// <para> 可以查询失败错误原因 </para>
        /// </summary>
        ERROR
    }

    /// <summary>
    /// 直播流审核状态
    /// </summary>
    public enum XGVcrStreamStatus
    {
        /// <summary>
        /// 排队中
        /// <para> 审核排队中 </para>
        /// </summary>
        PROVISIONING,
        /// <summary>
        /// 审核中
        /// <para> 审核进行中 </para>
        /// </summary>
        PROCESSING,
        /// <summary>
        /// 审核完成
        /// <para> 可以查询审核结果 </para>
        /// </summary>
        FINISHED,
        /// <summary>
        /// 取消审核
        /// </summary>
        CANCELLED,
        /// <summary>
        /// 审核失败
        /// <para> 可以查询失败错误原因 </para>
        /// </summary>
        ERROR
    }

    /// <summary>
    /// 通知等级
    /// </summary>
    public enum XGVcrNotifyLevel
    {
        NORMAL,
        REVIEW,
        REJECT
    }

}
