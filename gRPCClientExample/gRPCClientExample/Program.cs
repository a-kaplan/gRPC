using Grpc.Core;
using Grpc.Net.Client;
using System;
using System.Threading.Tasks;

namespace gRPCClientExample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            while (true)
            {

                var channel = GrpcChannel.ForAddress("https://localhost:5001");
                var greetClient = new Greeter.GreeterClient(channel);
                HelloReply response = await greetClient.SayHelloAsync(new HelloRequest { Name = "hi say" });
                Console.WriteLine($"Gelen Cevap 1: {response.Message}");

                response = await greetClient.SayHelloAsync(new HelloRequest { Name = "hi say 2" });
                Console.WriteLine($"Gelen Cevap 2: {response.Message}");
                Console.ReadLine();

            }

        }
    }
}
