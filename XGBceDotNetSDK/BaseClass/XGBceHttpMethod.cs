using System;
namespace XGBceDotNetSDK.BaseClass
{
    public class XGBceHttpMethod
    {
        private int methodINT=-1;

        private static XGBceHttpMethod method;

        public static XGBceHttpMethod GET { get {
                if (method == null)
                    method = new XGBceHttpMethod(0);
                return method;
            } }

        public static XGBceHttpMethod POST
        {
            get
            {
                if (method == null)
                    method = new XGBceHttpMethod(1);
                return method;
            }
        }

        public static XGBceHttpMethod PUT
        {
            get
            {
                if (method == null)
                    method = new XGBceHttpMethod(2);
                return method;
            }
        }

        public static XGBceHttpMethod DELETE
        {
            get
            {
                if (method == null)
                    method = new XGBceHttpMethod(3);
                return method;
            }
        }

        public static XGBceHttpMethod HEAD
        {
            get
            {
                if (method == null)
                    method = new XGBceHttpMethod(4);
                return method;
            }
        }

        public static XGBceHttpMethod TRACE
        {
            get
            {
                if (method == null)
                    method = new XGBceHttpMethod(5);
                return method;
            }
        }

        public static XGBceHttpMethod PATCH
        {
            get
            {
                if (method == null)
                    method = new XGBceHttpMethod(6);
                return method;
            }
        }

        public static XGBceHttpMethod CONNECT
        {
            get
            {
                if (method == null)
                    method = new XGBceHttpMethod(7);
                return method;
            }
        }

        public static XGBceHttpMethod OPTIONS
        {
            get
            {
                if (method == null)
                    method = new XGBceHttpMethod(8);
                return method;
            }
        }

        public static XGBceHttpMethod ANY
        {
            get
            {
                if (method == null)
                    method = new XGBceHttpMethod(9);
                return method;
            }
        }

        private XGBceHttpMethod(int method)
        {
            methodINT = method;
        }

        public override bool Equals(object obj)
        {
            if (GetType()==obj.GetType())
            {
                XGBceHttpMethod resultObj = (XGBceHttpMethod)obj;
                if (resultObj.methodINT == methodINT)
                    return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return methodINT;
        }

        public override string ToString()
        {
            string methodStr = "GET";
            switch (methodINT)
            {
                case 1:methodStr = "POST";
                    break;
                case 2:
                    methodStr = "PUT";
                    break;
                case 3:
                    methodStr = "DELETE";
                    break;
                case 4:
                    methodStr = "HEAD";
                    break;
                case 5:
                    methodStr = "TRACE";
                    break;
                case 6:
                    methodStr = "PATCH";
                    break;
                case 7:
                    methodStr = "CONNECT";
                    break;
                case 8:
                    methodStr = "OPTIONS";
                    break;
                case 9:
                    methodStr = "ANY";
                    break;
            }

            return methodStr;
        }
    }
}
