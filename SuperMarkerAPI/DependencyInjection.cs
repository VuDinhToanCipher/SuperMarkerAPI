﻿using SuperMarket.Application;
using SuperMarket.Infrastructure;

namespace SuperMarkerAPI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppDI(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddApplicationDI()
                .AddInfrastructureDI(configuration);
            return services;
        }
    }
}
