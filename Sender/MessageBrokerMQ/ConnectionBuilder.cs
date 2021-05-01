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
        protected Config _config;
        public ConnectionBuilder(Config config)
        {
            _config = config;
        
        }
        public virtual void SetConfigs()
        {
            _factory = new ConnectionFactory() { HostName = _config.Host };
            _connection = _factory.CreateConnection();
            _channel = _connection.CreateModel();
         
        }

      
    }
}
