using AutoMapper;
using CarWorkshop.Application.CarWorkshop.Commands;
using CarWorkshop.Application.Mappings;
using CarWorkshop.Application.ApplicationUser;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CarWorkshop.Application.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddAppllication(this IServiceCollection services)
    {
        services.AddScoped<IUserContext, UserContext>();

        services.AddMediatR(typeof(CreateCarWorkshopCommand));

        services.AddScoped(provider => new MapperConfiguration( cfg =>
        {
            var scope = provider.CreateScope();
            var userContext = scope.ServiceProvider.GetRequiredService<IUserContext>();
            cfg.AddProfile(new CarWorkshopMappingProfile(userContext));
        }).CreateMapper());

        services.AddValidatorsFromAssemblyContaining<CreateCarWorkshopCommandValidator>()
            .AddFluentValidationAutoValidation()
            .AddFluentValidationClientsideAdapters();

        services.AddValidatorsFromAssemblyContaining<UpdateCarWorkshopCommandValidator>()
            .AddFluentValidationAutoValidation()
            .AddFluentValidationClientsideAdapters();
    }
}