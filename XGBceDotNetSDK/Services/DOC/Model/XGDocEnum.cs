using System;
namespace XGBceDotNetSDK.Services.DOC.Model
{
    /// <summary>
    /// 文档服务枚举类
    /// </summary>
    public class XGDocEnum
    {
        public XGDocEnum()
        {
        }
    }

    /// <summary>
    /// 文档服务API版本
    /// </summary>
    public enum XGDocVersion
    {
        v1,
        v2
    }

    /// <summary>
    /// 文档格式
    /// </summary>
    public enum XGDocFileFormat
    {
        doc,
        docx,
        ppt,
        pptx,
        xls,
        xlsx,
        vsd,
        pot,
        pps,
        rtf,
        wps,
        et,
        dps,
        pdf,
        txt,
        epub
    }

    /// <summary>
    /// 文档转码类型
    /// </summary>
    public enum XGDocTargetType
    {
        h5,
        image
    }

    /// <summary>
    /// 文档权限
    /// </summary>
    public enum XGDocAccess
    {
        /// <summary>
        /// 公开文档
        /// </summary>
        PUBLIC,
        /// <summary>
        /// 私有文档
        /// </summary>
        PRIVATE
    }

    /// <summary>
    /// 文档状态
    /// <para>文档在DOC整个生命周期中的各种状态称为文档状态</para>
    /// <para>说明文档：https://cloud.baidu.com/doc/DOC/s/Kjwvyprf0 </para>
    /// </summary>
    public enum XGDocStatus
    {
        /// <summary>
        /// 上传中
        /// <para>文档正在上传中</para>
        /// </summary>
        UPLOADING,
        /// <summary>
        /// 处理中
        /// <para>系统正在对文档进行后台处理。文档上传成功自动进入此状态</para>
        /// </summary>
        PROCESSING,
        /// <summary>
        /// 已发布
        /// <para>文档已完成处理，可以正常播放。系统完成对文档的后台处理后进入此状态</para>
        /// </summary>
        PUBLISHED,
        /// <summary>
        /// 处理失败
        /// <para>系统处理文档时发生异常</para>
        /// </summary>
        FAILED
    }
}
