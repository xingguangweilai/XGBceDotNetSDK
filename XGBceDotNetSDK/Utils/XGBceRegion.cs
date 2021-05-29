using System;
namespace XGBceDotNetSDK.Utils
{
    public class XGBceRegion
    {
        private string region="bj";
        /// <summary>
        /// 默认区域
        /// </summary>
        public static XGBceRegion DefaultRegion = new("bj");
        public XGBceRegion()
        {
        }

        public XGBceRegion(string regio)
        {
            region = regio;
        }
    }
}
