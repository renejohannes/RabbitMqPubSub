using System;
using RabbitMq.Core.Base;
using RabbitMq.Core.Configuration.Interfaces;
using RabbitMq.Core.Tools;
using RabbitMq.Models;

namespace RabbitMq.Subscribe
{
    public class Subscriber : SubscribeRabbitMqBase, ISubscriber
    {
        private readonly ISerializerService _serializerService;

        public Subscriber(IBusConfiguration busConfiguration, ISerializerService serializerService) : base(busConfiguration)
        {
            _serializerService = serializerService;
        }

        public void Consume()
        {
            PerformBasicConsume();
        }

        public override void ProcessBasicConsume(string message)
        {
            var deserialized = _serializerService.DeserializeJson<User>(message);

            if (string.IsNullOrEmpty(deserialized.FirstName.Trim()))
                Console.WriteLine("Invalid name detected!"); //throw onto error/audit queue depending on business rules
            else
                Console.WriteLine("Hello {0}, I am your father!", deserialized.FirstName);
        }
    }
}
