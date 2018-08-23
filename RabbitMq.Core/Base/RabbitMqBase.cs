using RabbitMq.Core.Configuration.Interfaces;
using RabbitMQ.Client;

namespace RabbitMq.Core.Base
{
    public abstract class RabbitMqBase
    {
        protected readonly IBusConfiguration BusConfiguration;

        protected readonly IModel Channel;

        protected RabbitMqBase(IBusConfiguration busConfiguration)
        {
            BusConfiguration = busConfiguration;
            Channel = CreateChannel();
        }

        protected IModel CreateChannel()
        {
            var factory = new ConnectionFactory()
            {
                HostName = BusConfiguration.HostName,
                Port = AmqpTcpEndpoint.UseDefaultPort,
                UserName = BusConfiguration.Username,
                Password = BusConfiguration.Password
            };

            var connection = factory.CreateConnection();

            var channel = connection.CreateModel();

            channel.QueueDeclare(queue: BusConfiguration.QueueSetting.QueueName,
                durable: BusConfiguration.QueueSetting.Durable,
                exclusive: BusConfiguration.QueueSetting.Exclusive,
                autoDelete: BusConfiguration.QueueSetting.AutoDelete,
                arguments: null);

            return channel;
        }

        public virtual void ProcessBasicConsume(string message)
        {
        }

    }

}
