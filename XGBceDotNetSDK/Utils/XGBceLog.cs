using System;
namespace XGBceDotNetSDK.Utils
{
    public enum XGBceLogLevel
    {
        Info=0,
        Debug,
        Warn,
        Error,
        None
    }
    /// <summary>
    /// 日志类
    /// </summary>
    public class XGBceLog
    {
        private static XGBceLog instance=null;
        private static readonly object locklog = new object();
        private XGBceLogLevel level;
        private string appName = "XGBceDotNetSDK";

        /// <summary>
        /// 日志级别
        /// </summary>
        public XGBceLogLevel Level { get => level; set => level = value; }
        public string AppName { get => appName; set => appName = value; }

        /// <summary>
        /// 单例模式
        /// </summary>
        /// <returns></returns>
        public static XGBceLog GetLog()
        {
            if (instance == null)
            {
                lock (locklog)
                {
                    if (instance == null)
                    {
                        instance = new XGBceLog();
                        instance.level = XGBceLogLevel.Info;
                    }
                }
            }
            return instance;
        }
        private XGBceLog()
        {
        }

        private void PrintMessage(string levelName,string tag,string message)
        {
            DateTime dateTime = DateTime.Now;
            Console.WriteLine("[" + dateTime.ToString("yyyy-MM-dd HH:mm:ss.fff") +"]["+ levelName+"]["+appName+" | "+tag+"] "+message);
        }

        public void Info(string tag,string message)
        {
            if ((int)level > 0)
                return;
            PrintMessage("I",tag,message);
        }

        public void Debug(string tag, string message)
        {
            if((int)level > 1)
                return;
            PrintMessage("D",tag, message);
        }

        public void Warn(string tag, string message)
        {
            if ((int)level > 2)
                return;
            PrintMessage("W",tag, message);
        }

        public void Error(string tag, string message)
        {
            PrintMessage("E",tag, message);
        }
    }
}
