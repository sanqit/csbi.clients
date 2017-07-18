using System;
using System.Collections.Generic;
using System.Text;

namespace CSBI.Clients.BLL.Extensions
{
    using Contracts;
    using DAL;
    using DAL.Contracts;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection.Extensions;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddClientsService(this IServiceCollection services, string connectionString)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            services.TryAdd(ServiceDescriptor.Singleton<IService, Service>());
            services.AddSingleton<IRepository>(new Repository(connectionString));
            return services;
        }

        public static void ConfigureAuthorizationService(this IServiceCollection services)
        {

        }
    }
}
