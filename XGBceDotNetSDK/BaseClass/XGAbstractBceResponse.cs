using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace XGBceDotNetSDK.BaseClass
{
    /// <summary>
    /// Bce抽象类
    /// </summary>
    [Serializable]
    public class XGAbstractBceResponse:ISerializable
    {
        private XGBceResponseMetadata metadata = new XGBceResponseMetadata();
        public XGAbstractBceResponse()
        {
        }

        [JsonIgnore]
        public XGBceResponseMetadata Metadata { get => metadata; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
        }

        public void Update(XGAbstractBceResponse updateResponse)
        {
            if (updateResponse == null)
                return;
            metadata = updateResponse.Metadata;
        }
         
    }
}
