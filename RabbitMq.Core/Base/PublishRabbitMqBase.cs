using System.Text;
using RabbitMq.Core.Configuration.Interfaces;
using RabbitMQ.Client;

namespace RabbitMq.Core.Base
{
    public class PublishRabbitMqBase : RabbitMqBase
    {
        public PublishRabbitMqBase(IBusConfiguration busConfiguration) : base(busConfiguration)
        {
        }

        protected void PerformBasicPublish(string message)
        {
            var body = Encoding.UTF8.GetBytes(message);

            if (!Channel.IsOpen)
                base.CreateChannel();

            if (Channel.IsOpen)
                Channel.BasicPublish(
                    exchange: BusConfiguration.ExchangeSetting.ExchangeName,
                    routingKey: BusConfiguration.ExchangeSetting.RoutingKey,
                    basicProperties: null,
                    body: body);
        }
    }
}
