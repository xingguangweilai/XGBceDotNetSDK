# XGBceDotNetSDK
## 百度智能云服务端API 第三方C#SDK 

目前已集成简单消息服务SMS、媒体内容分析MCA、媒体内容审核VCR、物联网核心套件IoTCore的设备管理、音视频处理MCP，更多产品陆续完善中...

### 安装方法
> 支持最低版本：.NET Standard 2.0、.NET 5.0、.NET Core 2.0、.NET Framework 4.6.1

> NuGet Package Manager： Install-Package XG.XGBceDotNetSDK

> .NET CLI：dotnet add package XG.XGBceDotNetSDK 

### 使用方法示例(以音视频处理MCP为例)
> 新建MediaClient

    private static string access_key_id = "your-access-key-id";
    private static string secret_access_key = "your-secret-access-key";
    private static string endpoint = ""http://media.bj.baidubce.com";";

    //初始化一个MediaClient
    XGBceClientConfiguration bceClientConfiguration = new XGBceClientConfiguration()
    {
        Credentials = new XGBceDefaultBceCredentials(access_key_id, secret_access_key),
        Endpoint=endpoint
    };
    XGMediaClient mediaClient = new XGMediaClient(bceClientConfiguration);

* access_key_id和secret_access_key是由系统分配给用户的，均为字符串，用于标识用户，为访问Media做签名验证。其中access_key_id对应控制台中的“Access Key ID”（AK），Ssecret_access_key（SK）对应控制台中的“Access Key Secret”，获取方式请参考获取 [AK/SK](https://cloud.baidu.com/doc/Reference/s/9jwvz2egb)。
 * endpoint参数只能用产品指定的包含Region的域名来进行定义，例如：目前Media只提供北京一个Region，因此endpoint支持主域名http://media.bj.baidubce.com和备域名http://digitialmedia.bj.baidubce.com，随着Region的增加将会开放其他可以支持的域名。

> 调用MediaClient方法

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

> 更多示例参见： [XGBceDotNetSDKDemo.Example](https://github.com/xingguangweilai/XGBceDotNetSDK/tree/master/XGBceDotNetSDKDemo/Example)