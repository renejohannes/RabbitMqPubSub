using System.Text;
using RabbitMq.Core.Configuration.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitMq.Core.Base
{
   public class SubscribeRabbitMqBase : RabbitMqBase
    {
        public SubscribeRabbitMqBase(IBusConfiguration busConfiguration) : base(busConfiguration)
        {
        }

        protected void PerformBasicConsume()
        {
            var consumer = new EventingBasicConsumer(Channel);

            consumer.Received += (model, ea) =>
            {
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body);

                ProcessBasicConsume(message);
            };

            Channel.BasicConsume(
                queue: BusConfiguration.QueueSetting.QueueName,
                autoAck: BusConfiguration.QueueSetting.AutoAck,
                consumer: consumer);

        }
    }
}
