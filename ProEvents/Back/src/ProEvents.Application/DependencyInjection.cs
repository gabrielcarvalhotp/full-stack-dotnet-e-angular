using Microsoft.Extensions.DependencyInjection;
using ProEvents.Application.Abstractions;
using ProEvents.Application.Services;

namespace ProEvents.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            AddServices(services);
            return services;
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IEventService, EventService>();
        }
    }
}