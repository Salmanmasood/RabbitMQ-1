using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MessageBrokerMQ
{
  public class MessageReceiver:ConnectionBuilder
    {
        public MessageReceiver(Config config) : base(config)
        {
          
        }

        public override void SetConfigs()
        {
            base.SetConfigs();
          
        }

            public void ReceivedMessageThroughQueue()
        {
            _channel.QueueDeclare(queue: _config.Queue,
                                 durable: true,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);


            _channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);
            var message = string.Empty;

                var consumer = new EventingBasicConsumer(_channel);
                consumer.Received += (sender, ea) =>
                {
                    var body = ea.Body.ToArray();
                     message = Encoding.UTF8.GetString(body);
                    int dots = message.Split('.').Length - 1;
                    Thread.Sleep(dots * 1000);
                    Console.ForegroundColor=System.ConsoleColor.Green;
                    Console.WriteLine("Your Friend: "+message);
                    _channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                };
                _channel.BasicConsume(queue: _config.Queue,
                                     autoAck: false,
                                     consumer: consumer);


        }

        public void ReceivedMessageThroughExchange()
        {

            _channel.ExchangeDeclare(exchange: _config.Exchange, type: ExchangeType.Fanout);

            var queueName = _channel.QueueDeclare().QueueName;
            _channel.QueueBind(queue: queueName,
                              exchange: _config.Exchange,
                              routingKey: "");

            
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine( message);
            };
            _channel.BasicConsume(queue: queueName,
                                 autoAck: true,
                                 consumer: consumer);


        }
    }
}
