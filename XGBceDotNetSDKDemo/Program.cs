using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using XGBceDotNetSDK.BaseClass;
using XGBceDotNetSDK.Services.SMS;
using XGBceDotNetSDK.Services.SMS.Model;
using XGBceDotNetSDK.Services.VCA;
using XGBceDotNetSDK.Services.VCA.Model;
using XGBceDotNetSDK.Sign;
using XGBceDotNetSDK.Services.VCR;
using XGBceDotNetSDK.Services.VCR.Model;
using XGBceDotNetSDK.Services.IoTCore.Model;
using XGBceDotNetSDK.Services.IoTCore;
using XGBceDotNetSDKDemo.Example;

namespace XGBceDotNetSDKDemo
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //new DocExample();
            //new VcaExample();
            //new McpExample();
            //new YuqingExample();
            new LssExample();
            //new VcrExample();
        }
    }
}
