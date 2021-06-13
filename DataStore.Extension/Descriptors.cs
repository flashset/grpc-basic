using Grpc.Core; 

namespace DataStore.Extension
{
    public class Descriptors
    {
        public static Method<TRequest,TResponse> GetMethodConfig<TRequest, TResponse>(string serviceName , string methodName)
        {
            return new Method<TRequest, TResponse>(
                    type: MethodType.DuplexStreaming,
                    serviceName: serviceName,
                    name: methodName,
                    requestMarshaller: Marshallers.Create(
                        serializer: BinarySerializer<TRequest>.Serialize,
                        deserializer: BinarySerializer<TRequest>.Deserialize),
                    responseMarshaller: Marshallers.Create(
                        serializer: BinarySerializer<TResponse>.Serialize,
                        deserializer: BinarySerializer<TResponse>.Deserialize));
        }       
    }    
}