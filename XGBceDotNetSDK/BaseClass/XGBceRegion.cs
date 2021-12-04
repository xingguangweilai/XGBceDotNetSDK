using System;
namespace XGBceDotNetSDK.BaseClass
{
    public class XGBceRegion
    {
        private string region="bj";
        /// <summary>
        /// 默认区域
        /// </summary>
        public static XGBceRegion DefaultRegion = new XGBceRegion("bj");
        public XGBceRegion()
        {
        }

        public XGBceRegion(string regio)
        {
            if (regio == null)
                return;
            region = regio;
        }

        public override string ToString()
        {
            return region;
        }
    }
}
