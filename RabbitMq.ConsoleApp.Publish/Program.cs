using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMq.Core.Configuration;
using RabbitMq.Core.Configuration.Interfaces;

namespace RabbitMq.ConsoleApp.Publish
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IBusConfiguration businessConfiguration;

            try
            {
                businessConfiguration = GetBusConfiguration();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error retrieving configuration. \n" + e.Message);
                throw;
            }

            IServiceProvider serviceProvider;

            try
            {
                serviceProvider = ConfigureServices(businessConfiguration);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error configuring services. \n" + e.Message);
                throw;
            }
            
            try
            {
                var appService = serviceProvider.GetService<IAppService>();

                appService.Run();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error running application. \n" + e.Message);
                throw;
            }

        }

        private static IBusConfiguration GetBusConfiguration()
        {
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("busSettings.json");

            var configuration = configurationBuilder.Build();

            return RabbitBusConfigurationService.GetConfiguration(configuration);
        }

        private static IServiceProvider ConfigureServices(IBusConfiguration busConfiguration)
        {
            var services = new ServiceCollection()
                .AddTransient<IAppService, AppService>()
                .AddSingleton(busConfiguration);

            RabbitMq.Publish.IoC.Configure(services);

            return services.BuildServiceProvider();
        }
    }
}

