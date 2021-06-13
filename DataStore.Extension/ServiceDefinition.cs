using DataStore.DataModel;
using Grpc.Core;

namespace DataStore.Extension
{
    public class ServiceDefinition
    {
        public static Method<RegisterRequestModel, RegisterResponseModel> Register =
            Descriptors.GetMethodConfig<RegisterRequestModel, RegisterResponseModel>("FileStoreService", "Register");
    }
}


