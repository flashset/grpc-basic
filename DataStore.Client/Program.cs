using DataStore.DataModel;
using DataStore.Extension;
using Grpc.Core;
using Grpc.Core.Utils;
using System;
using System.Configuration;
using System.Threading.Tasks;

namespace DataStore.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = Register(new RegisterRequestModel()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "gRPC Demo",
                EmailId = "examples@sparkyflash.com"
            }).Result;

            Console.WriteLine(result.Message);
            Console.ReadLine();
        }

        public static async Task<RegisterResponseModel> Register(RegisterRequestModel request)
        {
            var channel = new Channel(ConfigurationManager.AppSettings["Server"], int.Parse(ConfigurationManager.AppSettings["Port"]), ChannelCredentials.Insecure);
            var invoker = new DefaultCallInvoker(channel);
            RegisterResponseModel res = null;
            using (var call = invoker.AsyncDuplexStreamingCall(ServiceDefinition.Register, null, new CallOptions { }))
            {
                var responseCompleted = call.ResponseStream
                        .ForEachAsync(async response =>
                        {
                            res = response;
                        });

                await call.RequestStream.WriteAsync(request);
                await call.RequestStream.CompleteAsync();
                await responseCompleted;
            }

            return res;
        }
    }
}
