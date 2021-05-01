using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace MessageBrokerMQ
{
   public class MessagePublisher: ConnectionBuilder
    {

        public MessagePublisher(Config config):base(config)
        {

        }


        public string SendMessageThroughQueue(string message)
        {
            _channel.QueueDeclare(queue: _config.Queue,
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

            Console.ForegroundColor = System.ConsoleColor.Gray;
            var body = Encoding.UTF8.GetBytes(message);

            var properties = _channel.CreateBasicProperties();
            properties.Persistent = true;

            _channel.BasicPublish(exchange: "",
                                 routingKey: _config.Queue,
                                 basicProperties: properties,
                                 body: body);
          
            return message;
        }

        public string SendMessageThroughExchange(string message)
        {
           _channel.ExchangeDeclare(exchange: _config.Exchange, type: ExchangeType.Fanout);
            var body = Encoding.UTF8.GetBytes(message);
            _channel.BasicPublish(exchange: _config.Exchange,
                                 routingKey: "",
                                 basicProperties: null,
                                 body: body);
            return message;
        }

    }
}
