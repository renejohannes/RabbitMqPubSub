using System.ComponentModel.DataAnnotations;

namespace RabbitMq.Core.Configuration.Implementation
{
   public class ExchangeSetting
    {
        public string ExchangeName { get; set; }

        [Required (ErrorMessage = "RoutingKey is Required")]
        public string RoutingKey { get; set; }

        public string BasicProperties { get; set; }

        [Required (ErrorMessage = "ExchangeType is Required")]
        public string ExchangeType { get; set; }
    }
}
