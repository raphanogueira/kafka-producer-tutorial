﻿using KafkaExample.Domain.Configuration;
using KafkaExample.Domain.Consumers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace KafkaExample.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSettings<T>(this IServiceCollection services, IConfiguration configuration) where T : Settings, new()
        {
            services.Configure<T>(configuration.GetSection(typeof(T).Name));

            var settings = services.BuildServiceProvider().GetRequiredService<IOptions<T>>().Value;

            return services.AddSingleton(settings);
        }

        public static IServiceCollection AddHostedServices(this IServiceCollection services)
        {
            services
                .AddHostedService<KafkaExampleConsumer>();

            return services;
        }
    }
}
