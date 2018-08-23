using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Configuration;
using RabbitMq.Core.Configuration.Implementation;
using RabbitMq.Core.Configuration.Interfaces;
using RabbitMq.Core.Tools;

namespace RabbitMq.Core.Configuration
{
    public static class RabbitBusConfigurationService
    {
        public static IBusConfiguration GetConfiguration(IConfiguration configuration)
        {
            if (!AreConfigurationParametersValid(configuration))
                throw new Exception("Empty setup fields were detected. Check the values in the busSettings.json configuration file");

            var busConfiguration = new BusConfiguration
            {
                HostName = configuration["HostName"],
                Port = int.Parse(configuration["Port"]),
                Username = configuration["Username"],
                Password = configuration["Password"],
                QueueSetting = new QueueSetting()
                {
                    QueueName = configuration["QueueSetting:QueueName"],
                    Durable = bool.Parse(configuration["QueueSetting:Durable"]),
                    Exclusive = bool.Parse(configuration["QueueSetting:Exclusive"]),
                    AutoAck = bool.Parse(configuration["QueueSetting:AutoAck"]),
                },
                ExchangeSetting = new ExchangeSetting()
                {
                    ExchangeName = configuration["ExchangeSetting:ExchangeName"],
                    RoutingKey = configuration["ExchangeSetting:RoutingKey"],
                    BasicProperties = null,
                    ExchangeType = configuration["ExchangeSetting:ExchangeType"],
                }
            };

            return IsValidateConfiguration(busConfiguration) ? busConfiguration : null;
        }

        private static bool AreConfigurationParametersValid(IConfiguration configuration)
        {
            return (configuration["HostName"].Length != 0 ||
                    configuration["Port"].Length != 0 ||
                    configuration["Username"].Length != 0 ||
                    configuration["Password"].Length != 0 ||
                    configuration["QueueSetting:QueueName"].Length != 0 ||
                    //Configuration["ExchangeSetting:ExchangeName"].Length == 0 ||
                    configuration["ExchangeSetting:RoutingKey"].Length != 0 ||
                    configuration["ExchangeSetting:ExchangeType"].Length != 0);
        }

        private static bool IsValidateConfiguration(IBusConfiguration busConfiguration)
        {
            //todo find a way to validate entire object in one go

            var validationResultList = new List<ValidationResult>();

            var valid = ObjectValidatorService.TryValidate(busConfiguration, out var lstvalidationResult);

            if (lstvalidationResult.Count > 0)
                validationResultList.AddRange(lstvalidationResult);

            var valid2 = ObjectValidatorService.TryValidate(busConfiguration.ExchangeSetting, out var lstvalidationResult2);

            if (lstvalidationResult2.Count > 0)
                validationResultList.AddRange(lstvalidationResult2);

            var valid3 = ObjectValidatorService.TryValidate(busConfiguration.QueueSetting, out var lstvalidationResult3);

            if (lstvalidationResult3.Count > 0)
                validationResultList.AddRange(lstvalidationResult3);

            if (valid && valid2 && valid3)
                return true;

            foreach (var res in validationResultList)
            {
                Console.WriteLine(res.MemberNames + ":" + res.ErrorMessage);
            }

            return false;
        }
    }
}
