using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace MessageBrokerMQ
{
   public class MessagePublisher: ConnectionBuilder
    {

        public MessagePublisher(string host):base(host)
        {

        }
        public string SendMessage(string message)
        {

            var body = Encoding.UTF8.GetBytes(message);

            var properties = _channel.CreateBasicProperties();
            properties.Persistent = true;

            _channel.BasicPublish(exchange: "",
                                 routingKey: "task_queue",
                                 basicProperties: properties,
                                 body: body);

            return message;
        }
        
    }
}
