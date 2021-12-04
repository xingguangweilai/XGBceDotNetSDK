using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.SMS.Model
{
    /// <summary>
    /// 修改频控请求类
    /// </summary>
    public class XGSmsModifyQuotaRateRequest:XGSmsRequest
    {
        private int quotaPerDay;
        private int quotaPerMonth;
        private int rateLimitPerMobilePerSignByMinute;
        private int rateLimitPerMobilePerSignByHour;
        private int rateLimitPerMobilePerSignByDay;

        public XGSmsModifyQuotaRateRequest()
        {
        }

        /// <summary>
        /// 日（自然日）发送配额
        /// <para>必需</para>
        /// </summary>
        [JsonProperty("quotaPerDay")]
        public int QuotaPerDay { get => quotaPerDay; set => quotaPerDay = value; }
        /// <summary>
        /// 月（自然月）发送配额
        /// <para>必需</para>
        /// </summary>
        [JsonProperty("quotaPerMonth")]
        public int QuotaPerMonth { get => quotaPerMonth; set => quotaPerMonth = value; }
        /// <summary>
        /// 单手机号单签名每分钟（60s）发送频率
        /// <para>必需</para>
        /// </summary>
        [JsonProperty("rateLimitPerMobilePerSignByMinute")]
        public int RateLimitPerMobilePerSignByMinute { get => rateLimitPerMobilePerSignByMinute; set => rateLimitPerMobilePerSignByMinute = value; }
        /// <summary>
        /// 单手机号单签名每小时（60mins）发送频率
        /// <para>必需</para>
        /// </summary>
        [JsonProperty("rateLimitPerMobilePerSignByHour")]
        public int RateLimitPerMobilePerSignByHour { get => rateLimitPerMobilePerSignByHour; set => rateLimitPerMobilePerSignByHour = value; }
        /// <summary>
        /// 单手机号单签名每天（24h）发送频率
        /// <para>必需</para>
        /// </summary>
        [JsonProperty("rateLimitPerMobilePerSignByDay")]
        public int RateLimitPerMobilePerSignByDay { get => rateLimitPerMobilePerSignByDay; set => rateLimitPerMobilePerSignByDay = value; }
    }
}
