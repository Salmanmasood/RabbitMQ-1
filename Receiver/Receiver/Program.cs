
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;
using MessageBrokerMQ;
namespace Receiver
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----------------------------Receiver-------------------------");
            MessageReceiver messageReceiver = new MessageReceiver("localhost");
            MessagePublisher messagePublisher = new MessagePublisher("localhost");
            messageReceiver.SetConfigs();
            messagePublisher.SetConfigs();
            messageReceiver.ReceivedMessage();
            while (true)
            {
                Console.Write("You: ");
                string s = Console.ReadLine();
                Console.WriteLine();
                messagePublisher.SendMessage(s);

            }
         
        }
    }
    
}
