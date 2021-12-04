using System;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.Services.SMS.Model
{
    public class XGSmsQueryQuotaRateResponse:XGSmsResponse
    {
        private int quotaPerDay;
        private int quotaPerMonth;
        private int quotaRemainToday;
        private int quotaRemainThisMonth;
        private bool quotaWhiteList;
        private int rateLimitPerMobilePerSignByMinute;
        private int rateLimitPerMobilePerSignByHour;
        private int rateLimitPerMobilePerSignByDay;
        private bool rateLimitWhiteList;

        public XGSmsQueryQuotaRateResponse()
        {
        }

        /// <summary>
        /// 日（自然日）发送配额
        /// </summary>
        [JsonProperty("quotaPerDay")]
        public int QuotaPerDay { get => quotaPerDay; set => quotaPerDay = value; }
        /// <summary>
        /// 月（自然月）发送配额
        /// </summary>
        [JsonProperty("quotaPerMonth")]
        public int QuotaPerMonth { get => quotaPerMonth; set => quotaPerMonth = value; }
        /// <summary>
        /// 日剩余配额
        /// </summary>
        [JsonProperty("quotaRemainToday")]
        public int QuotaRemainToday { get => quotaRemainToday; set => quotaRemainToday = value; }
        /// <summary>
        /// 月剩余配额
        /// </summary>
        [JsonProperty("quotaRemainThisMonth")]
        public int QuotaRemainThisMonth { get => quotaRemainThisMonth; set => quotaRemainThisMonth = value; }
        /// <summary>
        /// 是否为配额白名单（白名单用户无配额限制）
        /// </summary>
        [JsonProperty("quotaWhiteList")]
        public bool QuotaWhiteList { get => quotaWhiteList; set => quotaWhiteList = value; }
        /// <summary>
        /// 单手机号单签名每分钟（60s）发送频率
        /// </summary>
        [JsonProperty("rateLimitPerMobilePerSignByMinute")]
        public int RateLimitPerMobilePerSignByMinute { get => rateLimitPerMobilePerSignByMinute; set => rateLimitPerMobilePerSignByMinute = value; }
        /// <summary>
        /// 单手机号单签名每小时（60mins）发送频率
        /// </summary>
        [JsonProperty("rateLimitPerMobilePerSignByHour")]
        public int RateLimitPerMobilePerSignByHour { get => rateLimitPerMobilePerSignByHour; set => rateLimitPerMobilePerSignByHour = value; }
        /// <summary>
        /// 单手机号单签名每天（24h）发送频率
        /// </summary>
        [JsonProperty("rateLimitPerMobilePerSignByDay")]
        public int RateLimitPerMobilePerSignByDay { get => rateLimitPerMobilePerSignByDay; set => rateLimitPerMobilePerSignByDay = value; }
        /// <summary>
        /// 是否为频控白名单（白名单用户无频率限制）
        /// </summary>
        [JsonProperty("rateLimitWhiteList")]
        public bool RateLimitWhiteList { get => rateLimitWhiteList; set => rateLimitWhiteList = value; }

        public override string ToString()
        {
            return GetType().ToString() + "\n" + JsonConvert.SerializeObject(this);
        }
    }
}
