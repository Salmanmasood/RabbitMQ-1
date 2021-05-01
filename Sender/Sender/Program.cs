using MessageBrokerMQ;
using System;

namespace Sender
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----------------------------Sender-------------------------");


            MessagePublisher messagePublisher = new MessagePublisher("localhost");
            messagePublisher.SetConfigs();
           
            while (true)
            {
                Console.WriteLine("Type Message: ");
                string s = Console.ReadLine();
                messagePublisher.SendMessage(s);
                
            }
            
           
         
            
    
        }
    }
}
