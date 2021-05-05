


namespace MessageBrokerMQ
{
   public class Config
    {    //
         // Summary:
         //     Exchange type used for AMQP direct exchanges.
        public const string Direct = "direct";
        //
        // Summary:
        //     Exchange type used for AMQP fanout exchanges.
        public const string Fanout = "fanout";
        //
        // Summary:
        //     Exchange type used for AMQP headers exchanges.
        public const string Headers = "headers";
        //
        // Summary:
        //     Exchange type used for AMQP topic exchanges.
        public const string Topic = "topic";
        public string Host { get; set; }
        public string Queue { get; set; }
       public string Exchange { get; set; }
        public bool GenerateQueue { get; set; }
        public string ExchangeType { get; set; }
        public string RoutingKey { get; set; }


    }


}
