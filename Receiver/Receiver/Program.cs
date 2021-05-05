
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;

using MessageBrokerMQ;
namespace Receiver
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var receivingconfig = new Config()
            {
                Host = "localhost",
                Queue = "q",
                Exchange = "xchange",
                ExchangeType = Config.Direct,
                RoutingKey = "abcd"

            };

            Console.WriteLine("-----------------------------User-2-------------------------");
            MessageReceiver messageReceiver = new MessageReceiver(receivingconfig);
            try
            {
                messageReceiver.SetConfigs();
                messageReceiver.ReceivedMessageThroughExchange();
            }
            catch (Exception ex)
            {

                throw;
            }

            Console.ReadKey();

        }

    }
    
    
}
