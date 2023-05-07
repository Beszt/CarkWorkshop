using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using CarWorkshop.Application.CarWorkshop;
using CarWorkshop.Application.Mappings;
using CarWorkshop.Application.Services;

namespace CarWorkshop.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddAppllication(this IServiceCollection services)
        {
            services.AddScoped<ICarWokrshopService, CarWokrshopService>();

            services.AddAutoMapper(typeof(CarWorkshopMappingProfile));

            services.AddValidatorsFromAssemblyContaining<CarWorkshopDtoValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
        }
    }
}