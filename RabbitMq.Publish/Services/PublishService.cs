using RabbitMq.Core.Base;

namespace RabbitMq.Publish.Services
{
    public class PublishService : ServiceBase, IPublishService
    {
        private readonly IPublisher _publish;

        public PublishService(IPublisher publish)
        {
            _publish = publish;
        }

        public bool Publish<T>(T model)
        {
            var response = Try(() => _publish.Publish(model));

            return response.Success;
        }
    }
}
