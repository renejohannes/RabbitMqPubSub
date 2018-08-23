using RabbitMq.Core.Configuration.Implementation;

namespace RabbitMq.Core.Configuration.Interfaces
{
  public interface   IBusConfiguration
    {
        string HostName { get; set; }
        int Port { get; set; }
        string Username { get; set; }
        string Password { get; set; }
        QueueSetting QueueSetting { get; set; }
        ExchangeSetting ExchangeSetting { get; set; }
    }
}
