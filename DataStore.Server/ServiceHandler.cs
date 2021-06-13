using DataStore.DataModel;
using DataStore.Server.FileStore;
using Grpc.Core;
using Grpc.Core.Utils;

namespace DataStore.Server
{
    class ServiceHandler
    {
        public static DuplexStreamingServerMethod<RegisterRequestModel, RegisterResponseModel> Register =
          async (requestStream, responseStream, context) =>
          {
              await requestStream.ForEachAsync(async request =>
              {
                  FileOperations fileOperations = new FileOperations();
                  await responseStream.WriteAsync(fileOperations.Register(request));
              });
          };
    }
}
