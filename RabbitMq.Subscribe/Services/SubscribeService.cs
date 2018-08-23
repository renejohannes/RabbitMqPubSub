using RabbitMq.Core.Base;

namespace RabbitMq.Subscribe.Services
{
  public  class SubscribeService : ServiceBase, ISubscribeService
  {
      private readonly ISubscriber _subscriber;

        public SubscribeService(ISubscriber subscriber)
        {
            _subscriber = subscriber;
        }
        public bool Consume()
        {
            var response = Try(() => _subscriber.Consume());

            return response.Success;
        }
    }
}
