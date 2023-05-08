using CarWorkshop.Application.CarWorkshop.Commands;
using CarWorkshop.Application.Mappings;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CarWorkshop.Application.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddAppllication(this IServiceCollection services)
    {
        services.AddMediatR(typeof(CreateCarWorkshopCommand));

        services.AddAutoMapper(typeof(CarWorkshopMappingProfile));

        services.AddValidatorsFromAssemblyContaining<CreateCarWorkshopCommandValidator>()
            .AddFluentValidationAutoValidation()
            .AddFluentValidationClientsideAdapters();

        services.AddValidatorsFromAssemblyContaining<UpdateCarWorkshopCommandValidator>()
            .AddFluentValidationAutoValidation()
            .AddFluentValidationClientsideAdapters();
    }
}