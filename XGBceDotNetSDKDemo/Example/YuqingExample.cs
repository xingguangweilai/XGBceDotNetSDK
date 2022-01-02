using System;
using System.Collections.Generic;
using XGBceDotNetSDK.BaseClass;
using XGBceDotNetSDK.Services.YUQING;
using XGBceDotNetSDK.Services.YUQING.Model;
using XGBceDotNetSDK.Sign;

namespace XGBceDotNetSDKDemo.Example
{
    public class YuqingExample
    {
        private static string access_key_id = @"";
        private static string secret_access_key = @"";
        public YuqingExample()
        {
            Console.WriteLine("YuqingExample!");
            XGBceClientConfiguration bceClientConfiguration = new XGBceClientConfiguration()
            {
                Credentials = new XGBceDefaultBceCredentials(access_key_id, secret_access_key),
            };

            XGYuqingClient yuqingClient = new XGYuqingClient(bceClientConfiguration);

            //AddTask(yuqingClient);
            //ListTasks(yuqingClient);
            //DeleteTasks(yuqingClient);
            ListSelectedSystemTasks(yuqingClient);
        }

        /// <summary>
        /// 添加自定义监测任务
        /// </summary>
        /// <param name="yuqingClient"></param>
        public static void AddTask(XGYuqingClient yuqingClient)
        {
            try
            {
                XGYuqingAddTaskRequest request = new XGYuqingAddTaskRequest()
                {
                    FilterKeywords = new List<string>() { { "排除词测试" }, { "排除词2" } },
                    GeoIds = new List<int>() { { 1 } },
                    Name = "检测方案名称测试3",
                    OptionalKeywords = new List<string>() { { "搭配词1"} },
                    RequiredKeywords=new List<string>() { { "主监控词1"},{ "主监控词2"} },
                    TaskType=XGYuqingTaskType.EVENT
                };
                XGYuqingAddTaskResponse response = yuqingClient.AddTask(request);
                Console.WriteLine("添加自定义监测任务成功：\n" + response);
            }
            catch (Exception ex)
            {
                Console.WriteLine("添加自定义监测任务失败：\n" + ex.Message);
            }
        }

        /// <summary>
        /// 获取监测任务列表
        /// </summary>
        /// <param name="yuqingClient"></param>
        public static void ListTasks(XGYuqingClient yuqingClient)
        {
            try
            {
                XGYuqingListTasksResponse response = yuqingClient.ListTasks();
                Console.WriteLine("获取监测任务列表成功：\n" + response);
            }
            catch (Exception ex)
            {
                Console.WriteLine("获取监测任务列表失败：\n" + ex.Message);
            }
        }

        /// <summary>
        /// 删除监测任务列表
        /// </summary>
        /// <param name="yuqingClient"></param>
        public static void DeleteTasks(XGYuqingClient yuqingClient)
        {
            try
            {
                XGYuqingDeleteTaskResponse response = yuqingClient.DeleteTask("5861");
                Console.WriteLine("删除监测任务列表成功：\n" + response);
            }
            catch (Exception ex)
            {
                Console.WriteLine("删除监测任务列表失败：\n" + ex.Message);
            }
        }

        /// <summary>
        /// 获取用户选中的系统监测任务列表
        /// </summary>
        /// <param name="yuqingClient"></param>
        public static void ListSelectedSystemTasks(XGYuqingClient yuqingClient)
        {
            try
            {
                XGYuqingListSelectedSystemTasksResponse response = yuqingClient.ListSelectedSystemTasks();
                Console.WriteLine("获取用户选中的系统监测任务列表成功：\n" + response);
            }
            catch (Exception ex)
            {
                Console.WriteLine("获取用户选中的系统监测任务列表失败：\n" + ex.Message);
            }
        }

    }
}
