using MessageBrokerMQ;
using System;

namespace Sender
{
    class Program
    {
        static void Main(string[] args)
        {
            var sendingconfig = new Config()
            {
                Host = "localhost",
                Queue = "q",
                Exchange = "xchange",
                ExchangeType=Config.Direct,
                RoutingKey="abcd"
            };

            Console.WriteLine("-----------------------------User-1-------------------------");
       
            MessagePublisher messagePublisher = new MessagePublisher(sendingconfig);
            messagePublisher.SetConfigs();
            while (true)
            {
                Console.ForegroundColor =ConsoleColor.Gray;
                string s = Console.ReadLine();
                Console.WriteLine();
                messagePublisher.SendMessageThroughExchange(s);
            }




        }
    }
}
