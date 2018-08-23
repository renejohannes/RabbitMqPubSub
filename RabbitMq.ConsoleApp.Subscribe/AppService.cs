using System;
using RabbitMq.Subscribe.Services;

namespace RabbitMq.ConsoleApp.Subscribe
{
    public class AppService : IAppService
    {
        private readonly ISubscribeService _subscribeService;

        public AppService(ISubscribeService subscribeService)
        {
            _subscribeService = subscribeService;
        }

        public void Run()
        {
            Console.WriteLine("Subscriber");
            Console.WriteLine("Listening...");
            
            _subscribeService.Consume();
        }
    }
}
