using RabbitMq.Core.Base;
using RabbitMq.Core.Configuration.Interfaces;
using RabbitMq.Core.Tools;

namespace RabbitMq.Publish
{
    public class Publisher : PublishRabbitMqBase, IPublisher
    {
        private readonly ISerializerService _serializerService;

        public Publisher(IBusConfiguration busConfiguration, ISerializerService serializerService) : base(busConfiguration)
        {
            _serializerService = serializerService;
        }

        public void Publish<T>(T model)
        {
            var message = _serializerService.SerializeJson(model);

            PerformBasicPublish(message);
        }
    }
}
