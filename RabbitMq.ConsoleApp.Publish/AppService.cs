using System;
using RabbitMq.Models;
using RabbitMq.Publish.Services;

namespace RabbitMq.ConsoleApp.Publish
{
    public class AppService : IAppService
    {
        private readonly IPublishService _publishService;

        public AppService(IPublishService publishService)
        {
            _publishService = publishService;
        }

        public void Run()
        {
            Console.WriteLine("Publisher");
            Console.WriteLine("Please enter a name...");

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "exit")
                    break;
            
                _publishService.Publish(new User
                {
                    FirstName = input,
                    LastName = "Johannes",
                    EmailAddress = "reneb@live.co.za"
                });
            }
        }
    }
}
