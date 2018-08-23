using Microsoft.Extensions.DependencyInjection;
using RabbitMq.Subscribe.Services;

namespace RabbitMq.Subscribe
{
    public class IoC
    {
        public static void Configure(IServiceCollection services)
        {
            Core.IoC.Configure(services);

            services.AddTransient<ISubscriber, Subscriber>();
            services.AddTransient<ISubscribeService, SubscribeService>();
        }
    }
}
