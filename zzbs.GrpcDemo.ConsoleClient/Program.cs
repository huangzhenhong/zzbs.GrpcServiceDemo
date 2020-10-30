using Grpc.Net.Client;
using System;
using System.Threading.Tasks;
using zzbs.GrpcServiceDemo.DefaultServer;

namespace zzbs.GrpcDemo.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            {
                Console.WriteLine("*********************************************");
                TestHello().Wait();
            }
        }

        private static async Task TestHello() { 
            using(var channel = GrpcChannel.ForAddress("https://localhost:5001")) {
                var client = new Greeter.GreeterClient(channel);
                var reply = await client.SayHelloAsync(new HelloRequest { Name = "Mr. Daniel" });
                Console.WriteLine("Server: " + reply.Message);
            }
        }
    }
}
