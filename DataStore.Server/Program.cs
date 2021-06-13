using DataStore.Extension;
using Grpc.Core;
using System;
using System.Configuration;
using System.Threading.Tasks;

namespace DataStore.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            RunAsync().Wait();
        }

        private static async Task RunAsync()
        {
            var server = new Grpc.Core.Server
            {
                Ports = { { ConfigurationManager.AppSettings["Server"], 
                        int.Parse(ConfigurationManager.AppSettings["Port"]), ServerCredentials.Insecure } },
                Services =
                {
                    ServerServiceDefinition.CreateBuilder()
                        .AddMethod(ServiceDefinition.Register, ServiceHandler.Register)                       
                        .Build()
                }
            };

            server.Start();

            Console.WriteLine(string.Format("Server started under [{0}:{1}]. Press Enter to stop it...",
                ConfigurationManager.AppSettings["Server"], ConfigurationManager.AppSettings["Port"]));

            Console.ReadLine();

            await server.ShutdownAsync();
        }

    }
}
