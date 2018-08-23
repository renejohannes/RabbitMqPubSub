using System.ComponentModel.DataAnnotations;
using RabbitMq.Core.Configuration.Interfaces;

namespace RabbitMq.Core.Configuration.Implementation
{
    public class BusConfiguration: IBusConfiguration
    {
        [Required (ErrorMessage = "HostName is Required")]
        public string HostName { get; set; }

        [Range(0, 65535, ErrorMessage = "Invalid Port Number")]
        public int Port { get; set; }

        [Required (ErrorMessage = "Username is Required")]
        public string Username { get; set; }

        [Required (ErrorMessage = "Password is Required")]
        public string Password { get; set; }

        public QueueSetting QueueSetting { get; set; }

        public ExchangeSetting ExchangeSetting { get; set; }

    }
}
