using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sender
{
   public class TaskPublisher
    {
        private ConnectionFactory factory;
        private IConnection connection;
        private IModel channel;
        public TaskPublisher()
        {
            factory = new ConnectionFactory() { HostName = "localhost" };
        }
        public void Publish()
        {

            connection = factory.CreateConnection();
            channel = connection.CreateModel();
            channel.QueueDeclare(queue: "task_queue",
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);
                
        }

        public void Message(string message,int i)
        {
            
            var body = Encoding.UTF8.GetBytes(message);

            var properties = channel.CreateBasicProperties();
            properties.Persistent = true;

            channel.BasicPublish(exchange: "",
                                 routingKey: "task_queue",
                                 basicProperties: properties,
                                 body: body);
          //  Console.WriteLine("{0}--->{1}",i, message);
        }
        private static string GetMessage(string[] args)
        {
            return ((args.Length > 0) ? string.Join(" ", args) : "Hello World!");
        }
    }
}
