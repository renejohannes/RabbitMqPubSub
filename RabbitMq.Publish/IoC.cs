using Microsoft.Extensions.DependencyInjection;
using RabbitMq.Publish.Services;

namespace RabbitMq.Publish
{
   public class IoC
    {
        public static void Configure(IServiceCollection services)
        {
            Core.IoC.Configure(services);

            services.AddTransient<IPublisher, Publisher>();
            services.AddTransient<IPublishService, PublishService>();
        }
    }
}
