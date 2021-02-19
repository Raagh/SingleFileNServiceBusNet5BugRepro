using System;
using System.Threading.Tasks;
using NServiceBus;

namespace MainProject
{
    class Program
    {
        static async Task Main(string[] args)
        {
            EndpointConfiguration configuration = new EndpointConfiguration("MainProject");

            configuration.UseTransport<LearningTransport>();
            configuration.UsePersistence<LearningPersistence>();
            
            IEndpointInstance endpoint = await NServiceBus.Endpoint.Start(configuration).ConfigureAwait(false);

            Console.WriteLine("Main project is running");
            Console.WriteLine("Press Enter to stop it...");
            Console.ReadLine();

            await endpoint.Stop()
                .ConfigureAwait(false);
        }
    }
}