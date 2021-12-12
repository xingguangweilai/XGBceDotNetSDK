using System;
using XGBceDotNetSDK.BaseClass;
using XGBceDotNetSDK.Services.MEDIA;
using XGBceDotNetSDK.Services.MEDIA.Model;
using XGBceDotNetSDK.Sign;

namespace XGBceDotNetSDKDemo.Example
{
    public class McpExample
    {
        private static string access_key_id = @"";
        private static string secret_access_key = @"";
        public McpExample()
        {
            Console.WriteLine("McpExample!");
            XGBceClientConfiguration bceClientConfiguration = new XGBceClientConfiguration()
            {
                Credentials = new XGBceDefaultBceCredentials(access_key_id, secret_access_key)
            };

            XGMediaClient mediaClient = new XGMediaClient(bceClientConfiguration);

            //QueryPipelineTranscodingJob(mediaClient);
            //QueryTranscodingJob(mediaClient);
            //ListPresets(mediaClient);
            //QueryMediaInfo(mediaClient);
            //CreateWatermark(mediaClient);
            //ListWatermarks(mediaClient);
            //ListNotifications(mediaClient);
            QueryPipelineThumbnailJob(mediaClient);
        }

        /// <summary>
        /// 查询指定队列的视频转码任务信息
        /// </summary>
        /// <param name="mediaClient"></param>
        public static void QueryPipelineTranscodingJob(XGMediaClient mediaClient)
        {
            XGMediaQueryPipelineTranscodingJobRequest request = new XGMediaQueryPipelineTranscodingJobRequest()
            {
                PipelineName = "ttttttzdx",
                MaxSize=1
            };
            try
            {
                XGMediaQueryPipelineTranscodingJobResponse response = mediaClient.QueryPipelineTranscodingJob(request);
                Console.WriteLine("查询指定队列的视频转码任务信息成功：" + response);
            }
            catch(Exception ex)
            {
                Console.WriteLine("查询指定队列的视频转码任务信息失败："+ex.Message);
            }

        }

        /// <summary>
        /// 查询指定视频转码任务
        /// </summary>
        /// <param name="mediaClient"></param>
        public static void QueryTranscodingJob(XGMediaClient mediaClient)
        {
            try
            {
                XGMediaQueryTranscodingJobResponse response = mediaClient.QueryTranscodingJob("job-mm6i1ib3b6rrw4rw");
                Console.WriteLine("查询指定视频转码任务成功：" + response);
            }
            catch (Exception ex)
            {
                Console.WriteLine("查询指定视频转码任务失败：" + ex.Message);
            }
        }

        /// <summary>
        /// 查询当前用户模板及所有系统模板
        /// </summary>
        /// <param name="mediaClient"></param>
        public static void ListPresets(XGMediaClient mediaClient)
        {
            try
            {
                XGMediaListPresetsResponse response = mediaClient.ListPreset();
                Console.WriteLine("查询当前用户模板及所有系统模板成功：" + response);
            }
            catch (Exception ex)
            {
                Console.WriteLine("查询当前用户模板及所有系统模板失败：" + ex.Message);
            }
        }

        /// <summary>
        /// 查询指定媒体信息
        /// </summary>
        /// <param name="mediaClient"></param>
        public static void QueryMediaInfo(XGMediaClient mediaClient)
        {
            try
            {
                XGMediaQueryMediaInfoResponse response = mediaClient.QueryMediaInfo("bos", "0001.[风华国乐]无羁video.mp4");
                Console.WriteLine("查询指定媒体信息成功：" + response);
            }
            catch (Exception ex)
            {
                Console.WriteLine("查询指定媒体信息失败：" + ex.Message);
            }
        }

        /// <summary>
        /// 创建水印
        /// </summary>
        public static void CreateWatermark(XGMediaClient mediaClient)
        {
            try
            {
                XGMediaCreateWatermarkResponse response = mediaClient.CreateWatermark("bos", "IMG_8886.JPG");
                Console.WriteLine("创建水印成功：" + response);
            }
            catch (Exception ex)
            {
                Console.WriteLine("创建水印失败：" + ex.Message);
            }
        }

        /// <summary>
        /// 列举当前用户水印
        /// </summary>
        public static void ListWatermarks(XGMediaClient mediaClient)
        {
            try
            {
                XGMediaListWatermarksResponse response = mediaClient.ListWatermarks();
                Console.WriteLine("列举当前用户水印：" + response);
            }
            catch (Exception ex)
            {
                Console.WriteLine("列举当前用户水印失败：" + ex.Message);
            }
        }

        /// <summary>
        /// 列举通知
        /// </summary>
        /// <param name="mediaClient"></param>
        public static void ListNotifications(XGMediaClient mediaClient)
        {
            try
            {
                XGMediaListNotificationsResponse response = mediaClient.ListNotifications();
                Console.WriteLine("列举通知成功：" + response);
            }
            catch (Exception ex)
            {
                Console.WriteLine("列举通知失败：" + ex.Message);
            }
        }

        /// <summary>
        /// 查询指定队列的缩略图任务信息
        /// </summary>
        /// <param name="mediaClient"></param>
        public static void QueryPipelineThumbnailJob(XGMediaClient mediaClient)
        {
            try
            {
                XGMediaQueryPipelineThumbnailJobResponse response = mediaClient.QueryPipelineThumbnailJob("");
                Console.WriteLine("查询指定队列的缩略图任务信息成功：" + response);
            }
            catch (Exception ex)
            {
                Console.WriteLine("查询指定队列的缩略图任务信息失败：" + ex.Message);
            }
        }
    }
}
