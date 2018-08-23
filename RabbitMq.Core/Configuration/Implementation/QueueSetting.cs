using System.ComponentModel.DataAnnotations;

namespace RabbitMq.Core.Configuration.Implementation
{
   public class QueueSetting
    {
        [Required (ErrorMessage = "QueueName is Required")]
        public string QueueName { get; set; }
        public bool Exclusive { get; set; }
        public bool AutoDelete { get; set; }
        public bool Durable { get; set; }
        public bool AutoAck { get; set; }
    }
}
