using System;
namespace XGBceDotNetSDK.Sign
{
    public class BceSignOption
    {
        private DateTime timeStamp;
        private int expirationPeriodInSeconds=1800;

        public readonly static BceSignOption defaultBceSignOption = new BceSignOption() { timeStamp=DateTime.Now};

        public BceSignOption()
        {
        }

        /// <summary>
        /// 时间戳
        /// </summary>
        public DateTime TimeStamp { get => timeStamp; set => timeStamp = value; }
        /// <summary>
        /// 超时时间
        /// </summary>
        public int ExpirationPeriodInSeconds { get => expirationPeriodInSeconds; set => expirationPeriodInSeconds = value; }
    }
}
