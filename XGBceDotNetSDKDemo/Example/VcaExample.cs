using System;
using XGBceDotNetSDK.BaseClass;
using XGBceDotNetSDK.Services.VCA;
using XGBceDotNetSDK.Services.VCA.Model;
using XGBceDotNetSDK.Sign;

namespace XGBceDotNetSDKDemo.Example
{
    public class VcaExample
    {
        private static string access_key_id = @"";
        private static string secret_access_key = @"";
        public VcaExample()
        {

            XGBceClientConfiguration bceClientConfiguration = new XGBceClientConfiguration()
            {
                Credentials = new DefaultBceCredentials(access_key_id, secret_access_key),
                Endpoint = "http://vca.bj.baidubce.com"
            };

            XGVcaClient vcaClient = new XGVcaClient(bceClientConfiguration);

            PuAnalyze(vcaClient);

            //try
            //{
            //    XGQueryResultResponse resultResponse = vcaClient.QueryResult("bos://视频地址");
            //    Console.WriteLine("分析成功：" + resultResponse.ToString());
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("分析失败：" + ex.Message);
            //}

            //try
            //{
            //    XGQuerySubTaskResponse resultResponse = vcaClient.QuerySubTaskResult("bos://视频地址", XGSubTaskType.cover);
            //    Console.WriteLine("中间任务分析成功：" + resultResponse.ToString());
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("中间任务分析失败：" + ex.Message);
            //}

            //try
            //{
            //    XGCreateCustomFaceLibResquest createCustomFaceLibResquest = new()
            //    {
            //        Lib = "faceLibTes"
            //    };
            //    vcaClient.CreateCustomLib(createCustomFaceLibResquest);
            //    Console.WriteLine("创建自定义face库成功");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("创建自定义face库失败：" + ex.Message);
            //}


            //try
            //{
            //    XGImageAnalyzeRequest imageAnalyzeRequest = new()
            //    {
            //        Source= "bos图片"
            //    };
            //    XGImageAnalyzeResponse imageAnalyzeResponse= vcaClient.ImageAnalyze(imageAnalyzeRequest);
            //    Console.WriteLine("图片分析成功："+imageAnalyzeResponse.ToString());
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("图片分析失败：" + ex.Message);
            //}
        }

        public static void PuAnalyze(XGVcaClient vcaClient)
        {
            try
            {
                XGAnalyzeResponse analyzeResponse = vcaClient.Analyze("");
                Console.WriteLine("分析提交成功：" + analyzeResponse.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("分析提交失败：" + ex.Message);
            }

        }
    }
}