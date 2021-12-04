using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XGBceDotNetSDK.BaseClass;

namespace XGBceDotNetSDK.Services.SMS
{
    /// <summary>
    /// 简单消息服务SMS客户端配置类
    /// <para> 说明：SMS用户默认使用“华北-北京“域名。</para>
    /// <para> 如需使用”华东-苏州“域名，请提交工单 https://ticket.bce.baidu.com/#/ticket/create </para>
    /// </summary>
    public class XGSmsClientConfiguration: XGBceClientConfiguration
    {
        public XGSmsClientConfiguration() { Endpoint = "http://smsv3.bj.baidubce.com/"; }
    }
}
