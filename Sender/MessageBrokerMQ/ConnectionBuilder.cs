using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace MessageBrokerMQ
{
   public class ConnectionBuilder
    {
        protected ConnectionFactory _factory;
        protected IConnection _connection;
        protected IModel _channel;
        public ConnectionBuilder(string host)
        {
            _factory = new ConnectionFactory() { HostName = host };
        }
        public virtual void SetConfigs()
        {

            _connection = _factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: "task_queue",
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);
                
        }

      
    }
}
