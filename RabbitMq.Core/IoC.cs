using Microsoft.Extensions.DependencyInjection;
using RabbitMq.Core.Tools;

namespace RabbitMq.Core
{
    public static class IoC
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddTransient<ISerializerService, SerializerService>();
        }
    }
}
