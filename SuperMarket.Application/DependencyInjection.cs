using MediatR;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using SuperMarket.Application.Behaviors;
using FluentValidation;

namespace SuperMarket.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDI(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
            // Đăng ký tất cả các validator trong assembly Application
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            // Đăng ký Validation Behavior cho MediatR pipeline
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}
