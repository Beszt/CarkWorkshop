using Microsoft.Extensions.DependencyInjection;
using CarWorkshop.Application.Services;

namespace CarWorkshop.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddAppllication(this IServiceCollection services)
        {
            services.AddScoped<ICarWokrshopService, CarWokrshopService>();
        }
    }
}