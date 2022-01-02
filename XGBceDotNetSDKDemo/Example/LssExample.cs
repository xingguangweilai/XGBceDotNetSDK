using System;
using XGBceDotNetSDK.BaseClass;
using XGBceDotNetSDK.Services.LSS;
using XGBceDotNetSDK.Services.LSS.Model;
using XGBceDotNetSDK.Sign;

namespace XGBceDotNetSDKDemo.Example
{
    public class LssExample
    {
        private static string access_key_id = @"";
        private static string secret_access_key = @"";
        public LssExample()
        {
            Console.WriteLine("LssExample!");
            XGBceClientConfiguration bceClientConfiguration = new XGBceClientConfiguration()
            {
                Credentials = new XGBceDefaultBceCredentials(access_key_id, secret_access_key),
            };

            XGLssClient lssClient = new XGLssClient(bceClientConfiguration);

            //ListStreams(lssClient);
            //ListApps(lssClient);
            //QueryStream(lssClient);
            //ListStreamings(lssClient);
            //ResetStream(lssClient);
            //QueryStreamSourceInfo(lssClient);
            //ListStreamsSourceInfoAsync(lssClient);
            QueryPushUrlParams(lssClient);
        }

        /// <summary>
        /// 查询所有Stream
        /// </summary>
        /// <param name="lssClient"></param>
        public static void ListStreams(XGLssClient lssClient)
        {
            try
            {
                XGLssListStreamsResponse response= lssClient.ListStreams("",XGLssEnum.XGLssStreamStatus.READY);
                Console.WriteLine("查询所有Stream成功：\n" + response);
            }
            catch (Exception ex)
            {
                Console.WriteLine("查询所有Stream失败：\n" + ex.Message);
            }
        }

        /// <summary>
        /// 查询特定Domain下所有App
        /// </summary>
        /// <param name="lssClient"></param>
        public static void ListApps(XGLssClient lssClient)
        {
            try
            {
                XGLssListAppsResponse response = lssClient.ListApps("");
                Console.WriteLine("查询特定Domain下所有App成功：\n" + response);
            }
            catch (Exception ex)
            {
                Console.WriteLine("查询特定Domain下所有App失败：\n" + ex.Message);
            }
        }

        /// <summary>
        /// 查询特定Stream
        /// </summary>
        /// <param name="lssClient"></param>
        public static void QueryStream(XGLssClient lssClient)
        {
            try
            {
                XGLssQueryStreamResponse response = lssClient.QueryStream("","live","livetest");
                Console.WriteLine("查询特定Domain下所有App成功：\n" + response);
            }
            catch (Exception ex)
            {
                Console.WriteLine("查询特定Domain下所有App失败：\n" + ex.Message);
            }
        }

        /// <summary>
        /// 查询活跃的Stream
        /// </summary>
        /// <param name="lssClient"></param>
        public static void ListStreamings(XGLssClient lssClient)
        {
            try
            {
                XGLssListStreamingsResponse response = lssClient.ListStreamings("");
                Console.WriteLine("查询活跃的Stream成功：\n" + response);
            }
            catch (Exception ex)
            {
                Console.WriteLine("查询活跃的Stream失败：\n" + ex.Message);
            }
        }

        /// <summary>
        /// 重置特定stream
        /// </summary>
        /// <param name="lssClient"></param>
        public static void ResetStream(XGLssClient lssClient)
        {
            try
            {
                XGLssResponse response = lssClient.ResetStream("","live","livetest");
                Console.WriteLine("重置特定stream成功：\n" + response);
            }
            catch (Exception ex)
            {
                Console.WriteLine("重置特定stream失败：\n" + ex.Message);
            }
        }

        /// <summary>
        /// 查询实时直播源信息
        /// </summary>
        /// <param name="lssClient"></param>
        public static void QueryStreamSourceInfo(XGLssClient lssClient)
        {
            try
            {
                XGLssQueryStreamSourceInfoResponse response = lssClient.QueryStreamSourceInfo("", "live", "livetest");
                Console.WriteLine("查询实时直播源信息成功：\n" + response);
            }
            catch (Exception ex)
            {
                Console.WriteLine("查询实时直播源信息失败：\n" + ex.Message);
            }
        }

        /// <summary>
        /// 查询域名下实时直播源信息
        /// </summary>
        /// <param name="lssClient"></param>
        public static void ListStreamsSourceInfoAsync(XGLssClient lssClient)
        {
            try
            {
                XGLssDomainListStreamsSourceInfoResponse response = lssClient.ListStreamsSourceInfo("");
                Console.WriteLine("查询域名下实时直播源信息成功：\n" + response);
            }
            catch (Exception ex)
            {
                Console.WriteLine("查询域名下实时直播源信息失败：\n" + ex.Message);
            }
        }

        /// <summary>
        /// 查看实时流推流url参数
        /// </summary>
        /// <param name="lssClient"></param>
        public static void QueryPushUrlParams(XGLssClient lssClient)
        {
            try
            {
                XGLssQueryPushUrlParamsResponse response = lssClient.QueryPushUrlParams("", "live", "livetest");
                Console.WriteLine("查看实时流推流url参数息成功：\n" + response);
            }
            catch (Exception ex)
            {
                Console.WriteLine("查看实时流推流url参数失败：\n" + ex.Message);
            }
        }
    }
}
