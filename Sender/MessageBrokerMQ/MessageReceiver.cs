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
        public MessageReceiver(string host):base(host)
        {
          
        }

        public override void SetConfigs()
        {
            base.SetConfigs();
            _channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);
        }

            public void ReceivedMessage()
            {
            

                var message = string.Empty;

                var consumer = new EventingBasicConsumer(_channel);
                consumer.Received += (sender, ea) =>
                {
                    var body = ea.Body.ToArray();
                     message = Encoding.UTF8.GetString(body);
                    int dots = message.Split('.').Length - 1;
                    Thread.Sleep(dots * 1000);
                    Console.WriteLine("Friend: "+message);
                    _channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                };
                _channel.BasicConsume(queue: "task_queue",
                                     autoAck: false,
                                     consumer: consumer);


        }
    }
}
