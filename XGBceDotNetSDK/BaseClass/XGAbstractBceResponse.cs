using System;
using System.Runtime.Serialization;

namespace XGBceDotNetSDK.BaseClass
{
    [Serializable]
    public class XGAbstractBceResponse:ISerializable
    {
        private XGBceResponseMetadata metadata = new XGBceResponseMetadata();
        public XGAbstractBceResponse()
        {
        }

        public XGBceResponseMetadata Metadata { get => metadata; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
        }
    }
}
