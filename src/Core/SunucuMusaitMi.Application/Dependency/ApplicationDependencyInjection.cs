using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace SunucuMusaitMi.Application.Dependency
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            #region mediator

            services.AddMediatR(Assembly.GetExecutingAssembly());

            #endregion mediator

            return services;
        }
    }
}
