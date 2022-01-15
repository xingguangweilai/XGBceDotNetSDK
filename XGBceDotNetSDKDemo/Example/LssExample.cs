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
            //QueryPushUrlParams(lssClient);
            //QueryRecording(lssClient);
            //ListRecordings(lssClient);
            //CreateWatermark(lssClient);
            //ListWatermarks(lssClient);
            //CreateTimestampWatermark(lssClient);
            //ListTimestampWatermarks(lssClient);
            //ListThumbnails(lssClient);
            //QueryDomainStatistics(lssClient);
            //QueryDomainSummaryStatistics(lssClient);
            //QueryDomainPlayCount(lssClient);
            //QueryDomainBandWidth(lssClient);
            //QueryDomainTraffic(lssClient);
            //ListNotifications(lssClient);
            DeleteNotification(lssClient);
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
                Console.WriteLine("查看实时流推流url参数成功：\n" + response);
            }
            catch (Exception ex)
            {
                Console.WriteLine("查看实时流推流url参数失败：\n" + ex.Message);
            }
        }

        /// <summary>
        /// 查询录制模板
        /// </summary>
        /// <param name="lssClient"></param>
        public static void QueryRecording(XGLssClient lssClient)
        {
            try
            {
                XGLssQueryRecordingResponse response = lssClient.QueryRecording("zdxtest111");
                Console.WriteLine("查询录制模板成功：\n" + response);
            }
            catch (Exception ex)
            {
                Console.WriteLine("查询录制模板失败：\n" + ex.Message);
            }
        }

        /// <summary>
        /// 录制模板列表
        /// </summary>
        /// <param name="lssClient"></param>
        public static void ListRecordings(XGLssClient lssClient)
        {
            try
            {
                XGLssListRecordingsResponse response = lssClient.ListRecordings();
                Console.WriteLine("列举录制模板成功：\n" + response);
            }
            catch (Exception ex)
            {
                Console.WriteLine("列举录制模板失败：\n" + ex.Message);
            }
        }

        /// <summary>
        /// 创建图片水印模板
        /// </summary>
        /// <param name="lssClient"></param>
        public static void CreateWatermark(XGLssClient lssClient)
        {
            try
            {
                string content = @"";
                XGLssResponse response = lssClient.CreateWatermark("watermarktest1",content);
                Console.WriteLine("创建图片水印模板成功：\n" + response);
            }
            catch (Exception ex)
            {
                Console.WriteLine("创建图片水印模板失败：\n" + ex.Message);
            }
        }

        /// <summary>
        /// 查询图片水印列表
        /// </summary>
        /// <param name="lssClient"></param>
        public static void ListWatermarks(XGLssClient lssClient)
        {
            try
            {
                XGLssListWatermarksResponse response = lssClient.ListWatermarks();
                Console.WriteLine("查询图片水印模板列表成功：\n" + response);
            }
            catch (Exception ex)
            {
                Console.WriteLine("查询图片水印模板列表失败：\n" + ex.Message);
            }
        }

        /// <summary>
        /// 删除图片水印
        /// </summary>
        /// <param name="lssClient"></param>
        public static void DeleteWatermark(XGLssClient lssClient)
        {
            try
            {
                lssClient.DeleteWatermark("");
                Console.WriteLine("删除图片水印成功");
            }
            catch (Exception ex)
            {
                Console.WriteLine("删除图片水印失败：\n" + ex.Message);
            }
        }

        /// <summary>
        /// 创建时间戳水印
        /// </summary>
        /// <param name="lssClient"></param>
        public static void CreateTimestampWatermark(XGLssClient lssClient)
        {
            try
            {
                lssClient.CreateTimestampWatermark("timestamptest");
                Console.WriteLine("创建时间戳水印成功");
            }
            catch (Exception ex)
            {
                Console.WriteLine("创建时间戳水印失败：\n" + ex.Message);
            }
        }

        /// <summary>
        /// 查询时间戳水印列表
        /// </summary>
        /// <param name="lssClient"></param>
        public static void ListTimestampWatermarks(XGLssClient lssClient)
        {
            try
            {
                XGLssListTimestampWatermarksResponse response = lssClient.ListTimestampWatermarks();
                Console.WriteLine("查询时间戳水印列表成功：\n" + response);
            }
            catch (Exception ex)
            {
                Console.WriteLine("查询时间戳水印列表失败：\n" + ex.Message);
            }
        }

        /// <summary>
        /// 列举缩略图模板
        /// </summary>
        /// <param name="lssClient"></param>
        public static void ListThumbnails(XGLssClient lssClient)
        {
            try
            {
                XGLssListThumbnailsResponse response = lssClient.ListThumbnails();
                Console.WriteLine("列举缩略图模板成功：\n" + response);
            }
            catch (Exception ex)
            {
                Console.WriteLine("列举缩略图模板失败：\n" + ex.Message);
            }
        }

        /// <summary>
        /// 查询统计数据
        /// </summary>
        /// <param name="lssClient"></param>
        public static void QueryDomainStatistics(XGLssClient lssClient)
        {
            try
            {
                XGLssQueryDomainStatisticsResponse response = lssClient.QueryDomainStatistics("域名","20211210","20220109");
                Console.WriteLine("查询统计数据成功：\n" + response);
            }
            catch (Exception ex)
            {
                Console.WriteLine("查询统计数据失败：\n" + ex.Message);
            }
        }

        /// <summary>
        /// 查询统计概要
        /// </summary>
        /// <param name="lssClient"></param>
        public static void QueryDomainSummaryStatistics(XGLssClient lssClient)
        {
            try
            {
                DateTime endTime = DateTime.Now;
                XGLssQueryDomainSummaryStatisticsResponse response = lssClient.QueryDomainSummaryStatistics(endTime.AddDays(-30),endTime);
                Console.WriteLine("查询统计概要成功：\n" + response);
            }
            catch (Exception ex)
            {
                Console.WriteLine("查询统计概要失败：\n" + ex.Message);
            }
        }

        /// <summary>
        /// 查询总请求数
        /// </summary>
        /// <param name="lssClient"></param>
        public static void QueryDomainPlayCount(XGLssClient lssClient)
        {
            try
            {
                DateTime endTime = DateTime.Now;
                XGLssQueryDomainPlayCountResponse response = lssClient.QueryDomainPlayCount(endTime.AddDays(-30),XGLssEnum.XGLssStatisticsTimeInterval.LONG_TERM, endTime, "lssplay.heyaochang.club");
                Console.WriteLine("查询总请求数成功：\n" + response);
            }
            catch (Exception ex)
            {
                Console.WriteLine("查询总请求数失败：\n" + ex.Message);
            }
        }

        /// <summary>
        /// 查询总带宽
        /// </summary>
        /// <param name="lssClient"></param>
        public static void QueryDomainBandWidth(XGLssClient lssClient)
        {
            try
            {
                DateTime endTime = DateTime.Now;
                XGLssQueryDomainBandWidthResponse response = lssClient.QueryDomainBandWidth(endTime.AddDays(-30), XGLssEnum.XGLssStatisticsTimeInterval.LONG_TERM, endTime, "lssplay.heyaochang.club");
                Console.WriteLine("查询总带宽成功：\n" + response);
            }
            catch (Exception ex)
            {
                Console.WriteLine("查询总带宽失败：\n" + ex.Message);
            }
        }

        /// <summary>
        /// 查询总流量
        /// </summary>
        /// <param name="lssClient"></param>
        public static void QueryDomainTraffic(XGLssClient lssClient)
        {
            try
            {
                DateTime endTime = DateTime.Now;
                XGLssQueryDomainTrafficResponse response = lssClient.QueryDomainTraffic(endTime.AddDays(-30), XGLssEnum.XGLssStatisticsTimeInterval.LONG_TERM, endTime, "lssplay.heyaochang.club");
                Console.WriteLine("查询总流量成功：\n" + response);
            }
            catch (Exception ex)
            {
                Console.WriteLine("查询总流量失败：\n" + ex.Message);
            }
        }

        /// <summary>
        /// 获取通知列表
        /// </summary>
        /// <param name="lssClient"></param>
        public static void ListNotifications(XGLssClient lssClient)
        {
            try
            {
                XGLssListNotificationsResponse response = lssClient.ListNotifications();
                Console.WriteLine("获取通知列表成功：\n" + response);
            }
            catch (Exception ex)
            {
                Console.WriteLine("获取通知列表失败：\n" + ex.Message);
            }
        }

        /// <summary>
        /// 删除通知
        /// </summary>
        /// <param name="lssClient"></param>
        public static void DeleteNotification(XGLssClient lssClient)
        {
            try
            {
                lssClient.DeleteNotification("1");
                Console.WriteLine("删除通知成功：\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("删除通知失败：\n" + ex.Message);
            }
        }
    }
}
